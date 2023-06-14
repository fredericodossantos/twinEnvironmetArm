using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public GameObject Arm;
    public GameObject Forearm;
    public GameObject Hand;
    public GameObject Target;
    private float armLength;
    private float forearmLength;

    void Start()
    {
        armLength = Vector3.Distance(Arm.transform.position, Forearm.transform.position);
        // show the armLength value in the console
        Debug.Log("Arm length: " + armLength);
        forearmLength = Vector3.Distance(Forearm.transform.position, Hand.transform.position);
        // show value in the console
        Debug.Log("Forearm length: " + forearmLength);
    }

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
        float a1 = 0f;
        float cosValue = (armLength * armLength + distance * distance - forearmLength * forearmLength) / (2 * armLength * distance);
        if (cosValue >= -1f && cosValue <= 1f)
            a1 = Mathf.Acos(cosValue);
        float a2 = Mathf.Atan2(dz, dx);
        float angle1 = a2 - a1;

        joint1.rotation = Quaternion.Euler(270f,  -1 * angle1 * Mathf.Rad2Deg -180f, 0f);

        dx = target.x - joint2.position.x;
        dz = target.z - joint2.position.z;
        float angle2 = Mathf.Atan2(dz, dx);

        joint2.rotation = Quaternion.Euler(90f, -1 * angle2 * Mathf.Rad2Deg + 180, 0f);
    }

}
