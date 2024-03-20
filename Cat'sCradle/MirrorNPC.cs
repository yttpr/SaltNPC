﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using UnityEngine;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //Chillybonez
    public static class MirrorNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("DopWorld.png", 24, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("DopWorld.png", 24);
        public static Sprite Front => ResourceLoader.LoadSprite("DopFace.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/MirrorGuy/mirror.yarn");
                return y;
            }
        }
        public static void Doppel()
        {
            string roomName = "MirrorRoom";
            string convoName = "MirrorConvo";
            string encounterName = "MirrorEncounter";


            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/MirrorGuy/MirrorRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Mirror.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)774998;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)774998 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 35;
            card._usePercentage = true;


            if (!gardE._FlavourPool.Contains(encounterName))
            {
                //List<string> oldEF = new List<string>(gardE._FlavourPool);
                //oldEF.Add(encounterName);
                //gardE._FlavourPool = oldEF.ToArray();

                //List<CardTypeInfo> oldEC = new List<CardTypeInfo>(gardE._deckInfo._possibleCards);
                //oldEC.Add(card);
                //gardE._deckInfo._possibleCards = oldEC.ToArray();
            }

            if (!gardH._FlavourPool.Contains(encounterName))
            {
                List<string> oldHF = new List<string>(gardH._FlavourPool);
                oldHF.Add(encounterName);
                gardH._FlavourPool = oldHF.ToArray();
                List<CardTypeInfo> oldHC = new List<CardTypeInfo>(gardH._deckInfo._possibleCards);
                oldHC.Add(card);
                gardH._deckInfo._possibleCards = oldHC.ToArray();
            }


            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = "Mirror" + PathUtils.speakerDataSuffix;
            test.name = "Mirror" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Bosch;


            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;
            
            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;

        }
        public static void Add()
        {
            AddSignType((SignType)774998, WNPivot);
        }
    }

    public static class HeartNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("HeartWorld.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("HeartWorld.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("HeartFace.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/HeartGuy/heart.yarn");
                return y;
            }
        }
        public static void Click()
        {
            string roomName = "HeartRoom";
            string convoName = "HeartConvo";
            string encounterName = "HeartEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/HeartGuy/HeartRoom.prefab").AddComponent<NPCRoomHandler>();

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
            log.startNode = "Salt.Heart.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775003;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775003 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;

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
            test.speakerName = "HeartClick" + PathUtils.speakerDataSuffix;
            test.name = "HeartClick" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Combat/Attack/DLC_01/ATK_Mandibles";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;

            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
            SecondVoice();
        }
        public static void Add()
        {
            AddSignType((SignType)775003, WNPivot);

        }
        public static void SecondVoice()
        {
            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = "HeartVoice" + PathUtils.speakerDataSuffix;
            test.name = "HeartVoice" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/NPC/Mordrake/CHR_NPC_Mordrake_Fleshy_Dx";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;

            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
        }
    }
}
