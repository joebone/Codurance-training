using Organizer = AirPNP.Core.Model.User.User;

namespace AirPNP.Core.Model.Party;
public class PartyBookRequest {

    public string Title;
    public Location.Location Location;
    public int Capacity;
    public int ExpectedAttendeeCount;
    public Organizer Organizer;
    public DateTime StartTime;
    public DateTime EndTime;
    public ePartyTheme? PartyTheme;

    public PartyBookRequest(Location.Location location, Organizer organizer) {
        Location = location;
        Organizer = organizer;
    }


}