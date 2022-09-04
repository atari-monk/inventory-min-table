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
        RegisterTable<BasicTableTest, Item>(ItemTablesTest.Basic);
        RegisterTable<MediumTableTest, Item>(ItemTablesTest.Medium);
        RegisterTable<SizeTableTest, Item>(ItemTablesTest.Size);
        RegisterTable<VerboseTableTest, Item>(ItemTablesTest.Verbose);
        
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