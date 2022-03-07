namespace ForecAPI.Dtos.MPR
{
    public class GetMPRsDto
    {
        public Guid Id { get; set; }
        public string Date { get; set; }
        public decimal TotalEstimateCost { get; set; }
        public string MPR_Number { get; set; }
        public string Status { get; set; }
    }
}
