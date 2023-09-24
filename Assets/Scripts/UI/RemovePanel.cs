using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class RemovePanel : MonoBehaviour
{
    [SerializeField] private Button _yesButton;
    [SerializeField] private Button _noButton;
    [SerializeField] private TMP_Text _text;
    [SerializeField] private BackpackInventory _inventory;

    private Item _currentData;

    private void Start()
    {
        _yesButton.onClick.AddListener(YesButton);
        _noButton.onClick.AddListener(NoButton);

    }

    private void OnDestroy()
    {
        _yesButton.onClick.RemoveListener(YesButton);
        _noButton.onClick.RemoveListener(NoButton);
    }

    private void YesButton()
    {
        _inventory.RemoveItem(_currentData);
        gameObject.SetActive(false);
    }

    private void NoButton()
    {
        gameObject.SetActive(false);
    }

    public void SetupPanel(Item itemData)
    {
        gameObject.SetActive(true);
        _currentData = itemData;
        _text.text = $"Remove {itemData.Name}";
    }
}