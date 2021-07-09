using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class DanhmucSanphamDao
    {
        ShopDbContext db = null;
        public DanhmucSanphamDao()
        {
            db = new ShopDbContext();
        }

        public List<DanhMucSanPham> ListAll()
        {
            return db.DanhMucSanPhams.Where(x => x.Status == true).OrderBy(x => x.SapXep).ToList();
        }

        public DanhMucSanPham ViewDetail(long id)
        {
            return db.DanhMucSanPhams.Find(id);
        }
    }
}