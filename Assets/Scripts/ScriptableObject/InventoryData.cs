using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "new InventoryData", menuName = "InventoryData")]
public class InventoryData : ScriptableObject
{
    [SerializeField] private List<Item> _items = new List<Item>();

    public void SetData(List<Item> data) => _items = data;

    public List<Item> GetData() => _items;
}
