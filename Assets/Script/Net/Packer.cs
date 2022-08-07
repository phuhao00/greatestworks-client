using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

public class packer 
{

    public static byte[] packData(uint messageId,byte[] data ) {

        byte[] msg = BitConverter.GetBytes(messageId);

        Int64 total = msg.Length + data.Length;
        byte[] totalByte = BitConverter.GetBytes(total);
        totalByte.Concat(msg).ToArray<byte>().Concat(data).ToArray<byte>();

        return totalByte;
    }

}
