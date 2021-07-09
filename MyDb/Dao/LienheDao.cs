using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class LienheDao
    {
        ShopDbContext db = null;
        public LienheDao()
        {
            db = new ShopDbContext();
        }
        public LienHe GetLH()
        {
            return db.LienHes.Single(x => x.Status == true);
        }
        public int ThemPH(PhanHoi ph)    //Thêm phản hồi từ khách hàng
        {
            db.PhanHois.Add(ph);
            db.SaveChanges();
            return ph.Id;
        }
    }
}
