using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Enrolledstudent
    {
        private int EnrolledStudentId;
        private int StudentId;
        private Student Student;
        private int CourseId;
        private Course Course;
        private DateTime EnrollmentDate;

        [Key]
        public int enrolledstudentid
        {
            get { return EnrolledStudentId; }
            set { EnrolledStudentId = value; }
        }
        [ForeignKey("StudentId")]
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
        [ForeignKey("CourseId")]
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
        public DateTime enrollementdate
        {
            get { return EnrollmentDate; }
            set { EnrollmentDate = value; }
        }

       
    }
}
