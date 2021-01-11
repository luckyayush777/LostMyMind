using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class HealthManager : MonoBehaviour
{

    [SerializeField]
    private Image healthBarSpriteImage;
    [SerializeField]
    private TextMeshProUGUI healthBarText;
    private float healthAmount = 100;
    private float damageAmount = 16.0f;

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
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReduceHealth()
    {
        healthBarSpriteImage.fillAmount -= 0.167f;
        healthAmount -= damageAmount;
        healthBarText.text = healthAmount.ToString();
    }
}
