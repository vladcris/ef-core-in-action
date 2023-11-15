namespace ef_core_data.QueryObjects;
public static class GenericPaging
{
    public static IQueryable<T> Page<T>(this IQueryable<T> query, int pageNumZeroStart, int pageSize) {
        if(pageSize == 0)
            throw new ArgumentException(nameof(pageSize), "pageSize cannot be zero");

        query = query
            .Skip(pageNumZeroStart * pageSize)
            .Take(pageSize);
        return query;
    }
}
