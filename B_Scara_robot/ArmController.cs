using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public GameObject Arm;
    public GameObject Forearm;
    public GameObject Hand;
    public GameObject Guide;

    public float handOffSet = -1.7f;
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

        // set the (x,z) positon of the guide to the same (x,z) position as the hand
        Vector3 guidePos = new Vector3(Guide.transform.position.x, 0f, Guide.transform.position.z);
        guidePos.x = handPos.x;
        guidePos.z = handPos.z;
        Guide.transform.position = guidePos;
    }
    void Update()
    {
        InverseKinematics(Arm.transform, Forearm.transform, Hand.transform);
    }
    void InverseKinematics(Transform joint1, Transform joint2, Transform joint3)
    {
        Vector3 guide = Guide.transform.position;
        float dx = guide.x - joint1.position.x;
        float dz = guide.z - joint1.position.z;
        
        
        float distance = Mathf.Sqrt(dx * dx + dz * dz);
        float a1 = 0f;
        float cosValue = (armLength * armLength + distance * distance - forearmLength * forearmLength) / (2 * armLength * distance);
        if (cosValue >= -1f && cosValue <= 1f)
            a1 = Mathf.Acos(cosValue);
        float a2 = Mathf.Atan2(dz, dx);
        float angle1 = a2 - a1;

        joint1.rotation = Quaternion.Euler(270f,  -1 * angle1 * Mathf.Rad2Deg + 180f, 0f);

        dx = guide.x - joint2.position.x;
        dz = guide.z - joint2.position.z;
        float angle2 = Mathf.Atan2(dz, dx);

        joint2.rotation = Quaternion.Euler(90f, -1 * angle2 * Mathf.Rad2Deg + 180, 0f);

        // move joint3(hand) to the same y position as the guide
        Vector3 handPos = joint3.position;
        handPos.y = guide.y - handOffSet;
        joint3.position = handPos;

        // get the glogal rotation of the guide and set only the rotaton in the y axis to the joint3(hand)
        Vector3 guideRotation = Guide.transform.rotation.eulerAngles;
        joint3.rotation = Quaternion.Euler(90f, guideRotation.y, 0f);

    }


}
