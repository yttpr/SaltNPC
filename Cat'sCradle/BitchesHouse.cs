using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Tools;
using UnityEngine;
using Yarn.Unity;
using static BrutalAPI.BrutalAPI;
using UnityEngine.Diagnostics;

namespace Cat_sCradle
{
    //anzyll
    public static class BitchesHouse
    {
        public static Sprite World => ResourceLoader.LoadSprite("bitches_house.png", 100, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("bitches_house.png", 100);
        public static Sprite Front => ResourceLoader.LoadSprite("bitches_house.png", 100);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/BitchesHouse/bitcheshouse.yarn");
                return y;
            }
        }
        public static void bitcheshouse()
        {
            string roomName = "BitchesHouseRoom";
            string convoName = "BitchesHouseConvo";
            string encounterName = "BitchesHouse";


            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/BitchesHouse/BitchesHouse.prefab").AddComponent<NPCRoomHandler>();

            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };

            room._npcSelectable._renderers[0].material = TestNPC.SpriteMat;

            if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + roomName)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + roomName, room);
            else LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + roomName] = room;


            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.BitchesHouse.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.questName = (QuestIDs)775000;
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775000;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775000 };
            ret.questsCompletedNeeded = new QuestIDs[0];
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 350;
            card._usePercentage = true;


            /*if (!gardE._FlavourPool.Contains(encounterName))
            {
                List<string> oldEF = new List<string>(gardE._FlavourPool);
                oldEF.Add(encounterName);
                gardE._FlavourPool = oldEF.ToArray();

                //List<CardTypeInfo> oldEC = new List<CardTypeInfo>(gardE._deckInfo._possibleCards);
                //oldEC.Add(card);
                //gardE._deckInfo._possibleCards = oldEC.ToArray();
            }*/

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
            test.speakerName = "BitchesHouse" + PathUtils.speakerDataSuffix;
            test.name = "BitchesHouse" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "BitchesHouse";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;


            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            //if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            //else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;

        }
        public static void Add()
        {
            AddSignType((SignType)775000, WNPivot);
            Setup();
        }

        public static bool DidCompleteQuest(Func<InGameDataSO, QuestIDs, bool> orig, InGameDataSO self, QuestIDs questName)
        {
            if (questName == (QuestIDs)775000)
            {
                Debug.Log("bitches house");
                return (UnityEngine.Random.Range(0, 100) < 96);
            }
            else if (questName == (QuestIDs)775001)
            {
                return (UnityEngine.Random.Range(0, 100) < 70);
            }
            else if (questName == (QuestIDs)775002)
            {
                return (UnityEngine.Random.Range(0, 100) < 60);
            }
            else if (questName == (QuestIDs)774992)
            {
                return (UnityEngine.Random.Range(0, 100) < 80);
            }
            else if (questName == (QuestIDs)775012)
            {
                return (UnityEngine.Random.Range(0, 100) < 50);
            }
            else if (questName == (QuestIDs)774995)
            {
                return (UnityEngine.Random.Range(0, 100) < 50);
            }
            else if (questName == (QuestIDs)775022)
            {
                return (UnityEngine.Random.Range(0, 100) < 80);
            }
            else if (questName == (QuestIDs)775023)
            {
                return (UnityEngine.Random.Range(0, 100) < 80);
            }
            else if (questName == (QuestIDs)775019)
            {
                return SaveGame.Check("GamerShore");
            }
            else if (questName == (QuestIDs)785019)
            {
                return SaveGame.Check("GamerOrpheum");
            }
            else if (questName == (QuestIDs)795019)
            {
                return SaveGame.Check("GamerGarden");
            }
            else if (questName == (QuestIDs)705019)
            {
                return false;
            }
            return orig(self, questName);
        }
        public static void Setup()
        {
            IDetour hook = new Hook(typeof(InGameDataSO).GetMethod(nameof(InGameDataSO.DidCompleteQuest), ~BindingFlags.Default), typeof(BitchesHouse).GetMethod(nameof(DidCompleteQuest), ~BindingFlags.Default));
        }

        public static void Wreck(string[] info)
        {
            UnityEngine.Diagnostics.Utils.ForceCrash(ForcedCrashCategory.Abort);
            Application.Quit();
        }
        public static void Setup(DialogueRunner dialogueRunner)
        {
            dialogueRunner.AddCommandHandler("CatsCradleEndIt", Wreck);
        }
    }
}
