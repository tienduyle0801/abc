using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class MenuDao
    {
        ShopDbContext db = null;
        public MenuDao()
        {
            db = new ShopDbContext();
        }

        public List<Menu> ListByGroupId(int groupId) //lấy id từ trong menu
        {
            return db.Menus.Where(x => x.TypeId == groupId && x.Status == true).OrderBy(x => x.SapXep).ToList();
            // săp xếp tăng dần là menutrên trước rồi đến menuchung
        }
    }
}
