<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class OrderForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DateLabel As System.Windows.Forms.Label
        Dim DueLabel As System.Windows.Forms.Label
        Dim EndTextLabel As System.Windows.Forms.Label
        Dim NotesLabel As System.Windows.Forms.Label
        Dim OrderNoLabel As System.Windows.Forms.Label
        Dim ReceivedLabel As System.Windows.Forms.Label
        Dim SentLabel As System.Windows.Forms.Label
        Dim StartTextLabel As System.Windows.Forms.Label
        Dim SuffixLabel As System.Windows.Forms.Label
        Dim SupplierLabel As System.Windows.Forms.Label
        Dim Address1Label As System.Windows.Forms.Label
        Dim Address2Label As System.Windows.Forms.Label
        Dim Address3Label As System.Windows.Forms.Label
        Dim Address4Label As System.Windows.Forms.Label
        Dim CodeLabel As System.Windows.Forms.Label
        Dim Contact_s_Label As System.Windows.Forms.Label
        Dim E_mailLabel As System.Windows.Forms.Label
        Dim EntryLabel As System.Windows.Forms.Label
        Dim FaxNumberLabel As System.Windows.Forms.Label
        Dim MobileNumberLabel As System.Windows.Forms.Label
        Dim PostcodeLabel As System.Windows.Forms.Label
        Dim Supplier1Label As System.Windows.Forms.Label
        Dim TelephoneNumberLabel As System.Windows.Forms.Label
        Dim WebsiteLabel As System.Windows.Forms.Label
        Dim SupplierLabel1 As System.Windows.Forms.Label
        Dim FaxNumberLabel1 As System.Windows.Forms.Label
        Dim Address1Label1 As System.Windows.Forms.Label
        Dim Address2Label1 As System.Windows.Forms.Label
        Dim Address3Label1 As System.Windows.Forms.Label
        Dim Address4Label1 As System.Windows.Forms.Label
        Dim PostcodeLabel1 As System.Windows.Forms.Label
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(OrderForm))
        Dim DataGridViewCellStyle16 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle9 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle10 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle11 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle12 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle13 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle14 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle15 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.OrderBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrderBindingNavigator = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.BindingNavigatorAddNewItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorCountItem = New System.Windows.Forms.ToolStripLabel()
        Me.BindingNavigatorMoveFirstItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMovePreviousItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorPositionItem = New System.Windows.Forms.ToolStripTextBox()
        Me.BindingNavigatorSeparator1 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorMoveNextItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorMoveLastItem = New System.Windows.Forms.ToolStripButton()
        Me.BindingNavigatorSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.BindingNavigatorDeleteItem = New System.Windows.Forms.ToolStripButton()
        Me.OrderBindingNavigatorSaveItem = New System.Windows.Forms.ToolStripButton()
        Me.DateDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.DueDateTimePicker = New System.Windows.Forms.DateTimePicker()
        Me.EndTextTextBox = New System.Windows.Forms.TextBox()
        Me.NotesTextBox = New System.Windows.Forms.TextBox()
        Me.OrderNoTextBox = New System.Windows.Forms.TextBox()
        Me.ReceivedCheckBox = New System.Windows.Forms.CheckBox()
        Me.SentCheckBox = New System.Windows.Forms.CheckBox()
        Me.StartTextTextBox = New System.Windows.Forms.TextBox()
        Me.SuffixTextBox = New System.Windows.Forms.TextBox()
        Me.Address1TextBox = New System.Windows.Forms.TextBox()
        Me.Address2TextBox = New System.Windows.Forms.TextBox()
        Me.Address3TextBox = New System.Windows.Forms.TextBox()
        Me.Address4TextBox = New System.Windows.Forms.TextBox()
        Me.CodeTextBox = New System.Windows.Forms.TextBox()
        Me.Contact_s_TextBox = New System.Windows.Forms.TextBox()
        Me.E_mailTextBox = New System.Windows.Forms.TextBox()
        Me.EntryTextBox = New System.Windows.Forms.TextBox()
        Me.FaxNumberTextBox = New System.Windows.Forms.TextBox()
        Me.MobileNumberTextBox = New System.Windows.Forms.TextBox()
        Me.PostcodeTextBox = New System.Windows.Forms.TextBox()
        Me.Supplier1TextBox = New System.Windows.Forms.TextBox()
        Me.TelephoneNumberTextBox = New System.Windows.Forms.TextBox()
        Me.WebsiteTextBox = New System.Windows.Forms.TextBox()
        Me.OrderDetailsBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.OrderDetailsDataGridView = New System.Windows.Forms.DataGridView()
        Me.DataGridViewTextBoxColumn13 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn14 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn15 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn16 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn17 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn18 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn19 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn20 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn21 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.DataGridViewTextBoxColumn22 = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SupplierComboBox = New System.Windows.Forms.ComboBox()
        Me.SupplierBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.CustomOrderAddressesBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.SupplierTextBox = New System.Windows.Forms.TextBox()
        Me.FaxNumberTextBox1 = New System.Windows.Forms.TextBox()
        Me.Address1TextBox1 = New System.Windows.Forms.TextBox()
        Me.Address2TextBox1 = New System.Windows.Forms.TextBox()
        Me.Address3TextBox1 = New System.Windows.Forms.TextBox()
        Me.Address4TextBox1 = New System.Windows.Forms.TextBox()
        Me.PostcodeTextBox1 = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        DateLabel = New System.Windows.Forms.Label()
        DueLabel = New System.Windows.Forms.Label()
        EndTextLabel = New System.Windows.Forms.Label()
        NotesLabel = New System.Windows.Forms.Label()
        OrderNoLabel = New System.Windows.Forms.Label()
        ReceivedLabel = New System.Windows.Forms.Label()
        SentLabel = New System.Windows.Forms.Label()
        StartTextLabel = New System.Windows.Forms.Label()
        SuffixLabel = New System.Windows.Forms.Label()
        SupplierLabel = New System.Windows.Forms.Label()
        Address1Label = New System.Windows.Forms.Label()
        Address2Label = New System.Windows.Forms.Label()
        Address3Label = New System.Windows.Forms.Label()
        Address4Label = New System.Windows.Forms.Label()
        CodeLabel = New System.Windows.Forms.Label()
        Contact_s_Label = New System.Windows.Forms.Label()
        E_mailLabel = New System.Windows.Forms.Label()
        EntryLabel = New System.Windows.Forms.Label()
        FaxNumberLabel = New System.Windows.Forms.Label()
        MobileNumberLabel = New System.Windows.Forms.Label()
        PostcodeLabel = New System.Windows.Forms.Label()
        Supplier1Label = New System.Windows.Forms.Label()
        TelephoneNumberLabel = New System.Windows.Forms.Label()
        WebsiteLabel = New System.Windows.Forms.Label()
        SupplierLabel1 = New System.Windows.Forms.Label()
        FaxNumberLabel1 = New System.Windows.Forms.Label()
        Address1Label1 = New System.Windows.Forms.Label()
        Address2Label1 = New System.Windows.Forms.Label()
        Address3Label1 = New System.Windows.Forms.Label()
        Address4Label1 = New System.Windows.Forms.Label()
        PostcodeLabel1 = New System.Windows.Forms.Label()
        CType(Me.OrderBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderBindingNavigator, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.OrderBindingNavigator.SuspendLayout()
        CType(Me.OrderDetailsBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.OrderDetailsDataGridView, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SupplierBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomOrderAddressesBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'DateLabel
        '
        DateLabel.AutoSize = True
        DateLabel.Location = New System.Drawing.Point(20, 20)
        DateLabel.Name = "DateLabel"
        DateLabel.Size = New System.Drawing.Size(33, 13)
        DateLabel.TabIndex = 1
        DateLabel.Text = "Date:"
        '
        'DueLabel
        '
        DueLabel.AutoSize = True
        DueLabel.Location = New System.Drawing.Point(20, 46)
        DueLabel.Name = "DueLabel"
        DueLabel.Size = New System.Drawing.Size(30, 13)
        DueLabel.TabIndex = 3
        DueLabel.Text = "Due:"
        '
        'EndTextLabel
        '
        EndTextLabel.AutoSize = True
        EndTextLabel.Location = New System.Drawing.Point(432, 473)
        EndTextLabel.Name = "EndTextLabel"
        EndTextLabel.Size = New System.Drawing.Size(53, 13)
        EndTextLabel.TabIndex = 5
        EndTextLabel.Text = "End Text:"
        '
        'NotesLabel
        '
        NotesLabel.AutoSize = True
        NotesLabel.Location = New System.Drawing.Point(20, 97)
        NotesLabel.Name = "NotesLabel"
        NotesLabel.Size = New System.Drawing.Size(38, 13)
        NotesLabel.TabIndex = 7
        NotesLabel.Text = "Notes:"
        '
        'OrderNoLabel
        '
        OrderNoLabel.AutoSize = True
        OrderNoLabel.Location = New System.Drawing.Point(20, 123)
        OrderNoLabel.Name = "OrderNoLabel"
        OrderNoLabel.Size = New System.Drawing.Size(53, 13)
        OrderNoLabel.TabIndex = 9
        OrderNoLabel.Text = "Order No:"
        '
        'ReceivedLabel
        '
        ReceivedLabel.AutoSize = True
        ReceivedLabel.Location = New System.Drawing.Point(20, 151)
        ReceivedLabel.Name = "ReceivedLabel"
        ReceivedLabel.Size = New System.Drawing.Size(56, 13)
        ReceivedLabel.TabIndex = 11
        ReceivedLabel.Text = "Received:"
        '
        'SentLabel
        '
        SentLabel.AutoSize = True
        SentLabel.Location = New System.Drawing.Point(20, 181)
        SentLabel.Name = "SentLabel"
        SentLabel.Size = New System.Drawing.Size(32, 13)
        SentLabel.TabIndex = 13
        SentLabel.Text = "Sent:"
        '
        'StartTextLabel
        '
        StartTextLabel.AutoSize = True
        StartTextLabel.Location = New System.Drawing.Point(432, 123)
        StartTextLabel.Name = "StartTextLabel"
        StartTextLabel.Size = New System.Drawing.Size(56, 13)
        StartTextLabel.TabIndex = 15
        StartTextLabel.Text = "Start Text:"
        '
        'SuffixLabel
        '
        SuffixLabel.AutoSize = True
        SuffixLabel.Location = New System.Drawing.Point(20, 235)
        SuffixLabel.Name = "SuffixLabel"
        SuffixLabel.Size = New System.Drawing.Size(36, 13)
        SuffixLabel.TabIndex = 17
        SuffixLabel.Text = "Suffix:"
        '
        'SupplierLabel
        '
        SupplierLabel.AutoSize = True
        SupplierLabel.Location = New System.Drawing.Point(20, 261)
        SupplierLabel.Name = "SupplierLabel"
        SupplierLabel.Size = New System.Drawing.Size(48, 13)
        SupplierLabel.TabIndex = 19
        SupplierLabel.Text = "Supplier:"
        '
        'Address1Label
        '
        Address1Label.AutoSize = True
        Address1Label.Location = New System.Drawing.Point(20, 321)
        Address1Label.Name = "Address1Label"
        Address1Label.Size = New System.Drawing.Size(54, 13)
        Address1Label.TabIndex = 21
        Address1Label.Text = "Address1:"
        '
        'Address2Label
        '
        Address2Label.AutoSize = True
        Address2Label.Location = New System.Drawing.Point(20, 347)
        Address2Label.Name = "Address2Label"
        Address2Label.Size = New System.Drawing.Size(54, 13)
        Address2Label.TabIndex = 23
        Address2Label.Text = "Address2:"
        '
        'Address3Label
        '
        Address3Label.AutoSize = True
        Address3Label.Location = New System.Drawing.Point(20, 373)
        Address3Label.Name = "Address3Label"
        Address3Label.Size = New System.Drawing.Size(54, 13)
        Address3Label.TabIndex = 25
        Address3Label.Text = "Address3:"
        '
        'Address4Label
        '
        Address4Label.AutoSize = True
        Address4Label.Location = New System.Drawing.Point(20, 399)
        Address4Label.Name = "Address4Label"
        Address4Label.Size = New System.Drawing.Size(54, 13)
        Address4Label.TabIndex = 27
        Address4Label.Text = "Address4:"
        '
        'CodeLabel
        '
        CodeLabel.AutoSize = True
        CodeLabel.Location = New System.Drawing.Point(20, 425)
        CodeLabel.Name = "CodeLabel"
        CodeLabel.Size = New System.Drawing.Size(35, 13)
        CodeLabel.TabIndex = 29
        CodeLabel.Text = "Code:"
        '
        'Contact_s_Label
        '
        Contact_s_Label.AutoSize = True
        Contact_s_Label.Location = New System.Drawing.Point(20, 451)
        Contact_s_Label.Name = "Contact_s_Label"
        Contact_s_Label.Size = New System.Drawing.Size(58, 13)
        Contact_s_Label.TabIndex = 31
        Contact_s_Label.Text = "Contact s :"
        '
        'E_mailLabel
        '
        E_mailLabel.AutoSize = True
        E_mailLabel.Location = New System.Drawing.Point(20, 477)
        E_mailLabel.Name = "E_mailLabel"
        E_mailLabel.Size = New System.Drawing.Size(38, 13)
        E_mailLabel.TabIndex = 33
        E_mailLabel.Text = "E mail:"
        '
        'EntryLabel
        '
        EntryLabel.AutoSize = True
        EntryLabel.Location = New System.Drawing.Point(20, 503)
        EntryLabel.Name = "EntryLabel"
        EntryLabel.Size = New System.Drawing.Size(34, 13)
        EntryLabel.TabIndex = 35
        EntryLabel.Text = "Entry:"
        '
        'FaxNumberLabel
        '
        FaxNumberLabel.AutoSize = True
        FaxNumberLabel.Location = New System.Drawing.Point(20, 529)
        FaxNumberLabel.Name = "FaxNumberLabel"
        FaxNumberLabel.Size = New System.Drawing.Size(67, 13)
        FaxNumberLabel.TabIndex = 37
        FaxNumberLabel.Text = "Fax Number:"
        '
        'MobileNumberLabel
        '
        MobileNumberLabel.AutoSize = True
        MobileNumberLabel.Location = New System.Drawing.Point(20, 555)
        MobileNumberLabel.Name = "MobileNumberLabel"
        MobileNumberLabel.Size = New System.Drawing.Size(81, 13)
        MobileNumberLabel.TabIndex = 39
        MobileNumberLabel.Text = "Mobile Number:"
        '
        'PostcodeLabel
        '
        PostcodeLabel.AutoSize = True
        PostcodeLabel.Location = New System.Drawing.Point(20, 581)
        PostcodeLabel.Name = "PostcodeLabel"
        PostcodeLabel.Size = New System.Drawing.Size(55, 13)
        PostcodeLabel.TabIndex = 41
        PostcodeLabel.Text = "Postcode:"
        '
        'Supplier1Label
        '
        Supplier1Label.AutoSize = True
        Supplier1Label.Location = New System.Drawing.Point(20, 607)
        Supplier1Label.Name = "Supplier1Label"
        Supplier1Label.Size = New System.Drawing.Size(54, 13)
        Supplier1Label.TabIndex = 43
        Supplier1Label.Text = "Supplier1:"
        '
        'TelephoneNumberLabel
        '
        TelephoneNumberLabel.AutoSize = True
        TelephoneNumberLabel.Location = New System.Drawing.Point(20, 633)
        TelephoneNumberLabel.Name = "TelephoneNumberLabel"
        TelephoneNumberLabel.Size = New System.Drawing.Size(101, 13)
        TelephoneNumberLabel.TabIndex = 45
        TelephoneNumberLabel.Text = "Telephone Number:"
        '
        'WebsiteLabel
        '
        WebsiteLabel.AutoSize = True
        WebsiteLabel.Location = New System.Drawing.Point(20, 659)
        WebsiteLabel.Name = "WebsiteLabel"
        WebsiteLabel.Size = New System.Drawing.Size(49, 13)
        WebsiteLabel.TabIndex = 47
        WebsiteLabel.Text = "Website:"
        '
        'SupplierLabel1
        '
        SupplierLabel1.AutoSize = True
        SupplierLabel1.Location = New System.Drawing.Point(973, 23)
        SupplierLabel1.Name = "SupplierLabel1"
        SupplierLabel1.Size = New System.Drawing.Size(48, 13)
        SupplierLabel1.TabIndex = 56
        SupplierLabel1.Text = "Supplier:"
        '
        'FaxNumberLabel1
        '
        FaxNumberLabel1.AutoSize = True
        FaxNumberLabel1.Location = New System.Drawing.Point(973, 49)
        FaxNumberLabel1.Name = "FaxNumberLabel1"
        FaxNumberLabel1.Size = New System.Drawing.Size(67, 13)
        FaxNumberLabel1.TabIndex = 58
        FaxNumberLabel1.Text = "Fax Number:"
        '
        'Address1Label1
        '
        Address1Label1.AutoSize = True
        Address1Label1.Location = New System.Drawing.Point(973, 75)
        Address1Label1.Name = "Address1Label1"
        Address1Label1.Size = New System.Drawing.Size(54, 13)
        Address1Label1.TabIndex = 60
        Address1Label1.Text = "Address1:"
        '
        'Address2Label1
        '
        Address2Label1.AutoSize = True
        Address2Label1.Location = New System.Drawing.Point(973, 101)
        Address2Label1.Name = "Address2Label1"
        Address2Label1.Size = New System.Drawing.Size(54, 13)
        Address2Label1.TabIndex = 62
        Address2Label1.Text = "Address2:"
        '
        'Address3Label1
        '
        Address3Label1.AutoSize = True
        Address3Label1.Location = New System.Drawing.Point(973, 127)
        Address3Label1.Name = "Address3Label1"
        Address3Label1.Size = New System.Drawing.Size(54, 13)
        Address3Label1.TabIndex = 64
        Address3Label1.Text = "Address3:"
        '
        'Address4Label1
        '
        Address4Label1.AutoSize = True
        Address4Label1.Location = New System.Drawing.Point(973, 153)
        Address4Label1.Name = "Address4Label1"
        Address4Label1.Size = New System.Drawing.Size(54, 13)
        Address4Label1.TabIndex = 66
        Address4Label1.Text = "Address4:"
        '
        'PostcodeLabel1
        '
        PostcodeLabel1.AutoSize = True
        PostcodeLabel1.Location = New System.Drawing.Point(973, 179)
        PostcodeLabel1.Name = "PostcodeLabel1"
        PostcodeLabel1.Size = New System.Drawing.Size(55, 13)
        PostcodeLabel1.TabIndex = 68
        PostcodeLabel1.Text = "Postcode:"
        '
        'OrderBindingSource
        '
        Me.OrderBindingSource.DataSource = GetType(EJData.Order)
        '
        'OrderBindingNavigator
        '
        Me.OrderBindingNavigator.AddNewItem = Me.BindingNavigatorAddNewItem
        Me.OrderBindingNavigator.BindingSource = Me.OrderBindingSource
        Me.OrderBindingNavigator.CountItem = Me.BindingNavigatorCountItem
        Me.OrderBindingNavigator.DeleteItem = Nothing
        Me.OrderBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.OrderBindingNavigator.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BindingNavigatorMoveFirstItem, Me.BindingNavigatorMovePreviousItem, Me.BindingNavigatorSeparator, Me.BindingNavigatorPositionItem, Me.BindingNavigatorCountItem, Me.BindingNavigatorSeparator1, Me.BindingNavigatorMoveNextItem, Me.BindingNavigatorMoveLastItem, Me.BindingNavigatorSeparator2, Me.BindingNavigatorAddNewItem, Me.BindingNavigatorDeleteItem, Me.OrderBindingNavigatorSaveItem})
        Me.OrderBindingNavigator.Location = New System.Drawing.Point(0, 696)
        Me.OrderBindingNavigator.MoveFirstItem = Me.BindingNavigatorMoveFirstItem
        Me.OrderBindingNavigator.MoveLastItem = Me.BindingNavigatorMoveLastItem
        Me.OrderBindingNavigator.MoveNextItem = Me.BindingNavigatorMoveNextItem
        Me.OrderBindingNavigator.MovePreviousItem = Me.BindingNavigatorMovePreviousItem
        Me.OrderBindingNavigator.Name = "OrderBindingNavigator"
        Me.OrderBindingNavigator.PositionItem = Me.BindingNavigatorPositionItem
        Me.OrderBindingNavigator.Size = New System.Drawing.Size(1287, 25)
        Me.OrderBindingNavigator.TabIndex = 0
        Me.OrderBindingNavigator.Text = "BindingNavigator1"
        '
        'BindingNavigatorAddNewItem
        '
        Me.BindingNavigatorAddNewItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorAddNewItem.Image = CType(resources.GetObject("BindingNavigatorAddNewItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorAddNewItem.Name = "BindingNavigatorAddNewItem"
        Me.BindingNavigatorAddNewItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorAddNewItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorAddNewItem.Text = "Add new"
        '
        'BindingNavigatorCountItem
        '
        Me.BindingNavigatorCountItem.Name = "BindingNavigatorCountItem"
        Me.BindingNavigatorCountItem.Size = New System.Drawing.Size(35, 22)
        Me.BindingNavigatorCountItem.Text = "of {0}"
        Me.BindingNavigatorCountItem.ToolTipText = "Total number of items"
        '
        'BindingNavigatorMoveFirstItem
        '
        Me.BindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveFirstItem.Image = CType(resources.GetObject("BindingNavigatorMoveFirstItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveFirstItem.Name = "BindingNavigatorMoveFirstItem"
        Me.BindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveFirstItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveFirstItem.Text = "Move first"
        '
        'BindingNavigatorMovePreviousItem
        '
        Me.BindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMovePreviousItem.Image = CType(resources.GetObject("BindingNavigatorMovePreviousItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMovePreviousItem.Name = "BindingNavigatorMovePreviousItem"
        Me.BindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMovePreviousItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMovePreviousItem.Text = "Move previous"
        '
        'BindingNavigatorSeparator
        '
        Me.BindingNavigatorSeparator.Name = "BindingNavigatorSeparator"
        Me.BindingNavigatorSeparator.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorPositionItem
        '
        Me.BindingNavigatorPositionItem.AccessibleName = "Position"
        Me.BindingNavigatorPositionItem.AutoSize = False
        Me.BindingNavigatorPositionItem.Name = "BindingNavigatorPositionItem"
        Me.BindingNavigatorPositionItem.Size = New System.Drawing.Size(50, 23)
        Me.BindingNavigatorPositionItem.Text = "0"
        Me.BindingNavigatorPositionItem.ToolTipText = "Current position"
        '
        'BindingNavigatorSeparator1
        '
        Me.BindingNavigatorSeparator1.Name = "BindingNavigatorSeparator1"
        Me.BindingNavigatorSeparator1.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorMoveNextItem
        '
        Me.BindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveNextItem.Image = CType(resources.GetObject("BindingNavigatorMoveNextItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveNextItem.Name = "BindingNavigatorMoveNextItem"
        Me.BindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveNextItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveNextItem.Text = "Move next"
        '
        'BindingNavigatorMoveLastItem
        '
        Me.BindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorMoveLastItem.Image = CType(resources.GetObject("BindingNavigatorMoveLastItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorMoveLastItem.Name = "BindingNavigatorMoveLastItem"
        Me.BindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorMoveLastItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorMoveLastItem.Text = "Move last"
        '
        'BindingNavigatorSeparator2
        '
        Me.BindingNavigatorSeparator2.Name = "BindingNavigatorSeparator2"
        Me.BindingNavigatorSeparator2.Size = New System.Drawing.Size(6, 25)
        '
        'BindingNavigatorDeleteItem
        '
        Me.BindingNavigatorDeleteItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BindingNavigatorDeleteItem.Image = CType(resources.GetObject("BindingNavigatorDeleteItem.Image"), System.Drawing.Image)
        Me.BindingNavigatorDeleteItem.Name = "BindingNavigatorDeleteItem"
        Me.BindingNavigatorDeleteItem.RightToLeftAutoMirrorImage = True
        Me.BindingNavigatorDeleteItem.Size = New System.Drawing.Size(23, 22)
        Me.BindingNavigatorDeleteItem.Text = "Delete"
        '
        'OrderBindingNavigatorSaveItem
        '
        Me.OrderBindingNavigatorSaveItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.OrderBindingNavigatorSaveItem.Image = CType(resources.GetObject("OrderBindingNavigatorSaveItem.Image"), System.Drawing.Image)
        Me.OrderBindingNavigatorSaveItem.Name = "OrderBindingNavigatorSaveItem"
        Me.OrderBindingNavigatorSaveItem.Size = New System.Drawing.Size(23, 22)
        Me.OrderBindingNavigatorSaveItem.Text = "Save Data"
        '
        'DateDateTimePicker
        '
        Me.DateDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.OrderBindingSource, "Date", True))
        Me.DateDateTimePicker.Location = New System.Drawing.Point(82, 16)
        Me.DateDateTimePicker.Name = "DateDateTimePicker"
        Me.DateDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DateDateTimePicker.TabIndex = 2
        Me.DateDateTimePicker.Value = New Date(2017, 11, 16, 11, 48, 5, 0)
        '
        'DueDateTimePicker
        '
        Me.DueDateTimePicker.DataBindings.Add(New System.Windows.Forms.Binding("Value", Me.OrderBindingSource, "Due", True))
        Me.DueDateTimePicker.Location = New System.Drawing.Point(82, 42)
        Me.DueDateTimePicker.Name = "DueDateTimePicker"
        Me.DueDateTimePicker.Size = New System.Drawing.Size(200, 20)
        Me.DueDateTimePicker.TabIndex = 4
        '
        'EndTextTextBox
        '
        Me.EndTextTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "EndText", True))
        Me.EndTextTextBox.Location = New System.Drawing.Point(494, 470)
        Me.EndTextTextBox.Multiline = True
        Me.EndTextTextBox.Name = "EndTextTextBox"
        Me.EndTextTextBox.Size = New System.Drawing.Size(437, 76)
        Me.EndTextTextBox.TabIndex = 6
        '
        'NotesTextBox
        '
        Me.NotesTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Notes", True))
        Me.NotesTextBox.Location = New System.Drawing.Point(82, 94)
        Me.NotesTextBox.Name = "NotesTextBox"
        Me.NotesTextBox.Size = New System.Drawing.Size(200, 20)
        Me.NotesTextBox.TabIndex = 8
        '
        'OrderNoTextBox
        '
        Me.OrderNoTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "OrderNo", True))
        Me.OrderNoTextBox.Location = New System.Drawing.Point(82, 120)
        Me.OrderNoTextBox.Name = "OrderNoTextBox"
        Me.OrderNoTextBox.Size = New System.Drawing.Size(200, 20)
        Me.OrderNoTextBox.TabIndex = 10
        '
        'ReceivedCheckBox
        '
        Me.ReceivedCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.OrderBindingSource, "Received", True))
        Me.ReceivedCheckBox.Location = New System.Drawing.Point(82, 146)
        Me.ReceivedCheckBox.Name = "ReceivedCheckBox"
        Me.ReceivedCheckBox.Size = New System.Drawing.Size(200, 24)
        Me.ReceivedCheckBox.TabIndex = 12
        Me.ReceivedCheckBox.Text = "Received"
        Me.ReceivedCheckBox.UseVisualStyleBackColor = True
        '
        'SentCheckBox
        '
        Me.SentCheckBox.DataBindings.Add(New System.Windows.Forms.Binding("CheckState", Me.OrderBindingSource, "Sent", True))
        Me.SentCheckBox.Location = New System.Drawing.Point(82, 176)
        Me.SentCheckBox.Name = "SentCheckBox"
        Me.SentCheckBox.Size = New System.Drawing.Size(200, 24)
        Me.SentCheckBox.TabIndex = 14
        Me.SentCheckBox.Text = "Sent"
        Me.SentCheckBox.UseVisualStyleBackColor = True
        '
        'StartTextTextBox
        '
        Me.StartTextTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "StartText", True))
        Me.StartTextTextBox.Location = New System.Drawing.Point(494, 120)
        Me.StartTextTextBox.Multiline = True
        Me.StartTextTextBox.Name = "StartTextTextBox"
        Me.StartTextTextBox.Size = New System.Drawing.Size(437, 76)
        Me.StartTextTextBox.TabIndex = 16
        '
        'SuffixTextBox
        '
        Me.SuffixTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Suffix", True))
        Me.SuffixTextBox.Location = New System.Drawing.Point(82, 232)
        Me.SuffixTextBox.Name = "SuffixTextBox"
        Me.SuffixTextBox.Size = New System.Drawing.Size(200, 20)
        Me.SuffixTextBox.TabIndex = 18
        '
        'Address1TextBox
        '
        Me.Address1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Address1", True))
        Me.Address1TextBox.Location = New System.Drawing.Point(127, 318)
        Me.Address1TextBox.Name = "Address1TextBox"
        Me.Address1TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Address1TextBox.TabIndex = 22
        '
        'Address2TextBox
        '
        Me.Address2TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Address2", True))
        Me.Address2TextBox.Location = New System.Drawing.Point(127, 344)
        Me.Address2TextBox.Name = "Address2TextBox"
        Me.Address2TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Address2TextBox.TabIndex = 24
        '
        'Address3TextBox
        '
        Me.Address3TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Address3", True))
        Me.Address3TextBox.Location = New System.Drawing.Point(127, 370)
        Me.Address3TextBox.Name = "Address3TextBox"
        Me.Address3TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Address3TextBox.TabIndex = 26
        '
        'Address4TextBox
        '
        Me.Address4TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Address4", True))
        Me.Address4TextBox.Location = New System.Drawing.Point(127, 396)
        Me.Address4TextBox.Name = "Address4TextBox"
        Me.Address4TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Address4TextBox.TabIndex = 28
        '
        'CodeTextBox
        '
        Me.CodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Code", True))
        Me.CodeTextBox.Location = New System.Drawing.Point(127, 422)
        Me.CodeTextBox.Name = "CodeTextBox"
        Me.CodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.CodeTextBox.TabIndex = 30
        '
        'Contact_s_TextBox
        '
        Me.Contact_s_TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Contact_s_", True))
        Me.Contact_s_TextBox.Location = New System.Drawing.Point(127, 448)
        Me.Contact_s_TextBox.Name = "Contact_s_TextBox"
        Me.Contact_s_TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Contact_s_TextBox.TabIndex = 32
        '
        'E_mailTextBox
        '
        Me.E_mailTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.E_mail", True))
        Me.E_mailTextBox.Location = New System.Drawing.Point(127, 474)
        Me.E_mailTextBox.Name = "E_mailTextBox"
        Me.E_mailTextBox.Size = New System.Drawing.Size(100, 20)
        Me.E_mailTextBox.TabIndex = 34
        '
        'EntryTextBox
        '
        Me.EntryTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Entry", True))
        Me.EntryTextBox.Location = New System.Drawing.Point(127, 500)
        Me.EntryTextBox.Name = "EntryTextBox"
        Me.EntryTextBox.Size = New System.Drawing.Size(100, 20)
        Me.EntryTextBox.TabIndex = 36
        '
        'FaxNumberTextBox
        '
        Me.FaxNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.FaxNumber", True))
        Me.FaxNumberTextBox.Location = New System.Drawing.Point(127, 526)
        Me.FaxNumberTextBox.Name = "FaxNumberTextBox"
        Me.FaxNumberTextBox.Size = New System.Drawing.Size(100, 20)
        Me.FaxNumberTextBox.TabIndex = 38
        '
        'MobileNumberTextBox
        '
        Me.MobileNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.MobileNumber", True))
        Me.MobileNumberTextBox.Location = New System.Drawing.Point(127, 552)
        Me.MobileNumberTextBox.Name = "MobileNumberTextBox"
        Me.MobileNumberTextBox.Size = New System.Drawing.Size(100, 20)
        Me.MobileNumberTextBox.TabIndex = 40
        '
        'PostcodeTextBox
        '
        Me.PostcodeTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Postcode", True))
        Me.PostcodeTextBox.Location = New System.Drawing.Point(127, 578)
        Me.PostcodeTextBox.Name = "PostcodeTextBox"
        Me.PostcodeTextBox.Size = New System.Drawing.Size(100, 20)
        Me.PostcodeTextBox.TabIndex = 42
        '
        'Supplier1TextBox
        '
        Me.Supplier1TextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Supplier1", True))
        Me.Supplier1TextBox.Location = New System.Drawing.Point(127, 604)
        Me.Supplier1TextBox.Name = "Supplier1TextBox"
        Me.Supplier1TextBox.Size = New System.Drawing.Size(100, 20)
        Me.Supplier1TextBox.TabIndex = 44
        '
        'TelephoneNumberTextBox
        '
        Me.TelephoneNumberTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.TelephoneNumber", True))
        Me.TelephoneNumberTextBox.Location = New System.Drawing.Point(127, 630)
        Me.TelephoneNumberTextBox.Name = "TelephoneNumberTextBox"
        Me.TelephoneNumberTextBox.Size = New System.Drawing.Size(100, 20)
        Me.TelephoneNumberTextBox.TabIndex = 46
        '
        'WebsiteTextBox
        '
        Me.WebsiteTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.OrderBindingSource, "Supplier1.Website", True))
        Me.WebsiteTextBox.Location = New System.Drawing.Point(127, 656)
        Me.WebsiteTextBox.Name = "WebsiteTextBox"
        Me.WebsiteTextBox.Size = New System.Drawing.Size(100, 20)
        Me.WebsiteTextBox.TabIndex = 48
        '
        'OrderDetailsBindingSource
        '
        Me.OrderDetailsBindingSource.DataMember = "OrderDetails"
        Me.OrderDetailsBindingSource.DataSource = Me.OrderBindingSource
        '
        'OrderDetailsDataGridView
        '
        Me.OrderDetailsDataGridView.AllowUserToResizeColumns = False
        Me.OrderDetailsDataGridView.AllowUserToResizeRows = False
        Me.OrderDetailsDataGridView.AutoGenerateColumns = False
        Me.OrderDetailsDataGridView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.DisplayedCells
        Me.OrderDetailsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.OrderDetailsDataGridView.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.DataGridViewTextBoxColumn13, Me.DataGridViewTextBoxColumn14, Me.DataGridViewTextBoxColumn15, Me.DataGridViewTextBoxColumn16, Me.DataGridViewTextBoxColumn17, Me.DataGridViewTextBoxColumn18, Me.DataGridViewTextBoxColumn19, Me.DataGridViewTextBoxColumn20, Me.DataGridViewTextBoxColumn21, Me.DataGridViewTextBoxColumn22})
        Me.OrderDetailsDataGridView.DataSource = Me.OrderDetailsBindingSource
        Me.OrderDetailsDataGridView.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter
        Me.OrderDetailsDataGridView.Location = New System.Drawing.Point(302, 221)
        Me.OrderDetailsDataGridView.MultiSelect = False
        Me.OrderDetailsDataGridView.Name = "OrderDetailsDataGridView"
        Me.OrderDetailsDataGridView.RowHeadersWidth = 25
        DataGridViewCellStyle16.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.OrderDetailsDataGridView.RowsDefaultCellStyle = DataGridViewCellStyle16
        Me.OrderDetailsDataGridView.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.OrderDetailsDataGridView.Size = New System.Drawing.Size(907, 221)
        Me.OrderDetailsDataGridView.TabIndex = 51
        '
        'DataGridViewTextBoxColumn13
        '
        Me.DataGridViewTextBoxColumn13.DataPropertyName = "ID"
        DataGridViewCellStyle9.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.0!)
        DataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DataGridViewTextBoxColumn13.DefaultCellStyle = DataGridViewCellStyle9
        Me.DataGridViewTextBoxColumn13.HeaderText = "ID"
        Me.DataGridViewTextBoxColumn13.Name = "DataGridViewTextBoxColumn13"
        Me.DataGridViewTextBoxColumn13.ReadOnly = True
        Me.DataGridViewTextBoxColumn13.Visible = False
        '
        'DataGridViewTextBoxColumn14
        '
        Me.DataGridViewTextBoxColumn14.DataPropertyName = "Order"
        Me.DataGridViewTextBoxColumn14.HeaderText = "Order"
        Me.DataGridViewTextBoxColumn14.Name = "DataGridViewTextBoxColumn14"
        Me.DataGridViewTextBoxColumn14.Visible = False
        '
        'DataGridViewTextBoxColumn15
        '
        Me.DataGridViewTextBoxColumn15.DataPropertyName = "RowNo"
        DataGridViewCellStyle10.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.GrayText
        Me.DataGridViewTextBoxColumn15.DefaultCellStyle = DataGridViewCellStyle10
        Me.DataGridViewTextBoxColumn15.HeaderText = "RowNo"
        Me.DataGridViewTextBoxColumn15.Name = "DataGridViewTextBoxColumn15"
        Me.DataGridViewTextBoxColumn15.ReadOnly = True
        Me.DataGridViewTextBoxColumn15.Width = 30
        '
        'DataGridViewTextBoxColumn16
        '
        Me.DataGridViewTextBoxColumn16.DataPropertyName = "Qty"
        Me.DataGridViewTextBoxColumn16.HeaderText = "Qty"
        Me.DataGridViewTextBoxColumn16.Name = "DataGridViewTextBoxColumn16"
        Me.DataGridViewTextBoxColumn16.Width = 50
        '
        'DataGridViewTextBoxColumn17
        '
        Me.DataGridViewTextBoxColumn17.DataPropertyName = "Unit"
        DataGridViewCellStyle11.NullValue = Nothing
        Me.DataGridViewTextBoxColumn17.DefaultCellStyle = DataGridViewCellStyle11
        Me.DataGridViewTextBoxColumn17.HeaderText = "Unit"
        Me.DataGridViewTextBoxColumn17.Name = "DataGridViewTextBoxColumn17"
        Me.DataGridViewTextBoxColumn17.Width = 75
        '
        'DataGridViewTextBoxColumn18
        '
        Me.DataGridViewTextBoxColumn18.DataPropertyName = "Part"
        Me.DataGridViewTextBoxColumn18.HeaderText = "Part"
        Me.DataGridViewTextBoxColumn18.Name = "DataGridViewTextBoxColumn18"
        Me.DataGridViewTextBoxColumn18.Width = 75
        '
        'DataGridViewTextBoxColumn19
        '
        Me.DataGridViewTextBoxColumn19.DataPropertyName = "Description"
        DataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn19.DefaultCellStyle = DataGridViewCellStyle12
        Me.DataGridViewTextBoxColumn19.HeaderText = "Description"
        Me.DataGridViewTextBoxColumn19.Name = "DataGridViewTextBoxColumn19"
        Me.DataGridViewTextBoxColumn19.Width = 300
        '
        'DataGridViewTextBoxColumn20
        '
        Me.DataGridViewTextBoxColumn20.DataPropertyName = "UnitPrice"
        DataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle13.Format = "C2"
        DataGridViewCellStyle13.NullValue = Nothing
        Me.DataGridViewTextBoxColumn20.DefaultCellStyle = DataGridViewCellStyle13
        Me.DataGridViewTextBoxColumn20.HeaderText = "UnitPrice"
        Me.DataGridViewTextBoxColumn20.Name = "DataGridViewTextBoxColumn20"
        Me.DataGridViewTextBoxColumn20.Width = 75
        '
        'DataGridViewTextBoxColumn21
        '
        Me.DataGridViewTextBoxColumn21.DataPropertyName = "Price"
        DataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight
        DataGridViewCellStyle14.Format = "C2"
        DataGridViewCellStyle14.NullValue = Nothing
        Me.DataGridViewTextBoxColumn21.DefaultCellStyle = DataGridViewCellStyle14
        Me.DataGridViewTextBoxColumn21.HeaderText = "Price"
        Me.DataGridViewTextBoxColumn21.Name = "DataGridViewTextBoxColumn21"
        Me.DataGridViewTextBoxColumn21.Width = 75
        '
        'DataGridViewTextBoxColumn22
        '
        Me.DataGridViewTextBoxColumn22.DataPropertyName = "RowNotes"
        DataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridViewTextBoxColumn22.DefaultCellStyle = DataGridViewCellStyle15
        Me.DataGridViewTextBoxColumn22.HeaderText = "RowNotes"
        Me.DataGridViewTextBoxColumn22.Name = "DataGridViewTextBoxColumn22"
        Me.DataGridViewTextBoxColumn22.Width = 200
        '
        'SupplierComboBox
        '
        Me.SupplierComboBox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend
        Me.SupplierComboBox.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems
        Me.SupplierComboBox.DataBindings.Add(New System.Windows.Forms.Binding("SelectedValue", Me.OrderBindingSource, "Supplier", True))
        Me.SupplierComboBox.DataSource = Me.SupplierBindingSource
        Me.SupplierComboBox.DisplayMember = "Supplier1"
        Me.SupplierComboBox.FormattingEnabled = True
        Me.SupplierComboBox.Location = New System.Drawing.Point(82, 257)
        Me.SupplierComboBox.Name = "SupplierComboBox"
        Me.SupplierComboBox.Size = New System.Drawing.Size(200, 21)
        Me.SupplierComboBox.TabIndex = 52
        Me.SupplierComboBox.ValueMember = "Entry"
        '
        'SupplierBindingSource
        '
        Me.SupplierBindingSource.DataSource = GetType(EJData.Supplier)
        '
        'CustomOrderAddressesBindingSource
        '
        Me.CustomOrderAddressesBindingSource.DataMember = "CustomOrderAddresses"
        Me.CustomOrderAddressesBindingSource.DataSource = Me.OrderBindingSource
        '
        'SupplierTextBox
        '
        Me.SupplierTextBox.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomOrderAddressesBindingSource, "Supplier", True))
        Me.SupplierTextBox.Location = New System.Drawing.Point(1046, 20)
        Me.SupplierTextBox.Name = "SupplierTextBox"
        Me.SupplierTextBox.Size = New System.Drawing.Size(100, 20)
        Me.SupplierTextBox.TabIndex = 57
        '
        'FaxNumberTextBox1
        '
        Me.FaxNumberTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomOrderAddressesBindingSource, "FaxNumber", True))
        Me.FaxNumberTextBox1.Location = New System.Drawing.Point(1046, 46)
        Me.FaxNumberTextBox1.Name = "FaxNumberTextBox1"
        Me.FaxNumberTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.FaxNumberTextBox1.TabIndex = 59
        '
        'Address1TextBox1
        '
        Me.Address1TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomOrderAddressesBindingSource, "Address1", True))
        Me.Address1TextBox1.Location = New System.Drawing.Point(1046, 72)
        Me.Address1TextBox1.Name = "Address1TextBox1"
        Me.Address1TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.Address1TextBox1.TabIndex = 61
        '
        'Address2TextBox1
        '
        Me.Address2TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomOrderAddressesBindingSource, "Address2", True))
        Me.Address2TextBox1.Location = New System.Drawing.Point(1046, 98)
        Me.Address2TextBox1.Name = "Address2TextBox1"
        Me.Address2TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.Address2TextBox1.TabIndex = 63
        '
        'Address3TextBox1
        '
        Me.Address3TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomOrderAddressesBindingSource, "Address3", True))
        Me.Address3TextBox1.Location = New System.Drawing.Point(1046, 124)
        Me.Address3TextBox1.Name = "Address3TextBox1"
        Me.Address3TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.Address3TextBox1.TabIndex = 65
        '
        'Address4TextBox1
        '
        Me.Address4TextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomOrderAddressesBindingSource, "Address4", True))
        Me.Address4TextBox1.Location = New System.Drawing.Point(1046, 150)
        Me.Address4TextBox1.Name = "Address4TextBox1"
        Me.Address4TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.Address4TextBox1.TabIndex = 67
        '
        'PostcodeTextBox1
        '
        Me.PostcodeTextBox1.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.CustomOrderAddressesBindingSource, "Postcode", True))
        Me.PostcodeTextBox1.Location = New System.Drawing.Point(1046, 176)
        Me.PostcodeTextBox1.Name = "PostcodeTextBox1"
        Me.PostcodeTextBox1.Size = New System.Drawing.Size(100, 20)
        Me.PostcodeTextBox1.TabIndex = 69
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(869, 23)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 13)
        Me.Label1.TabIndex = 70
        Me.Label1.Text = "Custom supplier:"
        '
        'OrderForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1287, 721)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(SupplierLabel1)
        Me.Controls.Add(Me.SupplierTextBox)
        Me.Controls.Add(FaxNumberLabel1)
        Me.Controls.Add(Me.FaxNumberTextBox1)
        Me.Controls.Add(Address1Label1)
        Me.Controls.Add(Me.Address1TextBox1)
        Me.Controls.Add(Address2Label1)
        Me.Controls.Add(Me.Address2TextBox1)
        Me.Controls.Add(Address3Label1)
        Me.Controls.Add(Me.Address3TextBox1)
        Me.Controls.Add(Address4Label1)
        Me.Controls.Add(Me.Address4TextBox1)
        Me.Controls.Add(PostcodeLabel1)
        Me.Controls.Add(Me.PostcodeTextBox1)
        Me.Controls.Add(Me.SupplierComboBox)
        Me.Controls.Add(Me.OrderDetailsDataGridView)
        Me.Controls.Add(Address1Label)
        Me.Controls.Add(Me.Address1TextBox)
        Me.Controls.Add(Address2Label)
        Me.Controls.Add(Me.Address2TextBox)
        Me.Controls.Add(Address3Label)
        Me.Controls.Add(Me.Address3TextBox)
        Me.Controls.Add(Address4Label)
        Me.Controls.Add(Me.Address4TextBox)
        Me.Controls.Add(CodeLabel)
        Me.Controls.Add(Me.CodeTextBox)
        Me.Controls.Add(Contact_s_Label)
        Me.Controls.Add(Me.Contact_s_TextBox)
        Me.Controls.Add(E_mailLabel)
        Me.Controls.Add(Me.E_mailTextBox)
        Me.Controls.Add(EntryLabel)
        Me.Controls.Add(Me.EntryTextBox)
        Me.Controls.Add(FaxNumberLabel)
        Me.Controls.Add(Me.FaxNumberTextBox)
        Me.Controls.Add(MobileNumberLabel)
        Me.Controls.Add(Me.MobileNumberTextBox)
        Me.Controls.Add(PostcodeLabel)
        Me.Controls.Add(Me.PostcodeTextBox)
        Me.Controls.Add(Supplier1Label)
        Me.Controls.Add(Me.Supplier1TextBox)
        Me.Controls.Add(TelephoneNumberLabel)
        Me.Controls.Add(Me.TelephoneNumberTextBox)
        Me.Controls.Add(WebsiteLabel)
        Me.Controls.Add(Me.WebsiteTextBox)
        Me.Controls.Add(DateLabel)
        Me.Controls.Add(Me.DateDateTimePicker)
        Me.Controls.Add(DueLabel)
        Me.Controls.Add(Me.DueDateTimePicker)
        Me.Controls.Add(EndTextLabel)
        Me.Controls.Add(Me.EndTextTextBox)
        Me.Controls.Add(NotesLabel)
        Me.Controls.Add(Me.NotesTextBox)
        Me.Controls.Add(OrderNoLabel)
        Me.Controls.Add(Me.OrderNoTextBox)
        Me.Controls.Add(ReceivedLabel)
        Me.Controls.Add(Me.ReceivedCheckBox)
        Me.Controls.Add(SentLabel)
        Me.Controls.Add(Me.SentCheckBox)
        Me.Controls.Add(StartTextLabel)
        Me.Controls.Add(Me.StartTextTextBox)
        Me.Controls.Add(SuffixLabel)
        Me.Controls.Add(Me.SuffixTextBox)
        Me.Controls.Add(SupplierLabel)
        Me.Controls.Add(Me.OrderBindingNavigator)
        Me.Name = "OrderForm"
        Me.Text = "Order"
        CType(Me.OrderBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderBindingNavigator, System.ComponentModel.ISupportInitialize).EndInit()
        Me.OrderBindingNavigator.ResumeLayout(False)
        Me.OrderBindingNavigator.PerformLayout()
        CType(Me.OrderDetailsBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.OrderDetailsDataGridView, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SupplierBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomOrderAddressesBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents OrderBindingSource As BindingSource
    Friend WithEvents OrderBindingNavigator As BindingNavigator
    Friend WithEvents BindingNavigatorAddNewItem As ToolStripButton
    Friend WithEvents BindingNavigatorCountItem As ToolStripLabel
    Friend WithEvents BindingNavigatorDeleteItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveFirstItem As ToolStripButton
    Friend WithEvents BindingNavigatorMovePreviousItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator As ToolStripSeparator
    Friend WithEvents BindingNavigatorPositionItem As ToolStripTextBox
    Friend WithEvents BindingNavigatorSeparator1 As ToolStripSeparator
    Friend WithEvents BindingNavigatorMoveNextItem As ToolStripButton
    Friend WithEvents BindingNavigatorMoveLastItem As ToolStripButton
    Friend WithEvents BindingNavigatorSeparator2 As ToolStripSeparator
    Friend WithEvents OrderBindingNavigatorSaveItem As ToolStripButton
    Friend WithEvents DateDateTimePicker As DateTimePicker
    Friend WithEvents DueDateTimePicker As DateTimePicker
    Friend WithEvents EndTextTextBox As TextBox
    Friend WithEvents NotesTextBox As TextBox
    Friend WithEvents OrderNoTextBox As TextBox
    Friend WithEvents ReceivedCheckBox As CheckBox
    Friend WithEvents SentCheckBox As CheckBox
    Friend WithEvents StartTextTextBox As TextBox
    Friend WithEvents SuffixTextBox As TextBox
    Friend WithEvents Address1TextBox As TextBox
    Friend WithEvents Address2TextBox As TextBox
    Friend WithEvents Address3TextBox As TextBox
    Friend WithEvents Address4TextBox As TextBox
    Friend WithEvents CodeTextBox As TextBox
    Friend WithEvents Contact_s_TextBox As TextBox
    Friend WithEvents E_mailTextBox As TextBox
    Friend WithEvents EntryTextBox As TextBox
    Friend WithEvents FaxNumberTextBox As TextBox
    Friend WithEvents MobileNumberTextBox As TextBox
    Friend WithEvents PostcodeTextBox As TextBox
    Friend WithEvents Supplier1TextBox As TextBox
    Friend WithEvents TelephoneNumberTextBox As TextBox
    Friend WithEvents WebsiteTextBox As TextBox
    Friend WithEvents OrderDetailsBindingSource As BindingSource
    Friend WithEvents OrderDetailsDataGridView As DataGridView
    Friend WithEvents DataGridViewTextBoxColumn13 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn14 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn15 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn16 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn17 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn18 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn19 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn20 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn21 As DataGridViewTextBoxColumn
    Friend WithEvents DataGridViewTextBoxColumn22 As DataGridViewTextBoxColumn
    Friend WithEvents SupplierComboBox As ComboBox
    Friend WithEvents SupplierBindingSource As BindingSource
    Friend WithEvents CustomOrderAddressesBindingSource As BindingSource
    Friend WithEvents SupplierTextBox As TextBox
    Friend WithEvents FaxNumberTextBox1 As TextBox
    Friend WithEvents Address1TextBox1 As TextBox
    Friend WithEvents Address2TextBox1 As TextBox
    Friend WithEvents Address3TextBox1 As TextBox
    Friend WithEvents Address4TextBox1 As TextBox
    Friend WithEvents PostcodeTextBox1 As TextBox
    Friend WithEvents Label1 As Label
End Class
