// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.Data
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using Tools;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public static class Data
  {
    private static AssetBundle _assets;

    public static AssetBundle Assets
    {
      get
      {
        if (Object.op_Equality((Object) Data._assets, (Object) null))
          Data._assets = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("npcjak"));
        return Data._assets;
      }
    }

    public static Color Speech
    {
      get
      {
        return LoadedAssetsHandler.GetSpeakerData("Admo" + PathUtils.speakerDataSuffix)._defaultBundle.bundleTextColor;
      }
    }

    public static Color Bosch
    {
      get
      {
        return LoadedAssetsHandler.GetSpeakerData(nameof (Bosch) + PathUtils.speakerDataSuffix)._defaultBundle.bundleTextColor;
      }
    }

    public static Color Dimitri
    {
      get
      {
        return LoadedAssetsHandler.GetSpeakerData(nameof (Dimitri) + PathUtils.speakerDataSuffix)._defaultBundle.bundleTextColor;
      }
    }
  }
}
