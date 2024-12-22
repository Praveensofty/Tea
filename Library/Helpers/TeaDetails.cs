using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    [Table("TeaDetails", Schema = "public")]
    public class TeaDetail
    {
        [Key]
        [Column("ID")]
        public long TeaId { get; set; }

        [Required]
        [Column("Name", TypeName = "character varying(100)")]
        public string TeaName { get; set; }
    }
