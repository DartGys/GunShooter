using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealtBar : MonoBehaviour
{
    [SerializeField] private Image _healthBarFilling;

    [SerializeField] private PlayerStats _healthBar;

    [SerializeField] private Gradient _gradient;

    void Awake()
    {
        _healthBar.HealthBarChanged += OnHealthChanged;
        _healthBarFilling.color = _gradient.Evaluate(1);
    }

    private void OnDestroy()
    {
        _healthBar.HealthBarChanged -= OnHealthChanged;
    }

    private void OnHealthChanged(float valueAsPercantage)
    {
        _healthBarFilling.fillAmount = valueAsPercantage;
        _healthBarFilling.color = _gradient.Evaluate(valueAsPercantage);
    }

}
