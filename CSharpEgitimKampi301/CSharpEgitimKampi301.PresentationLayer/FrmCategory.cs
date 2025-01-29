using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFremawork;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class FrmCategory : Form
    {
        ICategoryService _categoryService;
        public FrmCategory()
        {
            InitializeComponent();
            _categoryService = new CategoryManager(new EfCateforyDal());
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            var categoryValues = _categoryService.TGetAll();
            dataGridView1.DataSource = categoryValues;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            Category category = new Category();
            category.CategoryName = txtCategoryName.Text;
            category.CategoryStatus = true;

            _categoryService.TInsert(category);
            MessageBox.Show("Ekleme başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var resultCategory = _categoryService.TGetById(int.Parse(txtCategoryId.Text));
            _categoryService.TDelete(resultCategory);
            MessageBox.Show("Silme başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var resultCategory = _categoryService.TGetById(int.Parse(txtCategoryId.Text));
            resultCategory.CategoryName = txtCategoryName.Text;
            resultCategory.CategoryStatus = rdbActive.Enabled ? true : false;
            _categoryService.TUpdate(resultCategory);
            MessageBox.Show("Güncelleme başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtCategoryId.Text);
            var values = _categoryService.TGetById(id);
            dataGridView1.DataSource = values;

        }
    }
}
