
public class BackpackInventory : Inventory
{
    public override void AddItem(Item newItem)
    {
        if (!IsFreeSpace) return;

        if (TryFindSpaceDublicate(newItem, out Item dublicate))
            SumItemLogic(newItem,dublicate);
        else
        {
            _itemList.Add(newItem);
            _inventoryDisplay.AddDisplayItem(newItem);
        }
    }

    public override void RemoveItem(Item item)
    {
        _itemList.Remove(item);
        _inventoryDisplay.RemoveDisplayItem(item);
    }

    public override void RemoveCountItem(string itemId, int needCount)
    {
        foreach (Item item in _itemList)
            if (itemId == item.Id)
            {
                if(needCount < item.Count)
                {
                    item.Count -= needCount;
                    _inventoryDisplay.UpdateCountCells(item);
                    return;
                }

                RemoveItem(item);
                return;
            }
    }

    private void SumItemLogic(Item newItem, Item dublicate)
    {
        int resultCount = newItem.Count + dublicate.Count;

        if (resultCount > dublicate.LimitCount)
        {
            dublicate.Count = dublicate.LimitCount;
            newItem.Count = resultCount - newItem.LimitCount;

            _inventoryDisplay.UpdateCountCells(dublicate);
            _itemList.Add(newItem);
            _inventoryDisplay.AddDisplayItem(newItem);
            return;
        }
        else
        {
            dublicate.Count += newItem.Count;
            _inventoryDisplay.UpdateCountCells(dublicate);
            return;
        }
    }
}