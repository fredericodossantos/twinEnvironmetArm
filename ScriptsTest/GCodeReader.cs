using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
public class GCodeReader : MonoBehaviour
{
    public Linear_Acumulator linear_acumulator;
    public string gcodeFilePath; // Path to the G-code file

    // Attach this method to the button's OnClick event in the Inspector
    public void ReadAndParseGCode()
    {
        if (string.IsNullOrEmpty(gcodeFilePath))
        {
            Debug.LogError("G-code file path is not set.");
            return;
        }

        // Read the G-code file
        try
        {
            Debug.Log("Trying to read the file");
            using (StreamReader sr = new StreamReader(gcodeFilePath))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    // Parse the G-code commands here
                    // Extract movement commands for each axis and update the target positions in the Linear_Acumulator script
                    // For example:
                    if (line.StartsWith("G1 X"))
                    {
                        float targetX = ExtractFloatValue(line, "X");
                        Vector3 newPosition = linear_acumulator.positions[1];
                        newPosition.x = targetX;
                        linear_acumulator.positions[1] = newPosition;
                        Debug.Log("Changing in X axis");

                        // Initiate movement on the X axis
                        StartCoroutine(MoveAxis(linear_acumulator, 1));
                    }
                    else if (line.StartsWith("G1 Y"))
                    {
                        float targetY = ExtractFloatValue(line, "Y");
                        Vector3 newPosition = linear_acumulator.positions[0];
                        newPosition.y = targetY;
                        linear_acumulator.positions[0] = newPosition;
                        Debug.Log("Changing in Y axis");

                        // Initiate movement on the Y axis
                        StartCoroutine(MoveAxis(linear_acumulator, 0));
                    }
                    else if (line.StartsWith("G1 Z"))
                    {
                        float targetZ = ExtractFloatValue(line, "Z");
                        Vector3 newPosition = linear_acumulator.positions[2];
                        newPosition.z = targetZ;
                        linear_acumulator.positions[2] = newPosition;
                        Debug.Log("Changing in Z axis");

                        // Initiate movement on the Z axis
                        StartCoroutine(MoveAxis(linear_acumulator, 2));
                    }
                }
            }
        }
        catch (FileNotFoundException)
        {
            Debug.LogError("G-code file not found: " + gcodeFilePath);
        }
        catch (IOException e)
        {
            Debug.LogError("Error reading G-code file: " + e.Message);
        }
    }

    // Coroutine to move an axis and wait for its completion
    private IEnumerator MoveAxis(Linear_Acumulator accumulator, int axisIndex)
    {
        accumulator.isMoving[axisIndex] = true;
        // Perform the movement logic for the specified axis
        // ...

        // Simulating movement completion by waiting for a few seconds
        yield return new WaitForSeconds(2f);

        accumulator.isMoving[axisIndex] = false;
    }


    // Coroutine to wait for movement completion of a specific axis
    private IEnumerator WaitForMovementCompletion(Linear_Acumulator accumulator, int axisIndex)
    {
        while (accumulator.isMoving[axisIndex])
        {
            yield return null;
        }
    }

    // Coroutine to wait for all movement coroutines to complete
    // Coroutine to wait for all movement coroutines to complete
    private IEnumerator WaitForAllMovementsCompletion(List<IEnumerator> movementCoroutines)
    {
        foreach (IEnumerator coroutine in movementCoroutines)
        {
            yield return StartCoroutine(coroutine);
        }

        // All movements completed, proceed to the next line in the G-code or perform any necessary action
        Debug.Log("All movements completed.");
        // Proceed to the next line or perform additional actions here
    }


    // Helper method to extract float values from G-code commands
    private float ExtractFloatValue(string line, string parameter)
    {
        int parameterIndex = line.IndexOf(parameter);
        int startIndex = parameterIndex + parameter.Length;
        int endIndex = line.IndexOf(' ', startIndex);
        string valueString = line.Substring(startIndex, endIndex - startIndex);
        return float.Parse(valueString);
    }
}
