using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace CreditS.Repository.Entities
{
    [Serializable]
    [Table("TransactionsData")]
    public class TransactionData
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        public int SendingUserId { get; set; }
        public User SendingUser { get; set; }

        [Required]
        public int ReceivingUserId { get; set; }
        public User ReceivingUser { get; set; }

        [Required]
        public float Amount { get; set; }

        [MaxLength(256)]
        public string WishMessage { get; set; }
    }
}
