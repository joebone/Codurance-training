namespace AirPNP.Core.Actions;
public class BookLocationForParty {
    public BookLocationForParty(
        PartyBookingService partyBookingService,
        UserAccountService userAccount,
        LocationPriceCalculationService priceCalculationService) {
    }

    public Party Execute(User user, PartyBookRequest partyBookRequest) {
        throw new NotImplementedException();
    }
}