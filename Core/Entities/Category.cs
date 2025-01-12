using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Category
    {
        private int CategoryId;
        private string Name;
        private string Description;
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
