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
        private readonly ISupplierServices _supplierServices;
        private IList<SupplierViewModel> supplierList;
        private IList<SupplierViewModel> filterList;
        private SupplierViewModel currentSupplier;

        public SupplierList(ISupplierServices supplierServices)
        {
            _supplierServices = supplierServices;
            InitializeComponent();
            CenterToParent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadSuppliers();
        }

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

                if (_supplierServices.UpdateSupplier(Mapper.Map<SupplierViewModel, SupplierModel>(currentSupplier)) != 0)
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
                    if (_supplierServices.DeleteSupplier(Mapper.Map<SupplierViewModel, SupplierModel>(currentSupplier)) != 0)
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
            var addSupplierForm = new AddSupplier(_supplierServices);
            addSupplierForm.FormClosed += AddSupplierFormClosed;
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
                var result = _supplierServices.GetSuppliers();
                if (result .Any())
                {
                    supplierList = result.ToList().Select(s => Mapper.Map<SupplierModel, SupplierViewModel>(s)).ToList();
                }

                supplierViewModelBindingSource.DataSource = supplierList;
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                ErrorMessage();
            }
        }

        private void GetSupplierDetails(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0) return;

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

            txtAddress.Enabled = true;
            txtCompany.Enabled = true;
            txtDirector.Enabled = true;
            txtEmail.Enabled = true;
            txtFax.Enabled = true;
            txtHomeTown.Enabled = true;
            txtInformation.Enabled = true;
            txtTaxCode.Enabled = true;
            txtPhone.Enabled = true;
            cbxIsActive.Enabled = true;

            btnUpdate.Enabled = true;
            btnDelete.Enabled = true;
        }

        private void SearchSupplier(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtSearch.Text.Trim()))
            {
                var filter = txtSearch.Text.Trim();
                filterList = supplierList.Where(s => s.CompanyName.Contains(filter) || s.DirectorName.Contains(filter)).ToList();
                supplierViewModelBindingSource.DataSource = filterList;
            }
            else
            {
                supplierViewModelBindingSource.DataSource = supplierList;
            }
        }
        
        private void ClearForm()
        {
            txtAddress.Enabled = false;
            txtCompany.Enabled = false;
            txtDirector.Enabled = false;
            txtEmail.Enabled = false;
            txtFax.Enabled = false;
            txtHomeTown.Enabled = false;
            txtInformation.Enabled = false;
            txtTaxCode.Enabled = false;
            txtPhone.Enabled = false;
            cbxIsActive.Enabled = false;

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
    }
}
