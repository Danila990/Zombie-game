using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _slider;

    private void Awake()
    {
        GetComponent<Canvas>().worldCamera = Camera.main;
    }

    public void SetupBar(float currentHealth, float maxHealth)
    {
        _slider.maxValue = maxHealth;
        _slider.value = currentHealth;
    }

    public void UpdateBar(float health) 
    {
        if (_slider.value - health <= 0)
            _slider.value = 0;

        _slider.value = health;
    }
}
