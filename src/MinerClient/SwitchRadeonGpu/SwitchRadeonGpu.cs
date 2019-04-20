﻿using System;
using System.IO;
using System.Reflection;

/// <summary>
/// 注意不要挪动这里的命名空间也不要挪动该代码文件所处的程序集
/// 嵌入的资源的位置和命名空间有关契约关系
/// </summary>
namespace NTMiner.SwitchRadeonGpu {
    public static class SwitchRadeonGpu {
        public static void Run(Action<bool, Exception> callback) {
            try {
                Type type = typeof(SwitchRadeonGpu);
                Assembly assembly = type.Assembly;
                string name = "switch-radeon-gpu.exe";
                string fileFullName = Path.Combine(SpecialPath.TempDirFullName, name);
                assembly.ExtractManifestResource(type, name, fileFullName);
                Windows.Cmd.RunClose(fileFullName, "--compute=on --admin --restart", waitForExit: true);
                File.Delete(fileFullName);
                callback?.Invoke(true, null);
            }
            catch (Exception e) {
                Logger.ErrorDebugLine(e.Message, e);
                callback?.Invoke(false, e);
            }
        }
    }
}
