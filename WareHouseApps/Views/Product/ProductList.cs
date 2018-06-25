using AutoMapper;
using HHCoApps.Libs;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseApps.Helper;
using WareHouseApps.Models;

namespace WareHouseApps
{
    public partial class ProductList : BaseMethod
    {
        private readonly ICategoryServices categoryServices;
        private readonly ISupplierServices supplierServices;
        private readonly IProductServices productServices;
        private IList<ProductViewModel> productList;
        public ProductList(
            ICategoryServices categoryServices,
            ISupplierServices supplierServices,
            IProductServices productServices
            )
        {
            this.categoryServices = categoryServices;
            this.supplierServices = supplierServices;
            this.productServices = productServices;
            InitializeComponent();
            CenterToParent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                dtPickerIssuedDate.MaxDate = new DateTime(DateTime.Now.Year, 12, 31);

                var categoryList = categoryServices.GetCategories().ToList();
                cbxCategory.DataSource = categoryList;
                cbxCategory.DisplayMember = "Name";
                cbxCategory.ValueMember = "Id";
                cbxCategorySearch.DataSource = categoryList;
                cbxCategorySearch.DisplayMember = "Name";
                cbxCategorySearch.ValueMember = "Id";

                var supplierList = supplierServices.GetSuppliers().ToList();
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

                var result = productServices.GetProducts().ToList();
                if (result != null)
                {
                    productList = result.ToList()
                        .Select(p => Mapper.Map<ProductModel, ProductViewModel>(p)).ToList();
                    mainBindingSource.DataSource = productList;
                }
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message);
                ErrorMessage();
                this.Close();
            }
        }
        
        private void SearchProduct(object sender, EventArgs e)
        {

        }
    }
}
