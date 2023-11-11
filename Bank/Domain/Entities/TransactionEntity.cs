using Api.Domain.Entities;

namespace Bank.Domain.Entities
{
    public class TransactionEntity : BaseEntity
    {
        public string? Description { get; set; }
        public DateTime Date { get; set; }
        public double Value { get; set; }
        public bool Doubtful { get; set; }
        public  Status Status { get; set; }
    }
}

public enum Status
{
    Valid = 1,
    Canceled = 2
}
