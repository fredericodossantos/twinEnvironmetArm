using UnityEngine;

public class ArmRotator : MonoBehaviour
{
    public float rotationSpeed;

    private bool isRotating = false;

    private void Update()
    {
        if (isRotating)
        {
            transform.Rotate(Vector3.forward, rotationSpeed * Time.deltaTime);
        }
    }

    public void StartRotation()
    {
        isRotating = true;
    }

    public void StopRotation()
    {
        isRotating = false;
    }
    
    public void RotateArm(float rotationAmount)
    {
        transform.Rotate(Vector3.forward, rotationAmount);
    }
}
