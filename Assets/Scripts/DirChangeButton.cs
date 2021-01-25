using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirChangeButton : MonoBehaviour
{
    [SerializeField]
    private string ButtonName;
    public string ReturnButtonName()
    {
        return ButtonName;
    }

}
