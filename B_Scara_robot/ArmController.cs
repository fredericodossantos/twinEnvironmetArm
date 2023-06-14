using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public GameObject Arm;
    public GameObject Forearm;
    public float segLength = 80f;

    void Update()
    {
        DragSegment(transform, Arm.transform);
        DragSegment(Arm.transform, Forearm.transform);
    }

    void DragSegment(Transform joint1, Transform joint2)
    {
        Vector3 target;
        if (joint2 != null)
            target = joint2.position;
        else
            target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));

        float dx = target.x - joint1.position.x;
        float dy = target.y - joint1.position.y;
        float angle = Mathf.Atan2(dy, dx);

        joint1.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);

        if (joint2 != null)
        {
            Vector3 joint2Pos = joint1.position;
            joint2Pos.x += Mathf.Cos(angle) * segLength;
            joint2Pos.y += Mathf.Sin(angle) * segLength;
            joint2.position = joint2Pos;
        }
    }
}
