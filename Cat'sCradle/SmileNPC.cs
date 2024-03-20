using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using UnityEngine;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //mats
    public static class SmileNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("smileWorld.png", 24, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("smileWorld.png", 24);
        public static Sprite Front => ResourceLoader.LoadSprite("smileNorm.png", 32);
        public static Sprite Grin => ResourceLoader.LoadSprite("smileHappy.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/SmileGuy/smile.yarn");
                return y;
            }
        }
        public static void Smile()
        {
            string roomName = "SmileRoom";
            string convoName = "SmileConvo";
            string encounterName = "SmileEncounter";


            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/SmileGuy/SmileRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Smile.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)774997;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)774997 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.First };
            card._percentage = 150;
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
            test.speakerName = "Smile" + PathUtils.speakerDataSuffix;
            test.name = "Smile" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            //testBund.dialogueSound = LoadedAssetsHandler.GetEnemyBundle("H_Zone03_GigglingMinister_Hard_EnemyBundle")._roarReference.roarEvent;
            testBund.dialogueSound = "event:/Characters/NPC/CHR_NPC_Psycho_Dx";
            //Debug.Log(testBund.dialogueSound);
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;

            SpeakerBundle happy = new SpeakerBundle()
            {
                dialogueSound = "event:/Characters/NPC/CHR_NPC_Psycho_Dx",
                portrait = Grin,
                bundleTextColor = Data.Speech,
            };

            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;
            test._emotionBundles = new SpeakerEmote[]
            {
                new SpeakerEmote(){ emotion = "Norm", bundle = testBund },
                new SpeakerEmote(){ emotion = "Happy", bundle = happy },
            };
            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;

        }
        public static void Add()
        {
            AddSignType((SignType)774997, WNPivot);
        }
    }
}
