using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private ItemData _data;

    private Item _item;

    private void Start()
    {
        _item = _data.GetCloneItem();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Inventory>(out Inventory inventory))
            if (inventory.Finditem(_item.Id, out int countItem) || inventory.IsFreeSpace)
            {
                inventory.AddItem(_data.GetCloneItem());
                gameObject.SetActive(false);
            }
    }
}
