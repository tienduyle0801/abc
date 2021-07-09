using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class SanphamDao
    {
        ShopDbContext db = null;
        public SanphamDao()
        {
            db = new ShopDbContext();
        }
        /// <summary>
        /// sp new
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<SanPham> ListNewSanpham(int top)  //sản phẩm mới
        {
            return db.SanPhams.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        /// <summary>
        /// sp hot
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        public List<SanPham> ListHotSanpham(int top) //sản phẩm hot
        {
            return db.SanPhams.Where(x => x.Topsp != null && x.Topsp > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        /// <summary>
        /// sp hiện tại
        /// </summary>
        /// <param name="spId"></param>
        /// <returns></returns>
        public List<SanPham> ListHotSanphams(long spId) //sp hiện tại
        {
            var sp = db.SanPhams.Find(spId);
            return db.SanPhams.Where(x => x.Id != spId && x.DanhmucId == sp.DanhmucId).ToList();
        }
        /// <summary>
        /// get listByDanhmucId
        /// </summary>
        /// <param name="dmId"></param>
        /// <returns></returns>
        public List<SanPham> ListByDanhmucId(long dmId,ref int totalTong, int pageIndex = 1, int pageSize = 2)  //phân trang cho sản phẩm
        {
            totalTong = db.SanPhams.Where(x => x.DanhmucId == dmId).Count();
            var model = db.SanPhams.Where(x => x.DanhmucId == dmId).OrderByDescending(x=>x.CreatedDate).Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            return model;
        }
        public SanPham ViewDetail(long spid)
        {
            return db.SanPhams.Find(spid);
        }
    }
}