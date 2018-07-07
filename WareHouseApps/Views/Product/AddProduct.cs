using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using HHCoApps.Libs;
using HHCoApps.Services.Interfaces;
using WareHouseApps.Helper;

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

            txtCode.Validating += TextBoxValidateNotEmpty;

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

            dtPickerExpiredDate.MinDate = dtPickerIssuedDate.Value.AddDays(1);

            var categoryList = _categoryServices.GetCategories().ToList();
            cbxCategory.DataSource = categoryList;
            cbxCategory.DisplayMember = "Name";
            cbxCategory.ValueMember = "Id";

            var supplierList = _supplierServices.GetSuppliers().ToList();
            cbxSupplier.DataSource = supplierList;
            cbxSupplier.DisplayMember = "CompanyName";
            cbxSupplier.ValueMember = "Id";

            cbxStatus.DataSource = Enum.GetValues(typeof(ProductStatus)).Cast<Enum>()
                .Select(value => new
                {
                    (Attribute.GetCustomAttribute(value.GetType().GetField(value.ToString()), typeof(DescriptionAttribute)) as DescriptionAttribute).Description, value
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

        }

        private bool FormValid(out string errorMessage)
        {
            errorMessage = string.Empty;
            return true;
        }

        private void ClearForm()
        {
            //txtDirector.Clear();
            //txtAddress.Clear();
            //txtCompany.Clear();
            //txtFax.Clear();
            //txtEmail.Clear();
            //txtHomeTown.Clear();
            //txtInformation.Clear();
            //txtPhone.Clear();
            //txtTaxCode.Clear();
        }
    }
}
