using System.Windows.Forms;

namespace WareHouseApps
{
    partial class ProductList
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
            this.grBoxProduct = new System.Windows.Forms.GroupBox();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.dtPickerExpiredDate = new System.Windows.Forms.DateTimePicker();
            this.lblExpiredDate = new System.Windows.Forms.Label();
            this.txtBaseCost = new System.Windows.Forms.TextBox();
            this.lblBaseCost = new System.Windows.Forms.Label();
            this.cbxIsActive = new System.Windows.Forms.CheckBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.grBoxSearch = new System.Windows.Forms.GroupBox();
            this.btnResetFilter = new System.Windows.Forms.Button();
            this.cbxCategorySearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.lblCategorySearch = new System.Windows.Forms.Label();
            this.cbxSupplierSearch = new System.Windows.Forms.ComboBox();
            this.lblSupplierSearch = new System.Windows.Forms.Label();
            this.txtProductNameSearch = new System.Windows.Forms.TextBox();
            this.lblProductSearch = new System.Windows.Forms.Label();
            this.dtPickerTo = new System.Windows.Forms.DateTimePicker();
            this.lblTo = new System.Windows.Forms.Label();
            this.dtPickerFrom = new System.Windows.Forms.DateTimePicker();
            this.lblIssuedDateSearch = new System.Windows.Forms.Label();
            this.cbxStatus = new System.Windows.Forms.ComboBox();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cbxCategory = new System.Windows.Forms.ComboBox();
            this.lblCategory = new System.Windows.Forms.Label();
            this.txtStock = new System.Windows.Forms.TextBox();
            this.lblStock = new System.Windows.Forms.Label();
            this.cbxSupplier = new System.Windows.Forms.ComboBox();
            this.lblSupplier = new System.Windows.Forms.Label();
            this.dtPickerIssuedDate = new System.Windows.Forms.DateTimePicker();
            this.lblIssuedDate = new System.Windows.Forms.Label();
            this.txtCode = new System.Windows.Forms.TextBox();
            this.lblCode = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.dataGridProducts = new System.Windows.Forms.DataGridView();
            this.productCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Supplier = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.statusDisplayDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.issuedDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stockDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).BeginInit();
            this.grBoxProduct.SuspendLayout();
            this.grBoxSearch.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).BeginInit();
            this.SuspendLayout();
            // 
            // mainBindingSource
            // 
            this.mainBindingSource.DataSource = typeof(WareHouseApps.Models.ProductViewModel);
            // 
            // grBoxProduct
            // 
            this.grBoxProduct.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grBoxProduct.Controls.Add(this.btnUpdate);
            this.grBoxProduct.Controls.Add(this.dtPickerExpiredDate);
            this.grBoxProduct.Controls.Add(this.lblExpiredDate);
            this.grBoxProduct.Controls.Add(this.txtBaseCost);
            this.grBoxProduct.Controls.Add(this.lblBaseCost);
            this.grBoxProduct.Controls.Add(this.cbxIsActive);
            this.grBoxProduct.Controls.Add(this.btnAdd);
            this.grBoxProduct.Controls.Add(this.grBoxSearch);
            this.grBoxProduct.Controls.Add(this.cbxStatus);
            this.grBoxProduct.Controls.Add(this.lblStatus);
            this.grBoxProduct.Controls.Add(this.cbxCategory);
            this.grBoxProduct.Controls.Add(this.lblCategory);
            this.grBoxProduct.Controls.Add(this.txtStock);
            this.grBoxProduct.Controls.Add(this.lblStock);
            this.grBoxProduct.Controls.Add(this.cbxSupplier);
            this.grBoxProduct.Controls.Add(this.lblSupplier);
            this.grBoxProduct.Controls.Add(this.dtPickerIssuedDate);
            this.grBoxProduct.Controls.Add(this.lblIssuedDate);
            this.grBoxProduct.Controls.Add(this.txtCode);
            this.grBoxProduct.Controls.Add(this.lblCode);
            this.grBoxProduct.Controls.Add(this.txtName);
            this.grBoxProduct.Controls.Add(this.lblName);
            this.grBoxProduct.Controls.Add(this.dataGridProducts);
            this.grBoxProduct.Location = new System.Drawing.Point(17, 16);
            this.grBoxProduct.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grBoxProduct.Name = "grBoxProduct";
            this.grBoxProduct.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grBoxProduct.Size = new System.Drawing.Size(1112, 578);
            this.grBoxProduct.TabIndex = 0;
            this.grBoxProduct.TabStop = false;
            this.grBoxProduct.Text = "Danh Sách";
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(463, 182);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(161, 28);
            this.btnUpdate.TabIndex = 22;
            this.btnUpdate.Text = "Cập Nhật";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.UpdateProduct);
            // 
            // dtPickerExpiredDate
            // 
            this.dtPickerExpiredDate.CustomFormat = "dd/MM/yyyy";
            this.dtPickerExpiredDate.Enabled = false;
            this.dtPickerExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerExpiredDate.Location = new System.Drawing.Point(463, 86);
            this.dtPickerExpiredDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPickerExpiredDate.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.dtPickerExpiredDate.Name = "dtPickerExpiredDate";
            this.dtPickerExpiredDate.Size = new System.Drawing.Size(160, 22);
            this.dtPickerExpiredDate.TabIndex = 21;
            // 
            // lblExpiredDate
            // 
            this.lblExpiredDate.AutoSize = true;
            this.lblExpiredDate.Location = new System.Drawing.Point(351, 94);
            this.lblExpiredDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblExpiredDate.Name = "lblExpiredDate";
            this.lblExpiredDate.Size = new System.Drawing.Size(101, 17);
            this.lblExpiredDate.TabIndex = 20;
            this.lblExpiredDate.Text = "Hạn Bảo Hành";
            // 
            // txtBaseCost
            // 
            this.txtBaseCost.Enabled = false;
            this.txtBaseCost.Location = new System.Drawing.Point(463, 123);
            this.txtBaseCost.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtBaseCost.MaxLength = 10;
            this.txtBaseCost.Name = "txtBaseCost";
            this.txtBaseCost.Size = new System.Drawing.Size(160, 22);
            this.txtBaseCost.TabIndex = 19;
            // 
            // lblBaseCost
            // 
            this.lblBaseCost.AutoSize = true;
            this.lblBaseCost.Location = new System.Drawing.Point(385, 127);
            this.lblBaseCost.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblBaseCost.Name = "lblBaseCost";
            this.lblBaseCost.Size = new System.Drawing.Size(68, 17);
            this.lblBaseCost.TabIndex = 18;
            this.lblBaseCost.Text = "Giá Nhập";
            // 
            // cbxIsActive
            // 
            this.cbxIsActive.AutoSize = true;
            this.cbxIsActive.Enabled = false;
            this.cbxIsActive.Location = new System.Drawing.Point(333, 155);
            this.cbxIsActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxIsActive.Name = "cbxIsActive";
            this.cbxIsActive.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.cbxIsActive.Size = new System.Drawing.Size(142, 21);
            this.cbxIsActive.TabIndex = 17;
            this.cbxIsActive.Text = "Đang Kinh Doanh";
            this.cbxIsActive.UseVisualStyleBackColor = true;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(293, 182);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(161, 28);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "Tạo Mới";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.LoadAddProduct);
            // 
            // grBoxSearch
            // 
            this.grBoxSearch.Controls.Add(this.btnResetFilter);
            this.grBoxSearch.Controls.Add(this.cbxCategorySearch);
            this.grBoxSearch.Controls.Add(this.btnSearch);
            this.grBoxSearch.Controls.Add(this.lblCategorySearch);
            this.grBoxSearch.Controls.Add(this.cbxSupplierSearch);
            this.grBoxSearch.Controls.Add(this.lblSupplierSearch);
            this.grBoxSearch.Controls.Add(this.txtProductNameSearch);
            this.grBoxSearch.Controls.Add(this.lblProductSearch);
            this.grBoxSearch.Controls.Add(this.dtPickerTo);
            this.grBoxSearch.Controls.Add(this.lblTo);
            this.grBoxSearch.Controls.Add(this.dtPickerFrom);
            this.grBoxSearch.Controls.Add(this.lblIssuedDateSearch);
            this.grBoxSearch.Location = new System.Drawing.Point(685, 21);
            this.grBoxSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grBoxSearch.Name = "grBoxSearch";
            this.grBoxSearch.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.grBoxSearch.Size = new System.Drawing.Size(419, 194);
            this.grBoxSearch.TabIndex = 16;
            this.grBoxSearch.TabStop = false;
            this.grBoxSearch.Text = "Tìm Kiếm";
            // 
            // btnResetFilter
            // 
            this.btnResetFilter.Location = new System.Drawing.Point(296, 149);
            this.btnResetFilter.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnResetFilter.Name = "btnResetFilter";
            this.btnResetFilter.Size = new System.Drawing.Size(123, 28);
            this.btnResetFilter.TabIndex = 17;
            this.btnResetFilter.Text = "Mặc Định";
            this.btnResetFilter.UseVisualStyleBackColor = true;
            this.btnResetFilter.Click += new System.EventHandler(this.ResetFilter);
            // 
            // cbxCategorySearch
            // 
            this.cbxCategorySearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategorySearch.FormattingEnabled = true;
            this.cbxCategorySearch.Location = new System.Drawing.Point(8, 151);
            this.cbxCategorySearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxCategorySearch.Name = "cbxCategorySearch";
            this.cbxCategorySearch.Size = new System.Drawing.Size(171, 24);
            this.cbxCategorySearch.TabIndex = 11;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(188, 149);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 28);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Tìm Kiếm";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.SearchProduct);
            // 
            // lblCategorySearch
            // 
            this.lblCategorySearch.AutoSize = true;
            this.lblCategorySearch.Location = new System.Drawing.Point(12, 132);
            this.lblCategorySearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategorySearch.Name = "lblCategorySearch";
            this.lblCategorySearch.Size = new System.Drawing.Size(72, 17);
            this.lblCategorySearch.TabIndex = 8;
            this.lblCategorySearch.Text = "Danh Mục";
            // 
            // cbxSupplierSearch
            // 
            this.cbxSupplierSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSupplierSearch.FormattingEnabled = true;
            this.cbxSupplierSearch.Location = new System.Drawing.Point(188, 97);
            this.cbxSupplierSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSupplierSearch.Name = "cbxSupplierSearch";
            this.cbxSupplierSearch.Size = new System.Drawing.Size(221, 24);
            this.cbxSupplierSearch.TabIndex = 7;
            // 
            // lblSupplierSearch
            // 
            this.lblSupplierSearch.AutoSize = true;
            this.lblSupplierSearch.Location = new System.Drawing.Point(184, 79);
            this.lblSupplierSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplierSearch.Name = "lblSupplierSearch";
            this.lblSupplierSearch.Size = new System.Drawing.Size(100, 17);
            this.lblSupplierSearch.TabIndex = 6;
            this.lblSupplierSearch.Text = "Nhà Cung Cấp";
            // 
            // txtProductNameSearch
            // 
            this.txtProductNameSearch.Location = new System.Drawing.Point(8, 98);
            this.txtProductNameSearch.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtProductNameSearch.MaxLength = 100;
            this.txtProductNameSearch.Name = "txtProductNameSearch";
            this.txtProductNameSearch.Size = new System.Drawing.Size(171, 22);
            this.txtProductNameSearch.TabIndex = 5;
            // 
            // lblProductSearch
            // 
            this.lblProductSearch.AutoSize = true;
            this.lblProductSearch.Location = new System.Drawing.Point(8, 79);
            this.lblProductSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblProductSearch.Name = "lblProductSearch";
            this.lblProductSearch.Size = new System.Drawing.Size(101, 17);
            this.lblProductSearch.TabIndex = 4;
            this.lblProductSearch.Text = "Tên Hàng Hóa";
            // 
            // dtPickerTo
            // 
            this.dtPickerTo.CustomFormat = "dd/MM/yyyy";
            this.dtPickerTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerTo.Location = new System.Drawing.Point(188, 44);
            this.dtPickerTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPickerTo.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.dtPickerTo.Name = "dtPickerTo";
            this.dtPickerTo.Size = new System.Drawing.Size(128, 22);
            this.dtPickerTo.TabIndex = 3;
            // 
            // lblTo
            // 
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(145, 52);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(32, 17);
            this.lblTo.TabIndex = 2;
            this.lblTo.Text = "đến";
            // 
            // dtPickerFrom
            // 
            this.dtPickerFrom.CustomFormat = "dd/MM/yyyy";
            this.dtPickerFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerFrom.Location = new System.Drawing.Point(8, 44);
            this.dtPickerFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPickerFrom.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.dtPickerFrom.Name = "dtPickerFrom";
            this.dtPickerFrom.Size = new System.Drawing.Size(128, 22);
            this.dtPickerFrom.TabIndex = 1;
            // 
            // lblIssuedDateSearch
            // 
            this.lblIssuedDateSearch.AutoSize = true;
            this.lblIssuedDateSearch.Location = new System.Drawing.Point(8, 25);
            this.lblIssuedDateSearch.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIssuedDateSearch.Name = "lblIssuedDateSearch";
            this.lblIssuedDateSearch.Size = new System.Drawing.Size(79, 17);
            this.lblIssuedDateSearch.TabIndex = 0;
            this.lblIssuedDateSearch.Text = "Ngày Nhập";
            // 
            // cbxStatus
            // 
            this.cbxStatus.Enabled = false;
            this.cbxStatus.FormattingEnabled = true;
            this.cbxStatus.Location = new System.Drawing.Point(121, 153);
            this.cbxStatus.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxStatus.Name = "cbxStatus";
            this.cbxStatus.Size = new System.Drawing.Size(184, 24);
            this.cbxStatus.TabIndex = 15;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(35, 156);
            this.lblStatus.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(78, 17);
            this.lblStatus.TabIndex = 14;
            this.lblStatus.Text = "Tình Trạng";
            // 
            // cbxCategory
            // 
            this.cbxCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxCategory.Enabled = false;
            this.cbxCategory.FormattingEnabled = true;
            this.cbxCategory.Location = new System.Drawing.Point(463, 53);
            this.cbxCategory.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxCategory.Name = "cbxCategory";
            this.cbxCategory.Size = new System.Drawing.Size(160, 24);
            this.cbxCategory.TabIndex = 13;
            // 
            // lblCategory
            // 
            this.lblCategory.AutoSize = true;
            this.lblCategory.Location = new System.Drawing.Point(379, 58);
            this.lblCategory.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(72, 17);
            this.lblCategory.TabIndex = 12;
            this.lblCategory.Text = "Danh Mục";
            // 
            // txtStock
            // 
            this.txtStock.Enabled = false;
            this.txtStock.Location = new System.Drawing.Point(463, 21);
            this.txtStock.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtStock.MaxLength = 4;
            this.txtStock.Name = "txtStock";
            this.txtStock.Size = new System.Drawing.Size(160, 22);
            this.txtStock.TabIndex = 11;
            // 
            // lblStock
            // 
            this.lblStock.AutoSize = true;
            this.lblStock.Location = new System.Drawing.Point(384, 25);
            this.lblStock.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblStock.Name = "lblStock";
            this.lblStock.Size = new System.Drawing.Size(69, 17);
            this.lblStock.TabIndex = 10;
            this.lblStock.Text = "Số Lượng";
            // 
            // cbxSupplier
            // 
            this.cbxSupplier.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxSupplier.Enabled = false;
            this.cbxSupplier.FormattingEnabled = true;
            this.cbxSupplier.Location = new System.Drawing.Point(121, 119);
            this.cbxSupplier.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.cbxSupplier.Name = "cbxSupplier";
            this.cbxSupplier.Size = new System.Drawing.Size(184, 24);
            this.cbxSupplier.TabIndex = 9;
            // 
            // lblSupplier
            // 
            this.lblSupplier.AutoSize = true;
            this.lblSupplier.Location = new System.Drawing.Point(11, 123);
            this.lblSupplier.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblSupplier.Name = "lblSupplier";
            this.lblSupplier.Size = new System.Drawing.Size(100, 17);
            this.lblSupplier.TabIndex = 8;
            this.lblSupplier.Text = "Nhà Cung Cấp";
            // 
            // dtPickerIssuedDate
            // 
            this.dtPickerIssuedDate.CustomFormat = "dd/MM/yyyy";
            this.dtPickerIssuedDate.Enabled = false;
            this.dtPickerIssuedDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtPickerIssuedDate.Location = new System.Drawing.Point(121, 86);
            this.dtPickerIssuedDate.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dtPickerIssuedDate.MinDate = new System.DateTime(1999, 1, 1, 0, 0, 0, 0);
            this.dtPickerIssuedDate.Name = "dtPickerIssuedDate";
            this.dtPickerIssuedDate.Size = new System.Drawing.Size(184, 22);
            this.dtPickerIssuedDate.TabIndex = 7;
            // 
            // lblIssuedDate
            // 
            this.lblIssuedDate.AutoSize = true;
            this.lblIssuedDate.Location = new System.Drawing.Point(32, 94);
            this.lblIssuedDate.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblIssuedDate.Name = "lblIssuedDate";
            this.lblIssuedDate.Size = new System.Drawing.Size(79, 17);
            this.lblIssuedDate.TabIndex = 5;
            this.lblIssuedDate.Text = "Ngày Nhập";
            // 
            // txtCode
            // 
            this.txtCode.Enabled = false;
            this.txtCode.Location = new System.Drawing.Point(121, 54);
            this.txtCode.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtCode.MaxLength = 10;
            this.txtCode.Name = "txtCode";
            this.txtCode.ReadOnly = true;
            this.txtCode.Size = new System.Drawing.Size(184, 22);
            this.txtCode.TabIndex = 4;
            // 
            // lblCode
            // 
            this.lblCode.AutoSize = true;
            this.lblCode.Location = new System.Drawing.Point(15, 58);
            this.lblCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCode.Name = "lblCode";
            this.lblCode.Size = new System.Drawing.Size(95, 17);
            this.lblCode.TabIndex = 3;
            this.lblCode.Text = "Mã Hàng Hóa";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(121, 21);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.txtName.MaxLength = 100;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(184, 22);
            this.txtName.TabIndex = 2;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(9, 25);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(101, 17);
            this.lblName.TabIndex = 1;
            this.lblName.Text = "Tên Hàng Hóa";
            // 
            // dataGridProducts
            // 
            this.dataGridProducts.AllowUserToAddRows = false;
            this.dataGridProducts.AllowUserToDeleteRows = false;
            this.dataGridProducts.AllowUserToResizeColumns = false;
            this.dataGridProducts.AllowUserToResizeRows = false;
            this.dataGridProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridProducts.AutoGenerateColumns = false;
            this.dataGridProducts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridProducts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.productCodeDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.Category,
            this.Supplier,
            this.statusDisplayDataGridViewTextBoxColumn,
            this.issuedDateDataGridViewTextBoxColumn,
            this.stockDataGridViewTextBoxColumn});
            this.dataGridProducts.DataSource = this.mainBindingSource;
            this.dataGridProducts.Location = new System.Drawing.Point(9, 223);
            this.dataGridProducts.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridProducts.MultiSelect = false;
            this.dataGridProducts.Name = "dataGridProducts";
            this.dataGridProducts.ReadOnly = true;
            this.dataGridProducts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridProducts.Size = new System.Drawing.Size(1095, 348);
            this.dataGridProducts.TabIndex = 0;
            this.dataGridProducts.CellMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GetProductDetails);
            // 
            // productCodeDataGridViewTextBoxColumn
            // 
            this.productCodeDataGridViewTextBoxColumn.DataPropertyName = "ProductCode";
            this.productCodeDataGridViewTextBoxColumn.HeaderText = "Mã Hàng";
            this.productCodeDataGridViewTextBoxColumn.Name = "productCodeDataGridViewTextBoxColumn";
            this.productCodeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Tên Hàng Hóa";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.Width = 200;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "CategoryName";
            this.Category.HeaderText = "Danh Mục Hàng";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 200;
            // 
            // Supplier
            // 
            this.Supplier.DataPropertyName = "SupplierName";
            this.Supplier.HeaderText = "Nhà Cung Cấp";
            this.Supplier.Name = "Supplier";
            this.Supplier.ReadOnly = true;
            this.Supplier.Width = 200;
            // 
            // statusDisplayDataGridViewTextBoxColumn
            // 
            this.statusDisplayDataGridViewTextBoxColumn.DataPropertyName = "StatusDisplay";
            this.statusDisplayDataGridViewTextBoxColumn.HeaderText = "Tình Trạng";
            this.statusDisplayDataGridViewTextBoxColumn.Name = "statusDisplayDataGridViewTextBoxColumn";
            this.statusDisplayDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // issuedDateDataGridViewTextBoxColumn
            // 
            this.issuedDateDataGridViewTextBoxColumn.DataPropertyName = "IssuedDate";
            this.issuedDateDataGridViewTextBoxColumn.HeaderText = "Ngày Nhập";
            this.issuedDateDataGridViewTextBoxColumn.Name = "issuedDateDataGridViewTextBoxColumn";
            this.issuedDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // stockDataGridViewTextBoxColumn
            // 
            this.stockDataGridViewTextBoxColumn.DataPropertyName = "Stock";
            this.stockDataGridViewTextBoxColumn.HeaderText = "Số Lượng Tồn";
            this.stockDataGridViewTextBoxColumn.Name = "stockDataGridViewTextBoxColumn";
            this.stockDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ProductList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1145, 609);
            this.Controls.Add(this.grBoxProduct);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "ProductList";
            this.Text = "Danh Sách Hàng Hóa";
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).EndInit();
            this.grBoxProduct.ResumeLayout(false);
            this.grBoxProduct.PerformLayout();
            this.grBoxSearch.ResumeLayout(false);
            this.grBoxSearch.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridProducts)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grBoxProduct;
        private System.Windows.Forms.DataGridView dataGridProducts;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtCode;
        private System.Windows.Forms.Label lblCode;
        private System.Windows.Forms.Label lblIssuedDate;
        private System.Windows.Forms.DateTimePicker dtPickerIssuedDate;
        private System.Windows.Forms.Label lblSupplier;
        private System.Windows.Forms.Label lblStock;
        private System.Windows.Forms.ComboBox cbxSupplier;
        private System.Windows.Forms.TextBox txtStock;
        private System.Windows.Forms.Label lblCategory;
        private System.Windows.Forms.ComboBox cbxCategory;
        private System.Windows.Forms.ComboBox cbxStatus;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox grBoxSearch;
        private System.Windows.Forms.DateTimePicker dtPickerFrom;
        private System.Windows.Forms.Label lblIssuedDateSearch;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.DateTimePicker dtPickerTo;
        private System.Windows.Forms.Label lblProductSearch;
        private System.Windows.Forms.TextBox txtProductNameSearch;
        private System.Windows.Forms.Label lblSupplierSearch;
        private System.Windows.Forms.Label lblCategorySearch;
        private System.Windows.Forms.ComboBox cbxSupplierSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn supplierIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn basePriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn expiredDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.ComboBox cbxCategorySearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn productCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Category;
        private System.Windows.Forms.DataGridViewTextBoxColumn Supplier;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDisplayDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn issuedDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn stockDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnResetFilter;
        private System.Windows.Forms.CheckBox cbxIsActive;
        private System.Windows.Forms.TextBox txtBaseCost;
        private System.Windows.Forms.Label lblBaseCost;
        private System.Windows.Forms.DateTimePicker dtPickerExpiredDate;
        private System.Windows.Forms.Label lblExpiredDate;
        private System.Windows.Forms.Button btnUpdate;
    }
}