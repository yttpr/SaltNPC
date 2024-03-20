using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using UnityEngine;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //embercoral
    public static class FishNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("fishoverworld.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("fishoverworld.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("fishdialogue.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/FishGuy/fish.yarn");
                return y;
            }
        }
        public static void Bowl()
        {
            string roomName = "FreddyGoldfishRoom";
            string convoName = "FreddyGoldfishConvo";
            string encounterName = "FreddyGoldfishEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/FishGuy/FishRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Fish.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775007;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775007 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 350;
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
                //List<CardTypeInfo> oldHC = new List<CardTypeInfo>(gardH._deckInfo._possibleCards);
                //oldHC.Add(card);
                //gardH._deckInfo._possibleCards = oldHC.ToArray();
            }


            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = "Freddy" + PathUtils.speakerDataSuffix;
            test.name = "Freddy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Dimitri;


            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
        }
        public static void Add()
        {
            AddSignType((SignType)775007, WNPivot);

        }
    }

    public static class BallNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("ballpit.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("ballpit.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("ballpit.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/BallsGuy/balls.yarn");
                return y;
            }
        }
        public static void Orb()
        {
            string roomName = "BallpitRoom";
            string convoName = "BallpitConvo";
            string encounterName = "BallpitEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/BallsGuy/BallsRoom.prefab").AddComponent<NPCRoomHandler>();
            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>(),
                room._npcSelectable.transform.GetChild(1).GetComponent<SpriteRenderer>()
            };

            room._npcSelectable._renderers[0].material = TestNPC.SpriteMat;
            room._npcSelectable._renderers[1].material = TestNPC.SpriteMat;


            if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + roomName)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + roomName, room);
            else LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + roomName] = room;


            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Balls.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.questName = (QuestIDs)775022;
            ret.questsCompletedNeeded = new QuestIDs[0];
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775022;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775022 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;

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
            test.speakerName = "WeedGuy" + PathUtils.speakerDataSuffix;
            test.name = "WeedGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Player/Griffin/CHR_PLR_Griffin_Dx";
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
            AddSignType((SignType)775022, WNPivot);
        }
    }
}
