using UnityEngine;

public class BackpackDisplay : InventoryDisplay
{
    [SerializeField] private RemovePanel _removePanel;

    public override void OnClickItem(Item item)
    {
        _removePanel.SetupPanel(item);
    }

    public override void AddDisplayItem(Item item)
    {
        CellItem cell = GetFreeCell();
        cell.SetupData(item);
        cell.gameObject.SetActive(true);
    }

    public override void RemoveDisplayItem(Item item)
    {
        for (int i = 0; i < _cellList.Count; i++)
            if (_cellList[i]._item == item)
            {
                _cellList[i].ResetData();
                SortingCells(i);
                break;
            }
    }
}