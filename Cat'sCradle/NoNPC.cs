// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.NoNPC
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public static class NoNPC
  {
    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("Mungcorpse.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("Mungcorpse.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("Mungcorpse.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/GamerGuy/gamer.yarn");
    }

    public static void Empty()
    {
      string str1 = "NoNPCRoom";
      string str2 = "NoNPCConvo";
      string key = "NoNPCEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/NoGuy/NoRoom.prefab").AddComponent<NPCRoomHandler>();
      npcRoomHandler._npcSelectable = (BaseRoomItem) ((Component) ((Component) npcRoomHandler).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      npcRoomHandler._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) npcRoomHandler._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) npcRoomHandler._npcSelectable._renderers[0]).material = TestNPC.SpriteMat;
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + str1))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + str1, (BaseRoomHandler) npcRoomHandler);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + str1] = (BaseRoomHandler) npcRoomHandler;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = str2;
      instance1.dialog = NoNPC.Script;
      instance1.startNode = "Salt.Gamer.Start";
      BasicEncounterSO instance2 = ScriptableObject.CreateInstance<BasicEncounterSO>();
      ((Object) instance2).name = key;
      instance2._dialogue = str2;
      instance2.encounterRoom = str1;
      instance2.signType = (SignType) 775020;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775020
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key, instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key] = instance2;
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;
      CardTypeInfo cardTypeInfo = new CardTypeInfo()
      {
        _cardInfo = new CardInfo()
        {
          cardType = (CardType) 300,
          pilePosition = (PilePositionType) 0
        },
        _percentage = 350,
        _usePercentage = true
      };
      if (!((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key))
        zoneDb1._FlavourPool = new List<string>((IEnumerable<string>) zoneDb1._FlavourPool)
        {
          key
        }.ToArray();
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key))
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "Gamer" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "Gamer" + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx",
        portrait = NoNPC.Front,
        bundleTextColor = Color32.op_Implicit(new Color32((byte) 95, (byte) 23, (byte) 23, byte.MaxValue))
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 775020, NoNPC.WNPivot);
  }
}
