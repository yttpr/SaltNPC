using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using UnityEngine;
using System.Linq;
using Tools;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    public static class HelpNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("Computer.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("Computer.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("Screen.png", 32);
        public static Sprite Static => ResourceLoader.LoadSprite("Static.png", 32);
        public static Sprite Corpse => ResourceLoader.LoadSprite("Off.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/HelpGuy/help.yarn");
                return y;
            }
        }
        public static void Song()
        {
            string roomName = "HelpRoom";
            string convoName = "HelpConvo";
            string encounterName = "HelpEncounter";

            FlipNPCHandler room = Data.Assets.LoadAsset<GameObject>("assets/HelpGuy/HelpRoom.prefab").AddComponent<FlipNPCHandler>();
            room.Second = Corpse;
            room.check = "Off";
            room._dialogueMusic = "";
            room.Shake = false;

            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };

            room._npcSelectable._renderers[0].material = TestNPC.SpriteMat;

            room._extraSelectable = room.transform.GetChild(2).gameObject.AddComponent<BasicRoomItem>();
            room._extraSelectable._renderers = new SpriteRenderer[]
            {
                room._extraSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };

            room._extraSelectable._renderers[0].material = TestNPC.SpriteMat;


            if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + roomName)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + roomName, room);
            else LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + roomName] = room;


            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Help.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775006;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775006 };
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
            test.speakerName = "Help" + PathUtils.speakerDataSuffix;
            test.name = "Help" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/GlassBeach";
            testBund.portrait = Front;
            //testBund.bundleTextColor = Data.Speech;

            SpeakerBundle die = new SpeakerBundle();
            die.dialogueSound = "";
            die.portrait = Static;
            //die.bundleTextColor = Data.Speech;

            SpeakerBundle ggg = new SpeakerBundle();
            ggg.dialogueSound = "";
            ggg.portrait = Corpse;
            //ggg.bundleTextColor = Data.Speech;

            test._defaultBundle = testBund;
            test._emotionBundles = new SpeakerEmote[]
            {
                new SpeakerEmote()
                {
                    emotion = "Screen",
                    bundle = testBund
                },
                new SpeakerEmote()
                {
                    emotion = "Static",
                    bundle = die
                },
                new SpeakerEmote()
                {
                    emotion = "Off",
                    bundle = ggg
                }
            };
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
        }
        public static void Add()
        {
            AddSignType((SignType)775006, WNPivot);

        }
    }
    public static class SoundClass
    {
        public static void CreateSoundBankFile(string resourceName, bool onlyIfNotExist = false)
        {
            CreateResourceFile(resourceName, Application.dataPath + "/StreamingAssets", resourceName + ".bank", onlyIfNotExist);
            //call this like, CreateSoundBankFile("FunnyGuyHitNoise");
        }

        public static void CreateResourceFile(string resourceName, string path, string outputName, bool onlyIfNotExist = false)
        {
            byte[] resource = new byte[0] { };
            try
            {
                resource = ResourceLoader.ResourceBinary(resourceName);
            }
            catch (Exception ex)
            {
                Debug.Log("YOUR FILE DOES NOT EXIST MOTHERFUCKER");
            }
            if (resource.Length > 0 && !(onlyIfNotExist && File.Exists(path + "/" + outputName)))
            {
                File.WriteAllBytes(path + "/" + outputName, resource);
            }
        }

        public static void Setup()
        {
            CreateSoundBankFile("SaltNPCShowcaseMusic");
            CreateSoundBankFile("SaltNPCShowcaseMusic.strings");

            FMODUnity.RuntimeManager.LoadBank("SaltNPCShowcaseMusic", true);
            FMODUnity.RuntimeManager.LoadBank("SaltNPCShowcaseMusic.strings", true);

            //event:/GlassBeach
        }
    }

    public static class LostNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("lost.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("lost.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("lost.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/LostGuy/lost.yarn");
                return y;
            }
        }
        public static void Found()
        {
            string roomName = "LostNPCRoom";
            string convoName = "LostNPCConvo";
            string encounterName = "LostNPCEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/LostGuy/LostRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Lost.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775008;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775008 };
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
            test.speakerName = "Lost" + PathUtils.speakerDataSuffix;
            test.name = "Lost" + PathUtils.speakerDataSuffix;

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
            AddSignType((SignType)775008, WNPivot);

        }
    }
}
