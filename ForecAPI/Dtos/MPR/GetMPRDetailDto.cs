namespace ForecAPI.Dtos.MPR
{
    public class GetMPRDetailDto
    {
        public string MPRNumber { get; set; }
        public string Date { get; set; }
        public string? Description { get; set; }
        public int QTY { get; set; }
        public decimal UnitCost { get; set; }
        public decimal TotalEstimateCost { get; set; }
        public string ReasonForPurchase { get; set; }
        public string AddressForDelivery { get; set; } // Base id
        public string MethodofDelivery { get; set; } // masteDataCode
        public string Type { get; set; }//masterdatacode
        public string Status { get; set; } //ACCDCLOG
        public string Feedback { get; set; }
        public string Filepath { get; set; }
    }
}
