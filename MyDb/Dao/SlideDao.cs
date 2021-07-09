using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class SlideDao
    {
        ShopDbContext db = null;
        public SlideDao()
        {
            db = new ShopDbContext();
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.SapXep).ToList();
        }
    }
}
