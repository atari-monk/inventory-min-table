using System.Drawing;
using Better.Console.Tables.Wrapper;
using BetterConsoles.Tables;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Configuration;
using BetterConsoles.Tables.Models;
using Inventory.Min.Data;

namespace Inventory.Min.BetterTable;

public class ItemTable
    : BetterTable<Item>
{
    public ItemTable()
    {
        var headerFormat = new CellFormat()
        {
            Alignment = Alignment.Center,
            ForegroundColor = Color.Magenta
        };
        base.Table = new TableBuilder(headerFormat)
            .AddColumn(nameof(LogModel.Id)
                , rowsFormat: new CellFormat(foregroundColor: Color.FromArgb(255, 255, 0)))
        .Build();
        base.Table.Config = TableConfig.Unicode();
    }

    protected override void AddRowsToTable(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            Table.AddRow(
                item.Id);
        }
    }

    protected override List<object[]> ConvertData(IEnumerable<Item> items)
    {
        var list = new List<object[]>();
        foreach (var item in items)
        {
            list.Add(new [] { 
                item.Id.ToString()});
        }
        return list;
    }
}