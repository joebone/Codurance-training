using Attendee = AirPNP.Core.Model.User.User;
using Organizer = AirPNP.Core.Model.User.User;

namespace AirPNP.Core.Model.Party;
public record Party(
    Location.Location Location,
    int Capacity,
    List<Attendee> Attendees,
    Organizer Organizer,
    DateTime StartTime,
    DateTime EndTime,
    ePartyTheme? PartyTheme,
    string Title
);