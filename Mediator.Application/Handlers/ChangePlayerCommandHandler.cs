using Mediator.Application.Commands;
using Mediator.Domain.Entities;
using MediatR;

namespace Mediator.Application.Handlers;

public class ChangePlayerCommandHandler :
    IRequestHandler<ChangePlayerCommand, GenericResult>
{

    public Task<GenericResult> Handle(ChangePlayerCommand request, CancellationToken cancellationToken)
    {
        var changePlayer = request.Technician.ChangePlayer(request.PlayerIn, request.PlayerOut);
        var raiseThePlate = request.FourthOfficial.RaiseThePlate(request.PlayerIn, request.PlayerOut);


        var testPlayerIn = request.Technician.Team.Where(x => x.Number == request.PlayerIn && x.IsPlaying == false).FirstOrDefault();
        var testPlayerOut = request.Technician.Team.Where(x => x.Number == request.PlayerOut && x.IsPlaying == true).FirstOrDefault();


        if (testPlayerIn == null || testPlayerOut == null)
        {
            var resultError = new GenericResult(request.Technician.Team);
            resultError.AddMessage("Invalid players. No changes were made.");
            return Task.FromResult(resultError);
        }

        var result = new GenericResult(ChangePlayer(
                        request.Technician.Team,
                        request.PlayerIn,
                        request.PlayerOut
                    ));

        result.AddMessage(changePlayer);
        result.AddMessage(raiseThePlate);

        return Task.FromResult(result);
    }

    private IEnumerable<Player> ChangePlayer(
            IEnumerable<Player> team,
            int playerIn,
            int playerOut
        )
    {
        return PlayerGetsIn(PlayerGetsOut(team, playerOut), playerIn);
    }

    private IEnumerable<Player> PlayerGetsIn(IEnumerable<Player> team, int playerNumber)
    {
        var player = team.Where(x => x.Number == playerNumber && x.IsPlaying == false).FirstOrDefault();
        if (player != null)
            player!.SetPlaying();
        return team;
    }

    private IEnumerable<Player> PlayerGetsOut(IEnumerable<Player> team, int playerNumber)
    {
        var player = team.Where(x => x.Number == playerNumber && x.IsPlaying == true).FirstOrDefault();
        if (player != null)
            player!.StopPlaying();
        return team;
    }

}