using CoreProject.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreProject.Entity.Concrete
{
    public class Experience:IEntity
    {
        [Key]
        public int ExprerienceID { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }
    }
}
