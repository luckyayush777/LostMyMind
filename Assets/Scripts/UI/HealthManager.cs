using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{

    [SerializeField]
    private Image healthBarSpriteImage;
    // Start is called before the first frame update

    private void OnEnable()
    {
        FaceBehaviour.tookDamage += ReduceHealth;
    }
    private void OnDisable()
    {
        FaceBehaviour.tookDamage -= ReduceHealth;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReduceHealth()
    {
        healthBarSpriteImage.fillAmount -= 0.1f;
    }
}
