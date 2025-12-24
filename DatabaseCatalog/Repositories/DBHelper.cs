using Core.Entities;
using Core.ViewModels.Request;

namespace DatabaseCatalog.Repositories
{
    public static class DBHelper
    {
        public static IQueryable<T> ApplyPagination<T>(IQueryable<T> query, Pagination pagination)
        {
            return query.Skip(pagination.Skip).Take(pagination.Take);
        }

        public static IQueryable<T> ApplySorting<T>(IQueryable<T> query, Sorting sorting)
        {
            var itemQuery = query as IQueryable<Product>;
            itemQuery = sorting.SortingCondition switch
            {
                SortingCondition.Newest => itemQuery.OrderByDescending(w => w.CreationTime),
                SortingCondition.FromCheepToExpensive => itemQuery.OrderBy(w => w.Price),
                SortingCondition.FromExpensiveToCheep => itemQuery.OrderByDescending(w => w.Price),
                _ => itemQuery.OrderBy(w => w.Price),
            };
            return itemQuery as IQueryable<T>;
        }
    }
}
