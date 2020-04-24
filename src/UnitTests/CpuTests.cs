﻿using Microsoft.VisualStudio.TestTools.UnitTesting;
using NTMiner.Windows;
using System;

namespace NTMiner {
    [TestClass]
    public class CpuTests {
        [TestMethod]
        public void CpuTest1() {
            for (int i = 0; i < 100; i++) {
                Cpu.Instance.GetSensorValue(out double performance, out float temperature, out double power);
                Console.WriteLine($"使用率：{performance.ToString("f1")} % 温度：{temperature.ToString("f1")} ℃ 功耗：{power.ToString("f1")} W");
                Console.WriteLine($"PerformanceCounter CpuUsage {Cpu.Instance.GetCurrentCpuUsage().ToString("f1")}");
                System.Threading.Thread.Sleep(10);
            }
        }

        [TestMethod]
        public void CpuTest2() {
            for (int i = 0; i < 10000; i++) {
                Cpu.Instance.GetCurrentCpuUsage();
            }
        }
    }
}
