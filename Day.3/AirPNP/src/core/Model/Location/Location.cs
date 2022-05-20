namespace AirPNP.Core.Model.Location;
public record Location(

    // restrictions
    int Capacity,
    int MininumAge,

    //characteristics
    GeoLocation PartyLocation,

    LocationCost CostPerHour,

    LocationProvider owner,

    LocationRestrictions restrictions
);

public record LocationCost(decimal? StaticFee, decimal? PricePerPerson);

public record GeoLocation(double Longitude, double Latitude);