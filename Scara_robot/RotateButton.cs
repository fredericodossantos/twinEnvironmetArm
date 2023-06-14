using UnityEngine;
using TMPro;

public class RotateButton : MonoBehaviour
{
    public TMP_InputField inputField;
    public ArmRotator armRotator;

    private void Start()
    {
        GetComponent<UnityEngine.UI.Button>().onClick.AddListener(RotateObject);
    }

    private void RotateObject()
    {
        if (float.TryParse(inputField.text, out float value))
        {
            armRotator.RotateArm(value);
        }
        else
        {
            Debug.LogWarning("Invalid rotation value.");
        }
    }
}
