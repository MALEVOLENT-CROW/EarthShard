using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Hidden public fields
    [HideInInspector]
    public bool healthFull;

    //public fields
    public float passiveHealInterval = 10;
    public float passiveHealAmount = 10;

    //private fields
    [SerializeField]private float health;
    private float timeSinceLastDmg;
    private float second;

    [Header("Menu manager")]
    [SerializeField]
    private MenuManager menuManager;

    //UI GOs
    [Header("HUD and Death Overlay")]
    public GameObject playerUI;
    public GameObject deathScreen;

    [Header("Health Properties")]
    public float maxHealth = 100f;

    [Header("Damage Overlay")]
    public Image damageOverlay;
    public float damageDuration;
    public float damageFadeSpeed;
    private float damageDurationTimer;

    /*
    [Header("Heal Overlay")]
    public Image healOverlay;
    public float healDuration;
    public float healFadeSpeed;
    private float healDurationTimer;
    */

    void Start()
    {
        health = maxHealth;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 0);
        //healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(health == maxHealth)
            healthFull = true;
        else healthFull = false;

        health = Mathf.Clamp(health, 0, maxHealth);

        if(health <= 0)
        {
            Debug.Log("dead");
            Die();
        }

        /*
        //heal overlay
        if(healOverlay.color.a > 0)
        {
            healDurationTimer += Time.deltaTime;
            if(healDurationTimer > healDuration)
            {
                //fade image
                float tempAplhaHeal = healOverlay.color.a;
                tempAplhaHeal -= Time.deltaTime * healFadeSpeed;
                healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, tempAplhaHeal);
            }
        }*/

        //dmg overlay
        if(damageOverlay.color.a > 0)
        {
            if(health < 30)
                return;
            damageDurationTimer += Time.deltaTime;
            if(damageDurationTimer > damageDuration)
            {
                //fade image
                float tempAplhaDmg = damageOverlay.color.a;
                tempAplhaDmg -= Time.deltaTime * damageFadeSpeed;
                damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, tempAplhaDmg);
            }
        }

        //updates time since last damage was taken
        timeSinceLastDmg += Time.deltaTime;
        //starts passive heal
        if(health < maxHealth && timeSinceLastDmg >= passiveHealInterval)
        {
            PassiveHeal(passiveHealAmount);
        }

    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        damageDurationTimer = 0f;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);

        timeSinceLastDmg = 0;
    }

    public void HealHealth(float heal)
    {
        health += heal;
        //healDurationTimer = 0f;
        //healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, 1);
    }

    private void PassiveHeal(float heal)
    {
        second += Time.deltaTime;
        if(second > 1)
        {
            HealHealth(heal);
            second = 0;
        }
    }

    public void Die()
    {
        playerUI.SetActive(false);
        deathScreen.SetActive(true);

        //unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        if(menuManager != null)
        {
            menuManager.gamePaused = true;
        }
        Time.timeScale = 0;
    }
}
