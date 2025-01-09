namespace ProiectAutoCore.Models
{
    public class ServiceHistory
    {
        public int ServiceHistoryId { get; set; }
        public int CarId { get; set; }
        public int ServiceId { get; set; }
        public DateTime Date { get; set; }
        public string Notes { get; set; } = string.Empty;
        public Car Car { get; set; } = null!;
        public Service Service { get; set; } = null!;
    }

}
