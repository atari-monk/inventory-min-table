using Better.Console.Tables.Wrapper;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Configuration;
using Inventory.Min.Data;

namespace Inventory.Min.BetterTable;

public class DefaultItemTable
    : BetterTableToolbox<Item>
{
    public DefaultItemTable()
    {
        var builder = new TableBuilder();
        BuildColumn(builder, nameof(Item.Id));
        BuildColumn(builder, nameof(Item.Name));
        BuildColumn(builder, nameof(Item.Description));
        BuildColumn(builder, nameof(Item.Category));
        BuildColumn(builder, nameof(Item.Quantity));
        BuildColumn(builder, nameof(Item.Mass));
        BuildColumn(builder, nameof(Item.Length));
        BuildColumn(builder, nameof(Item.Heigth));
        BuildColumn(builder, nameof(Item.Depth));
        //BuildColumn(builder, "CreatedDate");
        //BuildColumn(builder, "UpdatedDate");
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
                , item.Category?.Name
                , item.Quantity
                , item.Mass
                , item.Length
                , item.Heigth
                , item.Depth);
        }
    }

    protected override List<object[]> ConvertData(IEnumerable<Item> items)
    {
        var list = new List<object[]>();
        foreach (var item in items)
        {
            list.Add(new object[] { 
                item.Id.ToString()
                , item.Name ?? string.Empty
                , item.Description ?? string.Empty
                , item.Category?.Name ?? string.Empty
                , item.Quantity?.ToString() ?? string.Empty
                , item.Mass?.ToString() ?? string.Empty
                , item.Length?.ToString() ?? string.Empty
                , item.Heigth?.ToString() ?? string.Empty
                , item.Depth?.ToString() ?? string.Empty
                });
        }
        return list;
    }
}