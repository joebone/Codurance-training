namespace Library.Interfaces {
    public interface IDatetimeProvider {
        DateTime Now { get; }
        DateTime UtcNow { get; }
    }
}
