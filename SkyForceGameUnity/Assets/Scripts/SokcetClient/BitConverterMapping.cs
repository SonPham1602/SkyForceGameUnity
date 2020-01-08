using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class BitConverterMapping
{
    public static byte[] GetBytes(bool value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(char value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(double value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(short value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(int value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(long value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(float value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(ushort value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(uint value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }
    public static byte[] GetBytes(ulong value)
    {
        byte[] data = BitConverter.GetBytes(value);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return data;
    }

    private static long TripleShift(long n, int s)
    {
        if (n >= 0)
            return n >> s;
        return (n >> s) + (2 << ~s);
    }

    public static byte[] GetBytes(string value)
    {
        int strlen = value.Length;
        int utflen = 0;
        int c, count = 0, i = 0;

        for (i = 0; i < strlen; i++)
        {
            c = value[i];
            if ((c >= 0x0001) && (c <= 0x007F))
            {
                utflen++;
            }
            else if (c > 0x07FF)
            {
                utflen += 3;
            }
            else
            {
                utflen += 2;
            }
        }

        byte[] bytearr = new byte[2*utflen + 2];

        bytearr[count++] = (byte)(TripleShift(utflen, 8) & 0xFF);
        bytearr[count++] = (byte)(TripleShift(utflen, 0) & 0xFF);

        i = 0;
        for (i = 0; i < strlen; i++)
        {
            c = value[i];
            if (!((c >= 0x0001) && (c <= 0x007F))) break;
            bytearr[count++] = (byte)c;
        }

        for (; i < strlen; i++)
        {
            c = value[i];
            if ((c >= 0x0001) && (c <= 0x007F))
            {
                bytearr[count++] = (byte)c;

            }
            else if (c > 0x07FF)
            {
                bytearr[count++] = (byte)(0xE0 | ((c >> 12) & 0x0F));
                bytearr[count++] = (byte)(0x80 | ((c >> 6) & 0x3F));
                bytearr[count++] = (byte)(0x80 | ((c >> 0) & 0x3F));
            }
            else
            {
                bytearr[count++] = (byte)(0xC0 | ((c >> 6) & 0x1F));
                bytearr[count++] = (byte)(0x80 | ((c >> 0) & 0x3F));
            }
        }
        return bytearr;
    }
}
