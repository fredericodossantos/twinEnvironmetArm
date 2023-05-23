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
                string line = sr.ReadLine();
                if (!string.IsNullOrEmpty(line))
                {
                    ParseGCodeLine(line);
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

    // Parse a single G-code line and execute the corresponding movement
    private void ParseGCodeLine(string line)
    {
        string[] commands = line.Split(' ');

        foreach (string command in commands)
        {
            if (command.StartsWith("X"))
            {
                float targetX = ExtractFloatValue(command, "X");
                Vector3 newPosition = linear_acumulator.positions[0];
                newPosition.x = targetX;
                linear_acumulator.positions[0] = newPosition;
                Debug.Log("Changing in X axis");
            }
            else if (command.StartsWith("Y"))
            {
                float targetY = ExtractFloatValue(command, "Y");
                Vector3 newPosition = linear_acumulator.positions[1];
                newPosition.y = targetY;
                linear_acumulator.positions[1] = newPosition;
                Debug.Log("Changing in Y axis");
            }
            else if (command.StartsWith("Z"))
            {
                float targetZ = ExtractFloatValue(command, "Z");
                Vector3 newPosition = linear_acumulator.positions[2];
                newPosition.z = targetZ;
                linear_acumulator.positions[2] = newPosition;
                Debug.Log("Changing in Z axis");
            }
        }
    }

    // Helper method to extract float values from G-code commands
    private float ExtractFloatValue(string command, string parameter)
    {
        int parameterIndex = command.IndexOf(parameter);
        int startIndex = parameterIndex + parameter.Length;
        string valueString = command.Substring(startIndex);
        return float.Parse(valueString);
    }
}
