using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SimplePhoneBook.Models
{
    public class PhoneBook
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [Display(Name="Name")]
        public string Name { get; set; }

        [ForeignKey("Entry_Id")]
        public virtual Entry Entries { get; set; }
    }
}
