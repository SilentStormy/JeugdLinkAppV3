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

        private int CourseId { get; set; }
        [Required]
        
        private string Title { get; set; }
        private string Description { get; set; }
        private DateTime Date { get; set; }
        private int MentorId { get; set; }
        public Mentor Mentor { get; set; }  
        private int CategoryId { get; set; }
        public Category Category { get; set; }
        private string CourseImage { get; set; }

        [Range(1,1000,ErrorMessage ="Prijs moet tussen 1 en 1000eur zijn")]
        private double CoursePrice { get;set; }
       

        public Course() { }
        public Course(string title, DateTime date, int mentorId, string courseImage, string description="")
        {
            Title = title;
            Date = date;
            MentorId = mentorId;
            CourseImage = courseImage;
            Description = description;
        }
        public int courseId
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
        
        public DateTime date
        {
            get { return Date; }
            set { Date = value; }
        } 
        public string courseimage
        {
            get { return CourseImage; }
            set { CourseImage = value; }
        }

        public int categoryid
        {
            get { return CategoryId; }
            set { CategoryId = value; }
        }  
        public int mentorid
        {
            get { return MentorId; }
            set { MentorId = value; }
        } 
        
        public double courseprice
        {
            get { return CoursePrice; }
            set { CoursePrice = value; }
        }
      


    }
}
