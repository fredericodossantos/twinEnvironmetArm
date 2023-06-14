using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public GameObject Arm;
    public GameObject Forearm;
    public GameObject Target;
    public float armLength;
    public float forearmLength;

    void Update()
    {
        InverseKinematics(Arm.transform, Forearm.transform);
    }

    void InverseKinematics(Transform joint1, Transform joint2)
    {
        Vector3 target = Target.transform.position;
        float dx = target.x - joint1.position.x;
        float dz = target.z - joint1.position.z;
        float distance = Mathf.Sqrt(dx * dx + dz * dz);
        float a1 = Mathf.Acos((armLength * armLength + distance * distance - forearmLength * forearmLength) / (2 * armLength * distance));
        float a2 = Mathf.Atan2(dz, dx);
        float angle1 = a2 - a1;

        joint1.rotation = Quaternion.Euler(90f, 180 + angle1 * Mathf.Rad2Deg, 0f);

        dx = target.x - joint2.position.x;
        dz = target.z - joint2.position.z;
        float angle2 = Mathf.Atan2(dz, dx);

        joint2.rotation = Quaternion.Euler(90f, 180 + angle2 * Mathf.Rad2Deg, 0f);
    }
}
