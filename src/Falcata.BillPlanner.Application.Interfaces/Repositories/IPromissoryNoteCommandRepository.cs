using Falcata.BillPlanner.Application.Interfaces.Repositories.Base;
using Falcata.BillPlanner.Domain.Models.BillPlanner.PromisoryNote;

namespace Falcata.BillPlanner.Application.Interfaces.Repositories;

public interface IPromissoryNoteCommandRepository: ICreateCommandRepository<PromissoryNote, long>, IUpdateCommandRepository<PromissoryNote, long>
{
    
}