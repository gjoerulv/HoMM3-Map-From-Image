using System;

namespace Heroes_3_Map
{
    public class TextMap
    {
        //public string FileName { get; private set; }

        public string[] Lines { get; private set; }

        public bool HasEvenDimensions { get; private set; }

        public TextMap(string[] lines)
        {

            Lines = lines; //File.ReadAllLines(file);
            int lengthLine1 = Lines[0].Length;

            HasEvenDimensions = lengthLine1 == Lines.Length; //TODO: check all lines

            if (!HasEvenDimensions)
                if (Lines.Length != lengthLine1 / 2) //TODO: check all lines
                    throw new Exception("Number of lines in file must be exactly like line legth, or line lenght / 2.");

            foreach (string line in Lines)
            {
                if (line.Length != lengthLine1)
                    throw new Exception("Each line must have same lenght.");
            }
        }
    }
}
