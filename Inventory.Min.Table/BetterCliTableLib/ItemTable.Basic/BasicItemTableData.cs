using Better.Console.Tables.Wrapper;
using Inventory.Min.Data;
using ModelHelper;

namespace Inventory.Min.BetterTable;

public class BasicItemTableData
    : TableData
{
    public BasicItemTableData()
    {
        Columns.Add(nameof(Item.Id), new ColumnData(14));
        Columns.Add(nameof(Item.Name), new ColumnData(Model.NameMax));
        Columns.Add(nameof(Item.Description), new ColumnData(Model.DescriptionMax));
    }
}