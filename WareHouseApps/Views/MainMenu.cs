using HHCoApps.Services.Interfaces;
using System;
using System.Windows.Forms;
using WareHouseApps.Helper;

namespace WareHouseApps
{
    public partial class MainMenu : BaseMethod
    {
        private readonly ISupplierServices _supplierServices;
        private readonly ICategoryServices _categoryServices;
        private readonly IProductServices _productServices;
        public MainMenu(ISupplierServices supplierServices, ICategoryServices categoryServices, IProductServices productServices)
        {
            InitializeComponent();
            CenterToScreen();
            _supplierServices = supplierServices;
            _categoryServices = categoryServices;
            _productServices = productServices;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (YesNoDialog("Xác Nhận!", "Bạn có muốn thoát ?") == DialogResult.Yes)
            {
                Close();
            }
        }

        private void LoadReportForm(object sender, EventArgs e)
        {
            Report reportForm = new Report();
            reportForm.ShowDialog();
        }

        private void LoadCategoryForm(object sender, EventArgs e)
        {
            CategoryList categoryForm = new CategoryList(_categoryServices);
            categoryForm.ShowDialog();
        }

        private void LoadProductForm(object sender, EventArgs e)
        {
            ProductList productForm = new ProductList(_categoryServices, _supplierServices, _productServices);
            productForm.ShowDialog();
        }

        private void LoadImportExportForm(object sender, EventArgs e)
        {
            NoteList noteForm = new NoteList();
            noteForm.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierList supplierForm = new SupplierList(_supplierServices);
            supplierForm.ShowDialog();
        }

        private void ImportProduct(object sender, EventArgs e)
        {
            ImportProduct importForm = new ImportProduct();
            importForm.ShowDialog();
        }

        private void ExportProduct(object sender, EventArgs e)
        {
            ExportProduct exportForm = new ExportProduct();
            exportForm.ShowDialog();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            var timer = new Timer
            {
                Interval = 100,
                Enabled = true
            };
            timer.Tick += TimerSetDate;
            timer.Start();
            lblVersion.Text = "Version: 1.0.0";
        }

        private void TimerSetDate(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("hh:mm:ss dd/MM/yyyy");
        }
    }
}
