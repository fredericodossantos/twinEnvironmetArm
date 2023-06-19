using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuideController : MonoBehaviour
{
    public LineRenderer path;
    public PathToTarget pathToTarget;
    public UnityEngine.AI.NavMeshAgent agent;
    public Conveyor conveyor;
    public GameObject Hand;
    public GameObject Target;
    private bool MoveGuide = false;

    void Update()
    {
        if (pathToTarget.HasPassedTarget())
        {
            path.SetPosition(0, transform.position);
            path.SetPosition(1, pathToTarget.target.transform.position);

            agent.SetDestination(pathToTarget.target.transform.position);
            conveyor.isActive = false; // Deactivate the conveyor

            MoveGuide = true;
        }
        if (MoveGuide)
        {
            MoveGuideToYTarget();
        }
        
    }
   

    void MoveGuideToYTarget()
    {
        float targetY = Target.transform.position.y;
        float objectY = Hand.transform.position.y;

        if (Mathf.Abs(targetY - objectY) > 0.1f)
        {
            Hand.transform.position += Vector3.up * 0.1f * Time.deltaTime;
        }
        else
        {
            MoveGuide = false;
        }

    }
}
