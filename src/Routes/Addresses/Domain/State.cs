using ValueOf;

namespace Rusell.Routes.Addresses.Domain;

public class State : ValueOf<string, State>
{
    public static implicit operator string(State state) => state.Value;
    public static implicit operator State(string state) => From(state);
}
