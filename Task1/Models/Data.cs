using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Task1.Models
{
    public class Data
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)] //設定流水編號
        public int Id { get; set; }

        [StringLength(50), Required]   //Required 該欄位非null值
        public string Context { get; set; }
    }
}