using AirPNP.Core.Model.Legal;

namespace AirPNP.Core.Model.Location {
    public class LocationPriceCalculationService {
        private readonly LocalTaxService taxService;

        public LocationPriceCalculationService(LocalTaxService taxService) {
            this.taxService = taxService;
        }

        public decimal CalculatePrice(Location location) => throw new NotImplementedException();

    }
}