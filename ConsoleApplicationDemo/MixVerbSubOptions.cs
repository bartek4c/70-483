﻿using CommandLine;

namespace ConsoleApplicationDemo
{
    public class MixVerbSubOptions
    {
        [Option("mins")]
        public int Minutes { get; set; }
        [Option("speed")]
        public int Speed { get; set; }
    }
}
