using System;
using System.Dynamic;
using System.Text;

public static class CSUtil
{
    public static ExpandoObject Expando(string name1, object value1)
    {
        var ex = new ExpandoObject();
        ex.TryAdd(name1, value1);
        return ex;
    }
    public static ExpandoObject Expando(string name1, object value1, string name2, object value2)
    {
        var ex = new ExpandoObject();
        ex.TryAdd(name1, value1);
        ex.TryAdd(name2, value2);
        return ex;
    }
    public static ExpandoObject Expando(string name1, object value1, string name2, object value2, string name3, object value3)
    {
        var ex = new ExpandoObject();
        ex.TryAdd(name1, value1);
        ex.TryAdd(name2, value2);
        ex.TryAdd(name3, value3);
        return ex;
    }
    public static ExpandoObject Expando(string name1, object value1, string name2, object value2, string name3, object value3, string name4, object value4)
    {
        var ex = new ExpandoObject();
        ex.TryAdd(name1, value1);
        ex.TryAdd(name2, value2);
        ex.TryAdd(name3, value3);
        ex.TryAdd(name4, value4);
        return ex;
    }
}

public class SaveBuffer {
    public byte[] buffer;
    private int realOffset;
    public SaveBuffer(byte[] buffer, int realOffset ) {
        this.buffer = buffer;
        this.realOffset = realOffset;
    }

    public int offset 
    {
        get
        {
            return this.realOffset;
        }
    }

    public void advance(int num) {
        this.realOffset += num;
    }

    public SaveBuffer clone() {
        return new SaveBuffer(this.buffer, this.offset);
    }

    public DateTime readDate(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 16 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 16 <= endOffset);
        var wordBuf = new ReadOnlySpan<byte>(this.buffer, this.offset, 16);
        dynamic wYear   = BitConverter.ToInt16(this.buffer,0*2+this.offset);
        dynamic wMonth  = BitConverter.ToInt16(this.buffer,1*2+this.offset);
        dynamic wDay    = BitConverter.ToInt16(this.buffer,3*2+this.offset);
        dynamic wHour   = BitConverter.ToInt16(this.buffer,4*2+this.offset);
        dynamic wMinute = BitConverter.ToInt16(this.buffer,5*2+this.offset);
        dynamic wSecond = BitConverter.ToInt16(this.buffer,6*2+this.offset);
        
        dynamic wMilliseconds = BitConverter.ToInt16(this.buffer, 7 * 2 + this.offset);
        this.realOffset += 16;

        return new DateTime(wYear, wMonth, wDay, wHour, wMinute, wSecond, wMilliseconds);
    }

    public int readInt(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 4 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 4 <= endOffset);
        var rval = BitConverter.ToInt32(this.buffer,this.offset);
        this.realOffset += 4;
        return rval;
    }

    public short readShort(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 2 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 2 <= endOffset);
        var shortBuf = BitConverter.ToInt16(this.buffer, this.offset);
        this.realOffset += 2;
        return shortBuf;
    }

    public short peekShort(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 2 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 2 <= endOffset);
        var shortBuf = BitConverter.ToInt16(this.buffer, this.offset);
        return shortBuf;
    }

    public byte readByte(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 1 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 1 <= endOffset);
        var byteBuf = this.buffer[this.offset];
        this.realOffset += 1;
        return byteBuf;
    }

    public byte peekByte(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 1 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 1 <= endOffset);
        var byteBuf = this.buffer[this.offset];
        return byteBuf;
    }

    public float readFloat(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 4 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 4 <= endOffset);
        var floatBuf = BitConverter.ToSingle(this.buffer, this.offset);
        this.realOffset += 4;
        return floatBuf;
    }

    public double readDouble(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 8 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 8 <= endOffset);
        var doubleBuf = BitConverter.ToDouble(this.buffer, this.offset);
        this.realOffset += 8;
        return doubleBuf;
    }

    public string readbzString(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        var str = this.readbString(endOffset);

        // Remove the null byte at the end of the string
        return str.Substring(0,str.Length-1);
    }

    public string readbString(int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + 1 <= endOffset)) Debugger.Break();
        // console.assert(this.offset + 1 <= endOffset);
        var strLen = this.readByte(endOffset);

        // if (!(this.offset + strLen <= endOffset)) Debugger.Break();
        // console.assert(this.offset + strLen <= endOffset);
        var str = this.readString(strLen, endOffset);

        return str;
    }

    public string readString(int len, int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + len <= endOffset)) Debugger.Break();
        // console.assert(this.offset + len <= endOffset);
        var str = Encoding.UTF8.GetString(this.buffer, this.offset, len);
        this.realOffset += len;
        return str;
    }

    public byte[] readByteArray(int len, int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + len <= endOffset)) Debugger.Break();
        // console.assert(this.offset + len <= endOffset);
        var rval = new byte[len];
        Array.Copy(this.buffer, this.offset, rval, 0, len);
        this.realOffset += len;
        return rval;
    }

    public short[] readShortArray(int len, int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + (len * 2) <= endOffset)) Debugger.Break();
        // console.assert(this.offset + (len * 2) <= endOffset);
        var rval = new short[len];
        Buffer.BlockCopy(this.buffer, this.offset, rval, 0, len*2);
        this.realOffset += (len * 2);
        return rval;
    }

    public int[] readIntArray(int len, int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + (len * 4) <= endOffset)) Debugger.Break();
        // console.assert(this.offset + (len * 4) <= endOffset);
        var rval = new int[len];
        Buffer.BlockCopy(this.buffer, this.offset, rval, 0, len * 4);
        this.realOffset += (len * 4);
        return rval;
    }

    public float[] readFloatArray(int len, int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + (len * 4) <= endOffset)) Debugger.Break();
        // console.assert(this.offset + (len * 4) <= endOffset);
        var rval = new float[len];
        Buffer.BlockCopy(this.buffer, this.offset, rval, 0, len * 4);
        this.realOffset += (len * 4);
        return rval;
    }

    public double[] readDoubleArray(int len, int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        // if (!(this.offset + (len * 8) <= endOffset)) Debugger.Break();
        // console.assert(this.offset + (len * 8) <= endOffset);
        var rval = new double[len];
        Buffer.BlockCopy(this.buffer, this.offset, rval, 0, len * 8);
        this.realOffset += (len * 8);
        return rval;
    }

    public string[] readbStringArray(int len, int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        string[] ret = new string[len];
        for (var i = 0; i < len; ++i) {
            ret[i] = this.readbString(endOffset);
        }
        return ret;
    }

    public string[] readbzStringArray(int len, int? endOffset = null) {
        endOffset ??= this.buffer.Length;
        string[] ret = new string[len];
        for (var i = 0; i < len; ++i) {
            ret[i] = this.readbzString(endOffset);
        }
        return ret;
    }

};
