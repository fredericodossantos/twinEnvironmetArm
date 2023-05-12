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
        for (int i = 0; i < gameObjects.Length; i++)
        {
            Vector3 direction = positions[i] - gameObjects[i].transform.position;
            gameObjects[i].transform.Translate(direction * Time.deltaTime);
        }
    }

}


