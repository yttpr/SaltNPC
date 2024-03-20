// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.ToyNPC
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

#nullable disable
namespace Cat_sCradle
{
  public static class ToyNPC
  {
    public const string CluelessTalk = "event:/CluelessTalk";

    public static Sprite World
    {
      get
      {
        return ResourceLoader.LoadSprite("clueless_sits.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      }
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("clueless_sits.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("clueless_dialogue.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/ToyGuy/toys.yarn");
    }

    public static void Doll()
    {
      string str = "TeaPartyToysRoom";
      string key1 = "TeaPartyToysConvo";
      string key2 = "TeaPartyToysEncounter";
      MultiNPCRoomHandler multiNpcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/ToyGuy/ToyRoom.prefab").AddComponent<MultiNPCRoomHandler>();
      multiNpcRoomHandler._npcSelectable = (BaseRoomItem) ((Component) ((Component) multiNpcRoomHandler).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      multiNpcRoomHandler._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) multiNpcRoomHandler._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) multiNpcRoomHandler._npcSelectable._renderers[0]).material = TestNPC.SpriteMat;
      multiNpcRoomHandler.TalkExtra = "TeaPartyNowakConvo";
      multiNpcRoomHandler._extraSelectable = (BaseRoomItem) ((Component) ((Component) multiNpcRoomHandler).transform.GetChild(1)).gameObject.AddComponent<BasicRoomItem>();
      multiNpcRoomHandler._extraSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) multiNpcRoomHandler._extraSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) multiNpcRoomHandler._extraSelectable._renderers[0]).material = TestNPC.SpriteMat;
      multiNpcRoomHandler.Artist = (BaseRoomItem) ((Component) ((Component) multiNpcRoomHandler).transform.GetChild(2)).gameObject.AddComponent<BasicRoomItem>();
      multiNpcRoomHandler.Artist._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) multiNpcRoomHandler.Artist).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) multiNpcRoomHandler.Artist._renderers[0]).material = TestNPC.SpriteMat;
      multiNpcRoomHandler.TalkArtist = "TeaPartyArtistConvo";
      multiNpcRoomHandler.Chilly = (BaseRoomItem) ((Component) ((Component) multiNpcRoomHandler).transform.GetChild(3)).gameObject.AddComponent<BasicRoomItem>();
      multiNpcRoomHandler.Chilly._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) multiNpcRoomHandler.Chilly).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) multiNpcRoomHandler.Chilly._renderers[0]).material = TestNPC.SpriteMat;
      multiNpcRoomHandler.TalkChilly = "TeaPartyChillyConvo";
      multiNpcRoomHandler.Ember = (BaseRoomItem) ((Component) ((Component) multiNpcRoomHandler).transform.GetChild(4)).gameObject.AddComponent<BasicRoomItem>();
      multiNpcRoomHandler.Ember._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) multiNpcRoomHandler.Ember).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) multiNpcRoomHandler.Ember._renderers[0]).material = TestNPC.SpriteMat;
      multiNpcRoomHandler.TalkEmber = "TeaPartyEmberConvo";
      multiNpcRoomHandler.Jub = (BaseRoomItem) ((Component) ((Component) multiNpcRoomHandler).transform.GetChild(5)).gameObject.AddComponent<BasicRoomItem>();
      multiNpcRoomHandler.Jub._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) multiNpcRoomHandler.Jub).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) multiNpcRoomHandler.Jub._renderers[0]).material = TestNPC.SpriteMat;
      multiNpcRoomHandler.TalkJub = "TeaPartyJubConvo";
      multiNpcRoomHandler.Peep = (BaseRoomItem) ((Component) ((Component) multiNpcRoomHandler).transform.GetChild(6)).gameObject.AddComponent<BasicRoomItem>();
      multiNpcRoomHandler.Peep._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) multiNpcRoomHandler.Peep).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) multiNpcRoomHandler.Peep._renderers[0]).material = TestNPC.SpriteMat;
      multiNpcRoomHandler.TalkPeep = "TeaPartyPeepConvo";
      multiNpcRoomHandler.PeepWithGun = (BaseRoomItem) ((Component) ((Component) multiNpcRoomHandler).transform.GetChild(7)).gameObject.AddComponent<BasicRoomItem>();
      multiNpcRoomHandler.PeepWithGun._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) multiNpcRoomHandler.PeepWithGun).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) multiNpcRoomHandler.PeepWithGun._renderers[0]).material = TestNPC.SpriteMat;
      multiNpcRoomHandler.TalkLeftover = "TeaPartyPeepConvo";
      multiNpcRoomHandler.PeepFlipCheck = "Peep";
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + str))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + str, (BaseRoomHandler) multiNpcRoomHandler);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + str] = (BaseRoomHandler) multiNpcRoomHandler;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = key1;
      instance1.dialog = ToyNPC.Script;
      instance1.startNode = "Salt.Toys.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      ToyNPC.ExtraDialogue();
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questName = (QuestIDs) 775023;
      instance2.questsCompletedNeeded = new QuestIDs[0];
      ((Object) instance2).name = key2;
      ((BasicEncounterSO) instance2)._dialogue = key1;
      ((BasicEncounterSO) instance2).encounterRoom = str;
      ((BasicEncounterSO) instance2).signType = (SignType) 775023;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775023
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
      instance3.speakerName = "Clueless" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "Clueless" + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "event:/CluelessTalk",
        portrait = ToyNPC.Front,
        bundleTextColor = Color32.op_Implicit(new Color32((byte) 0, (byte) 140, byte.MaxValue, byte.MaxValue))
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }

    public static void Add()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) 775023, ToyNPC.WNPivot);
      ToyNPC.Setup();
    }

    public static void ExtraDialogue()
    {
      ToyNPC.Nowak();
      ToyNPC.Artist();
      ToyNPC.Chilly();
      ToyNPC.Ember();
      ToyNPC.Jub();
      ToyNPC.Peep();
    }

    public static void Nowak()
    {
      string key = "TeaPartyNowakConvo";
      DialogueSO instance = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance).name = key;
      instance.dialog = ToyNPC.Script;
      instance.startNode = "Salt.Toys.Nowak";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedDialogues.Add(key, instance);
      else
        LoadedAssetsHandler.LoadedDialogues[key] = instance;
    }

    public static void Artist()
    {
      string key = "TeaPartyArtistConvo";
      DialogueSO instance = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance).name = key;
      instance.dialog = ToyNPC.Script;
      instance.startNode = "Salt.Toys.artist";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedDialogues.Add(key, instance);
      else
        LoadedAssetsHandler.LoadedDialogues[key] = instance;
    }

    public static void Chilly()
    {
      string key = "TeaPartyChillyConvo";
      DialogueSO instance = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance).name = key;
      instance.dialog = ToyNPC.Script;
      instance.startNode = "Salt.Toys.Chilly";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedDialogues.Add(key, instance);
      else
        LoadedAssetsHandler.LoadedDialogues[key] = instance;
    }

    public static void Ember()
    {
      string key = "TeaPartyEmberConvo";
      DialogueSO instance = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance).name = key;
      instance.dialog = ToyNPC.Script;
      instance.startNode = "Salt.Toys.Ember";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedDialogues.Add(key, instance);
      else
        LoadedAssetsHandler.LoadedDialogues[key] = instance;
    }

    public static void Jub()
    {
      string key = "TeaPartyJubConvo";
      DialogueSO instance = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance).name = key;
      instance.dialog = ToyNPC.Script;
      instance.startNode = "Salt.Toys.Jub";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedDialogues.Add(key, instance);
      else
        LoadedAssetsHandler.LoadedDialogues[key] = instance;
    }

    public static void Peep()
    {
      string key = "TeaPartyPeepConvo";
      DialogueSO instance = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance).name = key;
      instance.dialog = ToyNPC.Script;
      instance.startNode = "Salt.Toys.Peep";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key))
        LoadedAssetsHandler.LoadedDialogues.Add(key, instance);
      else
        LoadedAssetsHandler.LoadedDialogues[key] = instance;
    }

    public static void ForceDialogue(object sender, object args)
    {
      DialogueAndEntityContent andEntityContent = args as DialogueAndEntityContent;
      DialogueDataReference dialogueRef = andEntityContent.dialogueRef;
      int npcId = dialogueRef.npcID;
      TalkingEntityContentData entityContent = andEntityContent.entityContent;
      string dialogue = entityContent != null ? entityContent.dialogue : "";
      bool flag = dialogueRef.songEvent != "";
      BlueNPC.overManager._inDialogue = BlueNPC.overManager._dialogueHandler.TryStartConversation(dialogue, flag);
      BlueNPC.overManager._dialogueIsFromRoomNPC = BlueNPC.overManager._inDialogue;
      if (!flag || !BlueNPC.overManager._soundManager.TryPlayDialogueMusicTrack(dialogueRef.songEvent))
        return;
      BlueNPC.overManager._soundManager.PauseOverworldMusic(true);
    }

    public static void InitializeNotifications(
      Action<OverworldManagerBG> orig,
      OverworldManagerBG self)
    {
      orig(self);
      NtfUtils.notifications.AddObserver(new Action<object, object>(ToyNPC.ForceDialogue), "ForceDialogeNotif");
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (OverworldManagerBG).GetMethod("InitializeNotifications", ~BindingFlags.Default), typeof (ToyNPC).GetMethod("InitializeNotifications", ~BindingFlags.Default));
    }
  }
}
