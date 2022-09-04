using Better.Console.Tables.Wrapper;
using DIHelper.Unity;
using Inventory.Min.BetterTable.ItemTable;
using Inventory.Min.Data;
using Unity;

namespace Inventory.Min.BetterTable;

public class BetterTableSet
    : UnityDependencySet
{
    public BetterTableSet(
        IUnityContainer container) 
        : base(container)
    {
    }

    public override void Register()
    {
        RegisterTable<BasicTableTest, Item>(ItemTablesTest.BasicTest);
        RegisterTable<MediumTableTest, Item>(ItemTablesTest.MediumTest);
        RegisterTable<SizeTableTest, Item>(ItemTablesTest.SizeTest);
        RegisterTable<VerboseTableTest, Item>(ItemTablesTest.VerboseTest);
        
        RegisterTable<BasicTable, Item>(ItemTables.Basic);
        RegisterTable<MediumTable, Item>(ItemTables.Medium);
        RegisterTable<SizeTable, Item>(ItemTables.Size);
        RegisterTable<VerboseTable, Item>(ItemTables.Verbose);
    }
    
    private void RegisterTable<TType, TEntity>(ItemTables key)
        where TType : IBetterTable<TEntity>
    {
        Container
            .RegisterSingleton<IBetterTable<TEntity>, TType>(
                key.ToString());
    }

    private void RegisterTable<TType, TEntity>(ItemTablesTest key)
        where TType : IBetterTable<TEntity>
    {
        Container
            .RegisterSingleton<IBetterTable<TEntity>, TType>(
                key.ToString());
    }
}