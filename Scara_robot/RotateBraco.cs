using UnityEngine;
using UnityEngine.UI;

public class RotateBraco : MonoBehaviour
{
    public Button rotateButton;
    public GameObject targetObject;
    public string rotationInputBraco;

    private bool isRotating = false;
    private InputField rotationInput;

    private void Start()
    {
        rotateButton.onClick.AddListener(RotateObject);
        
    }

    private void RotateObject()
    {
        if (!isRotating)
        {
            if (float.TryParse(rotationInput.text, out float rotationValue))
            {
                isRotating = true;
                targetObject.transform.Rotate(0, 0, rotationValue);
                isRotating = false;
            }
            else
            {
                Debug.LogWarning("Invalid rotation value entered.");
            }
        }
    }
}
