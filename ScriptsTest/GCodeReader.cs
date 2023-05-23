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
            Debug.Log("trying to read the file");
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
                        Vector3 newPosition = linear_acumulator.positions[0];
                        newPosition.x = targetX;
                        linear_acumulator.positions[0] = newPosition;
                        Debug.Log("changin in X axis");
                    }
                    else if (line.StartsWith("G1 Y"))
                    {
                        float targetY = ExtractFloatValue(line, "Y");
                        Vector3 newPosition = linear_acumulator.positions[1];
                        newPosition.y = targetY;
                        linear_acumulator.positions[1] = newPosition;
                        Debug.Log("changin in Y axis");
                    }
                    else if (line.StartsWith("G1 Z"))
                    {
                        float targetZ = ExtractFloatValue(line, "Z");
                        Vector3 newPosition = linear_acumulator.positions[2];
                        newPosition.z = targetZ;
                        linear_acumulator.positions[2] = newPosition;
                        Debug.Log("changin in Z axis");
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
