using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using UnityEngine;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //Tairbaz
    public static class BucketNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("BucketWorld.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("BucketWorld.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("BucketFace.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/BucketGuy/bucket.yarn");
                return y;
            }
        }
        public static void Fish()
        {
            string roomName = "BucketRoom";
            string convoName = "BucketConvo";
            string encounterName = "BucketEncounter";


            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/BucketGuy/BucketRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Bucket.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)774994;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)774994 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO orphE = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO orphH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;

            //CardTypeInfo card = new CardTypeInfo();
            //card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Middle };

            if (!orphE._FlavourPool.Contains(encounterName))
            {
                List<string> oldEF = new List<string>(orphE._FlavourPool);
                oldEF.Add(encounterName);
                orphE._FlavourPool = oldEF.ToArray();

                //List<CardTypeInfo> oldEC = new List<CardTypeInfo>(orphE._deckInfo._possibleCards);
                //oldEC.Add(card);
                //orphE._deckInfo._possibleCards = oldEC.ToArray();
            }

            if (!orphH._FlavourPool.Contains(encounterName))
            {
                List<string> oldHF = new List<string>(orphH._FlavourPool);
                oldHF.Add(encounterName);
                orphH._FlavourPool = oldHF.ToArray();
                //List<CardTypeInfo> oldHC = new List<CardTypeInfo>(orphH._deckInfo._possibleCards);
                //oldHC.Add(card);
                //orphH._deckInfo._possibleCards = oldHC.ToArray();
            }


            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = "Bucket" + PathUtils.speakerDataSuffix;
            test.name = "Bucket" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Player/Kleiver/CHR_PLR_Kleiver_Dx";
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
            AddSignType((SignType)774994, WNPivot);
        }
    }

    public static class ChestNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("Chest.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("Chest.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("Hidey.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/ChestGuy/chest.yarn");
                return y;
            }
        }
        public static void Troll()
        {
            string roomName = "FakeChestNPCRoom";
            string convoName = "FakeChestNPCConvo";
            string encounterName = "FakeChestNPCEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/ChestGuy/ChestRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Chest.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775005;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775005 };
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
            test.speakerName = "ChestGuy" + PathUtils.speakerDataSuffix;
            test.name = "ChestGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Player/Boyle/CHR_PLR_Boyle_Dx";
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
            AddSignType((SignType)775005, WNPivot);

        }
    }
}
