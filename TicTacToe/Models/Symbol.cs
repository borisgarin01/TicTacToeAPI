using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicTacToe.Models
{
    public record Symbol
    {
        [Key]
        public long Id { get; set; }
        [Required(ErrorMessage = "Symbol text is required")]
        [MaxLength(1, ErrorMessage = "Symbol should be single")]
        [MinLength(1, ErrorMessage = "Symbol should be single")]
        [Column("symbol")]
        public string Text { get; set; }
        [Range(1, 3, ErrorMessage = "X in invalid range")]
        [Column("x_coord")]
        public short X { get; set; }
        [Range(1, 3, ErrorMessage = "Y in invalid range")]
        [Column("y_coord")]
        public short Y { get; set; }
        [Column("is_placed")]
        public bool IsPlaced { get; set; } = false;
    }
}