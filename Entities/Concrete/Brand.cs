using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Concrete
{
    public class Brand:IEntity //entity'e business code u yazılmaz solidin s kuralına aykırıdır
    {
        public int Id { get; set; }
        public string BrandName { get; set; }
    }
}
