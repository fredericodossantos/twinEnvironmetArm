using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    public LineRenderer path;
    public PathToTarget pathToTarget;

    void Update()
    {
        if (pathToTarget.HasPassedTarget())
        {
            path.SetPosition(0, transform.position);
            path.SetPosition(1, pathToTarget.target.transform.position);
        }
    }
}
