using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EfProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnList_Click(object sender, EventArgs e)
        {
            /*
             * EgitimKampiEfTravelDbEntities dbfirst yaklaşımı ile otomatik oluşan bir context
             * 
             */
            EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1();
            var values = db.Guides.ToList();  // tolist() -> database'den verileri çekmek için kullanılır.
            dataGridView1.DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                using (EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1())
                {
                    db.Guides.Add(new Guide
                    {
                        Name = txtGuideName.Text,
                        Surname = txtGuideSurname.Text,
                    });
                    db.SaveChanges();
                    MessageBox.Show("Kayıt eklendi.");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Kayıt eklenemedi!!!");
            }
           
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtGuideId.Text);

            try
            {
                using (EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1())
                {
                    var value = db.Guides.Find(id);
                    db.Guides.Remove(value);
                    db.SaveChanges();
                    MessageBox.Show("Kayıt silindi.");
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt eklenemedi!!!");
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                using (EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1())
                {
                    int id = int.Parse(txtGuideId.Text);
                    var value = db.Guides.Find(id);
                    value.Name = txtGuideName.Text;
                    value.Surname = txtGuideSurname.Text;
                    db.SaveChanges();
                    MessageBox.Show("Kayıt güncellendi.","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Kayıt güncellenemedi.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnGetById_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtGuideId.Text);
            EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1();
            var values = db.Guides.Where(x => x.GuideId == id).ToList();
            dataGridView1.DataSource = values;
           
        }
    }
}
