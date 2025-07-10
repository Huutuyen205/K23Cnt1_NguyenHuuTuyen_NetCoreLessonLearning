namespace NhtLesson07.Models
{
    public class NhtEmployee
    {
        public int NhtId { get; set; }              // Mã nhân viên
        public string NhtName { get; set; }         // Họ tên
        public DateTime NhtBirthDay { get; set; }   // Ngày sinh
        public string NhtEmail { get; set; }        // Email
        public string NhtPhone { get; set; }        // Số điện thoại
        public decimal NhtSalary { get; set; }      // Lương
        public bool NhtStatus { get; set; }         // Trạng thái (true = đang làm việc, false = nghỉ việc)
    }
}
