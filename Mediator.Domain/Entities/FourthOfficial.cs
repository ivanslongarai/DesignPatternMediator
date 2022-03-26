namespace Mediator.Domain.Entities;

public class FourthOfficial : Entity
{
    public string Name { get; private set; }

    public FourthOfficial(string name)
    {
        Name = name;
    }

    public string RaiseThePlate(int numberIn, int numberOut)
    {
        return $"FourthOfficial says: Gets in: [{numberIn}] - Gets out: [{numberOut}]";
    }

}