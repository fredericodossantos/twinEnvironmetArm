using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    public float speed = 10f;
    public float xAngle = 0f;
    public float yAngle = 0f;
    public float zAngle = 0f;

    private Vector3 currentRotation;
    private Vector3 targetRotation;

    private void Start()
    {
        currentRotation = transform.rotation.eulerAngles;
        targetRotation = currentRotation + new Vector3(xAngle, yAngle, zAngle);
    }

    private void Update()
    {
        currentRotation = transform.rotation.eulerAngles;

        if (Vector3.Distance(currentRotation, targetRotation) > 0.01f)
        {
            transform.Rotate(new Vector3(xAngle, yAngle, zAngle) * speed * Time.deltaTime);
        }
    }
}
