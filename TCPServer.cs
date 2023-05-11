using System.Collections.Generic;
using UnityEngine;
using System.Collections;
using System.Net.Sockets;
using System.Net;
using System.Text;




public class TCPServer : MonoBehaviour
{
    private TcpListener server = null;
    private TcpClient client = null;

    void Start()
    {
        // Create the server and start listening for incoming connections
        IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        server = new TcpListener(ipAddress, 50000);
        server.Start();
        Debug.Log("Server started and listening for incoming connections on port 50000.");

        // Start accepting clients in a separate thread
        StartCoroutine(AcceptClients());
    }

    void OnDestroy()
    {
        // Close the server and disconnect any connected clients
        if (server != null)
        {
            server.Stop();
            Debug.Log("Server stopped.");
        }
        if (client != null)
        {
            client.Close();
            Debug.Log("Client disconnected.");
        }
    }

    private IEnumerator AcceptClients()
    {
        while (true)
        {
            // Wait for a client to connect
            yield return new WaitUntil(() => server.Pending());

            // Accept the client and start reading from it in a separate thread
            client = server.AcceptTcpClient();
            Debug.Log("Client connected.");

            StartCoroutine(ReceiveCommands());
        }
    }

    private IEnumerator ReceiveCommands()
    {
        // Create a buffer for incoming data
        byte[] buffer = new byte[1024];

        // Get the stream to read from the client
        NetworkStream stream = client.GetStream();

        while (true)
        {
            // Wait for data to be available
            yield return new WaitUntil(() => stream.DataAvailable);

            // Read the data into the buffer
            int bytesRead = stream.Read(buffer, 0, buffer.Length);

            // Convert the data to a string
            string data = Encoding.ASCII.GetString(buffer, 0, bytesRead);

            // Parse the data as a rotation command
            if (data.StartsWith("rotate"))
            {
                string[] parts = data.Split(' ');
                if (parts.Length == 4)
                {
                    string gameObjectName = parts[1];
                    float xAngle = float.Parse(parts[2]);
                    float yAngle = float.Parse(parts[3]);

                    // Rotate the game object
                    GameObject gameObject = GameObject.Find(gameObjectName);
                    gameObject.transform.Rotate(new Vector3(xAngle, yAngle, 0));
                    Debug.Log("Rotated game object " + gameObjectName + " by " + xAngle + " degrees on the x-axis and " + yAngle + " degrees on the y-axis.");
                }
            }
        }
    }
}
