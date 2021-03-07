using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;


public class HealthManager : MonoBehaviour
{

    [SerializeField]
    private Image healthBarSpriteImage;
    [SerializeField]
    private TextMeshProUGUI healthBarText;
    private float healthAmount = 100;
    private float damageAmount = 16.0f;
    [SerializeField]
    private Volume lowHealthVolume;
    private bool healthEffectAlreadyBeenApplied = false;
    private ColorAdjustments colorAdjustments;
    private Vignette vignette;
    [SerializeField]
    private float _minimumHealthToApplyLowHealthEffect;
    [Range(-30, -70)]
    public float saturationAmount;
    [Range(0.5f, 0.9f)]
    public float vignetteAmount;
    [SerializeField]
    private Image healthImage;
    [SerializeField]
    private Image gameOverImage;


    // Start is called before the first frame update

    private void OnEnable()
    {
        FaceBehaviour.TookDamage += ReduceHealth;
    }
    private void OnDisable()
    {
        FaceBehaviour.TookDamage -= ReduceHealth;
    }
    void Start()
    {
        healthBarText.text = healthAmount.ToString();
        lowHealthVolume.profile.TryGet(out colorAdjustments);
        lowHealthVolume.profile.TryGet(out vignette);

    }

    // Update is called once per frame
    void Update()
    {
        if(healthAmount <= _minimumHealthToApplyLowHealthEffect && healthEffectAlreadyBeenApplied == false)
        {
            colorAdjustments.saturation.value = saturationAmount;
            vignette.intensity.value = vignetteAmount;
            healthImage.enabled = true;
            healthEffectAlreadyBeenApplied = true;
        }
        OnDeath();
    }

    private void ReduceHealth()
    {
        if(healthAmount > 0.0)
        healthBarSpriteImage.fillAmount -= 0.167f;
        healthAmount -= damageAmount;
        healthBarText.text = healthAmount.ToString();
    }

    private void OnDeath()
    {
        if(healthAmount < 0)
        {
            Helper.Log("DIED!");
            healthImage.enabled = false;
            gameOverImage.enabled = true;
        }
    }
}
