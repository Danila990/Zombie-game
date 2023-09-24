using System.Collections.Generic;
using UnityEngine;

public abstract class InventoryDisplay : MonoBehaviour
{
    [SerializeField] private Transform _parentCell;
    [SerializeField] private CellItem _cellPrefab;
    
    protected List<CellItem> _cellList = new List<CellItem>();

    public abstract void OnClickItem(Item item);
    public abstract void AddDisplayItem(Item item);
    public abstract void RemoveDisplayItem(Item item);

    public void SetupCountCell(int count)
    {
        if (count > _cellList.Count)
        {
            for (int i = _cellList.Count; i < count; i++)
            {
                CellItem cell = Instantiate(_cellPrefab, _parentCell);
                cell.Init(this);
                _cellList.Add(cell);
            }
        } 
        else
        {
            for (int i = _cellList.Count - 1; i >= count; i--)
                Destroy(_cellList[i]);
        }  
    }

    public void UpdateCountCells(Item updateItem)
    {
        foreach (CellItem cell in _cellList)
        {
            if (cell._item == null) continue;

            if(updateItem == cell._item)
            {
                cell.OutputCount();
                return;
            }    
        }
    }

    protected CellItem GetFreeCell()
    {
        foreach (CellItem cell in _cellList)
            if (cell._isBusy == false)
            {
                cell.SetupStateBusy(true);
                return cell;
            }
        return null;
    }

    protected void SortingCells(int startCell)
    {
        for (int i = startCell; i < _cellList.Count - 1; i++)
        {
            if (_cellList[i]._item == null)
            {
                if (_cellList[i + 1]._item == null)
                    break;
                _cellList[i].SetupData(_cellList[i + 1]._item);
                _cellList[i + 1].ResetData();
            }
        }
    }
}