using Better.Console.Tables.Wrapper;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Configuration;
using Inventory.Min.Data;
using ModelHelper;

namespace Inventory.Min.BetterTable;

public class ItemTable
    : BetterTableToolbox<Item>
{
    public ItemTable()
    {
        var builder = new TableBuilder();
        BuildColumn(builder, nameof(Item.Id));
        BuildColumn(builder, nameof(Item.Name));
        BuildColumn(builder, nameof(Item.Description));
        BuildColumn(builder, nameof(Item.Quantity));
        BuildColumn(builder, nameof(Item.CategoryId));
        BuildColumn(builder, nameof(Item.PurchaseDate));
        Table = builder.Build();
        Table.Config = TableConfig.Unicode();
    }

    protected override void AddRowsToTable(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            Table.AddRow(
                item.Id
                , item.Name
                , item.Description
                , item.Quantity
                , item.CategoryId
                , item.PurchaseDate);
        }
    }

    protected override List<object[]> ConvertData(IEnumerable<Item> items)
    {
        var list = new List<object[]>();
        foreach (var item in items)
        {
            list.Add(new [] { 
                item.Id.ToString()
                , item.Name ?? string.Empty
                , item.Description ?? string.Empty
                , item.Quantity?.ToString() ?? string.Empty
                , item.CategoryId?.ToString() ?? string.Empty
                , item.PurchaseDate?.ToString(Model.DateOnlyFormat) ?? string.Empty
                });
        }
        return list;
    }
}