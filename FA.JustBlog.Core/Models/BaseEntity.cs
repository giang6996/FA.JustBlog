using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FA.JustBlog.Core
{
    public class BaseEntity : IBaseEntity
    {
        public BaseEntity()
        {
            
        }

        public int Id { get; set; }

        
    }
}
