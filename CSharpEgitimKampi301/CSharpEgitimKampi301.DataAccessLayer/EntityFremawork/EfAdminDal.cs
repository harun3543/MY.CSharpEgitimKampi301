using CSharpEgitimKampi301.DataAccessLayer.Abstract;
using CSharpEgitimKampi301.DataAccessLayer.Repositories;
using CSharpEgitimKampi301.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpEgitimKampi301.DataAccessLayer.EntityFremawork
{
    /*
     * IAdminDal implementasyonu; daha sonra Admin entity'sine özgü bir method yazabiliriz. Bu 
     * entity'e özgü methodları IAdminDal içerisine yazarız.
     * Örneğin son üç Admin'i getir gibi entity'e özgü methodlar.
     */

    // Örneğin Insert,Update ve Delete bütün entity'leri kapsadığı için GenericDal'a eklenir.
    public class EfAdminDal : GenericRepositories<Admin>, IAdminDal
    {

    }
}
