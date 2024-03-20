// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.HelpNPC
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
  public static class HelpNPC
  {
    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("Computer.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("Computer.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("Screen.png", 32);

    public static Sprite Static => ResourceLoader.LoadSprite("Static.png", 32);

    public static Sprite Corpse => ResourceLoader.LoadSprite("Off.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/HelpGuy/help.yarn");
    }

    public static void Song()
    {
      string str = "HelpRoom";
      string key1 = "HelpConvo";
      string key2 = "HelpEncounter";
      FlipNPCHandler flipNpcHandler = Data.Assets.LoadAsset<GameObject>("assets/HelpGuy/HelpRoom.prefab").AddComponent<FlipNPCHandler>();
      flipNpcHandler.Second = HelpNPC.Corpse;
      flipNpcHandler.check = "Off";
      flipNpcHandler._dialogueMusic = "";
      flipNpcHandler.Shake = false;
      flipNpcHandler._npcSelectable = (BaseRoomItem) ((Component) ((Component) flipNpcHandler).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      flipNpcHandler._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) flipNpcHandler._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) flipNpcHandler._npcSelectable._renderers[0]).material = TestNPC.SpriteMat;
      flipNpcHandler._extraSelectable = (BaseRoomItem) ((Component) ((Component) flipNpcHandler).transform.GetChild(2)).gameObject.AddComponent<BasicRoomItem>();
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
      instance1.dialog = HelpNPC.Script;
      instance1.startNode = "Salt.Help.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      BasicEncounterSO instance2 = ScriptableObject.CreateInstance<BasicEncounterSO>();
      ((Object) instance2).name = key2;
      instance2._dialogue = key1;
      instance2.encounterRoom = str;
      instance2.signType = (SignType) 775006;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775006
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = instance2;
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
      if (((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key2))
        ;
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key2))
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key2
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "Help" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "Help" + PathUtils.speakerDataSuffix;
      SpeakerBundle speakerBundle1 = new SpeakerBundle();
      speakerBundle1.dialogueSound = "event:/GlassBeach";
      speakerBundle1.portrait = HelpNPC.Front;
      SpeakerBundle speakerBundle2 = new SpeakerBundle();
      speakerBundle2.dialogueSound = "";
      speakerBundle2.portrait = HelpNPC.Static;
      SpeakerBundle speakerBundle3 = new SpeakerBundle();
      speakerBundle3.dialogueSound = "";
      speakerBundle3.portrait = HelpNPC.Corpse;
      instance3._defaultBundle = speakerBundle1;
      instance3._emotionBundles = new SpeakerEmote[3]
      {
        new SpeakerEmote()
        {
          emotion = "Screen",
          bundle = speakerBundle1
        },
        new SpeakerEmote()
        {
          emotion = "Static",
          bundle = speakerBundle2
        },
        new SpeakerEmote()
        {
          emotion = "Off",
          bundle = speakerBundle3
        }
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 775006, HelpNPC.WNPivot);
  }
}
