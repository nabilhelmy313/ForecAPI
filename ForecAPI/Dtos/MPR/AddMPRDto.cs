namespace ForecAPI.Dtos.MPR
{
    public class AddMPRDto
    {
        public string? Id { get; set; }
        public DateTime Date  { get; set; }
        public string? Description { get; set; }
        public int QTY { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalEstimateCost { get; set; }
        public string ReasonForPurchase { get; set; }
        public Guid AddressForDelivery { get; set; } // Base id
        public string MethodofDelivery { get; set; } // masteDataCode
        public string? TypeCode { get; set; }//masterdatacode
        public string Status { get; set; } //ACCDCLOG
        public string Feedback { get; set; }
        public byte[]? File { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
        public Guid UserId { get; set; }



    }
}
