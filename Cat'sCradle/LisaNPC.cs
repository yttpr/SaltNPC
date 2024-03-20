// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.LisaNPC
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;
using Yarn.Unity;

#nullable disable
namespace Cat_sCradle
{
  public static class LisaNPC
  {
    public static GameInformationHolder info;

    public static void Wreck(string[] info)
    {
      foreach (CharacterInGameData characterInGameData in LisaNPC.info.Run.playerData.CharacterListData)
      {
        if (characterInGameData != null)
          characterInGameData.CurrentHealth = 1;
      }
      ScreenShake.Shake();
    }

    public static void Setup(DialogueRunner dialogueRunner)
    {
      // ISSUE: method pointer
      dialogueRunner.AddCommandHandler("CatsCradleExplode", new DialogueRunner.CommandHandler((object) null, __methodptr(Wreck)));
      FlipNPC.Setup(dialogueRunner);
    }

    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("hi4.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("hi4.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("hi1.png", 32);

    public static Sprite Back => ResourceLoader.LoadSprite("hi3.png", 32);

    public static Sprite Burst => ResourceLoader.LoadSprite("hi2.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/LisaGuy/lisa.yarn");
    }

    public static void Bomb()
    {
      string str = "LisaRoom";
      string key1 = "LisaConvo";
      string key2 = "LisaEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/LisaGuy/LisaRoom.prefab").AddComponent<NPCRoomHandler>();
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
      instance1.dialog = LisaNPC.Script;
      instance1.startNode = "Salt.Lisa.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questsCompletedNeeded = new QuestIDs[0];
      instance2.questName = (QuestIDs) 774995;
      ((Object) instance2).name = key2;
      ((BasicEncounterSO) instance2)._dialogue = key1;
      ((BasicEncounterSO) instance2).encounterRoom = str;
      ((BasicEncounterSO) instance2).signType = (SignType) 774995;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 774995
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
          pilePosition = (PilePositionType) 3
        }
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
      instance3.speakerName = "LisaGuy" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "LisaGuy" + PathUtils.speakerDataSuffix;
      SpeakerBundle speakerBundle1 = new SpeakerBundle();
      speakerBundle1.dialogueSound = "event:/Characters/NPC/DLC_02/CHR_NPC_DollMaster_Unmasked_Dx";
      speakerBundle1.portrait = LisaNPC.Front;
      speakerBundle1.bundleTextColor = Data.Speech;
      instance3._defaultBundle = speakerBundle1;
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      SpeakerBundle speakerBundle2 = new SpeakerBundle();
      speakerBundle2.dialogueSound = "event:/Characters/NPC/DLC_02/CHR_NPC_DollMaster_Unmasked_Dx";
      speakerBundle2.portrait = LisaNPC.Back;
      speakerBundle2.bundleTextColor = Data.Speech;
      SpeakerBundle speakerBundle3 = new SpeakerBundle();
      speakerBundle3.dialogueSound = "event:/Characters/Bosses/Heaven/CHR_BOSS_Heaven_Dth";
      speakerBundle3.portrait = LisaNPC.Burst;
      instance3._emotionBundles = new SpeakerEmote[3]
      {
        new SpeakerEmote()
        {
          emotion = "Back",
          bundle = speakerBundle2
        },
        new SpeakerEmote()
        {
          emotion = "Pop",
          bundle = speakerBundle3
        },
        new SpeakerEmote()
        {
          emotion = "Front",
          bundle = speakerBundle1
        }
      };
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 774995, LisaNPC.WNPivot);
  }
}
