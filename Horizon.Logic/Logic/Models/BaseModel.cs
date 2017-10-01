using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.Models
{
    public class BaseModel<TKey>
        where TKey : struct
    {
        public TKey Id { get; set; }
    }
}
