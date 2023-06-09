using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public Linear_Acumulator linear_acumulator; // Drag and drop the game object with the Acumulator script attached to this field in the Inspector

    public void MoveIt()
    {
        Debug.Log("Clicked to move");

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
                // Change the target position and speed of the game object
                linear_acumulator.positions[index] = new Vector3(linear_acumulator.positions[index].x + Random.Range(-3f, 3f), linear_acumulator.positions[index].y, linear_acumulator.positions[index].z);
                linear_acumulator.moveSpeed = Random.Range(0.5f, 2f);
            }
            else
            {
                Debug.Log("Object still moving");
            }
        }
    }

    
}



// you can add multiple game objects to the gameObjects list in the Linear_Acumulator class and attach the Move script to each one. When you call the MoveIt method of a Move script, it will modify the target position of the game object that has the script attached to it.

// To add game objects to the gameObjects list, you can do the following:

// In the Inspector, select the game object that has the Linear_Acumulator script attached to it.
// In the Linear_Acumulator component, find the Game Objects field and set its size to the number of game objects you want to add.
// Drag and drop each game object from the Hierarchy panel to an element of the Game Objects array in the Inspector.
// Once you have added the game objects to the list, you can attach the Move script to each one and assign a reference to the Linear_Acumulator script by dragging and dropping the game object with the Linear_Acumulator script attached to the Linear Acumulator field of each Move component in the Inspector.

// After setting up your scripts this way, you can call the MoveIt method of each Move script to move its corresponding game object.
