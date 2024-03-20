// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.BitchesHouse
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Tools;
using UnityEngine;
using UnityEngine.Diagnostics;
using Yarn.Unity;

#nullable disable
namespace Cat_sCradle
{
  public static class BitchesHouse
  {
    public static Sprite World
    {
      get
      {
        return ResourceLoader.LoadSprite("bitches_house.png", 100, new Vector2?(new Vector2(0.5f, 0.0f)));
      }
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("bitches_house.png", 100);

    public static Sprite Front => ResourceLoader.LoadSprite("bitches_house.png", 100);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/BitchesHouse/bitcheshouse.yarn");
    }

    public static void bitcheshouse()
    {
      string str = "BitchesHouseRoom";
      string key1 = "BitchesHouseConvo";
      string key2 = nameof (BitchesHouse);
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/BitchesHouse/BitchesHouse.prefab").AddComponent<NPCRoomHandler>();
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
      instance1.dialog = BitchesHouse.Script;
      instance1.startNode = "Salt.BitchesHouse.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questName = (QuestIDs) 775000;
      ((Object) instance2).name = key2;
      ((BasicEncounterSO) instance2)._dialogue = key1;
      ((BasicEncounterSO) instance2).encounterRoom = str;
      ((BasicEncounterSO) instance2).signType = (SignType) 775000;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775000
      };
      instance2.questsCompletedNeeded = new QuestIDs[0];
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, (BasicEncounterSO) instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = (BasicEncounterSO) instance2;
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
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key2))
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key2
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = nameof (BitchesHouse) + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = nameof (BitchesHouse) + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = nameof (BitchesHouse),
        portrait = BitchesHouse.Front,
        bundleTextColor = Data.Speech
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
    }

    public static void Add()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) 775000, BitchesHouse.WNPivot);
      BitchesHouse.Setup();
    }

    public static bool DidCompleteQuest(
      Func<InGameDataSO, QuestIDs, bool> orig,
      InGameDataSO self,
      QuestIDs questName)
    {
      if (questName == 775000)
      {
        Debug.Log((object) "bitches house");
        return Random.Range(0, 100) < 96;
      }
      if (questName == 775001)
        return Random.Range(0, 100) < 70;
      if (questName == 775002)
        return Random.Range(0, 100) < 60;
      if (questName == 774992)
        return Random.Range(0, 100) < 80;
      if (questName == 775012 || questName == 774995)
        return Random.Range(0, 100) < 50;
      if (questName == 775022 || questName == 775023)
        return Random.Range(0, 100) < 80;
      if (questName == 775019)
        return SaveGame.Check("GamerShore");
      if (questName == 785019)
        return SaveGame.Check("GamerOrpheum");
      if (questName == 795019)
        return SaveGame.Check("GamerGarden");
      return questName != 705019 && orig(self, questName);
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (InGameDataSO).GetMethod("DidCompleteQuest", ~BindingFlags.Default), typeof (BitchesHouse).GetMethod("DidCompleteQuest", ~BindingFlags.Default));
    }

    public static void Wreck(string[] info)
    {
      Utils.ForceCrash((ForcedCrashCategory) 2);
      Application.Quit();
    }

    public static void Setup(DialogueRunner dialogueRunner)
    {
      // ISSUE: method pointer
      dialogueRunner.AddCommandHandler("CatsCradleEndIt", new DialogueRunner.CommandHandler((object) null, __methodptr(Wreck)));
    }
  }
}
