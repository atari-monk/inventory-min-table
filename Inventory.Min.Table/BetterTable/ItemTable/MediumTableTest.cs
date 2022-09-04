using Better.Console.Tables.Wrapper;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Configuration;
using Inventory.Min.Data;

namespace Inventory.Min.BetterTable;

public class MediumTableTest
    : BetterTable<Item>
{
    public MediumTableTest()
    {
        var builder = new TableBuilder();
        BuildColumn(builder, nameof(Item.Name));
        BuildColumn(builder, nameof(Item.Description));
        BuildColumn(builder, nameof(Item.Category));
        BuildColumn(builder, nameof(Item.InitialCount));
        BuildColumn(builder, nameof(Item.CurrentCount));
        BuildColumn(builder, nameof(Item.Mass));
        BuildColumn(builder, nameof(Item.State));
        BuildColumn(builder, nameof(Item.Parent));
        Table = builder.Build();
        Table.Config = TableConfig.Unicode();
    }

    protected override void AddRowsToTable(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            Table.AddRow(
                item.Name
                , item.Description
                , item.Category?.Name
                , item.InitialCount
                , item.CurrentCount
                , item.Mass
                , item.State
                , item.Parent
                );
        }
    }

    protected override List<object[]> ConvertData(IEnumerable<Item> items)
    {
        var list = new List<object[]>();
        foreach (var item in items)
        {
            list.Add(new object[] { 
                item.Name ?? string.Empty
                , item.Description ?? string.Empty
                , item.Category?.Name ?? string.Empty
                , item.InitialCount?.ToString() ?? string.Empty
                , item.CurrentCount?.ToString() ?? string.Empty
                , item.Mass?.ToString() ?? string.Empty
                , item.State?.Name?.ToString() ?? string.Empty
                , item.Parent?.Name?.ToString() ?? string.Empty
                });
        }
        return list;
    }
}