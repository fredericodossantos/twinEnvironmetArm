using System.Collections;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using UnityEngine;

public class TCPServer : MonoBehaviour
{
    private TcpListener listener;
    private Dictionary<string, RotateScript> rotations;

    void Start()
    {
        listener = new TcpListener(IPAddress.Any, 50000);
        listener.Start();
        Debug.Log("Server started and listening for incoming connections on port 50000.");

        rotations = new Dictionary<string, RotateScript>();

        StartCoroutine(AcceptClients());
    }

    void OnDestroy()
    {
        if (listener != null)
        {
            listener.Stop();
            Debug.Log("Server stopped.");
        }
    }

    private IEnumerator AcceptClients()
    {
        while (true)
        {
            yield return new WaitUntil(() => listener.Pending());

            TcpClient client = listener.AcceptTcpClient();
            Debug.Log("Client connected from " + ((IPEndPoint)client.Client.RemoteEndPoint).Address.ToString());

            StartCoroutine(ReceiveCommands(client));
        }
    }

    private IEnumerator ReceiveCommands(TcpClient client)
    {
        NetworkStream stream = client.GetStream();

        byte[] buffer = new byte[1024];

        while (true)
        {
            yield return new WaitUntil(() => stream.DataAvailable);

            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            if (data.StartsWith("rotate"))
            {
                string[] parts = data.Split(' ');
                if (parts.Length == 3)
                {
                    string axis = parts[1];
                    float speed = float.Parse(parts[2]);

                    RotateScript rotateScript;
                    if (!rotations.TryGetValue(axis, out rotateScript))
                    {
                        GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
                        cube.name = axis + "Cube";

                        rotateScript = cube.AddComponent<RotateScript>();
                        if (axis == "x")
                            rotateScript.xAngle = 1f;
                        else if (axis == "y")
                            rotateScript.yAngle = 1f;
                        else if (axis == "z")
                            rotateScript.zAngle = 1f;

                        rotations.Add(axis, rotateScript);
                    }

                    rotateScript.speed = speed;
                }
                else
                {
                    Debug.LogWarning("Invalid rotation command format: " + data);
                }
            }
        }
    }
}
