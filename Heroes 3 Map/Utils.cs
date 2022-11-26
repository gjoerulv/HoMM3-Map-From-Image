using System.IO;
using System.IO.Compression;

namespace Heroes_3_Map
{
    static class Utils
    {
        public static byte[] Compress(in byte[] data)
        {
            using (MemoryStream compressedStream = new MemoryStream())
            {
                using (GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Compress))
                {
                    zipStream.Write(data, 0, data.Length);
                    zipStream.Close();
                    return compressedStream.ToArray();
                }
            }
        }

        public static byte[] Decompress(in byte[] data)
        {
            using (MemoryStream compressedStream = new MemoryStream(data))
            {
                using (GZipStream zipStream = new GZipStream(compressedStream, CompressionMode.Decompress))
                {
                    using (MemoryStream resultStream = new MemoryStream())
                    {
                        zipStream.CopyTo(resultStream);
                        return resultStream.ToArray();
                    }
                }
            }
        }

        public static byte[] ReadBytesFromFile(string mapFile)
        {
            byte[] tempBuffer;
            using (FileStream fs = new FileStream(mapFile, FileMode.Open))
            {
                tempBuffer = new byte[fs.Length];
                fs.Read(tempBuffer, 0, (int)fs.Length);
            }
            return tempBuffer;
        }
    }
}
