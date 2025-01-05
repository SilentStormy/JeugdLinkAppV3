using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category
    {
        private int CategoryId { get; set; }
        private string Name { get; set; }
        private string Description{ get; set; }

        public int categoryId
        {
            get { return CategoryId; }
            set { CategoryId = value; }
        } 
        public string name
        {
            get { return Name; }
            set { Name = value; }
        } 
        public string description
        {
            get { return Description; }
            set { Description = value; }
        }


    }
}
