using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    //Hidden public fields
    [HideInInspector]
    public bool healthFull;

    //private fields
    private float health;
    private float lerpTimer;

    [Header("Menu manager")]
    [SerializeField]
    private MenuManager menuManager;

    //UI GOs
    [Header("HUD and Death Overlay")]
    public GameObject playerUI;
    public GameObject deathScreen;

    [Header("Health Bar Properties")]
    public float maxHealth = 100f;
    public float chipSpeed = 2f;

    [Header("Health Bar Images")]
    public Image frontHealthBar;
    public Image backHealthBar;

    [Header("Health Bar Text")]
    public TextMeshProUGUI currentHealthText;
    public TextMeshProUGUI maxHealthText;

    [Header("Damage Overlay")]
    public Image damageOverlay;
    public float damageDuration;
    public float damageFadeSpeed;
    private float damageDurationTimer;

    [Header("Heal Overlay")]
    public Image healOverlay;
    public float healDuration;
    public float healFadeSpeed;
    private float healDurationTimer;

    void Start()
    {
        health = maxHealth;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 0);
        healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if (health == maxHealth)
            healthFull = true;
        else healthFull = false;

        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (health <= 0)
        {
            Debug.Log("dead");
            Die();
        }

        //heal overlay
        if (healOverlay.color.a > 0)
        {
            healDurationTimer += Time.deltaTime;
            if (healDurationTimer > healDuration)
            {
                //fade image
                float tempAplhaHeal = healOverlay.color.a;
                tempAplhaHeal -= Time.deltaTime * healFadeSpeed;
                healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, tempAplhaHeal);
            }
        }

        //dmg overlay
        if (damageOverlay.color.a > 0)
        {
            if (health < 30)
                return;
            damageDurationTimer += Time.deltaTime;
            if (damageDurationTimer > damageDuration)
            {
                //fade image
                float tempAplhaDmg = damageOverlay.color.a;
                tempAplhaDmg -= Time.deltaTime * damageFadeSpeed;
                damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, tempAplhaDmg);
            }
        }

    }

    public void UpdateHealthUI()
    {
        currentHealthText.text = health.ToString();
        maxHealthText.text = maxHealth.ToString();

        float fillF = frontHealthBar.fillAmount;
        float fillB = backHealthBar.fillAmount;

        float hFraction = health / maxHealth;

        if (fillB > hFraction)
        {
            frontHealthBar.fillAmount = hFraction;
            backHealthBar.color = Color.red;

            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;

            backHealthBar.fillAmount = Mathf.Lerp(fillB, hFraction, percentComplete);
        }

        if (fillF < hFraction)
        {
            backHealthBar.color = Color.green;
            backHealthBar.fillAmount = hFraction;

            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            percentComplete = percentComplete * percentComplete;

            frontHealthBar.fillAmount = Mathf.Lerp(fillF, backHealthBar.fillAmount, percentComplete);

        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        damageDurationTimer = 0f;
        damageOverlay.color = new Color(damageOverlay.color.r, damageOverlay.color.g, damageOverlay.color.b, 1);
    }

    public void HealHealth(float heal)
    {
        health += heal;
        lerpTimer = 0f;
        healDurationTimer = 0f;
        healOverlay.color = new Color(healOverlay.color.r, healOverlay.color.g, healOverlay.color.b, 1);
    }

    public void Die()
    {
        playerUI.SetActive(false);
        deathScreen.SetActive(true);

        //unlock cursor
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

        menuManager.gamePaused = true;

        Time.timeScale = 0;
    }
}
