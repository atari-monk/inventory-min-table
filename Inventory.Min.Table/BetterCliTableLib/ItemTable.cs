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
            .AddColumn(nameof(Item.Id))
                .HeaderFormat(new CellFormat()
                    {
                        Alignment = Alignment.Center,
                        ForegroundColor = Color.LightGoldenrodYellow
                    })
                .RowsFormat(new CellFormat(foregroundColor: Color.LightGoldenrodYellow))
            .AddColumn(nameof(Item.Name))
                .HeaderFormat(new CellFormat()
                    {
                        Alignment = Alignment.Center,
                        ForegroundColor = Color.Green
                    })
                .RowsFormat(new CellFormat(foregroundColor: Color.Green))
        .Build();
        base.Table.Config = TableConfig.Unicode();
    }

    protected override void AddRowsToTable(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            Table.AddRow(
                item.Id
                , item.Name);
        }
    }

    protected override List<object[]> ConvertData(IEnumerable<Item> items)
    {
        var list = new List<object[]>();
        foreach (var item in items)
        {
            list.Add(new [] { 
                item.Id.ToString()
                , item.Name ?? string.Empty });
        }
        return list;
    }
}