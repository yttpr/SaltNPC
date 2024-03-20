// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.GamerNPC
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;
using Yarn.Unity;

#nullable disable
namespace Cat_sCradle
{
  public static class GamerNPC
  {
    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("GamerLand.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("GamerLand.png", 32);

    public static Sprite Corpse => ResourceLoader.LoadSprite("GamerDead.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("GamerFace.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/GamerGuy/gamer.yarn");
    }

    public static void Shore()
    {
      string str = "GamerShoreRoom";
      string key1 = "GamerConvo";
      string key2 = "GamerShoreEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/GamerGuy/GamerShoreRoom.prefab").AddComponent<NPCRoomHandler>();
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
      instance1.dialog = GamerNPC.Script;
      instance1.startNode = "Salt.Gamer.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questsCompletedNeeded = new QuestIDs[0];
      instance2.questName = (QuestIDs) 775019;
      ((Object) instance2).name = key2;
      ((BasicEncounterSO) instance2)._dialogue = key1;
      ((BasicEncounterSO) instance2).encounterRoom = str;
      ((BasicEncounterSO) instance2).signType = (SignType) 775019;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775019
      };
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
      if (((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key2))
        ;
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key2))
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key2
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "Gamer" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "Gamer" + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx",
        portrait = GamerNPC.Front,
        bundleTextColor = Color32.op_Implicit(new Color32((byte) 95, (byte) 23, (byte) 23, byte.MaxValue))
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
      GamerNPC.Orpheum();
      GamerNPC.Garden();
      GamerNPC.Body();
    }

    public static void Orpheum()
    {
      string str1 = "GamerOrpheumRoom";
      string str2 = "GamerConvo";
      string key = "GamerOrpheumEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/GamerGuy/GamerOrpheumRoom.prefab").AddComponent<NPCRoomHandler>();
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
      instance1.dialog = GamerNPC.Script;
      instance1.startNode = "Salt.Gamer.Start";
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questsCompletedNeeded = new QuestIDs[1]
      {
        (QuestIDs) 775019
      };
      instance2.questName = (QuestIDs) 785019;
      ((Object) instance2).name = key;
      ((BasicEncounterSO) instance2)._dialogue = str2;
      ((BasicEncounterSO) instance2).encounterRoom = str1;
      ((BasicEncounterSO) instance2).signType = (SignType) 775019;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775019
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key, (BasicEncounterSO) instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key] = (BasicEncounterSO) instance2;
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
      if (((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key))
        ;
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
        portrait = GamerNPC.Front,
        bundleTextColor = Color32.op_Implicit(new Color32((byte) 95, (byte) 23, (byte) 23, byte.MaxValue))
      };
      instance3.portraitLooksLeft = false;
      instance3.portraitLooksCenter = false;
    }

    public static void Garden()
    {
      string str1 = "GamerGardenRoom";
      string str2 = "GamerConvo";
      string key = "GamerGardenEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/GamerGuy/GamerGardenRoom.prefab").AddComponent<NPCRoomHandler>();
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
      instance1.dialog = GamerNPC.Script;
      instance1.startNode = "Salt.Gamer.Start";
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questsCompletedNeeded = new QuestIDs[2]
      {
        (QuestIDs) 775019,
        (QuestIDs) 785019
      };
      instance2.questName = (QuestIDs) 795019;
      ((Object) instance2).name = key;
      ((BasicEncounterSO) instance2)._dialogue = str2;
      ((BasicEncounterSO) instance2).encounterRoom = str1;
      ((BasicEncounterSO) instance2).signType = (SignType) 775019;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775019
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key, (BasicEncounterSO) instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key] = (BasicEncounterSO) instance2;
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
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
      if (((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key))
        ;
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
        portrait = GamerNPC.Front,
        bundleTextColor = Color32.op_Implicit(new Color32((byte) 95, (byte) 23, (byte) 23, byte.MaxValue))
      };
      instance3.portraitLooksLeft = false;
      instance3.portraitLooksCenter = false;
    }

    public static void Body()
    {
      // ISSUE: unable to decompile the method.
    }

    public static void Add()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) 775019, GamerNPC.WNPivot);
      BrutalAPI.BrutalAPI.AddSignType((SignType) 705019, GamerNPC.Corpse);
    }

    public static IEnumerator OneCoin(OverworldManagerBG manager)
    {
      int prize = 1;
      RunDataSO run = LisaNPC.info.Run;
      string dialog = string.Format(LocUtils.LocDB.GetUIData((UILocID) 94), (object) prize);
      string uIData4 = LocUtils.LocDB.GetUIData((UILocID) 37);
      Sprite coinSprite = manager._spritesDB.GetCoinSprite(prize);
      ConfirmDialogReference dialogReference3 = new ConfirmDialogReference(dialog, uIData4, "", coinSprite, "");
      NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, (object) null, (object) dialogReference3);
      while (dialogReference3.result == 1)
      {
        yield return (object) null;
        NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, (object) null, (object) dialogReference3);
      }
      run.playerData.AddCurrency(prize);
      while (dialogReference3.result == 0)
        yield return (object) null;
      if (manager._informationHolder.UnlockableManager.TryUnlockOver100Currency(run.playerData.PlayerCurrency))
        ((MonoBehaviour) manager).StartCoroutine(manager.ProcessOverworldAchievements());
      manager.SaveProgress(true);
    }

    public static void FreeStuff(string[] info)
    {
      ((MonoBehaviour) BlueNPC.overManager).StartCoroutine(GamerNPC.OneCoin(BlueNPC.overManager));
    }

    public static void Setup(DialogueRunner dialogueRunner)
    {
      // ISSUE: method pointer
      dialogueRunner.AddCommandHandler("CatsCradleGamerCoin", new DialogueRunner.CommandHandler((object) null, __methodptr(FreeStuff)));
    }
  }
}
