using HHCoApps.Libs;
using HHCoApps.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
using HHCoApps.Services.Models;
using WareHouseApps.Helper;
using WareHouseApps.Models;

namespace WareHouseApps
{
    public partial class ProductList : BaseMethod
    {
        private readonly ICategoryServices _categoryServices;
        private readonly ISupplierServices _supplierServices;
        private readonly IProductServices _productServices;
        private IList<ProductViewModel> _productList;
        private ProductViewModel _currentProduct;

        public ProductList(ICategoryServices categoryServices, ISupplierServices supplierServices, IProductServices productServices)
        {
            _categoryServices = categoryServices;
            _supplierServices = supplierServices;
            _productServices = productServices;
            InitializeComponent();
            CenterToParent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
            LoadProducts();

            txtName.Validating += TextBoxValidateNotEmpty;

            txtBaseCost.Validating += TextBoxValidateNotEmpty;
            txtBaseCost.KeyPress += NumericOnly;

            txtStock.Validating += TextBoxValidateNotEmpty;
            txtStock.KeyPress += NumericOnly;
        }

        private void LoadData()
        {
            try
            {
                dtPickerIssuedDate.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

                var categoryList = _categoryServices.GetCategories().ToList();

                cbxCategory.DataSource = categoryList;
                cbxCategory.DisplayMember = "Name";
                cbxCategory.ValueMember = "Id";

                cbxCategorySearch.DataSource = categoryList;
                cbxCategorySearch.DisplayMember = "Name";
                cbxCategorySearch.ValueMember = "Id";

                var supplierList = _supplierServices.GetSuppliers().ToList();

                cbxSupplier.DataSource = supplierList;
                cbxSupplier.DisplayMember = "CompanyName";
                cbxSupplier.ValueMember = "Id";

                cbxSupplierSearch.DataSource = supplierList;
                cbxSupplierSearch.DisplayMember = "CompanyName";
                cbxSupplierSearch.ValueMember = "Id";

                cbxStatus.DataSource =
                    Enum.GetValues(typeof(ProductStatus)).Cast<Enum>().Select(value => new
                    {
                        (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()),
                    typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                        value
                    })
                .OrderBy(item => item.value)
                .ToList();

                cbxStatus.DisplayMember = "Description";
                cbxStatus.ValueMember = "value";
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                ErrorMessage();
                Close();
            }
        }

        private void LoadProducts()
        {
            try
            {
                var result = _productServices.GetProductsOrderByIssuedDate();
                if (result.Any())
                {
                    _productList = result.Select(Mapper.Map<ProductViewModel>).ToList();
                }

                dataGridProducts.DataSource = _productList;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                ErrorMessage();
                Close();
            }
        }

        private void SearchProduct(object sender, EventArgs e)
        {

        }

        private void LoadAddProduct(object sender, EventArgs e)
        {
            var addProductForm = new AddProduct(_productServices, _categoryServices, _supplierServices);
            addProductForm.FormClosed += AddProductFormClosed;
            addProductForm.ShowDialog();
        }

        private void AddProductFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadProducts();
        }

        private void GetProductDetails(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _currentProduct = _productList[e.RowIndex];
            txtBaseCost.Text = _currentProduct.BasePrice.ToString();
            txtCode.Text = _currentProduct.ProductCode;
            txtName.Text = _currentProduct.Name;
            txtStock.Text = _currentProduct.Stock.ToString();

            cbxCategory.Text = _currentProduct.CategoryName;
            cbxSupplier.Text = _currentProduct.SupplierName;
            cbxIsActive.Checked = _currentProduct.IsActive;
            cbxStatus.Text = _currentProduct.StatusDisplay;

            dtPickerIssuedDate.Value = _currentProduct.IssuedDate;
            dtPickerExpiredDate.Value = _currentProduct.ExpiredDate ?? new DateTime(DateTime.Now.Year, 12, 31);

            txtBaseCost.Enabled = true;
            txtCode.Enabled = true;
            txtName.Enabled = true;
            txtStock.Enabled = true;

            cbxCategory.Enabled = true;
            cbxSupplier.Enabled = true;
            cbxIsActive.Enabled = true;
            cbxStatus.Enabled = true;

            dtPickerIssuedDate.Enabled = true;
            dtPickerExpiredDate.Enabled = true;
        }

        private void UpdateProduct(object sender, EventArgs e)
        {
            if (YesNoDialog("Thông Báo!", "Bạn có muốn tiếp tục không ?") != DialogResult.Yes)
                return;

            try
            {
                _currentProduct.BasePrice = Convert.ToDecimal(txtBaseCost.Text);
                _currentProduct.CategoryId = (int)cbxCategory.SelectedValue;
                _currentProduct.SupplierId = Guid.Parse(cbxSupplier.SelectedValue.ToString());
                _currentProduct.Stock = Convert.ToInt32(txtStock.Text);
                _currentProduct.Name = txtName.Text;
                _currentProduct.IssuedDate = dtPickerIssuedDate.Value;
                _currentProduct.ExpiredDate = dtPickerExpiredDate.Value;
                _currentProduct.Status = (int)cbxStatus.SelectedValue;
                _currentProduct.IsActive = cbxIsActive.Checked;
                var model = Mapper.Map<ProductModel>(_currentProduct);

                if (_productServices.UpdateProductByUniqueId(model) > 0)
                {
                    SuccessMessage();
                }
                else
                {
                    ErrorMessage();
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                ErrorMessage();
            }
        }
    }
}
