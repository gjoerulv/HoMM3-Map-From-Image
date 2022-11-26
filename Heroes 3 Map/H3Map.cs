using System;
using System.IO;

namespace Heroes_3_Map
{

    public class H3Map
    {
        //Horn = 20  SoD = 1C  Rest = 0E AB = 15
        public int OFFSET_DIMENSION
        {
            get
            {
                if (Version == MapVersion.HornOfTheAbbys)
                {
                    return 0x0F; //Used to be hardcoded 0xB
                }
                    
                else return 0x05;
            }
        }

        public int OFFSET_TWOLEVELMAP => OFFSET_DIMENSION + 4; //Used to be hardcoed 0xF

        public const int TILE_BYTE_LENGTH = 7;

        private byte[] mapBuffer;

        private byte VersionByte => mapBuffer[0];
        public MapVersion Version => (MapVersion)VersionByte;
        public ushort Dimension => mapBuffer[OFFSET_DIMENSION];
        public bool IsTwoLevelMap => mapBuffer[OFFSET_TWOLEVELMAP] == 1;
        public int EntireMapByteLength => SingleMapByteLength * (IsTwoLevelMap ? 2 : 1);
        public int SingleMapByteLength => Dimension * Dimension * TILE_BYTE_LENGTH;
        public int Map1StartOffset => mapStartOffset;

        public int Map2StartOffset
        {
            get
            {
                if (!IsTwoLevelMap)
                    throw new Exception("Can't find map 2 on a 1 level map.");
                return mapStartOffset + SingleMapByteLength;
            }
        }

        private int mapStartOffset = 0;
        public string MapFile { get; private set; }

        private int SetMap1StartOffset()
        {
            mapStartOffset = 0;
            for (int i = EntireMapByteLength + TILE_BYTE_LENGTH + OFFSET_TWOLEVELMAP + 4; i < mapBuffer.Length; i++)
            {
                CheckStartPositionOnIndex(i, ref mapStartOffset);
                if (mapStartOffset != 0) break;
            }

            if (mapStartOffset <= 0)
                throw new ArgumentException("Could not detrmine start position of Map.");
            mapStartOffset = mapStartOffset - EntireMapByteLength + TILE_BYTE_LENGTH;
            if (mapStartOffset < OFFSET_DIMENSION + 4 || mapBuffer[mapStartOffset] > (byte)TileType.Wasteland)
                throw new ArgumentException("Bad Position for starting of map.");
            return mapStartOffset;
        }

        private void CheckStartPositionOnIndex(in int i, ref int mapStartOffset)
        {
            if (i + 11 > mapBuffer.Length)
            {
                mapStartOffset = -1;
                return;
            }
            //41 56 57 6D 72 6E 64 30 2E 64 65 66 FF
            if (mapBuffer[i] == 0x41 && 
                mapBuffer[i + 1] == 0x56 && 
                mapBuffer[i + 2] == 0x57 &&
                mapBuffer[i + 3] == 0x6D && 
                mapBuffer[i + 4] == 0x72 &&
                mapBuffer[i + 8] == 0x2E && 
                mapBuffer[i + 12] == 0xFF)
                mapStartOffset = i - 15;
        }

        public H3Map(string mapFile)
        {
            mapBuffer = Utils.Decompress(Utils.ReadBytesFromFile(mapFile));
            SetMap1StartOffset();
            MapFile = mapFile;
        }

        public byte this[int index]
        {
            get => mapBuffer[index];
            set => mapBuffer[index] = value;
        }

        public void Save(string saveToFile)
        {
            byte[] compressedBuffer = Utils.Compress(mapBuffer);
            File.WriteAllBytes(saveToFile, compressedBuffer);
        }
    }
}
