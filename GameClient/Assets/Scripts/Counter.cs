using System.Collections;
using UnityEngine;
using GameLib;
using System;

public class Counter : MonoBehaviour
{
    WebSocket ws;
    IEnumerator Start()
    {
        ws = new WebSocket(new Uri("ws://127.0.0.1:8001/counter"));
        yield return StartCoroutine(ws.Connect());

        int counter = 1;
        while (true)
        {
            SendCounter(ws, counter);
            if(ws.error != null)
            {
                Debug.LogError($"Error: " + ws.error);
                break;
            }

            byte[] bytes = null;
            while(bytes == null)
            {
                bytes = ws.Recv();
                yield return null;
            }

            counter = RecvCounter(bytes);
            if (ws.error != null)
            {
                Debug.LogError($"Error: " + ws.error);
                break;
            }

            yield return new WaitForSeconds(1);
        }

        ws.Close();
        ws = null;
    }

    private void OnDestroy()
    {
        if(ws != null)
        {
            ws.Close();
            ws = null;
        }
    }

    int RecvCounter(byte[] bytes)
    {
        var received = new CounterPacket();
        received.Deserialize(bytes);
        Debug.Log($"counter: {received.counter}");
        return received.counter;
    }

    void SendCounter(WebSocket ws, int counter)
    {
        var packet = new CounterPacket()
        {
            counter = counter,
        };
        ws.Send(packet.Serialize());
    }
}
