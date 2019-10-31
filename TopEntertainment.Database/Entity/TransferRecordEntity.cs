using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TopEntertainment.Database.Enum;

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
        [Column(TypeName = "smallint")]
        public TransferTypeEnum Type { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,4)")]
        public decimal Integration { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Note { get; set; }

        [Required]
        [Column(TypeName ="int")]
        public int MemberId { get; set; }

        [Required]
        [Column(TypeName = "int")]
        public int OperatorId { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime UtcUpdateTime { get; set; }

        public MemberEntity Member { get; set; }

        public AdministratorEntity Operator { get; set; }
    }
}
