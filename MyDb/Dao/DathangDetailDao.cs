using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class DathangDetailDao
    {
        ShopDbContext db = null;
        public DathangDetailDao()
        {
            db = new ShopDbContext();
        }
        public bool Them(DatHangDetail detail)
        {
            try
            {
                db.DatHangDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
