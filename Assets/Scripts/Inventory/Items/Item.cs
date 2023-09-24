using UnityEngine;

[System.Serializable]
public class Item
{
    public string Id => _id;
    public string Name => _name;
    public Sprite Icon => _icon;
    public int LimitCount => _limitCount;

    public int Count;

    [SerializeField] private string _id;
    [SerializeField] private string _name;
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _limitCount;

    public Item(int count, string id, string name, Sprite icon, int limitCount)
    {
        Count = count;
        _id = id;
        _name = name;
        _icon = icon;
        _limitCount = limitCount;
    }
}
