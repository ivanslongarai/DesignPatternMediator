using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Mediator.Application.Commands;
using Mediator.Application.Handlers;
using Mediator.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Mediator.tests;

[TestClass]
public class ChangePlayerCommandHandlerTests
{
    [TestMethod]
    public async Task MakingASubstitutionSuccessfully()
    {
        /* Fact

            GIVEN
                Antonio set the team of QualyTeam
            WHEN
                He decides to make a substitution
            THEN
                The FourthOfficial Mark raises the Plate
                Leonardo gets out
                Marcel gets in
                
        */

        var technician = new Technician("Antonio");

        var playerOut = technician.Team.FirstOrDefault(x => x.Name == "Leonardo")!.Number;
        var playerIn = technician.Team.FirstOrDefault(x => x.Name == "Marcel")!.Number;

        var command = new ChangePlayerCommand(
            technician,
            playerIn,
            playerOut,
            new FourthOfficial("Mark")
        );

        var commandHandler = new ChangePlayerCommandHandler();
        GenericResult result = await commandHandler.Handle(command, new CancellationToken());
        IEnumerable<Player> team = (IEnumerable<Player>)result.Team;

        var gettingOut = team.FirstOrDefault(x => x.Name == "Leonardo");
        var gettingIn = team.FirstOrDefault(x => x.Name == "Marcel");

        Assert.IsTrue(gettingIn!.IsPlaying);
        Assert.IsFalse(gettingOut!.IsPlaying);

    }
}