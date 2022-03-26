namespace Mediator.Application.Commands;

public class GenericResult
{
    private readonly IList<string> _messages = new List<string>();

    public GenericResult(object team)
    {
        Team = team;
    }

    public IReadOnlyCollection<string> Messages { get => _messages.ToArray(); }
    public object Team { get; set; }

    public void AddMessage(string message)
    {
        _messages.Add(message);
    }

}
