using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;

public class BinaryReaderConverter : BinaryReader
{
    public BinaryReaderConverter(Stream input) : base(input)
    { }

    public BinaryReaderConverter(byte[] input) : base(new MemoryStream(input))
    { }

    public override Stream BaseStream => base.BaseStream;

    public override void Close()
    {
        base.Close();
    }

    public override bool Equals(object obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public override int PeekChar()
    {
        return base.PeekChar();
    }

    public override int Read()
    {
        return base.Read();
    }

    public override int Read(byte[] buffer, int index, int count)
    {
        return base.Read(buffer, index, count);
    }

    public override int Read(char[] buffer, int index, int count)
    {
        return base.Read(buffer, index, count);
    }

    public override bool ReadBoolean()
    {
        return base.ReadBoolean();
    }

    public override byte ReadByte()
    {
        return base.ReadByte();
    }

    public override byte[] ReadBytes(int count)
    {
        return base.ReadBytes(count);
    }

    public override char ReadChar()
    {
        return base.ReadChar();
    }

    public override char[] ReadChars(int count)
    {
        return base.ReadChars(count);
    }

    public override decimal ReadDecimal()
    {
        return base.ReadDecimal();
    }

    public override double ReadDouble()
    {
        var data = base.ReadBytes(8);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return BitConverter.ToDouble(data, 0);
    }

    public override int ReadInt32()
    {
        var data = base.ReadBytes(4);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return BitConverter.ToInt32(data, 0);
    }

    public override Int16 ReadInt16()
    {
        var data = base.ReadBytes(2);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return BitConverter.ToInt16(data, 0);
    }

    public override Int64 ReadInt64()
    {
        var data = base.ReadBytes(8);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return BitConverter.ToInt64(data, 0);
    }

    public override UInt32 ReadUInt32()
    {
        var data = base.ReadBytes(4);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return BitConverter.ToUInt32(data, 0);
    }

    public override sbyte ReadSByte()
    {
        return base.ReadSByte();
    }

    public override float ReadSingle()
    {
        var data = base.ReadBytes(4);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return BitConverter.ToSingle(data, 0);
    }

    public override string ReadString()
    {
        int utflen = base.ReadInt16();
        byte[] bytearr = base.ReadBytes(utflen);
        // The number of chars produced may be less than utflen
        return Encoding.UTF8.GetString(bytearr);
    }

    public override ushort ReadUInt16()
    {
        var data = base.ReadBytes(2);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return BitConverter.ToUInt16(data, 0);
    }

    public override ulong ReadUInt64()
    {
        var data = base.ReadBytes(8);
        if (BitConverter.IsLittleEndian)
            Array.Reverse(data);
        return BitConverter.ToUInt64(data, 0);
    }

    public override string ToString()
    {
        return base.ToString();
    }

    protected override void Dispose(bool disposing)
    {
        base.Dispose(disposing);
    }

    protected override void FillBuffer(int numBytes)
    {
        base.FillBuffer(numBytes);
    }

}
