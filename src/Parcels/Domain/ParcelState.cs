using System.Text.Json.Serialization;

namespace Rusell.Parcels.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum ParcelState
{
    Created,
    Delivered,
    Canceled
}
