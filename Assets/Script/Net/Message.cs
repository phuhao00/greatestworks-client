using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Message
{
    public byte[] data;
    public int startIndex = 0;

    public int StartIndex
    {
        get { return startIndex; }
    }
    public int RemainSize
    {

        get { return data.Length- startIndex; }
    }

    public void ReadMessage(int newDataCount ,Action<UInt64,byte[]> handler) {

        startIndex += newDataCount;
        while (true) {
            if (startIndex <= 4) return;
            int count = BitConverter.ToInt32(data, 0);
            if ((startIndex - 4) > count) {

                UInt64 messageId = BitConverter.ToUInt64(data, 4);
                byte[] tmp= new byte[count-8];
                Array.Copy(data, tmp, 4);
                handler(messageId, tmp);
                Array.Copy(data,count+4, data, 0, startIndex-count- 4);
                startIndex -= (count + 4);
            }else
            {
                break;
            }
        }


    }

}
