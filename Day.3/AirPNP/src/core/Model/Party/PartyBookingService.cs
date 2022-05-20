namespace AirPNP.Core.Model.Party;
public class PartyBookingService {

    public PartyBookingService(
        LocationPriceCalculationService priceCalculationService,
        Legal.LocalLawsService localLawsService,
        LocationService locationService) {
    }
    public BookPartyResult BookParty(PartyBookRequest request) => throw new NotImplementedException();
}
