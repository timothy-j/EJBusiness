﻿Imports EJViewModels
Imports Xceed.Wpf.DataGrid

Public Class BomView

    Private _machineColsCreated As Boolean
    Private _Model As String
    Private _Title As String

    Public Property Title As String
        Get
            Return CType(DataContext, BomViewModel).Title
        End Get
        Set
            CType(DataContext, BomViewModel).Title = Value
        End Set
    End Property

    Public Property MCModel As String
        Get
            Return _Model
        End Get
        Set
            _Model = Value
            CType(DataContext, BomViewModel).Model = Value
        End Set
    End Property

    Public Sub New()

        ' This call is required by the designer.
        InitializeComponent()

        '' Add any initialization after the InitializeComponent() call.
        'Dim modelBase = CType(DataContext, WpfHelpers.ViewModelBase)
        'modelBase.Initialize()
        'AddHandler Loaded, AddressOf modelBase.CallOnLoaded
        'AddHandler Unloaded, AddressOf modelBase.CallOnUnLoaded
    End Sub

    Private Sub BomView_Loaded(sender As Object, e As RoutedEventArgs) Handles Me.Loaded
        If Not _machineColsCreated Then
            Dim colNo As Integer
            For Each mc As BomViewModel.MachineInfo In CType(DataContext, BomViewModel).MachineList
                Dim colS As Column = FindResource("StatusColumn")
                colS.Title = "S" & mc.Number
                colS.FieldName = "S" & mc.Number
                Dim bind = New DataGridBindingInfo
                ' Binds to the Entities attached property, as indexed by colNo
                bind.Path = New PropertyPath("(0)[(1)].Status", MachInfo.EntitiesProperty, colNo)
                colS.DisplayMemberBindingInfo = bind

                'Dim rs As New RelativeSource(RelativeSourceMode.FindAncestor, GetType(DataGridRow), 1)
                'bind.RelativeSource = rs
                'colS.DisplayMemberBindingIn

                colS.VisiblePosition = 0
                _dataGrid.Columns.Add(colS)


                Dim col As Column = FindResource("QtyColumn")
                col.Title = mc.Number
                col.FieldName = mc.Number
                Dim qtyBind As New DataGridBindingInfo
                ' Binds to the Entities attached property, as indexed by colNo
                qtyBind.Path = New PropertyPath("(0)[(1)].Quantity", MachInfo.EntitiesProperty, colNo)
                'qtyBind.Path = New PropertyPath("(MachInfo.Entities)[" & colNo & "].Quantity")
                col.DisplayMemberBindingInfo = qtyBind
                colNo += 1
                'qtyBind.StringFormat = "G8"
                'qtyBind.TargetNullValue = ""
                'qtyBind.RelativeSource = rs
                col.VisiblePosition = 0
                _dataGrid.Columns.Add(col)
            Next
            _machineColsCreated = True
        End If
        'Dim Me.DataContext
    End Sub
End Class
