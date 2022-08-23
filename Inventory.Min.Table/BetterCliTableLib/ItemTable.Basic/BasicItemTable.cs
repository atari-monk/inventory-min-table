using Better.Console.Tables.Wrapper;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Configuration;
using Inventory.Min.Data;

namespace Inventory.Min.BetterTable;

public class BasicItemTable
    : BetterTableToolbox<Item>
{
    private readonly ITableData data;

    public BasicItemTable(ITableData data)
    {
        this.data = data;
        var builder = new TableBuilder();
        foreach (var column in data.Columns)
        {
            BuildColumn(builder, column.Key);
        }
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