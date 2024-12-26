using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class hp_controll : MonoBehaviour
{
    public Slider healthSlider; // Thanh Slider
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        currentHealth = Mathf.Max(0, currentHealth);
        healthSlider.value = currentHealth;
    }

    public void Heal(int healingAmount)
    {
        currentHealth += healingAmount;
        currentHealth = Mathf.Min(maxHealth, currentHealth);
        healthSlider.value = currentHealth;
    }

}
