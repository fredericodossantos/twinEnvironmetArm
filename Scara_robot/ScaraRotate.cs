using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaraRotate : MonoBehaviour
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
                Quaternion deltaRotation = Quaternion.Euler( 0f, 0f, Random.Range(-90f, 90f));
                angular_acumulator.targetRotations[index] *= deltaRotation;
                angular_acumulator.rotateSpeed = Random.Range(43f, 45f);
            }
            else
            {
                Debug.Log("Object still rotating");
            }
        }
    }
}
