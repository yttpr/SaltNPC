using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using UnityEngine;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //Devron
    public static class MaskNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("MaskWorld.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("MaskWorld.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("MaskHappy.png", 32);
        public static Sprite Sad => ResourceLoader.LoadSprite("MaskSad.png", 32);
        public static Sprite Finger => ResourceLoader.LoadSprite("MaskFinger.png", 32);
        public static Sprite Angry => ResourceLoader.LoadSprite("MaskAngry.png", 32);
        public static Sprite Scream => ResourceLoader.LoadSprite("MaskScream.png", 32);
        public static Sprite FirstDissolve => ResourceLoader.LoadSprite("MaskFirstDissolve.png", 32);
        public static Sprite SecondDissolve => ResourceLoader.LoadSprite("MaskSecondDissolve.png", 32);
        public static Sprite Dust => ResourceLoader.LoadSprite("MaskDust.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/MaskGuy/mask.yarn");
                return y;
            }
        }
        public static void Schizo()
        {
            string roomName = "FigmentRoom";
            string convoName = "FigmentConvo";
            string encounterName = "FigmentEncounter";

            FlipNPCHandler room = Data.Assets.LoadAsset<GameObject>("assets/MaskGuy/MaskRoom.prefab").AddComponent<FlipNPCHandler>();
            room.Second = Dust;
            room.check = "Dusted";
            room.Shake = false;

            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };

            room._npcSelectable._renderers[0].material = TestNPC.SpriteMat;

            room._extraSelectable = room.transform.GetChild(1).gameObject.AddComponent<BasicRoomItem>();
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
            log.startNode = "Salt.Mask.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.questName = (QuestIDs)775012;
            ret.questsCompletedNeeded = new QuestIDs[0];

            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775012;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775012 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO shoreH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;

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
            if (!shoreH._FlavourPool.Contains(encounterName))
            {
                List<string> oldHF = new List<string>(shoreH._FlavourPool);
                oldHF.Add(encounterName);
                shoreH._FlavourPool = oldHF.ToArray();
                //List<CardTypeInfo> oldHC = new List<CardTypeInfo>(gardH._deckInfo._possibleCards);
                //oldHC.Add(card);
                //gardH._deckInfo._possibleCards = oldHC.ToArray();
            }


            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = "Mask" + PathUtils.speakerDataSuffix;
            test.name = "Mask" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
            testBund.portrait = Front;
            //testBund.bundleTextColor = Data.Speech;

            SpeakerBundle sad = new SpeakerBundle();
            sad.dialogueSound = "event:/Combat/Attack/G1/ATK_Sob";
            sad.portrait = Sad;
            //sad.bundleTextColor = Data.Speech;

            SpeakerBundle finger = new SpeakerBundle();
            finger.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
            finger.portrait = Finger;
            //ggg.bundleTextColor = Data.Speech;

            SpeakerBundle angry = new SpeakerBundle();
            angry.dialogueSound = "event:/Characters/Enemies/DLC_01/Scrungie/CHR_ENM_Scrungie_Roar";
            angry.portrait = Angry;

            SpeakerBundle scream = new SpeakerBundle();
            scream.dialogueSound = "event:/Characters/Player/Agon/CHR_PLR_Agon_Dx";
            scream.portrait = Scream;

            SpeakerBundle dissolve1 = new SpeakerBundle();
            dissolve1.dialogueSound = "event:/Characters/NPC/Mordrake/CHR_NPC_Mordrake_Static_Dx";
            dissolve1.portrait = FirstDissolve;

            SpeakerBundle dissolve2 = new SpeakerBundle();
            dissolve2.dialogueSound = "event:/Characters/NPC/Mordrake/CHR_NPC_Mordrake_Static_Dx";
            dissolve2.portrait = FirstDissolve;

            SpeakerBundle dust = new SpeakerBundle();
            dust.dialogueSound = "";
            dust.portrait = Dust;

            test._defaultBundle = testBund;
            test._emotionBundles = new SpeakerEmote[]
            {
                new SpeakerEmote()
                {
                    emotion = "Happy",
                    bundle = testBund
                },
                new SpeakerEmote()
                {
                    emotion = "Sad",
                    bundle = sad
                },
                new SpeakerEmote()
                {
                    emotion = "Finger",
                    bundle = finger
                },
                new SpeakerEmote()
                {
                    emotion = "Angry",
                    bundle = angry
                },
                new SpeakerEmote()
                {
                    emotion = "Scream",
                    bundle = scream
                },
                new SpeakerEmote()
                {
                    emotion = "FirstDissolve",
                    bundle = dissolve1
                },
                new SpeakerEmote()
                {
                    emotion = "SecondDissolve",
                    bundle = dissolve2
                },
                new SpeakerEmote()
                {
                    emotion = "Dust",
                    bundle = dust
                }
            };
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
        }
        public static void Add()
        {
            AddSignType((SignType)775012, WNPivot);

        }
    }
}
