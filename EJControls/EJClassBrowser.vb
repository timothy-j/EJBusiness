﻿

Public Class EJClassBrowser
    Private _ClassType As Type

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        Dim dgv As New DataGridView
        dgv.Columns.Add(New DataGridViewTextBoxColumn)
        CustomComboBox1.DropDownControl = dgv
    End Sub

    Property Filter As String
        Get
            Return TextBox1.Text
        End Get
        Set
            TextBox1.Text = Value
        End Set
    End Property

    Property ClassType As Type
        Get
            Return _ClassType
        End Get
        Set
            _ClassType = Value
            FillTree()
        End Set
    End Property

    Private Sub FillTree()
        TreeView1.Nodes.Clear()
        Dim root As TreeNode = TreeView1.Nodes.Add(ClassType.Name)
        PopulateBranch(root, ClassType)
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ClassType = GetType(EJData.Item)
    End Sub

    Private Sub PopulateBranch(root As TreeNode, rootClass As Type)
        For Each prop In rootClass.GetProperties()
            Dim branch = root.Nodes.Add(prop.Name)
            If prop.PropertyType.IsPrimitive Or prop.PropertyType = GetType(String) Or prop.PropertyType.GetProperties.Count = 0 Then
                'branch.ForeColor = Color.Purple
            ElseIf prop.PropertyType.Name = "Nullable`1" Then
                branch.ForeColor = Color.MidnightBlue
                'branch.Nodes.Add("Dummy")
            ElseIf prop.PropertyType.Name = "ObservableListSource`1" Then
                branch.ForeColor = Color.Teal
                branch.Nodes.Add("Dummy")
            Else
                branch.ForeColor = Color.Purple
                branch.Nodes.Add("Dummy")
            End If
        Next
    End Sub

    Private Sub TreeView1_BeforeExpand(sender As Object, e As TreeViewCancelEventArgs) Handles TreeView1.BeforeExpand
        If e.Node.Nodes(0).Text = "Dummy" Then
            e.Node.Nodes.Clear()
            PopulateBranch(e.Node, GetNodeType(e.Node))
        End If
    End Sub

    Structure PropNode
        Dim propList As List(Of String)
        Dim node As TreeNode
    End Structure

    Function GetNodeType(node As TreeNode) As Type
        Dim pn As New PropNode With {.node = node}
        pn = GetPropTree(pn)
        Dim typ As Type = ClassType
        For Each propString In pn.propList
            typ = typ.GetProperty(propString).PropertyType
        Next
        Return typ
    End Function

    ''' <summary>
    ''' Recursively gets list of properties (index 0 being first property)
    ''' up to TreeNode supplied in PropNode
    ''' </summary>
    ''' <param name="pn">PropNode containing bottom TreeNode</param>
    ''' <returns>PropNode containing list of properties</returns>
    Function GetPropTree(pn As PropNode) As PropNode
        Dim pnOut As PropNode = pn
        pnOut.node = pn.node.Parent
        'pnOut.propList.Add(pn.node.Text)
        If pnOut.node.Level > 0 Then
            pnOut = GetPropTree(pnOut)
        Else
            pnOut.propList = New List(Of String)
        End If
        pnOut.propList.Add(pn.node.Text)
        Return pnOut
    End Function

    Private Sub TreeView1_AfterSelect(sender As Object, e As TreeViewEventArgs) Handles TreeView1.AfterSelect
        Dim nodeType As Type = GetNodeType(TreeView1.SelectedNode)
        TypeLabel.Text = nodeType.Name
        If TypeLabel.Text = "Nullable`1" Then
            TypeLabel.Text = "Nullable " + nodeType.GetProperty("Value").PropertyType.Name
        ElseIf TypeLabel.Text = "ObservableListSource`1" Then
            TypeLabel.Text = "List of " + nodeType.GetProperty("Item").PropertyType.Name
        End If

        ' Update operators list
        ListBox1.DataSource = nodeType.GetMethods(Reflection.BindingFlags.Public Or Reflection.BindingFlags.Instance Or Reflection.BindingFlags.FlattenHierarchy)

    End Sub

End Class
