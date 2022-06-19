using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;

public class Networking : MonoBehaviour 
{
    TcpClient client = new TcpClient();

    NetworkStream stream;

    const string IP = "127.0.0.2";
    const int PORT = 8080;

    const double MEM_SIZE = 5e+6;

    const int TIMEOUT_CONECTION = 5000;

    public byte[] Data = new byte[(int)MEM_SIZE];

    public bool Run = false;

    private void Start()
    {
        Connect((bool res) =>
        {
            if (res)
            {
                stream = client.GetStream();
                Run = true;
            }
            else
            {
                Debug.Log("CONNECTION FAILED!");
            }
        });
    }

    private void Update()
    {
        if (Run)
        {
            if (stream.DataAvailable)
            {
                int dataSize = stream.Read(Data, 0, Data.Length);

                string message = Encoding.UTF8.GetString(Data, 0, dataSize);

                executeCommand(message);
            }
        }
    }

    private void executeCommand(string command)
    {
        if (command == "ok")
        {
            Debug.Log("CONNECTED!");
        }
    }

    private void Connect(Action<bool> callback)
    {
        bool res = client.ConnectAsync(IP, PORT).Wait(TIMEOUT_CONECTION);
        callback(res);
    }

    private void OnApplicationQuit()
    {
        Run = false;
    }
}
