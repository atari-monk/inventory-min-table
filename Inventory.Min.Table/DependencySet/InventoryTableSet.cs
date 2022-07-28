using DataToTable;
using DataToTable.Unity;
using Inventory.Min.Data;
using Unity;

namespace Inventory.Min.Table;

public class InventoryTableSet 
    : DataToTableSet
{
    public InventoryTableSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container
            .RegisterType<IColumnCalculator<Item>, ColumnCalculator<Item>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .RegisterType<ITableTextEditor, TableTextEditor>()
            .RegisterType<IDataToText<Item>, ItemTable>();
    }
}