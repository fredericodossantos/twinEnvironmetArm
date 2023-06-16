using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandController : MonoBehaviour
{
    public GameObject Hand;
    public GameObject Target;

    void Update()
    {
        MoveHand(Hand.transform);
        RotateHand(Hand.transform);
    }

    void MoveHand(Transform joint)
    {
        Vector3 target = Target.transform.position;
        Vector3 jointPos = joint.position;
        jointPos.z = target.z;
        joint.position = jointPos;
    }

    void RotateHand(Transform joint)
    {
        Quaternion targetRotation = Target.transform.rotation;
        joint.rotation = targetRotation;
    }
}
