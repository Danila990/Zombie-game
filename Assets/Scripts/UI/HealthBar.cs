using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderHealt;
    [SerializeField] private TMP_Text _textHealt;

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    public void SetupBar(float currentHealth, float maxHealth)
    {
        _sliderHealt.maxValue = maxHealth;
        _sliderHealt.value = currentHealth;
        _textHealt.text = $"{_sliderHealt.value}/{_sliderHealt.maxValue}";
    }

    public void UpdateBar(float health) 
    {
        if (_sliderHealt.value - health <= 0)
            _sliderHealt.value = 0;

        _sliderHealt.value = health;
        _textHealt.text = $"{_sliderHealt.value}/{_sliderHealt.maxValue}";
    }
}
