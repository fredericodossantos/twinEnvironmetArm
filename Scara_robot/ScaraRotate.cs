using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaraRotate : MonoBehaviour
{
    public float rotateSpeed = 45f; // Speed at which the game object rotates

    public void RotateIt()
    {
        Debug.Log("Clicked to rotate");

        // Check if the game object is not rotating
        if (!IsRotating())
        {
            // Change the target rotation of the game object
            Quaternion deltaRotation = Quaternion.Euler(0f, 0f, Random.Range(-90f, 90f));
            Quaternion targetRotation = transform.rotation * deltaRotation;

            // Rotate the game object towards the target rotation
            StartCoroutine(RotateTowards(targetRotation));
        }
        else
        {
            Debug.Log("Object still rotating");
        }
    }

    private bool IsRotating()
    {
        // Check if the game object is rotating by comparing its current rotation with the target rotation
        return Quaternion.Angle(transform.rotation, GetTargetRotation()) > 0.01f;
    }

    private Quaternion GetTargetRotation()
    {
        // Calculate the target rotation based on the current rotation and the rotation speed
        float angle = (Time.time * rotateSpeed) % 360f;
        return Quaternion.Euler(0f, 0f, angle);
    }

    private System.Collections.IEnumerator RotateTowards(Quaternion targetRotation)
    {
        // Rotate the game object towards the target rotation gradually over time
        float duration = 1f; // Duration of rotation in seconds
        float elapsedTime = 0f;

        Quaternion startRotation = transform.rotation;

        while (elapsedTime < duration)
        {
            // Calculate the interpolation factor based on elapsed time
            float t = elapsedTime / duration;

            // Interpolate between the start rotation and the target rotation
            Quaternion newRotation = Quaternion.Slerp(startRotation, targetRotation, t);

            // Apply the new rotation to the game object
            transform.rotation = newRotation;

            // Increment the elapsed time
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        // Ensure the final rotation is set to the target rotation
        transform.rotation = targetRotation;
    }
}
