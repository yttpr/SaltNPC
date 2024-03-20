using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Text;
using Tools;
using System.Reflection;
using System.Linq;
using UnityEngine;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //Embercoral
    public static class ToyNPC
    {
        public const string CluelessTalk = "event:/CluelessTalk";
        public static Sprite World => ResourceLoader.LoadSprite("clueless_sits.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("clueless_sits.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("clueless_dialogue.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/ToyGuy/toys.yarn");
                return y;
            }
        }
        public static void Doll()
        {
            string roomName = "TeaPartyToysRoom";
            string convoName = "TeaPartyToysConvo";
            string encounterName = "TeaPartyToysEncounter";

            MultiNPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/ToyGuy/ToyRoom.prefab").AddComponent<MultiNPCRoomHandler>();
            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            room._npcSelectable._renderers[0].material = TestNPC.SpriteMat;
            room.TalkExtra = "TeaPartyNowakConvo";

            room._extraSelectable = room.transform.GetChild(1).gameObject.AddComponent<BasicRoomItem>();
            room._extraSelectable._renderers = new SpriteRenderer[]
            {
                room._extraSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            room._extraSelectable._renderers[0].material = TestNPC.SpriteMat;

            room.Artist = room.transform.GetChild(2).gameObject.AddComponent<BasicRoomItem>();
            room.Artist._renderers = new SpriteRenderer[]
            {
                room.Artist.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            room.Artist._renderers[0].material = TestNPC.SpriteMat;
            room.TalkArtist = "TeaPartyArtistConvo";

            room.Chilly = room.transform.GetChild(3).gameObject.AddComponent<BasicRoomItem>();
            room.Chilly._renderers = new SpriteRenderer[]
            {
                room.Chilly.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            room.Chilly._renderers[0].material = TestNPC.SpriteMat;
            room.TalkChilly = "TeaPartyChillyConvo";

            room.Ember = room.transform.GetChild(4).gameObject.AddComponent<BasicRoomItem>();
            room.Ember._renderers = new SpriteRenderer[]
            {
                room.Ember.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            room.Ember._renderers[0].material = TestNPC.SpriteMat;
            room.TalkEmber = "TeaPartyEmberConvo";

            room.Jub = room.transform.GetChild(5).gameObject.AddComponent<BasicRoomItem>();
            room.Jub._renderers = new SpriteRenderer[]
            {
                room.Jub.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            room.Jub._renderers[0].material = TestNPC.SpriteMat;
            room.TalkJub = "TeaPartyJubConvo";

            room.Peep = room.transform.GetChild(6).gameObject.AddComponent<BasicRoomItem>();
            room.Peep._renderers = new SpriteRenderer[]
            {
                room.Peep.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            room.Peep._renderers[0].material = TestNPC.SpriteMat;
            room.TalkPeep = "TeaPartyPeepConvo";

            room.PeepWithGun = room.transform.GetChild(7).gameObject.AddComponent<BasicRoomItem>();
            room.PeepWithGun._renderers = new SpriteRenderer[]
            {
                room.PeepWithGun.transform.GetChild(0).GetComponent<SpriteRenderer>(),
            };
            room.PeepWithGun._renderers[0].material = TestNPC.SpriteMat;
            room.TalkLeftover = "TeaPartyPeepConvo";

            room.PeepFlipCheck = "Peep";

            if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + roomName)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + roomName, room);
            else LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + roomName] = room;


            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Toys.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;
            ExtraDialogue();


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.questName = (QuestIDs)775023;
            ret.questsCompletedNeeded = new QuestIDs[0];
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775023;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775023 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 350;
            card._usePercentage = true;


            if (!gardE._FlavourPool.Contains(encounterName))
            {
                List<string> oldEF = new List<string>(gardE._FlavourPool);
                oldEF.Add(encounterName);
                gardE._FlavourPool = oldEF.ToArray();

                //List<CardTypeInfo> oldEC = new List<CardTypeInfo>(gardE._deckInfo._possibleCards);
                //oldEC.Add(card);
                //gardE._deckInfo._possibleCards = oldEC.ToArray();
            }

            if (!gardH._FlavourPool.Contains(encounterName))
            {
                List<string> oldHF = new List<string>(gardH._FlavourPool);
                oldHF.Add(encounterName);
                gardH._FlavourPool = oldHF.ToArray();
                //List<CardTypeInfo> oldHC = new List<CardTypeInfo>(gardH._deckInfo._possibleCards);
                //oldHC.Add(card);
                //gardH._deckInfo._possibleCards = oldHC.ToArray();
            }


            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = "Clueless" + PathUtils.speakerDataSuffix;
            test.name = "Clueless" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = CluelessTalk;
            testBund.portrait = Front;
            testBund.bundleTextColor = new Color32(0, 140, 255, 255);


            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
        }
        public static void Add()
        {
            AddSignType((SignType)775023, WNPivot);
            Setup();
        }
        public static void ExtraDialogue()
        {
            Nowak();
            Artist();
            Chilly();
            Ember();
            Jub();
            Peep();
        }
        public static void Nowak()
        {
            string convoName = "TeaPartyNowakConvo";
            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Toys.Nowak";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;
        }
        public static void Artist()
        {
            string convoName = "TeaPartyArtistConvo";
            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Toys.artist";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;
        }
        public static void Chilly()
        {
            string convoName = "TeaPartyChillyConvo";
            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Toys.Chilly";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;
        }
        public static void Ember()
        {
            string convoName = "TeaPartyEmberConvo";
            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Toys.Ember";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;
        }
        public static void Jub()
        {
            string convoName = "TeaPartyJubConvo";
            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Toys.Jub";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;
        }
        public static void Peep()
        {
            string convoName = "TeaPartyPeepConvo";
            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Toys.Peep";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;
        }

        public static void ForceDialogue(object sender, object args)
        {
            DialogueAndEntityContent group = args as DialogueAndEntityContent;
            DialogueDataReference dialogueDataReference = group.dialogueRef;
            int npcID = dialogueDataReference.npcID;
            TalkingEntityContentData talkingEntityData = group.entityContent;
            string dialogueReference = ((talkingEntityData != null) ? talkingEntityData.dialogue : "");
            bool flag = dialogueDataReference.songEvent != "";
            BlueNPC.overManager._inDialogue = BlueNPC.overManager._dialogueHandler.TryStartConversation(dialogueReference, flag);
            BlueNPC.overManager._dialogueIsFromRoomNPC = BlueNPC.overManager._inDialogue;
            if (flag && BlueNPC.overManager._soundManager.TryPlayDialogueMusicTrack(dialogueDataReference.songEvent))
            {
                BlueNPC.overManager._soundManager.PauseOverworldMusic(pause: true);
            }
        }
        public static void InitializeNotifications(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
            NtfUtils.notifications.AddObserver(ForceDialogue, Vonnegut.ForceDialogNtf);
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.InitializeNotifications), ~BindingFlags.Default), typeof(ToyNPC).GetMethod(nameof(InitializeNotifications), ~BindingFlags.Default));
        }
    }

    public class DialogueAndEntityContent
    {
        public DialogueDataReference dialogueRef;
        public TalkingEntityContentData entityContent;
        public DialogueAndEntityContent(DialogueDataReference dialogueRef, TalkingEntityContentData entityContent)
        {
            this.dialogueRef = dialogueRef;
            this.entityContent = entityContent;
        }
    }

    public class MultiNPCRoomHandler : NPCRoomHandler
    {
        public override BaseRoomItem[] RoomSelectables
        {
            get
            {
                if (_allSelectables == null)
                {
                    MoreGenerateAllSelectables();
                }

                return _allSelectables;
            }
        }

        public TalkingEntityContentData ContentExtra => new TalkingEntityContentData(TalkExtra);
        public string TalkExtra;
        public BaseRoomItem Artist;
        public TalkingEntityContentData ContentArtist => new TalkingEntityContentData(TalkArtist);
        public string TalkArtist;
        public BaseRoomItem Chilly;
        public TalkingEntityContentData ContentChilly => new TalkingEntityContentData(TalkChilly);
        public string TalkChilly;
        public BaseRoomItem Ember;
        public TalkingEntityContentData ContentEmber => new TalkingEntityContentData(TalkEmber);
        public string TalkEmber;
        public BaseRoomItem Jub;
        public TalkingEntityContentData ContentJub => new TalkingEntityContentData(TalkJub);
        public string TalkJub;
        public BaseRoomItem Peep;
        public TalkingEntityContentData ContentPeep => new TalkingEntityContentData(TalkPeep);
        public string TalkPeep;
        public BaseRoomItem PeepWithGun;
        public TalkingEntityContentData Leftover => new TalkingEntityContentData(TalkLeftover);
        public string TalkLeftover;

        public override void PopulateRoom(IGameCheckData gameData, IMinimalRunInfoData runData, IMinimalZoneInfoData zoneData, int dataID)
        {
            DialogueDataReference args = new DialogueDataReference(dataID, _dialogueMusic);
            _npcSelectable.SetClickData(Utils.startDialogNtf, args);
            _entityData = zoneData.GetTalkingEntityData(dataID);
            DialogueDataReference negRef = new DialogueDataReference(-1, _dialogueMusic);
            if (_extraSelectable != null)
            {
                _extraSelectable.SetClickData(Vonnegut.ForceDialogNtf, new DialogueAndEntityContent(negRef, ContentExtra));
            }
            if (Artist != null)
            {
                Artist.SetClickData(Vonnegut.ForceDialogNtf, new DialogueAndEntityContent(negRef, ContentArtist));
            }
            if (Chilly != null)
            {
                Chilly.SetClickData(Vonnegut.ForceDialogNtf, new DialogueAndEntityContent(negRef, ContentChilly));
            }
            if (Ember != null)
            {
                Ember.SetClickData(Vonnegut.ForceDialogNtf, new DialogueAndEntityContent(negRef, ContentEmber));
            }
            if (Jub != null)
            {
                Jub.SetClickData(Vonnegut.ForceDialogNtf, new DialogueAndEntityContent(negRef, ContentJub));
            }
            if (Peep != null)
            {
                Peep.SetClickData(Vonnegut.ForceDialogNtf, new DialogueAndEntityContent(negRef, ContentPeep));
            }
            if (PeepWithGun != null)
            {
                PeepWithGun.SetClickData(Vonnegut.ForceDialogNtf, new DialogueAndEntityContent(negRef, Leftover));
            }
            if (SavePerRun.Check(PeepFlipCheck)) DoSwap();
        }

        public string PeepFlipCheck;

        public void DoSwap()
        {
            this.Peep.HideItem();
            this.PeepWithGun.ShowItem();
        }

        public void MoreGenerateAllSelectables()
        {
            List<BaseRoomItem> items = new List<BaseRoomItem>();
            items.Add(_npcSelectable);
            if (_extraSelectable != null) items.Add(_extraSelectable);
            if (Artist != null) items.Add(Artist);
            if (Chilly != null) items.Add(Chilly);
            if (Ember != null) items.Add(Ember);
            if (Jub != null) items.Add(Jub);
            if (Peep != null) items.Add(Peep);
            if (PeepWithGun != null) items.Add(PeepWithGun);
            _allSelectables = items.ToArray();
        }
    }
}
