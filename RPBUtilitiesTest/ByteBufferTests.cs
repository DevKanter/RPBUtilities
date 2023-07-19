using RPBUtilities;

namespace RPBUtilitiesTest;

[TestClass]
public class ByteBufferTests
{
    [TestMethod]
    public void SizeConstructor()
    {
        var buffer = new ByteBuffer(6);

        Assert.AreEqual(buffer.Data.Length, 6);
    }

    [TestMethod]
    public void DataConstructor()
    {
        var bytes = new byte[] { 1, 2, 0, 0, 0, 3 };
        var buffer = new ByteBuffer(bytes);

        CollectionAssert.AreEqual(buffer.Data, bytes);
    }

    [TestMethod]
    public void WriteAndReadDataTypes()
    {
        var buffer = new ByteBuffer(42 + sizeof(decimal) + sizeof(bool) + sizeof(char) + 6 + 2);

        buffer.Write((byte)1);
        buffer.Write((sbyte)2);

        buffer.Write((short)3);
        buffer.Write((ushort)4);

        buffer.Write((int)5);
        buffer.Write((uint)6);

        buffer.Write((long)7);
        buffer.Write((ulong)8);

        buffer.Write((float)9.1);
        buffer.Write((double)10.1);

        buffer.Write((decimal)11.1);

        buffer.Write(true);

        buffer.Write('X');
        buffer.Write("string");



        buffer.ResetHead();

        var b = buffer.Read<byte>();
        var sb = buffer.Read<sbyte>();

        var s = buffer.Read<short>();
        var us = buffer.Read<ushort>();

        var i = buffer.Read<int>();
        var ui = buffer.Read<uint>();

        var l = buffer.Read<long>();
        var ul = buffer.Read<ulong>();

        var f = buffer.Read<float>();
        var d = buffer.Read<double>();

        var dec = buffer.Read<decimal>();

        var boo = buffer.Read<bool>();

        var c = buffer.Read<char>();
        var str = buffer.ReadString();


        Assert.AreEqual(b, 1);
        Assert.AreEqual(sb, 2);

        Assert.AreEqual(s, 3);
        Assert.AreEqual(us, 4);

        Assert.AreEqual(i, 5);
        Assert.AreEqual(ui, (uint)6);

        Assert.AreEqual(l, (long)7);
        Assert.AreEqual(ul, (ulong)8);

        Assert.AreEqual(f, (float)9.1);
        Assert.AreEqual(d, (double)10.1);

        Assert.AreEqual(dec, (decimal)11.1);

        Assert.AreEqual(boo, true);

        Assert.AreEqual(c, 'X');
        Assert.AreEqual(str, "string");

    }
}