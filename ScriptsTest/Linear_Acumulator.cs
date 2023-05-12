using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear_Acumulator : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public GameObject[] gameObjects;
    public float moveSpeed = 1f;
    public List<bool> isMoving = new List<bool>();

    void Start()
    {
        // Add the initial positions of the game objects to the list
        for (int i = 0; i < gameObjects.Length; i++)
        {
            positions.Add(gameObjects[i].transform.position);
            isMoving.Add(false);
        }
    } 
    void Update()
    {
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 direction = positions[i] - gameObjects[i].transform.position;
            if (direction.magnitude > 0.01f)
            {
                gameObjects[i].transform.Translate(direction * moveSpeed * Time.deltaTime);
                isMoving[i] = true;
            }
            else
            {
                isMoving[i] = false;
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


