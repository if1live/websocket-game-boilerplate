using System;

namespace GameLib
{
    public interface IPacket {
        byte[] Serialize();
        void Deserialize(byte[] bytes);
    }

    public struct CounterPacket : IPacket
    {
        public int counter;
        public void Deserialize(byte[] bytes)
        {
            counter = BitConverter.ToInt32(bytes, 0);
        }

        public byte[] Serialize()
        {
            var bytes = BitConverter.GetBytes(counter);
            return bytes;
        }
    }
}