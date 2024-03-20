// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.SoundClass
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using FMODUnity;
using System;
using System.IO;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public static class SoundClass
  {
    public static void CreateSoundBankFile(string resourceName, bool onlyIfNotExist = false)
    {
      SoundClass.CreateResourceFile(resourceName, Application.dataPath + "/StreamingAssets", resourceName + ".bank", onlyIfNotExist);
    }

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
        Debug.Log((object) "YOUR FILE DOES NOT EXIST MOTHERFUCKER");
      }
      if (bytes.Length == 0 || onlyIfNotExist && File.Exists(path + "/" + outputName))
        return;
      File.WriteAllBytes(path + "/" + outputName, bytes);
    }

    public static void Setup()
    {
      SoundClass.CreateSoundBankFile("SaltNPCShowcaseMusic");
      SoundClass.CreateSoundBankFile("SaltNPCShowcaseMusic.strings");
      RuntimeManager.LoadBank("SaltNPCShowcaseMusic", true);
      RuntimeManager.LoadBank("SaltNPCShowcaseMusic.strings", true);
    }
  }
}
