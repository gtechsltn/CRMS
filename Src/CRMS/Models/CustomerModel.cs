using System;
using System.ComponentModel;

namespace CRMS.Models
{
    public class CustomerModel
    {
        [DisplayName("Mã")]
        public int Id { get; set; }

        [DisplayName("Họ tên")]
        public string Name { get; set; }

        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [DisplayName("Giới tính")]
        public bool? Gender { get; set; }

        [DisplayName("Căn cước công dân")]
        public string CCCD { get; set; }

        [DisplayName("Địa chỉ")]
        public string Address { get; set; }

        [DisplayName("Ngày sinh")]
        public DateTime? DoB { get; set; }

        [DisplayName("Năm sinh")]
        public short? YoB { get; set; }

        [DisplayName("Thư điện tử")]
        public string Email { get; set; }

        [DisplayName("Facebook")]
        public string Facebook { get; set; }

        [DisplayName("Sở thích")]
        public string Hobbies { get; set; }

        [DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}