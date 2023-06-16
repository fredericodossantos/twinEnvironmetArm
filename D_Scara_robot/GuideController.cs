using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    public LineRenderer path;
    public PathToTarget pathToTarget;
    public UnityEngine.AI.NavMeshAgent agent;
    public Conveyor conveyor;

    void Update()
    {
        if (pathToTarget.HasPassedTarget())
        {
            path.SetPosition(0, transform.position);
            path.SetPosition(1, pathToTarget.target.transform.position);

            agent.SetDestination(pathToTarget.target.transform.position);
            conveyor.isActive = false; // Deactivate the conveyor
        }
    }
}
