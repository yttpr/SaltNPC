using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using UnityEngine;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //Peep
    public static class PitNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("HoleGuy_overworld.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("HoleGuy_overworld.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("HoleGuy_portrait.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/PitGuy/hole.yarn");
                return y;
            }
        }
        public static void Pit()
        {
            string roomName = "PitRoom";
            string convoName = "PitConvo";
            string encounterName = "PitEncounter";

            
            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/PitGuy/PitRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Pit.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)774993;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)774993 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO orphE = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO orphH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Middle };
            

            if (!orphE._FlavourPool.Contains(encounterName))
            {
                List<string> oldEF = new List<string>(orphE._FlavourPool);
                oldEF.Add(encounterName);
                orphE._FlavourPool = oldEF.ToArray();

                List<CardTypeInfo> oldEC = new List<CardTypeInfo>(orphE._deckInfo._possibleCards);
                oldEC.Add(card);
                orphE._deckInfo._possibleCards = oldEC.ToArray();
            }

            if (!orphH._FlavourPool.Contains(encounterName))
            {
                List<string> oldHF = new List<string>(orphH._FlavourPool);
                oldHF.Add(encounterName);
                orphH._FlavourPool = oldHF.ToArray();
                List<CardTypeInfo> oldHC = new List<CardTypeInfo>(orphH._deckInfo._possibleCards);
                oldHC.Add(card);
                orphH._deckInfo._possibleCards = oldHC.ToArray();
            }
            

            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = "PitGuy" + PathUtils.speakerDataSuffix;
            test.name = "PitGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;

            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;

        }
        public static void Add()
        {
            AddSignType((SignType)774993, WNPivot);
        }
    }

    public static class MinisterNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("GiggleIcon.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("GiggleIcon.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("Minister.png", 48);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/MinisterGuy/giggle.yarn");
                return y;
            }
        }
        public static void Giggle()
        {
            string roomName = "MinisterRoom";
            string convoName = "MinisterConvo";
            string encounterName = "MinisterEncounter";


            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/MinisterGuy/MinisterRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Giggle.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)774996;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)774996 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 60;
            card._usePercentage = true;
            
            /*
            if (!gardE._FlavourPool.Contains(encounterName))
            {
                List<string> oldEF = new List<string>(gardE._FlavourPool);
                oldEF.Add(encounterName);
                gardE._FlavourPool = oldEF.ToArray();

                List<CardTypeInfo> oldEC = new List<CardTypeInfo>(gardE._deckInfo._possibleCards);
                oldEC.Add(card);
                gardE._deckInfo._possibleCards = oldEC.ToArray();
            }*/

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
            test.speakerName = "Minister" + PathUtils.speakerDataSuffix;
            test.name = "Minister" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Enemies/GigglingMinister/CHR_ENM_GigglingMinister_Roar";
            //Debug.Log(testBund.dialogueSound);
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;

            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;

        }
        public static void Add()
        {
            AddSignType((SignType)774996, WNPivot);
            //Debug.Log("yeah");
        }
    }

    public static class GenericGardenNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("GardenGuy_overworld.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("GardenGuy_overworld.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("GardenGuy_portrait.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/GardenGuy/garden.yarn");
                return y;
            }
        }
        public static void Hopeless()
        {
            string roomName = "GenericGardenRoom";
            string convoName = "GenericGardenConvo";
            string encounterName = "GenericGardenEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/GardenGuy/GardenRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Garden.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775013;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775013 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 350;
            card._usePercentage = true;

            /*
            if (!gardE._FlavourPool.Contains(encounterName))
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
            test.speakerName = "GardenGuy" + PathUtils.speakerDataSuffix;
            test.name = "GardenGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/NPC/CHR_NPC_HyperDef_Dx";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;


            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
        }
        public static void Add()
        {
            AddSignType((SignType)775013, WNPivot);
        }
    }
}
