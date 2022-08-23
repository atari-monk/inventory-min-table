using Better.Console.Tables.Wrapper;
using DIHelper.Unity;
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
        RegisterTable<BasicItemTable, Item>();
        RegisterTable<BasicItemTableTest, Item>();
        RegisterTable<ItemTable, Item>();
        RegisterTable<ItemTableTest, Item>();
    }
    
    private void RegisterTable<TType, TEntity>()
        where TType : IBetterTable<TEntity>
    {
        Container
            .RegisterSingleton<IBetterTable<TEntity>, TType>(
                typeof(TType).Name);
    }
}