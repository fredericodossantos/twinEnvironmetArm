using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathToTarget : MonoBehaviour
{
    public GameObject target;

    public bool HasPassedTarget()
    {
        float targetX = target.transform.position.x;
        float objectX = transform.position.x;               

        return Mathf.Abs(targetX - objectX) < 0.1f;
    }
}
