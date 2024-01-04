namespace Packt.Shared;

public class Passenger
{
    public string? Name { get; set; }
}

public class BusinessClassPassenger : Passenger
{
    public override string ToString() => $"Business Class: {Name}";
}

public class FirstClassPassenger : Passenger
{
    public int AirMiles { get; set; }
    public override string ToString() => $"First Class with {AirMiles:N0} air miles: {Name}";
}

public class CoachClassPassenger : Passenger
{
    public double CarryOnKG { get; set; }
    public override string ToString() => $"Coach Class with {CarryOnKG:N2} KG carry on: {Name}";
}