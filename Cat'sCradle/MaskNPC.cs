// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.MaskNPC
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
  public static class MaskNPC
  {
    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("MaskWorld.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("MaskWorld.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("MaskHappy.png", 32);

    public static Sprite Sad => ResourceLoader.LoadSprite("MaskSad.png", 32);

    public static Sprite Finger => ResourceLoader.LoadSprite("MaskFinger.png", 32);

    public static Sprite Angry => ResourceLoader.LoadSprite("MaskAngry.png", 32);

    public static Sprite Scream => ResourceLoader.LoadSprite("MaskScream.png", 32);

    public static Sprite FirstDissolve => ResourceLoader.LoadSprite("MaskFirstDissolve.png", 32);

    public static Sprite SecondDissolve => ResourceLoader.LoadSprite("MaskSecondDissolve.png", 32);

    public static Sprite Dust => ResourceLoader.LoadSprite("MaskDust.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/MaskGuy/mask.yarn");
    }

    public static void Schizo()
    {
      string str = "FigmentRoom";
      string key1 = "FigmentConvo";
      string key2 = "FigmentEncounter";
      FlipNPCHandler flipNpcHandler = Data.Assets.LoadAsset<GameObject>("assets/MaskGuy/MaskRoom.prefab").AddComponent<FlipNPCHandler>();
      flipNpcHandler.Second = MaskNPC.Dust;
      flipNpcHandler.check = "Dusted";
      flipNpcHandler.Shake = false;
      flipNpcHandler._npcSelectable = (BaseRoomItem) ((Component) ((Component) flipNpcHandler).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      flipNpcHandler._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) flipNpcHandler._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) flipNpcHandler._npcSelectable._renderers[0]).material = TestNPC.SpriteMat;
      flipNpcHandler._extraSelectable = (BaseRoomItem) ((Component) ((Component) flipNpcHandler).transform.GetChild(1)).gameObject.AddComponent<BasicRoomItem>();
      flipNpcHandler._extraSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) flipNpcHandler._extraSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) flipNpcHandler._extraSelectable._renderers[0]).material = TestNPC.SpriteMat;
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + str))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + str, (BaseRoomHandler) flipNpcHandler);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + str] = (BaseRoomHandler) flipNpcHandler;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = key1;
      instance1.dialog = MaskNPC.Script;
      instance1.startNode = "Salt.Mask.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questName = (QuestIDs) 775012;
      instance2.questsCompletedNeeded = new QuestIDs[0];
      ((Object) instance2).name = key2;
      ((BasicEncounterSO) instance2)._dialogue = key1;
      ((BasicEncounterSO) instance2).encounterRoom = str;
      ((BasicEncounterSO) instance2).signType = (SignType) 775012;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775012
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, (BasicEncounterSO) instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = (BasicEncounterSO) instance2;
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb3 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;
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
      if (!((IEnumerable<string>) zoneDb3._FlavourPool).Contains<string>(key2))
        zoneDb3._FlavourPool = new List<string>((IEnumerable<string>) zoneDb3._FlavourPool)
        {
          key2
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "Mask" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "Mask" + PathUtils.speakerDataSuffix;
      SpeakerBundle speakerBundle1 = new SpeakerBundle();
      speakerBundle1.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
      speakerBundle1.portrait = MaskNPC.Front;
      SpeakerBundle speakerBundle2 = new SpeakerBundle();
      speakerBundle2.dialogueSound = "event:/Combat/Attack/G1/ATK_Sob";
      speakerBundle2.portrait = MaskNPC.Sad;
      SpeakerBundle speakerBundle3 = new SpeakerBundle();
      speakerBundle3.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
      speakerBundle3.portrait = MaskNPC.Finger;
      SpeakerBundle speakerBundle4 = new SpeakerBundle();
      speakerBundle4.dialogueSound = "event:/Characters/Enemies/DLC_01/Scrungie/CHR_ENM_Scrungie_Roar";
      speakerBundle4.portrait = MaskNPC.Angry;
      SpeakerBundle speakerBundle5 = new SpeakerBundle();
      speakerBundle5.dialogueSound = "event:/Characters/Player/Agon/CHR_PLR_Agon_Dx";
      speakerBundle5.portrait = MaskNPC.Scream;
      SpeakerBundle speakerBundle6 = new SpeakerBundle();
      speakerBundle6.dialogueSound = "event:/Characters/NPC/Mordrake/CHR_NPC_Mordrake_Static_Dx";
      speakerBundle6.portrait = MaskNPC.FirstDissolve;
      SpeakerBundle speakerBundle7 = new SpeakerBundle();
      speakerBundle7.dialogueSound = "event:/Characters/NPC/Mordrake/CHR_NPC_Mordrake_Static_Dx";
      speakerBundle7.portrait = MaskNPC.FirstDissolve;
      SpeakerBundle speakerBundle8 = new SpeakerBundle();
      speakerBundle8.dialogueSound = "";
      speakerBundle8.portrait = MaskNPC.Dust;
      instance3._defaultBundle = speakerBundle1;
      instance3._emotionBundles = new SpeakerEmote[8]
      {
        new SpeakerEmote()
        {
          emotion = "Happy",
          bundle = speakerBundle1
        },
        new SpeakerEmote()
        {
          emotion = "Sad",
          bundle = speakerBundle2
        },
        new SpeakerEmote()
        {
          emotion = "Finger",
          bundle = speakerBundle3
        },
        new SpeakerEmote()
        {
          emotion = "Angry",
          bundle = speakerBundle4
        },
        new SpeakerEmote()
        {
          emotion = "Scream",
          bundle = speakerBundle5
        },
        new SpeakerEmote()
        {
          emotion = "FirstDissolve",
          bundle = speakerBundle6
        },
        new SpeakerEmote()
        {
          emotion = "SecondDissolve",
          bundle = speakerBundle7
        },
        new SpeakerEmote()
        {
          emotion = "Dust",
          bundle = speakerBundle8
        }
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 775012, MaskNPC.WNPivot);
  }
}
