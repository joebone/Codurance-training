namespace AirPNP.Core.Model.User;
public record User(
    Guid UserId,
    string DisplayName,
    int BeersDrunkButNotPaidFor,
    decimal EuroBalance,
    bool Banned,

    eUserType UserType
);
