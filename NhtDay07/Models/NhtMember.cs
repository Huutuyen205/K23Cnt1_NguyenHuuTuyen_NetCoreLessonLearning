using System.ComponentModel.DataAnnotations;

namespace NhtDay07.Models
{
    public class NhtMember
    {
        public int nhtId { get; set; }

        public string nhtName { get; set; }
        public string nhtUserName { get; set; }

        public string nhtPassword { get; set; }

        public string nhtEmail { get; set; }

        public bool nhtStatus { get; set; }
    }
}