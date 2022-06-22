using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int maxHealth = 10;

    public void Initialize()
    {
        health = maxHealth;
        UpdateHUD();
    }

    public void UpdateHUD()
    {
        GameObject.Find("HPtext").GetComponent<Text>().text = "HP: " + health;
    }

    public void DealDamage(int damage)
    {
        health -= damage;

        UpdateHUD();

        if (health <= 0)
        {
            
            Die();
        }
    }

    public void Die()
    {
//        gameObject.SetActive(false);
        GameObject.Find("HPtext").GetComponent<Text>().text = "Вы проиграли, нажмите ESC чтобы продолжить";
    }
}
