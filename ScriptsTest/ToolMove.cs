using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolMove : MonoBehaviour
{
    public Linear_Acumulator linear_acumulator; // Drag and drop the game object with the Acumulator script attached to this field in the Inspector

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
void Update()
{
    // Check if there are at least three objects in the gameObjects array
    if (linear_acumulator.gameObjects.Length >= 3)
    {
        // Get the X, Y, and Z positions from the desired game objects
        float targetX = linear_acumulator.gameObjects[0].transform.position.x;
        float targetY = linear_acumulator.gameObjects[1].transform.position.y;
        float targetZ = linear_acumulator.gameObjects[2].transform.position.z;

        // Set the target position of the game object
        Vector3 targetPosition = new Vector3(targetX, targetY, targetZ);

        // Output the target position for debugging
        Debug.Log("Target Position: " + targetPosition);

        transform.position = targetPosition; // Use gameObject.transform to reference the game object's transform

        // Set the move speed of the game object
        linear_acumulator.moveSpeed = 2f;
    }
    else
    {
        Debug.LogError("Not enough game objects in the gameObjects array");
    }
}

}
