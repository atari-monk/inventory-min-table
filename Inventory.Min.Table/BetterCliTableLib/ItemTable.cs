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
        var builder = new TableBuilder();
        BuildColumn(builder, nameof(Item.Id), Color.LightGoldenrodYellow);
        BuildColumn(builder, nameof(Item.Name), Color.Green);
        BuildColumn(builder, nameof(Item.Description), Color.Crimson);
        BuildColumn(builder, nameof(Item.Quantity), Color.Red);
        Table = builder.Build();
        Table.Config = TableConfig.Unicode();
    }

    private void BuildColumn(
        TableBuilder builder
        , string propName
        , Color headerColor
        , Color rowColor
        , Alignment headerAlignment = Alignment.Center
        , Alignment rowAlignment = Alignment.Center)
    {
        var headerFormat = new CellFormat(alignment:headerAlignment, foregroundColor: headerColor);
        var rowFormat = new CellFormat(alignment:rowAlignment, foregroundColor: rowColor);
        builder
            .AddColumn(propName)
                .HeaderFormat(headerFormat)
                .RowsFormat(rowFormat);
    }

    private void BuildColumn(
        TableBuilder builder
        , string propName
        , Color color
        , Alignment alignment = Alignment.Center)
    {
        BuildColumn(builder, propName, color, color, alignment, alignment);
    }

    protected override void AddRowsToTable(IEnumerable<Item> items)
    {
        foreach (var item in items)
        {
            Table.AddRow(
                item.Id
                , item.Name
                , item.Description
                , item.Quantity);
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
                });
        }
        return list;
    }
}