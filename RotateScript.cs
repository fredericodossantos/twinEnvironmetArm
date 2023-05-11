using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float speed = 10f;
    public float xAngle = 0f;
    public float yAngle = 0f;
    public float zAngle = 0f;

    private void Update()
    {
        transform.Rotate(new Vector3(xAngle, yAngle, zAngle)* speed * Time.deltaTime);
    }
}
