using System;

namespace Arch.Domain.ValueObjects
{
    public class Price
    {
        public decimal Normal { get; set; }
        public decimal Promotional { get; set; }
        public DateTime? PromotionInit { get; set; }
        public DateTime? PromotionLimit { get; set; }
    }
}