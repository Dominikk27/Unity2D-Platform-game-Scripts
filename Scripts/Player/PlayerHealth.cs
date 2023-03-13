using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public static event Action OnPlayerDamaged;
    public static event Action OnPlayerDeath;

    public int maxHealth = 6;
    public float health;

    public bool isDamaged;
    public float DamageCooldown;

    //HEALTH BAR Replaced for HEARTH BAR
    //public Slider HP_Slider;
    //public Image fillImage;

    void Start()
    {
        isDamaged = false;
        health = maxHealth;
       // HP_Slider.maxValue = maxHealth;
       // HP_Slider.minValue = 0;
    }

    void Update()
    {
      //HP_Slider.value = health;
    }

    public void TakeDamage(float damage)
    {   
        health -= damage;
        // Debug.Log("isDamaged");
        OnPlayerDamaged?.Invoke();

        if(health<=0)
        {
            // HP_Slider.value = 0;
            OnPlayerDeath?.Invoke();
            Destroy(gameObject);
        }
    }
}
