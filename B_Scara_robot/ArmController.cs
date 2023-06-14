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
        Vector3 armPos = new Vector3(Arm.transform.position.x, 0f, Arm.transform.position.z);
        Vector3 forearmPos = new Vector3(Forearm.transform.position.x, 0f, Forearm.transform.position.z);
        armLength = Vector3.Distance(armPos, forearmPos);
        // show the armLength value in the console
        Debug.Log("Arm length: " + armLength);

        Vector3 handPos = new Vector3(Hand.transform.position.x, 0f, Hand.transform.position.z);
        forearmLength = Vector3.Distance(forearmPos, handPos);
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
