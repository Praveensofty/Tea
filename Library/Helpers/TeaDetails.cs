using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

    [Table("teadetails", Schema = "public")]
    public class TeaDetail
    {
        [Key]
        [Column("td_id")]
        public long TeaId { get; set; }

        [Required]
        [Column("td_name", TypeName = "character varying(100)")]
        public string TeaName { get; set; }
    }
