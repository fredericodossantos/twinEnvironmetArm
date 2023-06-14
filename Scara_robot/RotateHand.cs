using UnityEngine;
using UnityEngine.UI;

public class RotateHand : MonoBehaviour
{
    public Button rotateButton;
    public GameObject targetObject;

    private bool isRotating = false;

    private void Start()
    {
        rotateButton.onClick.AddListener(RotateObject);
    }

    private void RotateObject()
    {
        if (!isRotating)
        {
            isRotating = true;
            targetObject.transform.Rotate(0, 0, 30f);
            isRotating = false;
        }
    }
}