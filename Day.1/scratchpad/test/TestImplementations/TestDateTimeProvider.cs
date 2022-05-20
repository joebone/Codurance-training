using Library.Interfaces;

namespace Tests.TestImplementations;
public class TestDateTimeProvider : IDatetimeProvider {
    private DateTime? _dateTime;
    public TestDateTimeProvider() {
        _dateTime = null;
    }

    public TestDateTimeProvider(DateTime value) {
        _dateTime = value;
    }

    public DateTime Now => (_dateTime ?? DateTime.Now).ToLocalTime();
    public DateTime UtcNow => (_dateTime ?? DateTime.Now).ToUniversalTime();
}
