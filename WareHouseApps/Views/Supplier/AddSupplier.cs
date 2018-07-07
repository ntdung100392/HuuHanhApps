using AutoMapper;
using HHCoApps.Services.Interfaces;
using HHCoApps.Services.Models;
using System;
using System.Windows.Forms;
using Ninject;
using WareHouseApps.Helper;
using WareHouseApps.Models;

namespace WareHouseApps
{
    public partial class AddSupplier : BaseMethod
    {
        [Inject]
        private readonly ISupplierServices _supplierServices;

        public AddSupplier(ISupplierServices supplierServices)
        {
            InitializeComponent();
            CenterToParent();
            _supplierServices = supplierServices;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtCompany.Validating += TextBoxValidateNotEmpty;

            txtDirector.Validating += TextBoxValidateNotEmpty;

            txtAddress.Validating += TextBoxValidateNotEmpty;

            txtTaxCode.Validating += TextBoxValidateNotEmpty;
            txtTaxCode.KeyPress += NumericOnly;

            txtPhone.Validating += TextBoxValidateNotEmpty;
            txtPhone.KeyPress += NumericOnly;

            txtFax.Validating += TextBoxValidateNotEmpty;
            txtFax.KeyPress += NumericOnly;

            txtHomeTown.Validating += TextBoxValidateNotEmpty;

            FormClosing += PreventClosingFormWithErrorProvider;
        }
        
        private void AddNewSupplier(object sender, EventArgs e)
        {
            if (FormValid(out var errorMessage))
            {
                try
                {
                    var viewModel = new SupplierViewModel
                    {
                        DirectorName = txtDirector.Text.Trim(),
                        Address = txtAddress.Text.Trim(),
                        CompanyName = txtCompany.Text.Trim(),
                        Fax = txtFax.Text.Trim(),
                        Email = txtEmail.Text.Trim(),
                        HomeTown = txtHomeTown.Text.Trim(),
                        Note = txtInformation.Text.Trim(),
                        Phone = txtPhone.Text.Trim(),
                        TaxCode = txtTaxCode.Text.Trim(),
                    };
                    if (_supplierServices.AddNewSupplier(Mapper.Map<SupplierModel>(viewModel)) > 0)
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
                        ErrorMessage("Lỗi!", "Nhà cung cấp này đã tồn tại trong hệ thống!");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    ErrorMessage();
                }
            }
            else
            {
                ErrorMessage(errorMessage);
            }
        }

        private bool FormValid(out string errorMessage)
        {
            errorMessage = string.Empty;
            return ValidEmailAddress(txtEmail.Text.Trim(), out errorMessage);
        }
        
        private void ClearForm()
        {
            txtDirector.Clear();
            txtAddress.Clear();
            txtCompany.Clear();
            txtFax.Clear();
            txtEmail.Clear();
            txtHomeTown.Clear();
            txtInformation.Clear();
            txtPhone.Clear();
            txtTaxCode.Clear();
        }
    }
}
