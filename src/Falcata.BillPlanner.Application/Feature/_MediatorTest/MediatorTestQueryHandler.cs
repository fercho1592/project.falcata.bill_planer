using MediatR;

namespace Falcata.BillPlanner.Application.Feature.MediatorTest;

public class MediatorTestQueryHandler: IRequestHandler<MediatorTestQuery, bool>
{
    public async Task<bool> Handle(MediatorTestQuery request, CancellationToken cancellationToken)
    {
        return true;
    }
}