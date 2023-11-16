using CoreProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Entity.Concrete
{
    public class Service:IEntity
    {
        [Key]
        public int ServiceID { get; set; }
        public string Title { get; set; }
        public string ImageUrl { get; set; }
    }
}
