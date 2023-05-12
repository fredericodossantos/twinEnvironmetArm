using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acumulator : MonoBehaviour
{
    public List<Vector3> positions = new List<Vector3>();
    public GameObject[] gameObjects;

    void Start()
    {
        // Add the initial positions of the game objects to the list
        for (int i = 0; i < gameObjects.Length; i++)
        {
            positions.Add(gameObjects[i].transform.position);
        }
    }

    void Update()
    {
        // Update the positions of the game objects based on the values in the list
        for (int i = 0; i < gameObjects.Length; i++)
        {
            gameObjects[i].transform.position = positions[i];
        }
    }
}


