using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class FooterDao
    {
        ShopDbContext db = null;
        public FooterDao()
        {
            db = new ShopDbContext();
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }
    }
}