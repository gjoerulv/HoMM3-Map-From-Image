using System;

namespace Heroes_3_Map
{
    public enum MapVersion : byte
    {
        RestorationOfErathia = 0x0E,
        ArmageddonsBlade = 0x15,
        ShadowOfDeath = 0x1C,
        HornOfTheAbbys = 0x20
    }

    public enum ConversionMethod : byte
    {
        GrayScale, HuesOnly, MatchRGB, HueSaturationAndBrightness, DistanceRGB
    }

    public enum TileType : byte
    {
        Dirt = 0
        , Sand
        , Grass
        , Snow
        , Swamp
        , Rough
        , Subterranean
        , Lava
        , Water
        , Rock
        , Highland
        , Wasteland
    }

    public struct MapHandlerParams
    {
        private const int TILE_TYPES_LENGTH = 9;

        public ConversionMethod Method { get; set; }

        public int MapNumber;

        public TileType[] Types
        {
            get => types;
            set
            {
                types = value;
                if (types == null || types.Length != TILE_TYPES_LENGTH)
                    ThrowWrongNumerOfTileTypes();
            }
        }

        public static void ThrowWrongNumerOfTileTypes()
        {
            throw new ArgumentException("There must be " + TILE_TYPES_LENGTH + " types.");
        }

        TileType[] types;

        public TextMap AsciiMap { get; set; }

        public static MapHandlerParams Generate(ConversionMethod method, TileType[] types, string[] lines)
        {
            return new MapHandlerParams()
            {
                Method = method,
                types = types,
                AsciiMap = new TextMap(lines)
            };
        }

        public static MapHandlerParams Generate(int method, int[] types, string[] lines)
        {
            return new MapHandlerParams()
            {
                Method = (ConversionMethod)((byte)method),
                types = ToTileType(types),
                AsciiMap = new TextMap(lines)
            };
        }

        public static TileType[] ToTileType(int[] types)
        {
            if (types == null || types.Length != TILE_TYPES_LENGTH)
                ThrowWrongNumerOfTileTypes();
            TileType[] _t = new TileType[TILE_TYPES_LENGTH];
            for(int i = 0; i < TILE_TYPES_LENGTH; i++)
                _t[i] = (TileType)((byte)types[i]);
            return _t;
        }
    }
}
