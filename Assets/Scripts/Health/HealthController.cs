using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public delegate void HealthChangedHandler(object source, float oldHealth, float newHealth);
    public event HealthChangedHandler OnHealthChanged;

    [SerializeField] private float currentHealth;
    [SerializeField] private float maxHealth;
    private HealthUIController bar;
    [SerializeField] private GameObject drop;
    public float CurrentHealth => currentHealth;

    public void Awake()
    {
        currentHealth = maxHealth;
        bar = GetComponentInChildren<HealthUIController>(true);
    }
    public void ChangeHealth(float amount)
    {
        float oldHealth = currentHealth;
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        if (currentHealth < maxHealth)
            bar.gameObject.SetActive(true);
        else
            bar.gameObject.SetActive(false);
        bar.UpdateHealthBar(currentHealth, maxHealth);
        if (currentHealth <= 0)
            OnDeath();
        OnHealthChanged?.Invoke(this, oldHealth, currentHealth);
    }
    public void OnDeath()
    {
        GameObject itemDrop = Instantiate(drop, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
}
