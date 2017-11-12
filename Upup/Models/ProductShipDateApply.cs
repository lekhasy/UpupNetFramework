using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Upup.Models
{
    public class ProductShipDateApply
    {
        [Key, Column(Order = 0)]
        public int ShipDateSettingID { get; set; }
        [Key, Column(Order = 1)]
        public int ProductVariantID { get; set; }
    }
}