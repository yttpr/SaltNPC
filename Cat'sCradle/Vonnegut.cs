// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.Vonnegut
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using BepInEx;
using BrutalAPI;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  [BepInPlugin("Salt.KurtVonnegut", "Flavor Text NPCs Question Mark", "1.0.0")]
  [BepInDependency]
  public class Vonnegut : BaseUnityPlugin
  {
    public const bool increaseNPC = false;
    public const string ForceDialogNtf = "ForceDialogeNotif";

    public void Awake()
    {
      Vonnegut.Add();
      Hacks.Setup();
      YarnMand.Setup();
      TestNPC.Test();
      PitNPC.Pit();
      BucketNPC.Fish();
      LisaNPC.Bomb();
      MinisterNPC.Giggle();
      SmileNPC.Smile();
      MirrorNPC.Doppel();
      KetchupNPC.Sauce();
      BitchesHouse.bitcheshouse();
      MeatBaby.Fuck();
      BlueNPC.Red();
      HeartNPC.Click();
      FlipNPC.Dies();
      ChestNPC.Troll();
      HelpNPC.Song();
      FishNPC.Bowl();
      LostNPC.Found();
      SquintNPC.Squinto();
      UnoNPC.Piss();
      MagicNPC.Lobotomite();
      MaskNPC.Schizo();
      GenericGardenNPC.Hopeless();
      FleshNPC.Curse();
      CryptoNPC.Rich();
      LevisNPC.Levi();
      ScaryNPC.Fear();
      BoyGuyNPC.Urination();
      GamerNPC.Shore();
      NoNPC.Empty();
      WeedNPC.Smoke();
      BallNPC.Orb();
      ToyNPC.Doll();
      this.Logger.LogInfo((object) "Salt.KurtVonnegut loaded successfully!");
    }

    public static void Add()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) 774992, TestNPC.WNPivot);
      PitNPC.Add();
      BucketNPC.Add();
      LisaNPC.Add();
      MinisterNPC.Add();
      SmileNPC.Add();
      MirrorNPC.Add();
      KetchupNPC.Add();
      BitchesHouse.Add();
      MeatBaby.Add();
      BlueNPC.Add();
      new BlueItem(ItemPools.Extra).BlueDisciple.AddItem();
      HeartNPC.Add();
      FlipNPC.Add();
      ChestNPC.Add();
      SoundClass.Setup();
      HelpNPC.Add();
      FishNPC.Add();
      LostNPC.Add();
      SquintNPC.Add();
      UnoNPC.Add();
      MagicNPC.Add();
      MaskNPC.Add();
      GenericGardenNPC.Add();
      FleshNPC.Add();
      CryptoNPC.Add();
      LevisNPC.Add();
      ScaryNPC.Add();
      BoyGuyNPC.Add();
      GamerNPC.Add();
      NoNPC.Add();
      WeedNPC.Add();
      BallNPC.Add();
      ToyNPC.Add();
    }

    public static void search()
    {
    }

    public static void AdmoEncounter()
    {
      BasicEncounterSO basicEncounter = LoadedAssetsHandler.GetBasicEncounter("Admo_Flavour");
      Debug.Log((object) basicEncounter.DialoguePath);
      Debug.Log((object) basicEncounter.encounterRoom);
      DialogueSO dialogueData = LoadedAssetsHandler.GetDialogueData(basicEncounter.DialoguePath);
      Debug.Log((object) dialogueData.dialog);
      Debug.Log((object) dialogueData.startNode);
      Debug.Log((object) ((LoadedAssetsHandler.GetRoomPrefab((CardType) 300, basicEncounter.encounterRoom) as NPCRoomHandler)._npcSelectable as BasicRoomItem));
    }

    public static void Test()
    {
      string key1 = "TestRoom";
      string key2 = "TestConvo";
      string key3 = "TestEncounter";
      BaseRoomHandler baseRoomHandler = (BaseRoomHandler) new BasicRoomHandler();
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(key1, baseRoomHandler);
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedDialogues.Add(key2, instance1);
      BasicEncounterSO instance2 = ScriptableObject.CreateInstance<BasicEncounterSO>();
      instance2._dialogue = key2;
      instance2.encounterRoom = key3;
      instance2.signType = (SignType) 774992;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 774992
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key3))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key3, instance2);
      BrutalAPI.BrutalAPI.AddSignType((SignType) 774992, ResourceLoader.LoadSprite("spriteNotReal"));
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = (CardType) 300,
        pilePosition = (PilePositionType) 2
      };
      zoneDb1._FlavourPool = new List<string>((IEnumerable<string>) zoneDb1._FlavourPool)
      {
        key3
      }.ToArray();
      zoneDb1._deckInfo._possibleCards = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb1._deckInfo._possibleCards)
      {
        cardTypeInfo
      }.ToArray();
      zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
      {
        key3
      }.ToArray();
      zoneDb2._deckInfo._possibleCards = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb2._deckInfo._possibleCards)
      {
        cardTypeInfo
      }.ToArray();
      SpeakerData speakerData = new SpeakerData();
      speakerData.speakerName = "TESTER";
      speakerData._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "",
        portrait = ResourceLoader.LoadSprite("FaceNotReal")
      };
      speakerData.portraitLooksLeft = true;
      speakerData.portraitLooksCenter = false;
      if (LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(speakerData.speakerName))
        return;
      LoadedAssetsHandler.LoadedSpeakers.Add(speakerData.speakerName, speakerData);
    }

    public static void MoreFlavor()
    {
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = (CardType) 300,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo._minimumAmount = 20;
      cardTypeInfo._maximumAmount = 40;
      ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;
      zoneDb._deckInfo._possibleCards = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb._deckInfo._possibleCards)
      {
        cardTypeInfo
      }.ToArray();
    }

    public static void TheJarden()
    {
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = (CardType) 300,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo._minimumAmount = 20;
      cardTypeInfo._maximumAmount = 40;
      ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
      zoneDb._deckInfo._possibleCards = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb._deckInfo._possibleCards)
      {
        cardTypeInfo
      }.ToArray();
    }

    public static void Morbiud()
    {
      CardTypeInfo cardTypeInfo = new CardTypeInfo();
      cardTypeInfo._cardInfo = new CardInfo()
      {
        cardType = (CardType) 300,
        pilePosition = (PilePositionType) 2
      };
      cardTypeInfo._minimumAmount = 20;
      cardTypeInfo._maximumAmount = 40;
      ZoneBGDataBaseSO zoneDb = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;
      zoneDb._deckInfo._possibleCards = new List<CardTypeInfo>((IEnumerable<CardTypeInfo>) zoneDb._deckInfo._possibleCards)
      {
        cardTypeInfo
      }.ToArray();
    }
  }
}
