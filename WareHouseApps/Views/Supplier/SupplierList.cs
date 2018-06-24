using AutoMapper;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using WareHouseApps.Helper;
using WareHouseApps.Models;

namespace WareHouseApps
{
    public partial class SupplierList : BaseMethod
    {
        private readonly ISupplierServices supplierServices;
        private IList<SupplierViewModel> supplierList;
        private IList<SupplierViewModel> filterList;
        private SupplierViewModel currentSupplier;

        public SupplierList(ISupplierServices supplierServices)
        {
            InitializeComponent();
            CenterToParent();
            this.supplierServices = supplierServices;
        }

        #region Form Event
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadSuppliers();
        }
        #endregion

        #region Control Event
        private void UpdateSupplier(object sender, EventArgs e)
        {
            if (YesNoDialog() == DialogResult.Yes)
            {
                currentSupplier.Address = txtAddress.Text;
                currentSupplier.CompanyName = txtCompany.Text;
                currentSupplier.DirectorName = txtDirector.Text;
                currentSupplier.Email = txtEmail.Text;
                currentSupplier.Fax = txtFax.Text;
                currentSupplier.HomeTown = txtHomeTown.Text;
                currentSupplier.Note = txtInformation.Text;
                currentSupplier.TaxCode = txtTaxCode.Text;
                currentSupplier.Phone = txtPhone.Text;
                currentSupplier.IsActive = cbxIsActive.Checked;

                if (supplierServices.UpdateSupplier(Mapper.Map<SupplierViewModel, SupplierModel>(currentSupplier)))
                {
                    LoadSuppliers();
                    SuccessMessage();
                }
                else
                {
                    LoadSuppliers();
                    ErrorMessage();
                }
            }
        }

        private void DeleteSupplier(object sender, EventArgs e)
        {
            if (YesNoDialog() == DialogResult.Yes)
            {
                try
                {
                    if (supplierServices.DeleteSupplier(Mapper.Map<SupplierViewModel, SupplierModel>(currentSupplier)))
                    {
                        LoadSuppliers();
                        currentSupplier = null;
                        SuccessMessage();
                        ClearForm();
                    }
                    else
                    {
                        LoadSuppliers();
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

        private void LoadAddForm(object sender, EventArgs e)
        {
            AddSupplier addSupplierForm = new AddSupplier(supplierServices);
            addSupplierForm.FormClosed += new FormClosedEventHandler(AddSupplierFormClosed);
            addSupplierForm.ShowDialog();
        }

        private void AddSupplierFormClosed(object sender, FormClosedEventArgs e)
        {
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            try
            {
                var result = supplierServices.GetSuppliers();
                if (result != null)
                {
                    supplierList = result.ToList()
                        .Select(s => Mapper.Map<SupplierModel, SupplierViewModel>(s)).ToList();
                }

                supplierViewModelBindingSource.DataSource = supplierList;
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        private void GetSupplierDetails(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                currentSupplier = supplierList[e.RowIndex];
                txtAddress.Text = currentSupplier.Address;
                txtCompany.Text = currentSupplier.CompanyName;
                txtDirector.Text = currentSupplier.DirectorName;
                txtEmail.Text = currentSupplier.Email;
                txtFax.Text = currentSupplier.Fax;
                txtHomeTown.Text = currentSupplier.HomeTown;
                txtInformation.Text = currentSupplier.Note;
                txtTaxCode.Text = currentSupplier.TaxCode;
                txtPhone.Text = currentSupplier.Phone;
                cbxIsActive.Checked = currentSupplier.IsActive;

                btnUpdate.Enabled = true;
                btnDelete.Enabled = true;
            }
        }

        private void SearchSupplier(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                string filter = txtSearch.Text.Trim();
                filterList = supplierList.Where(s => s.CompanyName.Contains(filter)
                    || s.DirectorName.Contains(filter)).ToList();
                supplierViewModelBindingSource.DataSource = filterList;
            }
            else
            {
                supplierViewModelBindingSource.DataSource = supplierList;
            }
        }
        #endregion

        #region Private Method
        private void ClearForm()
        {
            txtAddress.Clear();
            txtCompany.Clear();
            txtDirector.Clear();
            txtEmail.Clear();
            txtFax.Clear();
            txtHomeTown.Clear();
            txtInformation.Clear();
            txtTaxCode.Clear();
            txtPhone.Clear();
            cbxIsActive.Checked = false;
        }
        #endregion
    }
}
