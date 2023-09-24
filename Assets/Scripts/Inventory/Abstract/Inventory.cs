using System.Collections.Generic;
using UnityEngine;

public abstract class Inventory : MonoBehaviour
{
    public List<Item> ItemList => _itemList;
    public bool IsFreeSpace => _itemList.Count < _maxItems;

    [SerializeField] protected InventoryData _inventoryData;
    [SerializeField] private int _maxItems = 10;
    [SerializeField] protected InventoryDisplay _inventoryDisplay;

    protected List<Item> _itemList = new List<Item>();

    private void Start()
    {
        _inventoryDisplay = _inventoryDisplay.GetComponent<InventoryDisplay>();
        _itemList = _inventoryData.GetData();
        _inventoryDisplay.SetupCountCell(_maxItems);
        AwakeAddItemDisplay();
    }

    public abstract void AddItem(Item newItem);
    public abstract void RemoveItem(Item newItem);
    public abstract void RemoveCountItem(string itemId, int needCount);

    public bool Finditem(string needItemId, out int countItem)
    {
        foreach (Item item in _itemList)
            if (needItemId == item.Id)
            {
                countItem = item.Count;
                return true;
            }

        countItem = 0;
        return false;
    }

    protected bool TryFindSpaceDublicate(Item findItem, out Item dublicateItem)
    {
        foreach (Item item in _itemList)
            if (findItem.Id == item.Id && item.Count < item.LimitCount)
            {
                dublicateItem = item;
                return true;
            }

        dublicateItem = null;
        return false;
    }

    private void AwakeAddItemDisplay()
    {
        foreach (Item item in _itemList)
            _inventoryDisplay.AddDisplayItem(item);
    }
}