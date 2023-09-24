using UnityEngine;

[CreateAssetMenu(fileName = "new Item", menuName = "Item")]
public class ItemData : ScriptableObject
{
    [SerializeField] private string _id = "1";
    [SerializeField] private string _name = "new _item";
    [SerializeField] private Sprite _icon;
    [SerializeField] private int _limitCount = 10;
    [SerializeField] private int _count = 1;

    public Item GetCloneItem()
    {
        return new Item(_count,_id,_name,_icon,_limitCount);
    }
}
