namespace ForecAPI.Dtos.MPR
{
    public class ReplayDto
    {
        public string Id { get; set; }
        public bool IsAccept { get; set; }
        public bool? IsFinalAccpt { get; set; }
        public string? MPRType { get; set; }
        public string? Feedback { get; set; }

    }
}
