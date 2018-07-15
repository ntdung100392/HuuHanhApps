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
        private IList<SupplierViewModel> _supplierList;
        private IList<SupplierViewModel> _filterList;
        private SupplierViewModel _currentSupplier;

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
            if (YesNoDialog() != DialogResult.Yes)
                return;

            _currentSupplier.Address = txtAddress.Text;
            _currentSupplier.CompanyName = txtCompany.Text;
            _currentSupplier.DirectorName = txtDirector.Text;
            _currentSupplier.Email = txtEmail.Text;
            _currentSupplier.Fax = txtFax.Text;
            _currentSupplier.HomeTown = txtHomeTown.Text;
            _currentSupplier.Note = txtInformation.Text;
            _currentSupplier.TaxCode = txtTaxCode.Text;
            _currentSupplier.Phone = txtPhone.Text;
            _currentSupplier.IsActive = cbxIsActive.Checked;

            if (_supplierServices.UpdateSupplier(Mapper.Map<SupplierModel>(_currentSupplier)) != 0)
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

        private void DeleteSupplier(object sender, EventArgs e)
        {
            if (YesNoDialog() != DialogResult.Yes)
                return;

            try
            {
                if (_supplierServices.DeleteSupplier(Mapper.Map<SupplierModel>(_currentSupplier)) != 0)
                {
                    LoadSuppliers();
                    _currentSupplier = null;
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
                if (result.Any())
                {
                    _supplierList = result.ToList().Select(Mapper.Map<SupplierViewModel>).ToList();
                }

                supplierViewModelBindingSource.DataSource = _supplierList;
            }
            catch(Exception ex)
            {
                _logger.Error(ex.Message);
                ErrorMessage();
            }
        }

        private void GetSupplierDetails(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _currentSupplier = _supplierList[e.RowIndex];
            txtAddress.Text = _currentSupplier.Address;
            txtCompany.Text = _currentSupplier.CompanyName;
            txtDirector.Text = _currentSupplier.DirectorName;
            txtEmail.Text = _currentSupplier.Email;
            txtFax.Text = _currentSupplier.Fax;
            txtHomeTown.Text = _currentSupplier.HomeTown;
            txtInformation.Text = _currentSupplier.Note;
            txtTaxCode.Text = _currentSupplier.TaxCode;
            txtPhone.Text = _currentSupplier.Phone;
            cbxIsActive.Checked = _currentSupplier.IsActive;

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
                _filterList = _supplierList.Where(s => s.CompanyName.Contains(filter) || s.DirectorName.Contains(filter)).ToList();
                supplierViewModelBindingSource.DataSource = _filterList;
            }
            else
            {
                supplierViewModelBindingSource.DataSource = _supplierList;
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
