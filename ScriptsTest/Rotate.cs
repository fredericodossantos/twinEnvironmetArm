using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Angular_Acumulator angular_acumulator;

    public void RotateIt()
    {
        Debug.Log("Clicked to rotate");

        // Find the index of this game object in the gameObjects list
        int index = -1;
        for (int i = 0; i < angular_acumulator.gameObjects.Length; i++)
        {
            if (angular_acumulator.gameObjects[i] == gameObject)
            {
                index = i;
                break;
            }
        }

        // Check if the game object was found
        if (index != -1)
        {
            // Check if the game object is not rotating
            if (!angular_acumulator.isRotating[index])
            {
                // Change the target rotation and speed of the game object
                angular_acumulator.targetRotations[index] += Random.Range(-90f, 90f);
                angular_acumulator.rotateSpeed = 90f;//Random.Range(30f, 60f);
            }
            else
            {
                Debug.Log("Object still rotating");
            }
        }
    }
}
// You can add multiple game objects to the gameObjects list in the Angular_Acumulator class and attach the Rotate script to each one. When you call the RotateIt method of a Rotate script, it will modify the target rotation of the game object that has the script attached to it.

// To add game objects to the gameObjects list, you can do the following:

// 1. In the Inspector, select the game object that has the Angular_Acumulator script attached to it. // 2. In the Angular_Acumulator component, find the Game Objects field and set its size to the number of game objects you want to add. // 3. Drag and drop each game object from the Hierarchy panel to an element of the Game Objects array in the Inspector.

// Once you have added the game objects to the list, you can attach the Rotate script to each one and assign a reference to the Angular_Acumulator script by dragging and dropping the game object with the Angular_Acumulator script attached to the Angular Acumulator field of each Rotate component in the Inspector.

// After setting up your scripts this way, you can call the RotateIt method of each Rotate script to rotate its corresponding game object.