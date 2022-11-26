using System;

namespace Heroes_3_Map
{

    public class MapHandler
    {

        H3Map Map { get; set; }        
        Random random;
        MapHandlerParams Params { get; set; }

        public MapHandler(MapHandlerParams _params, H3Map map)
        {
            Map = map;
            random = new Random();
            Params = _params;
        }

        private void DrawTile(char c)
        {

            byte b = ByteFromChar(c);

            Map[currentPos] = b;
            Map[currentPos + 1] = TerrainView(b);
            if (!Params.AsciiMap.HasEvenDimensions)
            {
                int pos = currentPos + (Map.Dimension * H3Map.TILE_BYTE_LENGTH);
                Map[pos] = b;
                Map[pos + 1] = TerrainView(b);
            }
        }

        private byte ByteFromChar(char c)
        {
            
            if (Params.Method != ConversionMethod.GrayScale) //RGB
                return byte.Parse(c.ToString(), System.Globalization.NumberStyles.HexNumber);
            //else Grayscale
            byte b;
            switch (c) //TODO: Have more cases?
            {
                case ASCIIConverter.BLACK:
                    b = (byte)Params.Types[0]; break;
                case ASCIIConverter.CHARCOAL:
                    b = (byte)Params.Types[1]; break;
                case ASCIIConverter.DARKGRAY:
                    b = (byte)Params.Types[2]; break;
                case ASCIIConverter.MEDIUMGRAY:
                    b = (byte)Params.Types[3]; break;
                case ASCIIConverter.MEDIUM:
                    b = (byte)Params.Types[4]; break;
                case ASCIIConverter.GRAY:
                    b = (byte)Params.Types[5]; break;
                case ASCIIConverter.SLATEGRAY:
                    b = (byte)Params.Types[6]; break;
                case ASCIIConverter.LIGHTGRAY:
                    b = (byte)Params.Types[7]; break;
                default:
                    b = (byte)Params.Types[8]; break;
            }
            return b;
        }

        private byte TerrainView(byte b)
        {
            int terViewI;
            switch ((TileType)b)
            {
                case TileType.Rock:
                    terViewI = random.Next(0, 8); break;
                case TileType.Grass:
                case TileType.Subterranean:
                case TileType.Snow:
                case TileType.Swamp:
                case TileType.Rough:
                case TileType.Lava:
                    terViewI = random.Next(0x31, 0x49); break;
                case TileType.Sand:
                    terViewI = random.Next(0, 0x18); break;
                case TileType.Dirt:
                    terViewI = random.Next(0x15, 0x2D); break;
                case TileType.Water:
                    terViewI = random.Next(0x15, 0x21); break;
                case TileType.Wasteland:
                case TileType.Highland:
                    terViewI = random.Next(0x4D, 0x76); break;
                default: terViewI = 0x32; break;
            }

            return (byte)terViewI;
        }

        private int currentPos;

        public void Import(in int mapNumber, string saveToFile)
        {
            int startOffset = mapNumber == 2 ? Map.Map2StartOffset : Map.Map1StartOffset;
            currentPos = startOffset;
            foreach (string line in Params.AsciiMap.Lines)
            {
                foreach (char c in line)
                {
                    if (!Params.AsciiMap.HasEvenDimensions && currentPos != startOffset)
                    {
                        if ((currentPos - startOffset) % (Map.Dimension * H3Map.TILE_BYTE_LENGTH) == 0)
                            currentPos += Map.Dimension * H3Map.TILE_BYTE_LENGTH;
                    }
                    DrawTile(c); currentPos += H3Map.TILE_BYTE_LENGTH;
                }
            }
            Map.Save(saveToFile);
        }
    }
}
