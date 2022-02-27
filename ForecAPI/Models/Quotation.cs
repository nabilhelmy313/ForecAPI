namespace ForecAPI.Models
{
    public class Quotation
    {
		public Guid Id { get; set; }
		public string? MPR_Number { get; set; }
		public DateTime Date { get; set; }
		public string? Description { get; set; }
		public int QTY { get; set; }
		public decimal UnitCost { get; set; }
		public decimal Total_Estimate_Cost { get; set; }
		public string? Reason_For_Purchase { get; set; }
		public string? Address_For_Delivery { get; set; }
		public string? Method_of_Delivery { get; set; }
	}
}
