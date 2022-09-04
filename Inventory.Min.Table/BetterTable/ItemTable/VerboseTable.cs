using System.Globalization;
using Better.Console.Tables.Wrapper;
using BetterConsoles.Tables.Builders;
using BetterConsoles.Tables.Configuration;
using Inventory.Min.Data;
using ModelHelper;

namespace Inventory.Min.BetterTable.ItemTable;

public class VerboseTable
    : BetterTable<Item>
{
    public VerboseTable()
    {
        var builder = new TableBuilder();
        BuildColumn(builder, nameof(Item.Id));
        BuildColumn(builder, nameof(Item.Name));
        BuildColumn(builder, nameof(Item.Description));
        BuildColumn(builder, nameof(Item.InitialCount));
        BuildColumn(builder, nameof(Item.CurrentCount));
        //BuildColumn(builder, nameof(Item.CategoryId));
        BuildColumn(builder, nameof(Item.PurchaseDate));
        BuildColumn(builder, nameof(Item.PurchasePrice));
        BuildColumn(builder, nameof(Item.SellPrice));
        //BuildColumn(builder, nameof(Item.ImagePath));
        //BuildColumn(builder, nameof(Item.LengthUnitId));
        BuildColumn(builder, nameof(Item.Length));
        BuildColumn(builder, nameof(Item.Heigth));
        BuildColumn(builder, nameof(Item.Depth));
        BuildColumn(builder, nameof(Item.Diameter));
        //BuildColumn(builder, nameof(Item.VolumeUnitId));
        BuildColumn(builder, nameof(Item.Volume));
        BuildColumn(builder, nameof(Item.Mass));
        //BuildColumn(builder, nameof(Item.MassUnitId));
        //BuildColumn(builder, nameof(Item.TagId));
        //BuildColumn(builder, nameof(Item.StateId));
        //BuildColumn(builder, nameof(Item.ParentId));
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
                , item.InitialCount
                , item.CurrentCount
                //, item.CategoryId
                , item.PurchaseDate
                , item.PurchasePrice
                , item.SellPrice
                //, item.ImagePath
                //, item.LengthUnitId
                , item.Length
                , item.Heigth
                , item.Depth
                , item.Diameter
                //, item.VolumeUnitId
                , item.Volume
                , item.Mass
                //, item.MassUnitId
                //, item.TagId
                //, item.StateId
                //, item.ParentId
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
                , item.InitialCount?.ToString() ?? string.Empty
                , item.CurrentCount?.ToString() ?? string.Empty
                //, item.CategoryId?.ToString() ?? string.Empty
                , item.PurchaseDate?.ToString(Model.DateOnlyFormat) ?? string.Empty
                , item.PurchasePrice?.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture)) ?? string.Empty
                , item.SellPrice?.ToString(Model.MoneyFormat, CultureInfo.GetCultureInfo(Model.PolishCulture)) ?? string.Empty
                //, item.ImagePath ?? string.Empty
                //, item.LengthUnitId?.ToString() ?? string.Empty
                , item.Length?.ToString() ?? string.Empty
                , item.Heigth?.ToString() ?? string.Empty
                , item.Depth?.ToString() ?? string.Empty
                , item.Diameter?.ToString() ?? string.Empty
                //, item.VolumeUnitId?.ToString() ?? string.Empty
                , item.Volume?.ToString() ?? string.Empty
                , item.Mass?.ToString() ?? string.Empty
                //, item.MassUnitId?.ToString() ?? string.Empty
                //, item.TagId?.ToString() ?? string.Empty
                //, item.StateId?.ToString() ?? string.Empty
                //, item.ParentId?.ToString() ?? string.Empty
                });
        }
        return list;
    }
}