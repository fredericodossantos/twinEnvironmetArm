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

            string[] parts = data.Split(' ');

            if (parts.Length == 5 && parts[0] == "Arm_2" && parts[1] == "rotate")
            {
                string axis = parts[2];
                float angle = float.Parse(parts[3]);
                float speed = float.Parse(parts[4]);

                RotateYAxis rotateScript = GameObject.Find(parts[0]).GetComponent<RotateYAxis>();
                if (rotateScript == null)
                {
                    Debug.LogWarning("No RotateYAxis script found on game object: " + parts[0]);
                    continue;
                }

                if (axis == "y")
                    rotateScript.yAngle = angle;
                else if (axis == "x")
                    rotateScript.xAngle = angle;
                else if (axis == "z")
                    rotateScript.zAngle = angle;

                rotateScript.speed = speed;
            }
            else
            {
                Debug.LogWarning("Invalid command format: " + data);
            }
        }
    }


}
