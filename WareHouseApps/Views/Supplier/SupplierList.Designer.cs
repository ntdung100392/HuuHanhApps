namespace WareHouseApps
{
    partial class SupplierList
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SupplierList));
            this.GroupBoxSupplierList = new System.Windows.Forms.GroupBox();
            this.dataGridSupplier = new System.Windows.Forms.DataGridView();
            this.companyNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.directorNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.homeTownDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isActiveDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.supplierViewModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.supplierViewModelBindingNavigator = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorCountItem = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorMoveFirstItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.txtSearch = new System.Windows.Forms.ToolStripTextBox();
            this.groupBoxInformation = new System.Windows.Forms.GroupBox();
            this.lblFax = new System.Windows.Forms.Label();
            this.txtFax = new System.Windows.Forms.TextBox();
            this.txtHomeTown = new System.Windows.Forms.TextBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.lblInformation = new System.Windows.Forms.Label();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.txtTaxCode = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.lblHomeTown = new System.Windows.Forms.Label();
            this.lblTaxCode = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.lblPhone = new System.Windows.Forms.Label();
            this.lblDirectorName = new System.Windows.Forms.Label();
            this.lblCompanyName = new System.Windows.Forms.Label();
            this.cbxIsActive = new System.Windows.Forms.CheckBox();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtDirector = new System.Windows.Forms.TextBox();
            this.txtCompany = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).BeginInit();
            this.GroupBoxSupplierList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSupplier)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierViewModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierViewModelBindingNavigator)).BeginInit();
            this.supplierViewModelBindingNavigator.SuspendLayout();
            this.groupBoxInformation.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainBindingSource
            // 
            this.mainBindingSource.DataSource = typeof(WareHouseApps.Models.SupplierViewModel);
            // 
            // GroupBoxSupplierList
            // 
            this.GroupBoxSupplierList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.GroupBoxSupplierList.Controls.Add(this.dataGridSupplier);
            this.GroupBoxSupplierList.Location = new System.Drawing.Point(0, 242);
            this.GroupBoxSupplierList.Name = "GroupBoxSupplierList";
            this.GroupBoxSupplierList.Size = new System.Drawing.Size(661, 297);
            this.GroupBoxSupplierList.TabIndex = 0;
            this.GroupBoxSupplierList.TabStop = false;
            this.GroupBoxSupplierList.Text = "Danh Sách";
            // 
            // dataGridSupplier
            // 
            this.dataGridSupplier.AllowUserToAddRows = false;
            this.dataGridSupplier.AllowUserToDeleteRows = false;
            this.dataGridSupplier.AllowUserToResizeRows = false;
            this.dataGridSupplier.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridSupplier.AutoGenerateColumns = false;
            this.dataGridSupplier.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridSupplier.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.companyNameDataGridViewTextBoxColumn,
            this.directorNameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.homeTownDataGridViewTextBoxColumn,
            this.isActiveDataGridViewCheckBoxColumn});
            this.dataGridSupplier.DataSource = this.supplierViewModelBindingSource;
            this.dataGridSupplier.GridColor = System.Drawing.SystemColors.ControlLight;
            this.dataGridSupplier.Location = new System.Drawing.Point(0, 19);
            this.dataGridSupplier.MultiSelect = false;
            this.dataGridSupplier.Name = "dataGridSupplier";
            this.dataGridSupplier.ReadOnly = true;
            this.dataGridSupplier.RowHeadersVisible = false;
            this.dataGridSupplier.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.Red;
            this.dataGridSupplier.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridSupplier.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridSupplier.ShowEditingIcon = false;
            this.dataGridSupplier.Size = new System.Drawing.Size(661, 249);
            this.dataGridSupplier.TabIndex = 1;
            this.dataGridSupplier.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GetSupplierDetails);
            // 
            // companyNameDataGridViewTextBoxColumn
            // 
            this.companyNameDataGridViewTextBoxColumn.DataPropertyName = "CompanyName";
            this.companyNameDataGridViewTextBoxColumn.HeaderText = "Nhà Cung Cấp (*)";
            this.companyNameDataGridViewTextBoxColumn.Name = "companyNameDataGridViewTextBoxColumn";
            this.companyNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.companyNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // directorNameDataGridViewTextBoxColumn
            // 
            this.directorNameDataGridViewTextBoxColumn.DataPropertyName = "DirectorName";
            this.directorNameDataGridViewTextBoxColumn.HeaderText = "Người Đại Diện (*)";
            this.directorNameDataGridViewTextBoxColumn.Name = "directorNameDataGridViewTextBoxColumn";
            this.directorNameDataGridViewTextBoxColumn.ReadOnly = true;
            this.directorNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Địa Chỉ";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.Width = 180;
            // 
            // homeTownDataGridViewTextBoxColumn
            // 
            this.homeTownDataGridViewTextBoxColumn.DataPropertyName = "HomeTown";
            this.homeTownDataGridViewTextBoxColumn.HeaderText = "Tỉnh/Thành";
            this.homeTownDataGridViewTextBoxColumn.Name = "homeTownDataGridViewTextBoxColumn";
            this.homeTownDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isActiveDataGridViewCheckBoxColumn
            // 
            this.isActiveDataGridViewCheckBoxColumn.DataPropertyName = "IsActive";
            this.isActiveDataGridViewCheckBoxColumn.FalseValue = "Không";
            this.isActiveDataGridViewCheckBoxColumn.HeaderText = "Đang Hoạt Động";
            this.isActiveDataGridViewCheckBoxColumn.Name = "isActiveDataGridViewCheckBoxColumn";
            this.isActiveDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isActiveDataGridViewCheckBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.isActiveDataGridViewCheckBoxColumn.TrueValue = "Có";
            this.isActiveDataGridViewCheckBoxColumn.Width = 65;
            // 
            // supplierViewModelBindingSource
            // 
            this.supplierViewModelBindingSource.DataSource = typeof(WareHouseApps.Models.SupplierViewModel);
            // 
            // supplierViewModelBindingNavigator
            // 
            this.supplierViewModelBindingNavigator.AddNewItem = null;
            this.supplierViewModelBindingNavigator.BindingSource = this.supplierViewModelBindingSource;
            this.supplierViewModelBindingNavigator.CountItem = this.bindingNavigatorCountItem;
            this.supplierViewModelBindingNavigator.DeleteItem = null;
            this.supplierViewModelBindingNavigator.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.supplierViewModelBindingNavigator.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem,
            this.bindingNavigatorMovePreviousItem,
            this.bindingNavigatorSeparator,
            this.bindingNavigatorPositionItem,
            this.bindingNavigatorCountItem,
            this.bindingNavigatorSeparator1,
            this.bindingNavigatorMoveNextItem,
            this.bindingNavigatorMoveLastItem,
            this.bindingNavigatorSeparator2,
            this.toolStripLabel1,
            this.txtSearch});
            this.supplierViewModelBindingNavigator.Location = new System.Drawing.Point(0, 507);
            this.supplierViewModelBindingNavigator.MoveFirstItem = this.bindingNavigatorMoveFirstItem;
            this.supplierViewModelBindingNavigator.MoveLastItem = this.bindingNavigatorMoveLastItem;
            this.supplierViewModelBindingNavigator.MoveNextItem = this.bindingNavigatorMoveNextItem;
            this.supplierViewModelBindingNavigator.MovePreviousItem = this.bindingNavigatorMovePreviousItem;
            this.supplierViewModelBindingNavigator.Name = "supplierViewModelBindingNavigator";
            this.supplierViewModelBindingNavigator.PositionItem = this.bindingNavigatorPositionItem;
            this.supplierViewModelBindingNavigator.Size = new System.Drawing.Size(661, 25);
            this.supplierViewModelBindingNavigator.TabIndex = 2;
            // 
            // bindingNavigatorCountItem
            // 
            this.bindingNavigatorCountItem.Name = "bindingNavigatorCountItem";
            this.bindingNavigatorCountItem.Size = new System.Drawing.Size(35, 22);
            this.bindingNavigatorCountItem.Text = "of {0}";
            this.bindingNavigatorCountItem.ToolTipText = "Total number of items";
            // 
            // bindingNavigatorMoveFirstItem
            // 
            this.bindingNavigatorMoveFirstItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem.Image")));
            this.bindingNavigatorMoveFirstItem.Name = "bindingNavigatorMoveFirstItem";
            this.bindingNavigatorMoveFirstItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveFirstItem.Text = "Move first";
            // 
            // bindingNavigatorMovePreviousItem
            // 
            this.bindingNavigatorMovePreviousItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem.Image")));
            this.bindingNavigatorMovePreviousItem.Name = "bindingNavigatorMovePreviousItem";
            this.bindingNavigatorMovePreviousItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMovePreviousItem.Text = "Move previous";
            // 
            // bindingNavigatorSeparator
            // 
            this.bindingNavigatorSeparator.Name = "bindingNavigatorSeparator";
            this.bindingNavigatorSeparator.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorPositionItem
            // 
            this.bindingNavigatorPositionItem.AccessibleName = "Position";
            this.bindingNavigatorPositionItem.AutoSize = false;
            this.bindingNavigatorPositionItem.Name = "bindingNavigatorPositionItem";
            this.bindingNavigatorPositionItem.Size = new System.Drawing.Size(50, 23);
            this.bindingNavigatorPositionItem.Text = "0";
            this.bindingNavigatorPositionItem.ToolTipText = "Current position";
            // 
            // bindingNavigatorSeparator1
            // 
            this.bindingNavigatorSeparator1.Name = "bindingNavigatorSeparator1";
            this.bindingNavigatorSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // bindingNavigatorMoveNextItem
            // 
            this.bindingNavigatorMoveNextItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem.Image")));
            this.bindingNavigatorMoveNextItem.Name = "bindingNavigatorMoveNextItem";
            this.bindingNavigatorMoveNextItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveNextItem.Text = "Move next";
            // 
            // bindingNavigatorMoveLastItem
            // 
            this.bindingNavigatorMoveLastItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem.Image")));
            this.bindingNavigatorMoveLastItem.Name = "bindingNavigatorMoveLastItem";
            this.bindingNavigatorMoveLastItem.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem.Size = new System.Drawing.Size(23, 22);
            this.bindingNavigatorMoveLastItem.Text = "Move last";
            // 
            // bindingNavigatorSeparator2
            // 
            this.bindingNavigatorSeparator2.Name = "bindingNavigatorSeparator2";
            this.bindingNavigatorSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(74, 22);
            this.toolStripLabel1.Text = "Tìm Kiếm (*)";
            // 
            // txtSearch
            // 
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(100, 25);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.SearchSupplier);
            this.txtSearch.TextChanged += new System.EventHandler(this.SearchSupplier);
            // 
            // groupBoxInformation
            // 
            this.groupBoxInformation.Controls.Add(this.lblFax);
            this.groupBoxInformation.Controls.Add(this.txtFax);
            this.groupBoxInformation.Controls.Add(this.txtHomeTown);
            this.groupBoxInformation.Controls.Add(this.btnAdd);
            this.groupBoxInformation.Controls.Add(this.lblInformation);
            this.groupBoxInformation.Controls.Add(this.txtInformation);
            this.groupBoxInformation.Controls.Add(this.txtTaxCode);
            this.groupBoxInformation.Controls.Add(this.lblAddress);
            this.groupBoxInformation.Controls.Add(this.lblHomeTown);
            this.groupBoxInformation.Controls.Add(this.lblTaxCode);
            this.groupBoxInformation.Controls.Add(this.lblEmail);
            this.groupBoxInformation.Controls.Add(this.lblPhone);
            this.groupBoxInformation.Controls.Add(this.lblDirectorName);
            this.groupBoxInformation.Controls.Add(this.lblCompanyName);
            this.groupBoxInformation.Controls.Add(this.cbxIsActive);
            this.groupBoxInformation.Controls.Add(this.btnDelete);
            this.groupBoxInformation.Controls.Add(this.btnUpdate);
            this.groupBoxInformation.Controls.Add(this.txtAddress);
            this.groupBoxInformation.Controls.Add(this.txtEmail);
            this.groupBoxInformation.Controls.Add(this.txtPhone);
            this.groupBoxInformation.Controls.Add(this.txtDirector);
            this.groupBoxInformation.Controls.Add(this.txtCompany);
            this.groupBoxInformation.Location = new System.Drawing.Point(13, 13);
            this.groupBoxInformation.Name = "groupBoxInformation";
            this.groupBoxInformation.Size = new System.Drawing.Size(636, 223);
            this.groupBoxInformation.TabIndex = 1;
            this.groupBoxInformation.TabStop = false;
            this.groupBoxInformation.Text = "Thông Tin";
            // 
            // lblFax
            // 
            this.lblFax.AutoSize = true;
            this.lblFax.Location = new System.Drawing.Point(76, 115);
            this.lblFax.Name = "lblFax";
            this.lblFax.Size = new System.Drawing.Size(24, 13);
            this.lblFax.TabIndex = 36;
            this.lblFax.Text = "Fax";
            // 
            // txtFax
            // 
            this.txtFax.Enabled = false;
            this.txtFax.Location = new System.Drawing.Point(117, 112);
            this.txtFax.MaxLength = 16;
            this.txtFax.Name = "txtFax";
            this.txtFax.Size = new System.Drawing.Size(183, 20);
            this.txtFax.TabIndex = 3;
            // 
            // txtHomeTown
            // 
            this.txtHomeTown.Enabled = false;
            this.txtHomeTown.Location = new System.Drawing.Point(420, 60);
            this.txtHomeTown.Name = "txtHomeTown";
            this.txtHomeTown.Size = new System.Drawing.Size(138, 20);
            this.txtHomeTown.TabIndex = 6;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(370, 187);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(82, 23);
            this.btnAdd.TabIndex = 33;
            this.btnAdd.Text = "Thêm";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.LoadAddForm);
            // 
            // lblInformation
            // 
            this.lblInformation.AutoSize = true;
            this.lblInformation.Location = new System.Drawing.Point(306, 115);
            this.lblInformation.Name = "lblInformation";
            this.lblInformation.Size = new System.Drawing.Size(108, 13);
            this.lblInformation.TabIndex = 32;
            this.lblInformation.Text = "Thông Tin Loại Hàng";
            // 
            // txtInformation
            // 
            this.txtInformation.Enabled = false;
            this.txtInformation.Location = new System.Drawing.Point(420, 112);
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(204, 68);
            this.txtInformation.TabIndex = 8;
            // 
            // txtTaxCode
            // 
            this.txtTaxCode.Enabled = false;
            this.txtTaxCode.Location = new System.Drawing.Point(420, 34);
            this.txtTaxCode.MaxLength = 16;
            this.txtTaxCode.Name = "txtTaxCode";
            this.txtTaxCode.Size = new System.Drawing.Size(138, 20);
            this.txtTaxCode.TabIndex = 5;
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Location = new System.Drawing.Point(333, 89);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(81, 13);
            this.lblAddress.TabIndex = 24;
            this.lblAddress.Text = "Địa Chỉ Liên Hệ";
            // 
            // lblHomeTown
            // 
            this.lblHomeTown.AutoSize = true;
            this.lblHomeTown.Location = new System.Drawing.Point(350, 63);
            this.lblHomeTown.Name = "lblHomeTown";
            this.lblHomeTown.Size = new System.Drawing.Size(64, 13);
            this.lblHomeTown.TabIndex = 23;
            this.lblHomeTown.Text = "Tỉnh/Thành";
            // 
            // lblTaxCode
            // 
            this.lblTaxCode.AutoSize = true;
            this.lblTaxCode.Location = new System.Drawing.Point(348, 37);
            this.lblTaxCode.Name = "lblTaxCode";
            this.lblTaxCode.Size = new System.Drawing.Size(66, 13);
            this.lblTaxCode.TabIndex = 22;
            this.lblTaxCode.Text = "Mã Số Thuế";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Location = new System.Drawing.Point(76, 141);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(32, 13);
            this.lblEmail.TabIndex = 19;
            this.lblEmail.Text = "Email";
            // 
            // lblPhone
            // 
            this.lblPhone.AutoSize = true;
            this.lblPhone.Location = new System.Drawing.Point(36, 89);
            this.lblPhone.Name = "lblPhone";
            this.lblPhone.Size = new System.Drawing.Size(75, 13);
            this.lblPhone.TabIndex = 18;
            this.lblPhone.Text = "Số Điện Thoại";
            // 
            // lblDirectorName
            // 
            this.lblDirectorName.AutoSize = true;
            this.lblDirectorName.Location = new System.Drawing.Point(10, 63);
            this.lblDirectorName.Name = "lblDirectorName";
            this.lblDirectorName.Size = new System.Drawing.Size(101, 13);
            this.lblDirectorName.TabIndex = 17;
            this.lblDirectorName.Text = "Tên Người Đại Diện";
            // 
            // lblCompanyName
            // 
            this.lblCompanyName.AutoSize = true;
            this.lblCompanyName.Location = new System.Drawing.Point(12, 37);
            this.lblCompanyName.Name = "lblCompanyName";
            this.lblCompanyName.Size = new System.Drawing.Size(99, 13);
            this.lblCompanyName.TabIndex = 16;
            this.lblCompanyName.Text = "Tên Nhà Cung Cấp";
            // 
            // cbxIsActive
            // 
            this.cbxIsActive.AutoSize = true;
            this.cbxIsActive.Enabled = false;
            this.cbxIsActive.Location = new System.Drawing.Point(120, 164);
            this.cbxIsActive.Name = "cbxIsActive";
            this.cbxIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxIsActive.Size = new System.Drawing.Size(180, 17);
            this.cbxIsActive.TabIndex = 10;
            this.cbxIsActive.Text = "Nhà Cung Cấp Đang Hoạt Động";
            this.cbxIsActive.UseVisualStyleBackColor = true;
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(546, 186);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(78, 23);
            this.btnDelete.TabIndex = 13;
            this.btnDelete.Text = "Xóa";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.DeleteSupplier);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Enabled = false;
            this.btnUpdate.Location = new System.Drawing.Point(458, 186);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(82, 23);
            this.btnUpdate.TabIndex = 12;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.UpdateSupplier);
            // 
            // txtAddress
            // 
            this.txtAddress.Enabled = false;
            this.txtAddress.Location = new System.Drawing.Point(420, 86);
            this.txtAddress.MaxLength = 255;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(204, 20);
            this.txtAddress.TabIndex = 7;
            // 
            // txtEmail
            // 
            this.txtEmail.Enabled = false;
            this.txtEmail.Location = new System.Drawing.Point(117, 138);
            this.txtEmail.MaxLength = 20;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(183, 20);
            this.txtEmail.TabIndex = 4;
            // 
            // txtPhone
            // 
            this.txtPhone.Enabled = false;
            this.txtPhone.Location = new System.Drawing.Point(117, 86);
            this.txtPhone.MaxLength = 16;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(183, 20);
            this.txtPhone.TabIndex = 2;
            // 
            // txtDirector
            // 
            this.txtDirector.Enabled = false;
            this.txtDirector.Location = new System.Drawing.Point(117, 60);
            this.txtDirector.MaxLength = 35;
            this.txtDirector.Name = "txtDirector";
            this.txtDirector.Size = new System.Drawing.Size(183, 20);
            this.txtDirector.TabIndex = 1;
            // 
            // txtCompany
            // 
            this.txtCompany.Enabled = false;
            this.txtCompany.Location = new System.Drawing.Point(117, 34);
            this.txtCompany.MaxLength = 100;
            this.txtCompany.Name = "txtCompany";
            this.txtCompany.Size = new System.Drawing.Size(183, 20);
            this.txtCompany.TabIndex = 0;
            // 
            // SupplierList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(661, 532);
            this.Controls.Add(this.supplierViewModelBindingNavigator);
            this.Controls.Add(this.groupBoxInformation);
            this.Controls.Add(this.GroupBoxSupplierList);
            this.Name = "SupplierList";
            this.Text = "Danh Sách Nhà Cung Cấp";
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).EndInit();
            this.GroupBoxSupplierList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridSupplier)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierViewModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.supplierViewModelBindingNavigator)).EndInit();
            this.supplierViewModelBindingNavigator.ResumeLayout(false);
            this.supplierViewModelBindingNavigator.PerformLayout();
            this.groupBoxInformation.ResumeLayout(false);
            this.groupBoxInformation.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        #region Properties
        private System.Windows.Forms.GroupBox GroupBoxSupplierList;
        private System.Windows.Forms.GroupBox groupBoxInformation;
        private System.Windows.Forms.Label lblAddress;
        private System.Windows.Forms.Label lblHomeTown;
        private System.Windows.Forms.Label lblTaxCode;
        private System.Windows.Forms.Label lblEmail;
        private System.Windows.Forms.Label lblPhone;
        private System.Windows.Forms.Label lblDirectorName;
        private System.Windows.Forms.Label lblCompanyName;
        private System.Windows.Forms.CheckBox cbxIsActive;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.TextBox txtAddress;
        private System.Windows.Forms.TextBox txtEmail;
        private System.Windows.Forms.TextBox txtPhone;
        private System.Windows.Forms.TextBox txtDirector;
        private System.Windows.Forms.TextBox txtCompany;
        private System.Windows.Forms.TextBox txtTaxCode;
        private System.Windows.Forms.Label lblInformation;
        private System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtHomeTown;
        private System.Windows.Forms.Label lblFax;
        private System.Windows.Forms.TextBox txtFax;
        private System.Windows.Forms.DataGridView dataGridSupplier;
        private System.Windows.Forms.BindingSource supplierViewModelBindingSource;

        private System.Windows.Forms.BindingNavigator supplierViewModelBindingNavigator;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator1;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator2;
        #endregion
        private System.Windows.Forms.ToolStripTextBox txtSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn companyNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn directorNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn homeTownDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isActiveDataGridViewCheckBoxColumn;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
    }
}