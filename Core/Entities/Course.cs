using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Course
    {
        [Key]

        private int CourseId;
      

        private string Title;
        private string Description;
        private DateTime StartDate;
        public int MentorId { get; private set; }
        public Mentor Mentor;
        public int CategoryId { get; private set; }
        public Category Category;
        private string CourseImage;
        private int Maxstudents =100;
        
        public ICollection<Enrolledstudent> Enrolledstudents { get; set; } =new List<Enrolledstudent>();


        public int courseid
        {
            get { return CourseId; }
            set { CourseId = value; }
        }
        public string title
        {
            get { return Title; }
            set { Title = value; }
        }

        public string description
        {
            get { return Description; }
            set { Description = value; }
        }
        public DateTime startdate
        {
            get { return StartDate; }
            set { StartDate = value; }
        }
        public string courseimage
        {
            get { return CourseImage; }
            set { CourseImage = value; }
        }
       
        public int maxstudents
        {
            get { return Maxstudents; }
            set { Maxstudents = value; }    
        }

        public Course() { }
        public Course(string title, DateTime date, int mentorId, string courseImage, string description = "")
        {
            Title = title;
            StartDate = date;
            MentorId = mentorId;
            CourseImage = courseImage;
            Description = description;
        }







    }
}
