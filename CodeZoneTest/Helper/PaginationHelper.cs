using CodeZoneTest.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeZoneTest.Helper;

public static class PaginationHelper
{
    public  static async Task<PaginationViewModel<T>> Paginate<T>(this IQueryable<T> query, int pageNumber, int pageSize)
    {
        pageNumber = pageNumber < 1 ? 1 : pageNumber;
        pageSize = pageSize < 1 ? 5 : pageSize;
        var totalItems =await query.CountAsync();
        if (totalItems is 0)
            return new PaginationViewModel<T>();
        var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
        var pageIndex = Math.Min(pageNumber, totalPages);
        pageSize = pageSize > totalItems ? totalItems : pageSize;
        var excludedItemsCount = (pageNumber - 1) * pageSize;
        var items = await query.Skip(excludedItemsCount).Take(pageSize).ToListAsync();
        return new PaginationViewModel<T>()
        {
            Items = items,
            PageSize = pageSize,
            PageIndex = pageIndex,
            TotalPages = totalPages,
            TotalItems = totalItems
        };
    }
}