namespace AirPNP.Core.Model.Location {
    public class LocationRestrictions {
        public int MinAge;
        public int MaxAge;

        public bool AllowsAlcohol;
        public bool MinOccupants;
        public bool MaxOccupants;

        public ePartyTheme? PartyThemeWhitelist;
    }
}