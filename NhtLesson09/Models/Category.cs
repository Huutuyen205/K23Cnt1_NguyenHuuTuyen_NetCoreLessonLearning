using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NhtLesson09.Models
{
    public partial class Category
    {
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Tên danh mục không được để trống")]
        [StringLength(100, ErrorMessage = "Tên danh mục không được vượt quá 100 ký tự")]
        public string CategoryName { get; set; } // bỏ dấu ? để bắt buộc nhập

        public virtual ICollection<Book> Books { get; set; } = new List<Book>();
    }
}
