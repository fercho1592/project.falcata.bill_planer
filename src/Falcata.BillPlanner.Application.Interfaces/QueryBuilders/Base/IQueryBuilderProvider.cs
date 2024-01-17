namespace Falcata.BillPlanner.Application.Interfaces.QueryBuilders.Base;

public interface IQueryBuilderProvider<TQueryBuilder, TEntity> where TQueryBuilder: IQueryBuilder<TEntity>
{
    TQueryBuilder NewQueryBuilder();
}