using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CSharpEgitimKampi301.EfProject
{
    public partial class FrmStatistics : Form
    {
        public FrmStatistics()
        {
            InitializeComponent();
        }

        EgitimKampiEfTravelDbEntities1 db = new EgitimKampiEfTravelDbEntities1();
        private void FrmStatistics_Load(object sender, EventArgs e)
        {
            // Toplam lokasyon sayısı
            lblLocationCount.Text = db.Locations.Count().ToString();

            // Toplam kapasite
            lblTotalCapacity.Text = db.Locations.Sum(x=> x.Capacity).ToString();
           
            // Rehber sayısı
            lblGuideCount.Text = db.Guides.Count().ToString();

            // Ortalama Kapasite
            lblAvgCapacity.Text = db.Locations.Average(x=> x.Capacity).ToString();

            // Ortalama Tur Fiyatı
            lblAvgLocationPrice.Text = db.Locations.Average(x=> x.Price).ToString();

            // Eklenen son ülke
            var lastCountryNameId = db.Locations.Max(x=> x.GuideId);
            lblLastCaountryName.Text = db.Locations.Where(x => x.LocationId == lastCountryNameId).Select(x=> x.City).ToString();

            // Kapadokya tur kapasitesi
            lblCapadociaLocationCapacity.Text = db.Locations.Where(x => x.City == "Kapadokya").Select(x=> x.Capacity).FirstOrDefault().ToString();

            // Türkiye turları ortalama kapasitesi
            lblTurkiyeLocationAvgCapacity.Text = db.Locations.Where(x=> x.Country == "Türkiye").Average(x => x.Capacity).ToString();

            // Roma gezi rehberi adı soyadı
            var romeGuideNameId = db.Locations.Where(x=> x.City == "Rome").Select(x=> x.GuideId).FirstOrDefault();
            lblRomeGuideName.Text = db.Guides.Where(x=> x.GuideId == romeGuideNameId).Select(y=> y.Name + " " + y.Surname).ToString();

            // en yüksek kapasiteli tur
            var maxLocationCapacityId = db.Locations.Max(x => x.Capacity);
            lblLocationMaxCapacity.Text = db.Locations.Where(x=> x.Capacity == maxLocationCapacityId).Select(y=> y.City).FirstOrDefault().ToString();

            // en pahalı tur
            var maxLocationPriceId = db.Locations.Max(x => x.Price);
            lblLocationMaxPrice.Text = db.Locations.Where(y=> y.Price == maxLocationPriceId).Select(z=> z.City).FirstOrDefault().ToString();

            // Ayşegül Çınar'ın toplam tur sayısı
            var guideIdByNameAysegulCinar = db.Guides.Where(x=> x.Name == "Ayşegül" &&  x.Surname =="Çınar").Select(y=> y.GuideId).FirstOrDefault();
            lblAysegulCinarLocationCount.Text = db.Locations.Where(x=>x.GuideId == guideIdByNameAysegulCinar).Count().ToString();
        }

    
    }
}
