﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Route : MonoBehaviour
{
    [SerializeField]
    private Transform[] controlPoints;

    private Vector2 gizmosPositions;

    private void OnDrawGizmos()
    {
        for (float i = 0; i <= 1; i += 0.05f)
        {
            gizmosPositions = Mathf.Pow(1 - i, 3) * controlPoints[0].position +
            3 * Mathf.Pow(1 - i, 2) * i * controlPoints[1].position +
            3 * (1 - i) * Mathf.Pow(i, 2) * controlPoints[2].position +
            Mathf.Pow(i, 3) * controlPoints[3].position;
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(gizmosPositions, 0.25f);
        }

        Gizmos.DrawLine(new Vector2(controlPoints[0].position.x, controlPoints[0].position.y),
            new Vector2(controlPoints[1].position.x, controlPoints[1].position.y));

        Gizmos.DrawLine(new Vector2(controlPoints[2].position.x, controlPoints[2].position.y),
            new Vector2(controlPoints[3].position.x, controlPoints[3].position.y));
    }
}
