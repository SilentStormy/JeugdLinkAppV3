using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class BookedCourse
    {
        private int BookedCourseId;
        private int StudentId;
        private Student Student;
        private int CourseId;
        private Course Course;
        private DateTime Bookeddate;

        [Key]
        public int bookedcourseid
        {
            get { return BookedCourseId; }
            set { BookedCourseId = value; }
        }
        [ForeignKey("Student")]
        public int studentid
        {
            get { return StudentId; }
            set { StudentId = value; }
        }  
        public Student student
        {
            get { return Student; }
            set { Student = value; }
        }

        [ForeignKey("Course")]
        public int courseid
        {
            get { return CourseId; }
            set { CourseId = value; } 
        }

        public Course course
        {
            get { return Course; }
            set { Course = value; }
        }
        public DateTime bookeddate
        {
            get { return Bookeddate; }
            set { Bookeddate = value; }
        }
      


    }
}
