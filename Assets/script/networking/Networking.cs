using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;
using UnityEngine;
using SocketIO;

public class Networking : SocketIOComponent
{
    public override void Start()
    {
        base.Start();
        SetupEvents();
    }

    public override void Update()
    {
        base.Update();

    }

    private void SetupEvents()
    {
        On("open", (E) => {
            Debug.Log("Connection mode with server");
        });
    }
}
