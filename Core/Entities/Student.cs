using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Student:ApplicationUser
    {
        public int StudentId { get; set; }
        public ICollection<BookedCourse> bookedcourses { get; set; } = new List<BookedCourse>();
        public Student(string firstname,string lastname,DateOnly dateofbirth,int studentid) : base(firstname,lastname,dateofbirth) 
        { 
            StudentId = studentid;
        }
        public Student() { }

    }
}
