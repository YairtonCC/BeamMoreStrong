using System;
using System.Collections.Generic;

namespace BeamMoreStrong
{
    public class Class1
    {
        public string BeamStr { get; set; }
        public int TotalWeight { get; private set; }

        private readonly Dictionary<char, int> BASES = new Dictionary<char, int>
        {
            { '%', 10 },
            { '&', 30 },
            { '#', 90 }
        };

        public Class1(string beamStr)
        {
            BeamStr = beamStr;
            TotalWeight = 0;
        }

        public bool IsValidStructure()
        {
            if (string.IsNullOrEmpty(BeamStr) || !BASES.ContainsKey(BeamStr[0]))
                return false;

            for (int i = 1; i < BeamStr.Length; i++)
            {
                if (BeamStr[i] == '*' && BeamStr[i - 1] == '*')
                    return false;
            }

            return true;
        }

        public int CalculateWeight()
        {
            int currentSeq = 0;
            int seqWeight = 0;
            int maxBlock = 0;

            for (int i = 1; i < BeamStr.Length; i++)
            {
                char c = BeamStr[i];
                if (c == '=')
                {
                    currentSeq++;
                    seqWeight += currentSeq;
                }
                else if (c == '*')
                {
                    int blockWeight = seqWeight + seqWeight * 2;
                    if (blockWeight > maxBlock) maxBlock = blockWeight;
                    currentSeq = 0;
                    seqWeight = 0;
                }
            }

            if (seqWeight > maxBlock) maxBlock = seqWeight;
            TotalWeight = maxBlock;
            return maxBlock;
        }


        public string CheckSupport()
        {
            if (!IsValidStructure())
                return "La viga está mal construida!";

            int resistance = BASES[BeamStr[0]];
            int weight = CalculateWeight();

            if (weight <= resistance)
                return "La viga soporta el peso!";
            else
                return "La viga NO soporta el peso!";
        }
    }
}
