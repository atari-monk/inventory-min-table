using DataToTable;
using Inventory.Min.Data;

namespace Inventory.Min.Table;

public abstract class ItemText
	: TextTable<Item>
{
    private const string Empty = "";

    public ItemText(
		ITableTextEditor tableTextEditor
		, IColumnCalculator<Item> columnCalculator) 
			: base(tableTextEditor, columnCalculator)
    {
    }

    protected string GetId(Item m) => m.Id.ToString();

	protected string GetName(Item m)
    {
        ArgumentNullException.ThrowIfNull(m.Name);
        return m.Name;
    }

    protected string GetDescription(Item m)
    {
        ArgumentNullException.ThrowIfNull(m.Description);
        return m.Description;
    }

    protected string GetCategory(Item m)
    {
        return m.Category != null ? 
			string.IsNullOrWhiteSpace(m.Category.Name) ? Empty : m.Category.Name
			: Empty;
    }

    protected string GetCategoryId(Item m)
    {
        return m.CategoryId.HasValue ? 
            m.CategoryId.Value.ToString()
            : Empty;
    }
}