﻿using AutoMapper;
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
    public partial class AddSupplier : BaseMethod
    {
        #region Constructor, Properties
        private readonly ISupplierServices supplierServices;
        public AddSupplier(ISupplierServices supplierServices)
        {
            InitializeComponent();
            this.CenterToParent();
            this.supplierServices = supplierServices;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            txtCompany.Validating += new CancelEventHandler(this.TextBoxValidateNotEmpty);

            txtDirector.Validating += new CancelEventHandler(this.TextBoxValidateNotEmpty);

            txtAddress.Validating += new CancelEventHandler(this.TextBoxValidateNotEmpty);

            txtTaxCode.Validating += new CancelEventHandler(this.TextBoxValidateNotEmpty);
            txtTaxCode.KeyPress += new KeyPressEventHandler(this.NumericOnly);

            txtPhone.Validating += new CancelEventHandler(this.TextBoxValidateNotEmpty);
            txtPhone.KeyPress += new KeyPressEventHandler(this.NumericOnly);

            txtFax.Validating += new CancelEventHandler(this.TextBoxValidateNotEmpty);
            txtFax.KeyPress += new KeyPressEventHandler(this.NumericOnly);

            txtHomeTown.Validating += new CancelEventHandler(this.TextBoxValidateNotEmpty);

            this.FormClosing += new FormClosingEventHandler(this.PreventClosingFormWithErrorProvider);
        }
        #endregion

        #region Control Event
        private void AddNewSupplier(object sender, EventArgs e)
        {
            string errorMessage = string.Empty;
            if (FormValid(out errorMessage))
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
                    if (this.supplierServices.AddSupplier(Mapper.Map<SupplierModel>(viewModel)))
                    {
                        if (this.YesNoDialog("Thành Công!", "Bạn có muốn tiếp tục không ?") == DialogResult.Yes)
                        {
                            this.ClearForm();
                        }
                        else
                        {
                            this.Close();
                        }
                    }
                    else
                    {
                        this.ErrorMessage("Lỗi!", "Nhà cung cấp này đã tồn tại trong hệ thống!");
                    }
                }
                catch (Exception ex)
                {
                    _logger.Error(ex.Message);
                    this.ErrorMessage();
                }
            }
            else
            {
                this.ShowMessage(errorMessage);
            }
        }
        #endregion

        #region Private Method
        private bool FormValid(out string errorMessage)
        {
            errorMessage = string.Empty;
            if (!ValidEmailAddress(txtEmail.Text.Trim(), out errorMessage))
                return false;
            return true;
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
        #endregion
    }
}