using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField]
    private string horizontalIdentifier;
    [SerializeField]
    private string verticalIdentifier;

    public string GetHorizontalIdentifer()
    {
        return horizontalIdentifier;
    }

    public string GetVerticalIdentifier()
    {
        return verticalIdentifier;
    }
}
