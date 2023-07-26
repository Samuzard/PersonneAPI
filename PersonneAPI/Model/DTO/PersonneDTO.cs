using System.ComponentModel.DataAnnotations;

namespace PersonneAPI.Model.DTO
{
    public class PersonneDTO
    {
        [Required]
        [MaxLength(100)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(100)]
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int Age { get; set; }
    }
}
