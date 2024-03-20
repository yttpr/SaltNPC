// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.LevisNPC
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
  public static class LevisNPC
  {
    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("levisWalk.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("levisWalk.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("levisTalk.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/CryptoGuy/blob.yarn");
    }

    public static void Levi()
    {
      string str = "LevisRoom";
      string key1 = "LevisConvo";
      string key2 = "LevisEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/LevisGuy/LevisRoom.prefab").AddComponent<NPCRoomHandler>();
      npcRoomHandler._npcSelectable = (BaseRoomItem) ((Component) ((Component) npcRoomHandler).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      npcRoomHandler._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) npcRoomHandler._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) npcRoomHandler._npcSelectable._renderers[0]).material = TestNPC.SpriteMat;
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + str))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + str, (BaseRoomHandler) npcRoomHandler);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + str] = (BaseRoomHandler) npcRoomHandler;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = key1;
      instance1.dialog = LevisNPC.Script;
      instance1.startNode = "Salt.Levis.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      BasicEncounterSO instance2 = ScriptableObject.CreateInstance<BasicEncounterSO>();
      ((Object) instance2).name = key2;
      instance2._dialogue = key1;
      instance2.encounterRoom = str;
      instance2.signType = (SignType) 775016;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775016
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = instance2;
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;
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
      if (!((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key2))
        zoneDb1._FlavourPool = new List<string>((IEnumerable<string>) zoneDb1._FlavourPool)
        {
          key2
        }.ToArray();
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key2))
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key2
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "LevisGuyPurple" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "LevisGuyPurple" + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "event:/Characters/Player/Hans/CHR_PLR_Hans_Dx",
        portrait = LevisNPC.Front,
        bundleTextColor = Color32.op_Implicit(new Color32((byte) 215, (byte) 95, (byte) 228, byte.MaxValue))
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
      LevisNPC.SecondVoice();
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 775016, LevisNPC.WNPivot);

    public static void SecondVoice()
    {
      SpeakerData instance = ScriptableObject.CreateInstance<SpeakerData>();
      instance.speakerName = "LevisGuyYellow" + PathUtils.speakerDataSuffix;
      ((Object) instance).name = "LevisGuyYellow" + PathUtils.speakerDataSuffix;
      instance._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "event:/Characters/Player/Leviat/CHR_PLR_Leviat_Dx",
        portrait = LevisNPC.Front,
        bundleTextColor = Color32.op_Implicit(new Color32((byte) 85, (byte) 86, (byte) 13, byte.MaxValue))
      };
      instance.portraitLooksLeft = true;
      instance.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance.speakerName, instance);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance.speakerName] = instance;
    }
  }
}
