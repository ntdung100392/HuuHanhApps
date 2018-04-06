using HHCoApps.Services.Interfaces;
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

namespace WareHouseApps
{
    public partial class MainMenu : BaseMethod
    {
        private readonly ISupplierServices supplierServices;
        private readonly ICategoryServices categoryServices;
        private readonly IProductServices productServices;
        public MainMenu(
            ISupplierServices supplierServices, 
            ICategoryServices categoryServices, 
            IProductServices productServices
            )
        {
            InitializeComponent();
            CenterToScreen();
            this.supplierServices = supplierServices;
            this.categoryServices = categoryServices;
            this.productServices = productServices;
        }

        #region Control Event

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (this.YesNoDialog("Xác Nhận!", "Bạn có muốn thoát ?") == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void LoadReportForm(object sender, EventArgs e)
        {
            Report reportForm = new Report();
            reportForm.ShowDialog();
        }

        private void LoadCategoryForm(object sender, EventArgs e)
        {
            CategoryList categoryForm = new CategoryList(categoryServices);
            categoryForm.ShowDialog();
        }

        private void LoadProductForm(object sender, EventArgs e)
        {
            ProductList productForm = new ProductList(categoryServices, supplierServices, productServices);
            productForm.ShowDialog();
        }

        private void LoadImportExportForm(object sender, EventArgs e)
        {
            NoteList noteForm = new NoteList();
            noteForm.ShowDialog();
        }

        private void btnSupplier_Click(object sender, EventArgs e)
        {
            SupplierList supplierForm = new SupplierList(supplierServices);
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
            Timer timer = new Timer
            {
                Interval = 100,
                Enabled = true
            };
            timer.Tick += new EventHandler(TimerSetDate);
            timer.Start();
            lblVersion.Text = "Version: 1.0.0";
        }

        #endregion

        private void TimerSetDate(object sender, EventArgs e)
        {
            lblDateTime.Text = DateTime.Now.ToString("hh:mm:ss dd/MM/yyyy");
        }
    }
}
