using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WareHouseApps.Models;

namespace WareHouseApps.Helper
{
    public class BaseMethod : Form
    {
        private ErrorProvider errorTextBox;
        private IContainer components;
        protected BindingSource mainBindingSource;
        public readonly log4net.ILog _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        public BaseMethod()
        {
            InitializeComponent();
            this.Icon = Properties.Resources.icon128x128;
        }

        #region Message Box Event
        public void ShowMessage(string message)
        {
            MessageBox.Show(message);
        }

        public void ErrorMessage(string title = "Lỗi!",
            string message = "Đã có lỗi xảy ra. Vui lòng thử lại.")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SuccessMessage(string title = "Thành Công!",
            string message = "Tác vụ thực hiện thành công.")
        {
            MessageBox.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public DialogResult YesNoDialog(string title = "Xác Nhận!",
            string message = "Bạn có muốn thực hiện tác vụ này ?")
        {
            return MessageBox.Show(message, title, MessageBoxButtons.YesNo);
        }
        #endregion

        #region Event Args
        public void TextBoxValidateNotEmpty(object sender, CancelEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            if (string.IsNullOrEmpty(textBox.Text.Trim()))
            {
                errorTextBox.SetError(textBox, "Thông tin bắt buộc!");
                e.Cancel = true;
            }
            else
            {
                errorTextBox.SetError(textBox, string.Empty);
            }
        }

        public void NumericOnly(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

            //// only allow one decimal point
            //if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            //{
            //    e.Handled = true;
            //}
        }

        public bool ValidEmailAddress(string emailAddress, out string errorMessage)
        {
            //if (emailAddress.Length == 0)
            //{
            //    errorMessage = "e-mail address is required.";
            //    return false;
            //}
            errorMessage = string.Empty;
            if (!string.IsNullOrEmpty(emailAddress))
            {
                if (emailAddress.IndexOf("@") > -1)
                {
                    if (emailAddress.IndexOf(".", emailAddress.IndexOf("@")) > emailAddress.IndexOf("@"))
                    {
                        return true;
                    }
                }

                errorMessage = "Địa chỉ Email không chính xác. Vui lòng điền lại Email.\n" +
                   "Ví dụ: 'someone@example.com' ";
                return false;
            }
            return true;
        }

        public void PreventClosingFormWithErrorProvider(object sender, FormClosingEventArgs e)
        {
            e.Cancel = false;
        }
        #endregion

        public void SetCurrentPrincipal(UserViewModel userModel)
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal myUser = (WindowsPrincipal)Thread.CurrentPrincipal;
            GenericIdentity userIdentity = new GenericIdentity(string.Empty);

            GenericPrincipal customPrincipal =
                new GenericPrincipal(userIdentity, new string[] { string.Empty });
            Thread.CurrentPrincipal = customPrincipal;
        }

        #region Private Method
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.errorTextBox = new System.Windows.Forms.ErrorProvider(this.components);
            this.mainBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // errorTextBox
            // 
            this.errorTextBox.ContainerControl = this;
            // 
            // BaseMethod
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "BaseMethod";
            ((System.ComponentModel.ISupportInitialize)(this.errorTextBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mainBindingSource)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion
    }
}
