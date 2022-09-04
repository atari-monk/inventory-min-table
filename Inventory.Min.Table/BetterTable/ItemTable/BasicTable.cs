using Better.Console.Tables.Wrapper;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Configuration;
using Inventory.Min.Data;

namespace Inventory.Min.BetterTable.ItemTable;

public class BasicTable
    : BetterTable<Item>
{
    public BasicTable()
    {
        var builder = new TableBuilder();
        BuildColumn(builder, nameof(Item.Id));
        BuildColumn(builder, nameof(Item.Name));
        BuildColumn(builder, nameof(Item.Description));
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
                , item.Description);
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
                , item.Description ?? string.Empty});
        }
        return list;
    }
}