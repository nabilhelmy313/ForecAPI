using System;

namespace Forces.Dtos
{
    public class MPR
    {
        public string Phone { get; set; }
        public string Description { get; set; }
        public Guid DofQ { get; set; }
        public int QTY { get; set; }
        public double UnitCost { get; set; }
        public string ReasonForPurchase { get; set; }
        public string PackingInstruction{ get; set; }
        public string AddressForDelivery { get; set; }
        public Guid MethodofDelivery { get; set; } = Guid.Empty;

    }
}
