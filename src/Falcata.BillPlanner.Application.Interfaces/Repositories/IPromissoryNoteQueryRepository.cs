using Falcata.BillPlanner.Application.Interfaces.QueryBuilders;
using Falcata.BillPlanner.Application.Interfaces.QueryBuilders.Base;
using Falcata.BillPlanner.Application.Interfaces.Repositories.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.PromisoryNote;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories;

public interface IPromissoryNoteQueryRepository: IQueryRepository<PromissoryNote, long>, IQueryBuilderProvider<IPromissoryNoteQueryBuilder, PromissoryNote>
{
    
}