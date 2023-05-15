using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Angular_Acumulator : MonoBehaviour
{
    public GameObject[] gameObjects;
    public List<float> targetRotations = new List<float>();
    public List<bool> isRotating = new List<bool>();
    public List<float> previousAngles = new List<float>();
    public float rotateSpeed = 45f;

    void Start()
    {
        // Add the initial rotations and movement states of the game objects to the lists
        for (int i = 0; i < gameObjects.Length; i++)
        {
            targetRotations.Add(gameObjects[i].transform.eulerAngles.x);
            isRotating.Add(false);
            previousAngles.Add(0f);
        }
    }

    void Update()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Quaternion targetRotation = Quaternion.Euler(targetRotations[i], gameObjects[i].transform.eulerAngles.y, gameObjects[i].transform.eulerAngles.z);
            float angle = Quaternion.Angle(gameObjects[i].transform.rotation, targetRotation);
            float speed = Mathf.Lerp(0f, rotateSpeed, angle / 90f);
            gameObjects[i].transform.rotation = Quaternion.RotateTowards(gameObjects[i].transform.rotation, targetRotation, speed * Time.deltaTime);

            if (angle > 0.01f)
            {
                isRotating[i] = true;
            }
            else
            {
                gameObjects[i].transform.rotation = targetRotation;
                isRotating[i] = false;
            }

            // Check if the game object is oscillating
            if (Mathf.Abs(angle - previousAngles[i]) > 1f)
            {
                Debug.Log("Game object " + i + " is oscillating");
            }

            // Store the current angle for the next frame
            previousAngles[i] = angle;
        }
    }
}



// You can add multiple game objects to the gameObjects list in the Angular_Acumulator class and attach the Rotate script to each one. When you call the RotateIt method of a Rotate script, it will modify the target rotation of the game object that has the script attached to it.

// To add game objects to the gameObjects list, you can do the following:

// 1. In the Inspector, select the game object that has the Angular_Acumulator script attached to it. 
// 2. In the Angular_Acumulator component, find the Game Objects field and set its size to the number of game objects you want to add. 
// 3. Drag and drop each game object from the Hierarchy panel to an element of the Game Objects array in the Inspector.

// Once you have added the game objects to the list, you can attach the Rotate script to each one and assign a reference to the Angular_Acumulator script by dragging and dropping the game object with the Angular_Acumulator script attached to the Angular Acumulator field of each Rotate component in the Inspector.

// After setting up your scripts this way, you can call the RotateIt method of each Rotate script to rotate its corresponding game object.
