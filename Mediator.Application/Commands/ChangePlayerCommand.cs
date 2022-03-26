using Mediator.Domain.Entities;
using MediatR;

namespace Mediator.Application.Commands;

public class ChangePlayerCommand : IRequest<GenericResult>
{
    public ChangePlayerCommand(Technician technician, int playerIn, int playerOut, FourthOfficial fourthOfficial)
    {
        Technician = technician;
        PlayerIn = playerIn;
        PlayerOut = playerOut;
        FourthOfficial = fourthOfficial;
    }

    public Technician Technician { get; private set; }
    public int PlayerIn { get; private set; }
    public int PlayerOut { get; private set; }
    public FourthOfficial FourthOfficial { get; private set; }

}
