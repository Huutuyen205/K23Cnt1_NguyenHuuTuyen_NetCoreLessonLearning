using System.ComponentModel.DataAnnotations;

namespace NetCoreMVCLAB5_Day08.Models
{
    public class NhtAccount
    {
        [Key]
        public int NhtId { get; set; }

        [Display(Name = "Họ và tên")]
        [Required(ErrorMessage = "Họ và tên không được để trống")]
        [MinLength(6, ErrorMessage = "Họ và tên ít nhất 6 ký tự")]
        [MaxLength(50, ErrorMessage = "Họ và tên tối đa 50 ký tự")]
        public string NhtFullName { get; set; }

        [Display(Name = "Địa chỉ email")]
        [Required(ErrorMessage = "Email không được để trống")]
        [EmailAddress(ErrorMessage = "Email không đúng định dạng")]
        public string NhtEmail { get; set; }

        [Display(Name = "Số điện thoại")]
        [Required(ErrorMessage = "Số điện thoại không được để trống")]
        [RegularExpression(@"^(0[3|5|7|8|9])+([0-9]{8})$", ErrorMessage = "Số điện thoại không đúng định dạng Việt Nam")]
        public string NhtPhone { get; set; }

        [Display(Name = "Địa chỉ thường trú")]
        [Required(ErrorMessage = "Địa chỉ không được để trống")]
        [StringLength(100, ErrorMessage = "Địa chỉ không vượt quá 100 ký tự")]
        public string NhtAddress { get; set; }

        [Display(Name = "Ảnh đại diện")]
        public string NhtAvatar { get; set; }

        [Display(Name = "Ngày sinh")]
        [Required(ErrorMessage = "Ngày sinh không được để trống")]
        [DataType(DataType.Date)]
        public DateTime NhtBirthday { get; set; }

        [Display(Name = "Giới tính")]
        [Required(ErrorMessage = "Giới tính không được để trống")]
        [RegularExpression("Nam|Nữ", ErrorMessage = "Giới tính chỉ có thể là Nam hoặc Nữ")]
        public string NhtGender { get; set; }

        [Display(Name = "Mật khẩu")]
        [Required(ErrorMessage = "Mật khẩu không được để trống")]
        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "Mật khẩu tối thiểu 6 ký tự")]
        public string NhtPassword { get; set; }

        [Display(Name = "Link Facebook cá nhân")]
        [Required(ErrorMessage = "Link Facebook không được để trống")]
        [Url(ErrorMessage = "URL phải đúng định dạng, bắt đầu bằng http hoặc https")]
        public string NhtFacebook { get; set; }
    }
}
