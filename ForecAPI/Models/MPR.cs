using ForecAPI.Models.General;

namespace ForecAPI.Models
{
    public class MPR:BaseEntity
    {
		public string MPR_Number { get; set; }
		public DateTime Date { get; set; }
		public string Description { get; set; }
		public int QTY { get; set; }
		public decimal UnitCost { get; set; }
		public decimal Total_Estimate_Cost { get; set; }
		public string Reason_For_Purchase { get; set; }
		public string Address_For_Delivery { get; set; } // Base id
		public string Method_of_Delivery { get; set; } // masterDataCode
        public string? Type_Code{ get; set; }//masterdatacode

        public string Status { get; set; } //ACCDCLOG

        public string? Feedback { get; set; }
        public virtual Base AddressOfDelivery { get; set; }
		public virtual MasterData MPRStatus { get; set; }
		public virtual MasterData MPRMethodofDelivery { get; set; }
		public virtual MasterData MPRType { get; set; }
	}
}
