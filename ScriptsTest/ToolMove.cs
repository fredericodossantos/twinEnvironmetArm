using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMove : MonoBehaviour
{
    public GameObject objectX;
    public GameObject objectY;
    public GameObject objectZ;

    // Update is called once per frame
    void Update()
    {
        // Check if the required game objects are assigned
        if (objectX != null && objectY != null && objectZ != null)
        {
            // Get the X, Y, and Z positions from the assigned game objects
            float targetX = objectX.transform.position.x;
            float targetY = objectZ.transform.position.y;
            float targetZ = objectY.transform.position.z;

            // Set the target position of the game object
            Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);

            // Output the target position for debugging
            //Debug.Log("Target Position: " + targetPosition);

            transform.position = targetPosition; // Use gameObject.transform to reference the game object's transform

            // Set the move speed of the game object
            // linear_acumulator.moveSpeed = 2f; // If you still need the moveSpeed, uncomment this line or assign it as a public variable
        }
        else
        {
            Debug.LogError("One or more required game objects are not assigned.");
        }
    }
}
