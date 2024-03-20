// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.TestNPC
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
  public static class TestNPC
  {
    public static bool TestCardAdded;

    public static Sprite World
    {
      get
      {
        return ResourceLoader.LoadSprite("OverworldPlaceholder.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      }
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("OverworldPlaceholder.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("PlaceholderFront.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/TestGuy/test.yarn");
    }

    public static Material SpriteMat
    {
      get
      {
        return ((Renderer) ((BaseRoomItem) ((LoadedAssetsHandler.GetRoomPrefab((CardType) 300, LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour").encounterRoom) as NPCRoomHandler)._npcSelectable as BasicRoomItem))._renderers[0]).material;
      }
    }

    public static void Test(bool initial = true)
    {
      string str = "TestRoom";
      string key1 = "TestConvo";
      string key2 = "TestEncounter";
      ((Component) (LoadedAssetsHandler.GetRoomPrefab((CardType) 300, LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour").encounterRoom) as NPCRoomHandler)).transform.GetChild(0);
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/TestGuy/TestRoom.prefab").AddComponent<NPCRoomHandler>();
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
      instance1.dialog = TestNPC.Script;
      instance1.startNode = "Salt.Test.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questName = (QuestIDs) 774992;
      instance2.questsCompletedNeeded = new QuestIDs[0];
      ((Object) instance2).name = key2;
      ((BasicEncounterSO) instance2)._dialogue = key1;
      ((BasicEncounterSO) instance2).encounterRoom = str;
      ((BasicEncounterSO) instance2).signType = (SignType) 774992;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 774992
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, (BasicEncounterSO) instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = (BasicEncounterSO) instance2;
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = (CardType) 300,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo._minimumAmount = 0;
      if (!((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key2))
      {
        zoneDb1._FlavourPool = new List<string>((IEnumerable<string>) zoneDb1._FlavourPool)
        {
          key2
        }.ToArray();
        zoneDb1._deckInfo._possibleCards = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb1._deckInfo._possibleCards)
        {
          cardTypeInfo
        }.ToArray();
      }
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key2))
      {
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key2
        }.ToArray();
        zoneDb2._deckInfo._possibleCards = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb2._deckInfo._possibleCards)
        {
          cardTypeInfo
        }.ToArray();
      }
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "TestGuy" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "TestGuy" + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx",
        portrait = TestNPC.Front
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }
  }
}
