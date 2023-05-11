using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYAxis : MonoBehaviour
{
    public float speed = 10f;
    public float yAngle = 0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, yAngle, 0) * speed * Time.deltaTime);
    }
}
