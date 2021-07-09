using MyDb.Entity;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyDb.Dao
{
    public class UserDao
    {
        ShopDbContext db = null;
        public UserDao()
        {
            db = new ShopDbContext();
        }

        public long Them(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.Id;
        }
        public long ThemForFb(User entity)
        {
            var user = db.Users.SingleOrDefault(x => x.UserName == entity.UserName);
            if (user == null)
            {
                db.Users.Add(entity);
                db.SaveChanges();
                return entity.Id;
            }
            else
            {
                return user.Id;
            }

        }

        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.Id);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.DiaChi = entity.DiaChi;
                user.Email = entity.Email;
                user.Sdt = entity.Sdt;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }

        }

        public object Login(string userName, object mahoa)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            IQueryable<User> model = db.Users.Where(x=> x.UserName != "admin");
            if (!string.IsNullOrEmpty(searchString))
            {
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString));
            }

            return model.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }

        public int Login(string userName, string password)
        {
            var kiemtra = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (kiemtra == null)
            {
                return 0;
            }
            else
            {
                if (kiemtra.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (kiemtra.Password == password)
                        return 1;
                    else
                        return -2;
                }
            }
        }
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool ktUserName(string userName)   //kiểm tra User có trùng ko
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool ktEmail(string email)  //Tương tự kiểm tra Email
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}



