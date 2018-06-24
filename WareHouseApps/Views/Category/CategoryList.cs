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
    public partial class CategoryList : BaseMethod
    {
        private readonly ICategoryServices categoryServices;
        private IList<CategoryViewModel> categoryList;
        private CategoryViewModel selectedCategory;
        public CategoryList(ICategoryServices categoryServices)
        {
            this.categoryServices = categoryServices;
            InitializeComponent();
            this.CenterToParent();
        }

        #region Form Event
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LoadData();
        }
        #endregion

        #region Private Method
        private void LoadData()
        {
            var result = categoryServices.GetCategories();
            if (result != null)
            {
                categoryList = result.ToList()
                    .Select(c => Mapper.Map<CategoryModel, CategoryViewModel>(c)).OrderBy(c => c.Code).ToList();
            }
            categoryViewModelBindingSource.DataSource = categoryList;
        }

        private void ClearForm()
        {
            txtCode.Clear();
            txtName.Clear();
        }
        #endregion

        #region Control Event
        private void AddNewCategory(object sender, EventArgs e)
        {
            if (YesNoDialog() == DialogResult.Yes)
            {
                var model = new CategoryModel()
                {
                    Code = txtCode.Text.Trim(),
                    Name = txtName.Text.Trim()
                };
                if (!categoryServices.CheckDuplicateCategory(model.Name))
                {
                    if (categoryServices.AddCategory(model))
                    {
                        LoadData();
                        SuccessMessage();
                        ClearForm();
                    }
                    else
                    {
                        ErrorMessage();
                    }
                }
                else
                {
                    ErrorMessage("Lỗi!", "Danh mục này đã tồn tại trong hệ thống!");
                }
            }
        }

        private void UpdateCategoryContent(object sender, EventArgs e)
        {
            if (YesNoDialog() == DialogResult.Yes)
            {
                if (!categoryServices.CheckDuplicateCategory(txtName.Text.Trim()))
                {
                    var model = categoryServices.GetCategoryById(selectedCategory.Id);
                    if (model != null)
                    {
                        model.Name = txtName.Text.Trim();
                        model.Code = txtCode.Text.Trim();

                        if (categoryServices.UpdateCategory(model))
                        {
                            LoadData();
                            SuccessMessage();
                        }
                        else
                        {
                            ErrorMessage();
                        }
                    }
                    else
                    {
                        ErrorMessage();
                    }
                }
                else
                {
                    ErrorMessage("Lỗi!", "Danh mục này đã tồn tại trong hệ thống!");
                }
            }
        }

        private void GeneratedCategoryCode(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtName.Text.Trim()))
            {
                string userName = string.Empty;
                var splitNameResult = txtName.Text.Trim().Split();
                if (splitNameResult.Count() > 1)
                {
                    int lenght = splitNameResult.Count();
                    for (int i = 0; i <= lenght - 1; i++)
                    {
                        userName += splitNameResult[i][0];
                    }
                    txtCode.Text = StringHelper.RemoveDiacritics(userName);
                }
            }
        }

        private void GetCategoryDetails(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                selectedCategory = categoryList[e.RowIndex];
                txtName.Text = selectedCategory.Name;
                txtCode.Text = selectedCategory.Code;
            }
        }
        #endregion
    }
}
