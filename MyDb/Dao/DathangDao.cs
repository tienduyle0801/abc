using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
   public class DathangDao
    {
        ShopDbContext db = null;
        public DathangDao()
        {
            db = new ShopDbContext();
        }
         public long Them(DatHang dathang)
        {
            db.DatHangs.Add(dathang);
            db.SaveChanges();
            return dathang.Id;
        }
    }
}
