using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CellItem : MonoBehaviour
{
    public bool _isBusy { get; private set; } = false;
    public Item _item { get; private set; }

    [SerializeField] private Image _iconButton;
    [SerializeField] private Button _cellButton;
    [SerializeField] private TMP_Text _countText;

    private InventoryDisplay _inventoryDisplay;

    private void OnDestroy() => _cellButton.onClick.RemoveListener(OnButtonClick);

    public void Init(InventoryDisplay inventoryDisplay)
    {
        _inventoryDisplay = inventoryDisplay;
        _cellButton.interactable = false;
        _cellButton.onClick.AddListener(OnButtonClick);
    }

    public void SetupStateBusy(bool isBusy)
    {
        _isBusy = isBusy;
        _cellButton.interactable = isBusy;
    }

    public void SetupData(Item itemData)
    {
        _item = itemData;
        _iconButton.sprite = _item.Icon;
        SetupStateBusy(true);
        OutputCount();
    }

    public void ResetData()
    {
        _iconButton.sprite = null;
        _item = null;
        _countText.gameObject.SetActive(false);
        SetupStateBusy(false);
    }

    public void OutputCount()
    {
        if (_item.Count > 1)
        {
            _countText.gameObject.SetActive(true);
            _countText.text = $"{_item.Count}/{_item.LimitCount}";
        }
    }

    private void OnButtonClick() => _inventoryDisplay.OnClickItem(_item);
}