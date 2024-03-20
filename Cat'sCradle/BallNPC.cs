// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.BallNPC
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
  public static class BallNPC
  {
    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("ballpit.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("ballpit.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("ballpit.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/BallsGuy/balls.yarn");
    }

    public static void Orb()
    {
      string str = "BallpitRoom";
      string key1 = "BallpitConvo";
      string key2 = "BallpitEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/BallsGuy/BallsRoom.prefab").AddComponent<NPCRoomHandler>();
      npcRoomHandler._npcSelectable = (BaseRoomItem) ((Component) ((Component) npcRoomHandler).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      npcRoomHandler._npcSelectable._renderers = new SpriteRenderer[2]
      {
        ((Component) ((Component) npcRoomHandler._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>(),
        ((Component) ((Component) npcRoomHandler._npcSelectable).transform.GetChild(1)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) npcRoomHandler._npcSelectable._renderers[0]).material = TestNPC.SpriteMat;
      ((Renderer) npcRoomHandler._npcSelectable._renderers[1]).material = TestNPC.SpriteMat;
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + str))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + str, (BaseRoomHandler) npcRoomHandler);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + str] = (BaseRoomHandler) npcRoomHandler;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = key1;
      instance1.dialog = BallNPC.Script;
      instance1.startNode = "Salt.Balls.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questName = (QuestIDs) 775022;
      instance2.questsCompletedNeeded = new QuestIDs[0];
      ((Object) instance2).name = key2;
      ((BasicEncounterSO) instance2)._dialogue = key1;
      ((BasicEncounterSO) instance2).encounterRoom = str;
      ((BasicEncounterSO) instance2).signType = (SignType) 775022;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775022
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, (BasicEncounterSO) instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = (BasicEncounterSO) instance2;
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
      instance3.speakerName = "WeedGuy" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "WeedGuy" + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "event:/Characters/Player/Griffin/CHR_PLR_Griffin_Dx",
        portrait = BallNPC.Front,
        bundleTextColor = Data.Speech
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 775022, BallNPC.WNPivot);
  }
}
