﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Mime;
using System.Reflection;
using BenchmarkMode.Tests;
using SampSharp.GameMode;
using SampSharp.GameMode.Controllers;
using SampSharp.GameMode.Natives;
using SampSharp.GameMode.World;

namespace BenchmarkMode
{
    public class GameMode : BaseMode
    {
        

        private readonly List<ITest> _tests = new List<ITest>
        {
            new NativeIsPlayerConnected(),
            new NativeCreateDestroyVehicle(),
            new CreateDestroyVehicle(),
        };

        public override bool OnGameModeInit()
        {
            SetGameModeText("sa-mp# benchmarkmode");

            Console.WriteLine("\n--------------------------------------");
            Console.WriteLine(" SampSharp benchmark MONO test");
            Console.WriteLine("--------------------------------------\n");
            Stopwatch sw = new Stopwatch();
            foreach (var test in _tests)
            {
                int count = 0;
                sw.Start();
                while (sw.ElapsedMilliseconds < 5000)
                {
                    count ++;
                    test.Run(this);
                }
                sw.Stop();
                Console.WriteLine(" Bench for {0}: executes, by average, {1} times/ms.", test.GetType().Name, Math.Round(((float)count / sw.ElapsedMilliseconds),2));
                sw.Reset();
            }

            Native.SendRconCommand("loadfs bench");

            return true;
        }

        protected override void LoadControllers(ControllerCollection controllers)
        {
            base.LoadControllers(controllers);

            foreach (var test in _tests.OfType<IControllerTest>())
                test.LoadControllers(controllers);
        }
    }
}