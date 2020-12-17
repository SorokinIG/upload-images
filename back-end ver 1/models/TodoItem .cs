using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace back_end_ver_1.models
{
    public class TodoItem
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Author { get; set; }
        public byte[] Image { get; set; }
    }
}
