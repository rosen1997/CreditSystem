using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Entities
{
    [Serializable]
    [Table("Users")]
    public class User
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(64)]
        [Required]
        public string FirstName { get; set; }

        [MaxLength(64)]
        [Required]
        public string LastName { get; set; }

        [MaxLength(9)]
        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public float Credits { get; set; }

        public LoginInfo LoginInfo { get; set; }
    }
}
