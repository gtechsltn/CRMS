using System;

namespace CRMS.Models
{
    public class CustomerModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public bool? Gender { get; set; }
        public string CCCD { get; set; }
        public string Address { get; set; }
        public DateTime? DoB { get; set; }
        public short? YoB { get; set; }
        public string Email { get; set; }
        public string Facebook { get; set; }
        public string Hobbies { get; set; }
        public string Note { get; set; }
    }
}