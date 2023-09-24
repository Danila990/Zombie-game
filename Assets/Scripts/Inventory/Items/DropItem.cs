using UnityEngine;

public class DropItem : MonoBehaviour
{
    [SerializeField] private ItemData _data;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.TryGetComponent<Inventory>(out Inventory inventory))
            if (inventory.IsFreeSpace)
            {
                inventory.AddItem(_data.GetCloneItem());
                gameObject.SetActive(false);
            }
    }
}
