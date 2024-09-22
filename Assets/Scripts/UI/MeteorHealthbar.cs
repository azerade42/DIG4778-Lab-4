using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeteorHealthbar : MonoBehaviour
{
    [SerializeField] Slider healthbar;
    [SerializeField] GameObject healthbarFill;
    [SerializeField] int maxHealth;

    public void UpdateHealth(int amount)
    {
        healthbar.value = amount;

        if (amount >= 1)
        {
            healthbar.gameObject.SetActive(true);
            healthbarFill.SetActive(true);
        }

        if (amount >= maxHealth)
        {
            healthbar.gameObject.SetActive(false);
            healthbarFill.SetActive(false);
        }
    }

}
