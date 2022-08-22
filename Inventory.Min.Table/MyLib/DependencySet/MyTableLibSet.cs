using DataToTable;
using DataToTable.Unity;
using Inventory.Min.Data;
using Unity;

namespace Inventory.Min.Table;

public class MyTableLibSet 
    : DataToTableSet
{
    public MyTableLibSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    protected override void RegisterColumnCalculators()
    {
        Container
            .RegisterSingleton<IColumnCalculator<Item>, ColumnCalculator<Item>>();
    }

    protected override void RegisterTableProviders()
    {
        Container
            .RegisterSingleton<ITableTextEditor, TableTextEditor>()
            .RegisterSingleton<IDataToText<Item>, ItemTable>();
    }
}