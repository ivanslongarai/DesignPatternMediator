namespace Mediator.Domain.Entities;

public class Player : Entity
{
    public Player(string name, int number, bool isPlaying)
    {
        Name = name;
        Number = number;
        IsPlaying = isPlaying;
    }

    public string Name { get; private set; }
    public int Number { get; private set; }
    public bool IsPlaying { get; private set; }


    public void StopPlaying()
    {
        IsPlaying = false;
    }

    public void SetPlaying()
    {
        IsPlaying = true;
    }
}