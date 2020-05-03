using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ERPProject.Entity
{
    public class Article
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public Unit Unit { get; set; }
        public int Amount { get; set; }
    }
}
