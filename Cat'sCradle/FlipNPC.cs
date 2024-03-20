// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.FlipNPC
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
  public static class FlipNPC
  {
    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("FlipWorld.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("FlipWorld.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("HOOD_IRONY2.png", 32);

    public static Sprite Fell => ResourceLoader.LoadSprite("HOOD_IRONY3.png", 32);

    public static Sprite Corpse => ResourceLoader.LoadSprite("HOOD_IRONY4.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/FlipGuy/flip.yarn");
    }

    public static void Dies()
    {
      string str = "FlipRoom";
      string key1 = "FlipConvo";
      string key2 = "FlipEncounter";
      FlipNPCHandler flipNpcHandler = Data.Assets.LoadAsset<GameObject>("assets/FlipGuy/FlipRoom.prefab").AddComponent<FlipNPCHandler>();
      flipNpcHandler.Second = FlipNPC.Corpse;
      flipNpcHandler.check = "Flipped";
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
      instance1.dialog = FlipNPC.Script;
      instance1.startNode = "Salt.Flip.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      BasicEncounterSO instance2 = ScriptableObject.CreateInstance<BasicEncounterSO>();
      ((Object) instance2).name = key2;
      instance2._dialogue = key1;
      instance2.encounterRoom = str;
      instance2.signType = (SignType) 775004;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775004
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = instance2;
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
      instance3.speakerName = "FlipGuy" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "FlipGuy" + PathUtils.speakerDataSuffix;
      SpeakerBundle speakerBundle1 = new SpeakerBundle();
      speakerBundle1.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
      speakerBundle1.portrait = FlipNPC.Front;
      speakerBundle1.bundleTextColor = Data.Speech;
      SpeakerBundle speakerBundle2 = new SpeakerBundle();
      speakerBundle2.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
      speakerBundle2.portrait = FlipNPC.Fell;
      speakerBundle2.bundleTextColor = Data.Speech;
      instance3._defaultBundle = speakerBundle1;
      instance3._emotionBundles = new SpeakerEmote[1]
      {
        new SpeakerEmote()
        {
          emotion = "Dead",
          bundle = speakerBundle2
        }
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 775004, FlipNPC.WNPivot);

    public static void Flip(string[] info)
    {
      if (LisaNPC.info.Run.GetCurrentRoomInstance() is FlipNPCHandler currentRoomInstance1)
      {
        currentRoomInstance1.DoFlip();
      }
      else
      {
        if (!(LisaNPC.info.Run.GetCurrentRoomInstance() is MultiNPCRoomHandler currentRoomInstance))
          return;
        currentRoomInstance.DoSwap();
      }
    }

    public static void Setup(DialogueRunner dialogueRunner)
    {
      // ISSUE: method pointer
      dialogueRunner.AddCommandHandler("CatsCradleFlip", new DialogueRunner.CommandHandler((object) null, __methodptr(Flip)));
    }
  }
}
