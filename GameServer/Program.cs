using System;
using GameLib;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace GameServer
{
    public class Counter : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            var received = new CounterPacket();
            received.Deserialize(e.RawData);
            Console.WriteLine($"received counter: {received.counter}");

            var send = new CounterPacket()
            {
                counter = received.counter + 1,
            };
            Send(send.Serialize());
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://127.0.0.1:8001");
            wssv.AddWebSocketService<Counter>("/counter");
            wssv.Start();
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}
