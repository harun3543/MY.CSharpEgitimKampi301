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
    public partial class FrmLocation : Form
    {
        public FrmLocation()
        {
            InitializeComponent();
            this.Load += FrmLocation_Load;
        }

        EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1();

        private void FrmLocation_Load(object sender, EventArgs e)
        {
            //var values = db.Guides.ToList();
            // Aşağıdaki select Linq sorgusu ile Fullname isminde yeni bir variable oluşturup
            // guide tablosundaki "Name" "Surname" değikenlerini birleştirmiş olduk
            // Ardından combobax aracına bu "Fullname" değişkenini verdik.
            // tamamen combobox'ın "DisplayMember" ı doldurmak için yapılmıştır
            var values = db.Guides.Select(x=> new
            {
                Fullname = x.Name + " " + x.Surname,
                x.GuideId
            }).ToList();

            cmbGuide.DisplayMember = "Fullname";
            cmbGuide.ValueMember = "GuideId";
            cmbGuide.DataSource = values;
        }

        
        private void btnList_Click(object sender, EventArgs e)
        {
            var values = db.Locations.ToList();
            dataGridView1 .DataSource = values;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            db.Locations.Add(new Location
            {
                City = txtCity.Text,
                Country = txtCountry.Text,
                Capacity = byte.Parse(nudCapacity.Value.ToString()),
                Price = decimal.Parse(txtPrice.Text),
                DayNight = txtDayNight.Text,
                GuideId = int.Parse(cmbGuide.SelectedValue.ToString())
            });
            db.SaveChanges();
            MessageBox.Show("Kayıt ekleme başarılı...","Uyarı",MessageBoxButtons.OK,MessageBoxIcon.Warning);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtLocationId.Text);
            var values = db.Locations.Find(id);
            db.Locations.Remove(values);
            db.SaveChanges();
            MessageBox.Show("Kayıt silme başarılı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            var id = int.Parse(txtLocationId.Text);
            var values = db.Locations.Find(id);
            values.City = txtCity.Text;
            values.Country = txtCountry.Text;
            values.Capacity =byte.Parse(nudCapacity.Value.ToString());
            values.Price = decimal.Parse(txtPrice.Text);
            values.DayNight = txtDayNight.Text;
            values.GuideId = int.Parse(cmbGuide.SelectedValue.ToString());
            db.SaveChanges();
            MessageBox.Show("Kayıt güncelleme başarılı...", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }
    }
}
