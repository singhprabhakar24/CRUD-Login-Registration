using System.ComponentModel.DataAnnotations;

namespace API_FINAL.Models
{
    public class Registration
    {
        public int id { get; set; }


        public int userid {  get; set; }

        [Required]
        public string fname { get; set; }

        [Required]
        public string lname {  get; set; }

        [EmailAddress]
        public string email {  get; set; }

        [Required]
        public string city { get; set; }
    }
}
