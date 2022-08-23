using System.Globalization;
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
        BuildColumn(builder, nameof(Item.PurchasePrice));
        BuildColumn(builder, nameof(Item.SellPrice));
        BuildColumn(builder, nameof(Item.ImagePath));
        BuildColumn(builder, nameof(Item.LengthUnitId));
        BuildColumn(builder, nameof(Item.Length));
        BuildColumn(builder, nameof(Item.Heigth));
        BuildColumn(builder, nameof(Item.Depth));
        BuildColumn(builder, nameof(Item.Diameter));
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
                , item.PurchaseDate
                , item.PurchasePrice
                , item.SellPrice
                , item.ImagePath
                , item.LengthUnitId
                , item.Length
                , item.Heigth
                , item.Depth
                , item.Diameter
                );
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
                , item.Quantity?.ToString() ?? string.Empty
                , item.CategoryId?.ToString() ?? string.Empty
                , item.PurchaseDate?.ToString(Model.DateOnlyFormat) ?? string.Empty
                , item.PurchasePrice?.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture)) ?? string.Empty
                , item.SellPrice?.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture)) ?? string.Empty
                , item.ImagePath ?? string.Empty
                , item.LengthUnitId?.ToString() ?? string.Empty
                , item.Length?.ToString() ?? string.Empty
                , item.Heigth?.ToString() ?? string.Empty
                , item.Depth?.ToString() ?? string.Empty
                , item.Diameter?.ToString() ?? string.Empty

                });
        }
        return list;
    }
}