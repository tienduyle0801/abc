using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class DanhmucDao
    {
  
       ShopDbContext db = null;
        public DanhmucDao()
        {
            db = new ShopDbContext();
        }
        public long Them(DanhMuc danhmuc)
        {
            db.DanhMucs.Add(danhmuc);
            db.SaveChanges();
            return danhmuc.Id;
        }
        public List<DanhMuc> ListAll()
        {
            return db.DanhMucs.Where(x => x.Status == true).ToList();
        }
        public DanhMucSanPham ViewDetail(long dmid)
        {
            return db.DanhMucSanPhams.Find(dmid);
        }
    }
}

