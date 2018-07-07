using HHCoApps.Libs;
using HHCoApps.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AutoMapper;
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
        public ProductList(
            ICategoryServices categoryServices,
            ISupplierServices supplierServices,
            IProductServices productServices
            )
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
                    _productList = result.ToList().Select(Mapper.Map<ProductViewModel>).ToList();
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
            var addSupplierForm = new AddProduct(_productServices, _categoryServices, _supplierServices);
            addSupplierForm.FormClosed += AddProductFormClosed;
            addSupplierForm.ShowDialog();
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

            dtPickerIssuedDate.Value = _currentProduct.IssuedDate;
            dtPickerExpiredDate.Value = _currentProduct.ExpiredDate ?? new DateTime(DateTime.Now.Year, 12, 31);

            txtBaseCost.Enabled = true;
            txtCode.Enabled = true;
            txtName.Enabled = true;
            txtStock.Enabled = true;

            cbxCategory.Enabled = true;
            cbxSupplier.Enabled = true;
            cbxIsActive.Checked = _currentProduct.IsActive;

            dtPickerIssuedDate.Enabled = true;
            dtPickerExpiredDate.Enabled = true;
        }
    }
}
