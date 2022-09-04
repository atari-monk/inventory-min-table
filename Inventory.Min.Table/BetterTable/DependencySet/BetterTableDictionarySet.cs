using Better.Console.Tables.Wrapper;
using DIHelper.Unity;
using Inventory.Min.Data;
using Unity;

namespace Inventory.Min.BetterTable;

public class BetterTableDictionarySet 
	: UnityDependencySet
{
	public BetterTableDictionarySet(
		IUnityContainer container) 
		: base(container)
	{
	}

	public override void Register()
	{
		Container.RegisterFactory<IDictionary<string, IBetterTable<Item>>>(
			c => FillDictionary(
                new Dictionary<string, IBetterTable<Item>>()));
	}

    private IDictionary<string, IBetterTable<Item>> FillDictionary(
        IDictionary<string, IBetterTable<Item>> store)
    {
		if(store.Count > 0) 
			return store;
		Add(store, ItemTablesTest.BasicTest);
		Add(store, ItemTablesTest.MediumTest);
		Add(store, ItemTablesTest.SizeTest);
		Add(store, ItemTablesTest.VerboseTest);
		
        Add(store, ItemTables.Basic);
		Add(store, ItemTables.Medium);
		Add(store, ItemTables.Size);
		Add(store, ItemTables.Verbose);
		return store;
    }

	private void Add(
        IDictionary<string, IBetterTable<Item>> store
		, ItemTablesTest key)
	{
        store.Add(key.ToString(), ResolveScript(key));
	}

    private IBetterTable<Item> ResolveScript(ItemTablesTest key)
	{
		return Container.Resolve<IBetterTable<Item>>(
			key.ToString());
	}

    private void Add(
        IDictionary<string, IBetterTable<Item>> store
		, ItemTables key)
	{
        store.Add(key.ToString(), ResolveScript(key));
	}

    private IBetterTable<Item> ResolveScript(ItemTables key)
	{
		return Container.Resolve<IBetterTable<Item>>(
			key.ToString());
	}
}