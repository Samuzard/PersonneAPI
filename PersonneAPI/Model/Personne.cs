using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PersonneAPI.Model
{
    public class Personne
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string FirstName { get;set; }
        public string LastName { get;set; }
        public DateTime BirthDay { get;set; }
        public DateTime CreateDate { get;set; }
        public DateTime UpdateDate { get;set;}
    }
}
