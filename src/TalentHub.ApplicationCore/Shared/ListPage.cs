using TalentHub.ApplicationCore.Shared.Results;

namespace TalentHub.ApplicationCore.Shared;

public class ListPage<T> : List<T>
{
    public int Page { get; }

    public int PageSize { get; }

    public int TotalPages { get; }

    public int TotalRows { get; }

    private ListPage
    (
        int page,
        int pageSize,
        int totalPages,
        int totalRows,
        IEnumerable<T> rows
    )
    {
        Page = page;
        PageSize = pageSize;
        TotalPages = totalPages;
        TotalRows = totalRows;
        AddRange(rows);
    }

    public static Result<ListPage<T>> New
    (
        IEnumerable<T> rows,
        int page,
        int pageSize,
        int totalRows
    )
    {
        var enumerable = rows as T[] ?? rows.ToArray();

        if (enumerable.Length != pageSize)
            return new Error("list_page", "invalid rows count");

        return new ListPage<T>
        (
            page,
            pageSize,
            (int)Math.Ceiling((double)totalRows / pageSize),
            totalRows,
            enumerable
        );
    }
}