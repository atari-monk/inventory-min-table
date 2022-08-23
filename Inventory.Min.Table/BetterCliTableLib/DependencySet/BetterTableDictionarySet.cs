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
		Add(store, nameof(BasicItemTable));
		Add(store, nameof(BasicItemTableTest));
		Add(store, nameof(ItemTable));
		Add(store, nameof(ItemTableTest));
		return store;
    }

	private void Add(
        IDictionary<string, IBetterTable<Item>> store
		, string key)
	{
        store.Add(key, ResolveScript(key));
	}

    private IBetterTable<Item> ResolveScript(string key)
	{
		return Container.Resolve<IBetterTable<Item>>(
			key.ToString());
	}
}