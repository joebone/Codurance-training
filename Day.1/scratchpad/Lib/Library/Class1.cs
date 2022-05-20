using Library.Interfaces;

namespace Library {
    public class ClassToBeTested {
        private readonly IDatetimeProvider datetimeProvider;

        public DateTime Now => datetimeProvider.Now;

        public ClassToBeTested(IDatetimeProvider datetimeProvider) {
            DateTime g = DateTime.UtcNow;
            Enumerable.Range(0, 1).Count();
            this.datetimeProvider = datetimeProvider;
        }
    }
}