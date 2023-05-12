using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateYAxis : MonoBehaviour
{
    public float speed = 10f;
    public float angle = 0f;

    private void Update()
    {
        transform.Rotate(new Vector3(0, angle, 0) * speed * Time.deltaTime);
    }
}
