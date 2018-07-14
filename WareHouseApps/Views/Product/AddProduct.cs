using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AutoMapper;
using HHCoApps.Libs;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using WareHouseApps.Helper;
using WareHouseApps.Models;

namespace WareHouseApps
{
    public partial class AddProduct : BaseMethod
    {
        private readonly IProductServices _productServices;
        private readonly ICategoryServices _categoryServices;
        private readonly ISupplierServices _supplierServices;

        public AddProduct(IProductServices productServices, ICategoryServices categoryServices, ISupplierServices supplierServices)
        {
            _productServices = productServices;
            _categoryServices = categoryServices;
            _supplierServices = supplierServices;
            InitializeComponent();
            CenterToParent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();

            txtName.Validating += TextBoxValidateNotEmpty;

            txtBaseCost.Validating += TextBoxValidateNotEmpty;
            txtBaseCost.KeyPress += NumericOnly;

            txtStock.Validating += TextBoxValidateNotEmpty;
            txtStock.KeyPress += NumericOnly;

            FormClosing += PreventClosingFormWithErrorProvider;
        }

        private void LoadData()
        {
            dtPickerIssuedDate.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            dtPickerIssuedDate.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            dtPickerIssuedDate.Value = DateTime.Now;

            dtPickerExpiredDate.MinDate = dtPickerIssuedDate.Value.AddDays(1);
            dtPickerExpiredDate.Value = dtPickerIssuedDate.Value.AddDays(2);

            var categoryList = _categoryServices.GetCategories().ToList();
            cbxCategory.DataSource = categoryList;
            cbxCategory.DisplayMember = "Name";
            cbxCategory.ValueMember = "Id";
            cbxCategory.DropDownStyle = ComboBoxStyle.DropDownList;

            var supplierList = _supplierServices.GetSuppliers().ToList();
            cbxSupplier.DataSource = supplierList;
            cbxSupplier.DisplayMember = "CompanyName";
            cbxSupplier.ValueMember = "Id";

            cbxStatus.DataSource = Enum.GetValues(typeof(ProductStatus)).Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description,
                    value
                })
                .OrderBy(item => item.value).ToList();

            cbxStatus.DisplayMember = "Description";
            cbxStatus.ValueMember = "value";
        }

        private void ResetMinDateExpiredDate(object sender, EventArgs e)
        {
            dtPickerExpiredDate.MinDate = dtPickerIssuedDate.Value.AddDays(1);
        }

        private void AddNewProduct(object sender, EventArgs e)
        {
            var viewModel = new ProductModel
            {
                BasePrice = Convert.ToDecimal(txtBaseCost.Text),
                CategoryId = (int)cbxCategory.SelectedValue,
                SupplierId = Guid.Parse(cbxSupplier.SelectedValue.ToString()),
                Stock = Convert.ToInt32(txtStock.Text),
                Name = txtName.Text,
                IssuedDate = dtPickerIssuedDate.Value,
                ExpiredDate = dtPickerExpiredDate.Value,
                Status = (int)cbxStatus.SelectedValue
            };
            try
            {
                if (_productServices.AddNewProduct(Mapper.Map<ProductModel>(viewModel)) > 0)
                {
                    if (YesNoDialog("Thành Công!", "Bạn có muốn tiếp tục không ?") == DialogResult.Yes)
                    {
                        ClearForm();
                    }
                    else
                    {
                        Close();
                    }
                }
                else
                {
                    ErrorMessage("Lỗi!", "Mặt hàng này đã tồn tại trong hệ thống!");
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                ErrorMessage();
            }
        }

        private void ClearForm()
        {
            txtName.Clear();
            txtBaseCost.Clear();
            txtCode.Clear();
            txtStock.Clear();

            dtPickerIssuedDate.MinDate = new DateTime(DateTime.Now.Year, 1, 1);
            dtPickerIssuedDate.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);
            dtPickerIssuedDate.Value = DateTime.Now;

            dtPickerExpiredDate.MinDate = dtPickerIssuedDate.Value.AddDays(1);
            dtPickerExpiredDate.Value = dtPickerIssuedDate.Value.AddDays(2);
        }
    }
}
