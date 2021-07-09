using MyDb.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fashion.Models
{    
    [Serializable]
    public class GiohangItem
    {
        public SanPham SanPham { set; get; }
        public int Soluong { set; get; }
       
    }
}