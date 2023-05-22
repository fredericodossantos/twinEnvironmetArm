using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTool : MonoBehaviour
{
    public Linear_Acumulator linear_acumulator; // Drag and drop the game object with the Acumulator script attached to this field in the Inspector

    public void MoveIt()
    {
        // Debug.Log("Clicked to move");

        // Check if there are at least three objects in the positions list
        if (linear_acumulator.positions.Count >= 3)
        {
            // Get the X, Y, and Z positions from the linear_acumulator positions list
            float targetX = linear_acumulator.positions[0].x;
            float targetY = linear_acumulator.positions[1].y;
            float targetZ = linear_acumulator.positions[2].z;

            // Set the target position of the game object
            Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);
            gameObject.transform.position = targetPosition; // Use gameObject.transform to reference the game object's transform

            // Set the move speed of the game object
            linear_acumulator.moveSpeed = Random.Range(0.5f, 2f);
        }
        else
        {
            Debug.LogError("Not enough objects in the positions list");
        }
    }

}
