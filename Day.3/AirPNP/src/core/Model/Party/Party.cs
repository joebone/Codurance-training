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