using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_XYZ : MonoBehaviour
{
    public enum MovementAxis
    {
        X,
        Y,
        Z
    }

    public Linear_Acumulator linear_acumulator; // Drag and drop the game object with the Acumulator script attached to this field in the Inspector
    public MovementAxis movementAxis = MovementAxis.X; // Serialized variable indicating the axis of movement

    public void MoveIt()
    {
        // Debug.Log("Clicked to move");

        // Find the index of this game object in the gameObjects list
        int index = -1;
        for (int i = 0; i < linear_acumulator.gameObjects.Length; i++)
        {
            if (linear_acumulator.gameObjects[i] == gameObject)
            {
                index = i;
                break;
            }
        }

        // Check if the game object was found
        if (index != -1)
        {
            // Check if the game object is not moving
            if (!linear_acumulator.isMoving[index])
            {
                // Change the target position and speed of the game object based on the selected axis
                Vector3 targetPosition = linear_acumulator.positions[index];
                float randomOffset = Random.Range(-3f, 3f);
                
                switch (movementAxis)
                {
                    case MovementAxis.X:
                        targetPosition.x += randomOffset;
                        break;
                    case MovementAxis.Y:
                        targetPosition.y += randomOffset;
                        break;
                    case MovementAxis.Z:
                        targetPosition.z += randomOffset;
                        break;
                }
                
                linear_acumulator.positions[index] = targetPosition;
                linear_acumulator.moveSpeed = Random.Range(0.5f, 2f);
            }
            else
            {
                Debug.Log("Object still moving");
            }
        }
    }
}
