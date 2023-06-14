using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmController : MonoBehaviour
{
    public GameObject Forearm;
    public GameObject Hand;

    void Update()
    {
        DragSegment(Forearm.transform);
    }

    void DragSegment(Transform joint)
    {
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10f));
        float dx = target.x - joint.position.x;
        float dy = target.y - joint.position.y;
        float angle = Mathf.Atan2(dy, dx);

        joint.rotation = Quaternion.Euler(0f, 0f, angle * Mathf.Rad2Deg);
    }
}
