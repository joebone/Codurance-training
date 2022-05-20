namespace AirPNP.Core.Model.User {
    public class UserAccountService {
        private readonly UserRepository userRepository;

        public UserAccountService(UserRepository userRepository) {
            this.userRepository = userRepository;
        }

        public bool HasBalance() => true;
        public bool IsAntiSocial() => true;
    }
}