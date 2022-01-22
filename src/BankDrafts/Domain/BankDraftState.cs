using System.Text.Json.Serialization;

namespace Rusell.BankDrafts.Domain;

[JsonConverter(typeof(JsonStringEnumConverter))]
public enum BankDraftState
{
    Created,
    Delivered,
    Canceled
}
