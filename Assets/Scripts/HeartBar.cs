using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartBar : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Lives = new GameObject[5];
    private static int countOfLivesLost = 0;

    private void OnEnable()
    {
        FaceBehaviour.LifeLost += ReduceLives;
    }
    private void OnDisable()
    {
        FaceBehaviour.LifeLost -= ReduceLives;
    }
    private void ReduceLives()
    {
        if(countOfLivesLost < Lives.Length)
        Lives[countOfLivesLost].SetActive(false);
        countOfLivesLost++;
    }
}
