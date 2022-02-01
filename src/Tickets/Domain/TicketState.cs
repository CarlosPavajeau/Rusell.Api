using System.Text.Json.Serialization;

namespace Rusell.Tickets.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TicketState
{
    Pending,
    Paid
}
