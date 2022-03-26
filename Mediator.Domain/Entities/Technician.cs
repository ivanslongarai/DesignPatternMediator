namespace Mediator.Domain.Entities;

public class Technician : Entity
{
    private readonly IList<Player> _players = new List<Player>();

    public string Name { get; private set; }
    public IReadOnlyCollection<Player> Team { get => _players.ToArray(); }

    public Technician(string name)
    {
        Name = name;
        SetTeam();
    }

    public string ChangePlayer(int playerIn, int playerOut)
    {
        var objPlayerIn = _players.Where(x => x.Number == playerIn).FirstOrDefault();
        var objPlayerOut = _players.Where(x => x.Number == playerOut).FirstOrDefault();
        return $"Technician says: I want to change {objPlayerOut?.Name} for {objPlayerIn?.Name}";
    }

    private void SetTeam()
    {
        string[] players = new string[14]
        {
            "Leonardo",
            "Pedro",
            "Marco",
            "Juliano",
            "Rô",
            "Portuga",
            "Luis",
            "Leandro",
            "Antonio",
            "Romulo",
            "Peralta",
            "Pedro Legacy",
            "Marcel",
            "Gabriel"
        };

        var i = 0;

        foreach (var player in players)
        {
            i++;
            _players.Add(new Player(player, i, i <= 11));
        }
    }
}