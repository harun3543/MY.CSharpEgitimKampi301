using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CSharpEgitimKampi301.BusinessLayer.Abstract;
using CSharpEgitimKampi301.BusinessLayer.Concrete;
using CSharpEgitimKampi301.DataAccessLayer.EntityFremawork;
using CSharpEgitimKampi301.EntityLayer.Concrete;

namespace CSharpEgitimKampi301.PresentationLayer
{
    public partial class Form1 : Form
    {
        /*
         * Category tablo işlemleri yapılacak
         */

        ICategoryService _categoryService;
        public Form1()
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
            MessageBox.Show("Silme başarılı","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var resultCategory = _categoryService.TGetById(int.Parse(txtCategoryId.Text));
            resultCategory.CategoryName = txtCategoryName.Text;
            resultCategory.CategoryStatus = rdbActive.Enabled ? true : false;
            _categoryService.TUpdate(resultCategory);
            MessageBox.Show("Güncelleme başarılı", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
