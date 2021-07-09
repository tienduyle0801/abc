using MyDb.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class TintucDao
    {
        ShopDbContext db = null;
        public static string USER_SESSION = "USER_SESSION";
        public TintucDao()
        {
            db = new ShopDbContext();
        }

        public IEnumerable<TinTuc> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<TinTuc> model = db.TinTucs;
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        /// <summary>
        /// List all content for client
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public IEnumerable<TinTuc> ListAllPaging(int page, int pageSize)
        {
            IQueryable<TinTuc> model = db.TinTucs;
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public IEnumerable<TinTuc> ListAllByTag(string tag, int page, int pageSize)
        {
            var model = (from a in db.TinTucs
                         join b in db.TinTucTags
                         on a.Id equals b.TinTucId
                         where b.TagId == tag
                         select new
                         {
                             Name = a.Name,
                             MetaTitle = a.MetaTitle,
                             Image = a.Hinh,
                             Description = a.Description,
                             CreatedDate = a.CreatedDate,
                             CreatedBy = a.CreatedBy,
                             ID = a.Id

                         }).AsEnumerable().Select(x => new TinTuc()
                         {
                             Name = x.Name,
                             MetaTitle = x.MetaTitle,
                             Hinh = x.Image,
                             Description = x.Description,
                             CreatedDate = x.CreatedDate,
                             CreatedBy = x.CreatedBy,
                             Id = x.ID
                         });
            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public TinTuc GetById(long id)
        {
            return db.TinTucs.Find(id); 
        }

        public Tag GetTag(string id)
        {
            return db.Tags.Find(id);
        }
    }
}       