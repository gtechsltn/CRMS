using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace CRMS.Models
{
    public class CustomerModel
    {
        [DisplayName("Mã")]
        public int Id { get; set; }

        [DisplayName("Họ và tên")]
        [Required(ErrorMessage = "Trường Họ tên là bắt buộc phải nhập")]
        public string Name { get; set; }

        [DisplayName("Số điện thoại")]
        public string PhoneNumber { get; set; }

        [DisplayName("Giới tính")]
        public bool? Gender { get; set; }

        [DisplayName("Giới tính")]
        public string Gender2 { get; set; }

        [DisplayName("Căn cước công dân")]
        public string CCCD { get; set; }

        [DisplayName("Địa chỉ liên hệ")]
        public string Address { get; set; }

        public DateTime? DoB { get; set; }

        [DisplayName("Ngày sinh")]
        public string DoB2 { get; set; }

        [DisplayName("Năm sinh")]
        [Range(1900, 9999, ErrorMessage = "Trường Năm sinh phải là số và nằm trong khoảng {1} và {2}")]
        [RegularExpression("([0-9]+)", ErrorMessage = "Trường Năm sinh phải là số")]
        public short? YoB { get; set; }

        [DisplayName("Thư điện tử")]
        [EmailAddress(ErrorMessage = "Trường Thư điện tử không đúng định dạng")]
        public string Email { get; set; }

        [DisplayName("Facebook")]
        public string Facebook { get; set; }

        [DisplayName("Sở thích")]
        public string Hobbies { get; set; }

        [AllowHtml]
        [DisplayName("Ghi chú")]
        public string Note { get; set; }
    }
}