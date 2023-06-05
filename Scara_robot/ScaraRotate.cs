using UnityEngine;

public class ScaraRotate : MonoBehaviour
{
    public Angular_Acumulator angular_acumulator;
    public GameObject parentArm; // Reference to the parent arm game object
    public GameObject childArm; // Reference to the child arm game object
    private Quaternion initialRelativeRotation; // Initial relative rotation between parent and child arms

    private void Start()
    {
        // Calculate the initial relative rotation
        initialRelativeRotation = Quaternion.Inverse(parentArm.transform.rotation) * childArm.transform.rotation;
    }

    public void RotateIt()
    {
        Debug.Log("Clicked to rotate");

        // Find the index of the parent arm game object in the gameObjects list
        int index = -1;
        for (int i = 0; i < angular_acumulator.gameObjects.Length; i++)
        {
            if (angular_acumulator.gameObjects[i] == parentArm)
            {
                index = i;
                break;
            }
        }

        // Check if the parent arm game object was found
        if (index != -1)
        {
            // Check if the parent arm game object is not rotating
            if (!angular_acumulator.isRotating[index])
            {
                // Change the target rotation and speed of the parent arm
                Quaternion deltaRotation = Quaternion.Euler(0f, 0f, Random.Range(-90f, 90f));
                angular_acumulator.targetRotations[index] *= deltaRotation;
                angular_acumulator.rotateSpeed = Random.Range(43f, 45f);

                // Calculate the target rotation for the child arm relative to the parent arm's rotation
                Quaternion targetRotation = parentArm.transform.rotation * initialRelativeRotation * deltaRotation;

                // Rotate the parent arm
                parentArm.transform.rotation = angular_acumulator.targetRotations[index];

                // Apply the relative rotation to the child arm
                childArm.transform.rotation = targetRotation * Quaternion.Inverse(parentArm.transform.rotation);
            }
            else
            {
                Debug.Log("Object still rotating");
            }
        }
    }
}
