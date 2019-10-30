using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TopEntertainment.Database.Entity
{
    public class TransferRecordEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(TypeName = "int", Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string TransactionId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int Amount { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int GiverId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int ReceiverId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int OperatorID { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime UtcUpdateTime { get; set; }

        public MemberEntity Giver { get; set; }

        public MemberEntity Receiver { get; set; }

        public AdministratorEntity Operator { get; set; }
    }
}
