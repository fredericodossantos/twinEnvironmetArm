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
        Vector3 target = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.z, 10f));
        float dx = target.x - joint.position.x;
        float dz = target.z - joint.position.z;
        float angle = 180 - Mathf.Atan2(dz, dx);

        joint.rotation = Quaternion.Euler(90f, angle * Mathf.Rad2Deg, 0f );
    }
}
