namespace AirPNP.Core.Actions;
public class ProvideLocationForParty {
    public ProvideLocationForParty(
        UserAccountService userAccount,
        LocationService locationService
        ) {
    }

    public void Execute(User user, Location location, DateTime[] availableTimes, LocationRestrictions conditions) {
    }
}