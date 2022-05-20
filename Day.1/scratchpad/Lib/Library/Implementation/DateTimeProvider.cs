using Library.Interfaces;

namespace Library.Implementation;

public class DateTimeProvider : IDatetimeProvider {
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}
