namespace ForecAPI.Models.General
{
    public class MasterData : BaseEntity
    {
        public string Category_Name { get; set; }
        public string Master_Data_Code { get; set; }
        public string MasterData_Parent_Code { get; set; }
        public string  Name { get; set; }
        public virtual ICollection<MPR> MPRStatus { get; set; }
        public virtual ICollection<MPR> MPRType { get; set; }
        public virtual ICollection<MPR> MPRMethodofDelivery { get; set; }


    }
}
