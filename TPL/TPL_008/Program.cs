Task<byte[]> data = Task.Run(() => GetData());

Task<Task<byte>> comp = data.ContinueWith(data => Task.Run(() => Compute(data.Result))); //Nochmal verschachtelter Task

byte b = comp.Unwrap().Result; //Auf inneren Task zugreifen


byte[] GetData()
{
    Random rand = new Random();
    byte[] bytes = new byte[64];
    rand.NextBytes(bytes);
    return bytes;
}

byte Compute(byte[] data)
{
    return data[0];
}