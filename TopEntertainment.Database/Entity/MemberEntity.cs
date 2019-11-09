using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TopEntertainment.Database.Enum;

namespace TopEntertainment.Database.Entity
{
    public class MemberEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        [Column(TypeName = "int", Order = 0)]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Account { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Password { get; set; }

        [Required]
        [Column(TypeName = "decimal(12,4)")]
        public decimal Integration { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Identity { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Name { get; set; }

        [Required]
        [Column(TypeName = "datetime")]
        public DateTime Birthday { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(10)")]
        public string Phone { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(50)")]
        public string Address { get; set; }

        [Required]
        [Column(TypeName = "smallint")]
        public AccountStatusTypeEnum Status { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Required]
        [Column(TypeName = "datetime")]
        public DateTime UtcUpdateTime { get; set; }

        public List<TransactionRecordEntity> TransactionRecords { get; set; }
    }
}
