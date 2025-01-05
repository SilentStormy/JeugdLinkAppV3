using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Entities
{
    public class Mentor
    {
        [Key]
        private int MentorId { get; set; }
        private string Name { get; set; }
        private string Email { get; set; }
        private string Specialization { get; set; }
        private bool Availability { get; set; }

        public int mentorid
        {
            get { return MentorId; }
            set { MentorId = value; }
        } 
        public string name
        {
            get { return Name; }
            set { Name = value; }
        }
        public string email
        {
            get { return Email; }
            set { Email = value; }
        } 
        public string specialization
        {
            get { return Specialization; }
            set { Specialization = value; }
        } 
        public bool availability
        {
            get { return Availability; }
            set { Availability = value; }
        }
    }
}
