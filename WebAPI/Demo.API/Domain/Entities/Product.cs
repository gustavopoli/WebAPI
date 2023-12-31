using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Demo.API.Domain.Entities
{
    [Table("product")]
    public record Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int Id { get; init; }

        [Column("product_name")]
        [MaxLength(100)]
        public string? ProductName { get; init; }

        [Column("product_code")]
        [MaxLength(10)]
        public string? ProductCode { get; init; }

        [Column("price", TypeName = "decimal(7,2)")]
        public decimal? Price { get; init; }
    }
}
