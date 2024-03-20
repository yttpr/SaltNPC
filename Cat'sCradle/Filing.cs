// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.Filing
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using System;
using System.IO;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public static class Filing
  {
    public static string Path = Application.dataPath + "/StreamingAssets";

    public static void CreateResourceFile(
      string resourceName,
      string path,
      string outputName,
      bool onlyIfNotExist = false)
    {
      byte[] bytes = new byte[0];
      try
      {
        bytes = ResourceLoader.ResourceBinary(resourceName);
      }
      catch (Exception ex)
      {
        Debug.Log((object) ex.Message);
        Debug.Log((object) "THIS IS A RESOURCE LOADER ERROR, YOU LOADED THE RESOURCE WRONG 4HEAD");
        Debug.Log((object) ex.StackTrace);
      }
      if (bytes.Length == 0 || onlyIfNotExist && File.Exists(path + "/" + outputName))
        return;
      File.WriteAllBytes(path + "/" + outputName, bytes);
    }

    public static void CreateYarnFile(string resourceName, bool onlyIfNotExist = false)
    {
      Filing.CreateResourceFile(resourceName, Filing.Path, resourceName, onlyIfNotExist);
    }
  }
}
