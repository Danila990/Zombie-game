using UnityEngine;

public class InventoryButton : MonoBehaviour
{
    public void OpenCloseInventory()
    {
        if(gameObject.activeSelf)
            gameObject.SetActive(false);
        else gameObject.SetActive(true);
    }
}
