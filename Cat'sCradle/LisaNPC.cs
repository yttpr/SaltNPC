﻿using BepInEx;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using Tools;
using UnityEngine;
using UnityEngine.Rendering;
using Yarn.Unity;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //Mungeater
    public static class LisaNPC
    {
        public static GameInformationHolder info;
        public static void Wreck(string[] info)
        {
            foreach (CharacterInGameData chara in LisaNPC.info.Run.playerData.CharacterListData)
            {
                if (chara != null)
                {
                    chara.CurrentHealth = 1;
                }
            }
            ScreenShake.Shake();
        }
        public static void Setup(DialogueRunner dialogueRunner)
        {
            dialogueRunner.AddCommandHandler("CatsCradleExplode", Wreck);
            FlipNPC.Setup(dialogueRunner);
        }

        public static Sprite World => ResourceLoader.LoadSprite("hi4.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("hi4.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("hi1.png", 32);
        public static Sprite Back => ResourceLoader.LoadSprite("hi3.png", 32);
        public static Sprite Burst => ResourceLoader.LoadSprite("hi2.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/LisaGuy/lisa.yarn");
                return y;
            }
        }
        public static void Bomb()
        {
            string roomName = "LisaRoom";
            string convoName = "LisaConvo";
            string encounterName = "LisaEncounter";


            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/LisaGuy/LisaRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Lisa.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.questsCompletedNeeded = new QuestIDs[0];
            ret.questName = (QuestIDs)774995;
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)774995;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)774995 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO orphE = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO orphH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Middle };

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
            test.speakerName = "LisaGuy" + PathUtils.speakerDataSuffix;
            test.name = "LisaGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/NPC/DLC_02/CHR_NPC_DollMaster_Unmasked_Dx";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;

            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            SpeakerBundle backbund = new SpeakerBundle();
            backbund.dialogueSound = "event:/Characters/NPC/DLC_02/CHR_NPC_DollMaster_Unmasked_Dx";
            backbund.portrait = Back;
            backbund.bundleTextColor = Data.Speech;

            SpeakerBundle pop = new SpeakerBundle();
            pop.dialogueSound = "event:/Characters/Bosses/Heaven/CHR_BOSS_Heaven_Dth";
            pop.portrait = Burst;

            test._emotionBundles = new SpeakerEmote[]
            {
                new SpeakerEmote() { emotion = "Back", bundle = backbund },
                new SpeakerEmote() { emotion = "Pop", bundle =  pop },
                new SpeakerEmote() { emotion = "Front", bundle = testBund },
            };

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;

        }
        public static void Add()
        {
            AddSignType((SignType)774995, WNPivot);
        }
    }

    public static class FlipNPC
    {

        public static Sprite World => ResourceLoader.LoadSprite("FlipWorld.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("FlipWorld.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("HOOD_IRONY2.png", 32);
        public static Sprite Fell => ResourceLoader.LoadSprite("HOOD_IRONY3.png", 32);
        public static Sprite Corpse => ResourceLoader.LoadSprite("HOOD_IRONY4.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/FlipGuy/flip.yarn");
                return y;
            }
        }
        public static void Dies()
        {
            string roomName = "FlipRoom";
            string convoName = "FlipConvo";
            string encounterName = "FlipEncounter";

            FlipNPCHandler room = Data.Assets.LoadAsset<GameObject>("assets/FlipGuy/FlipRoom.prefab").AddComponent<FlipNPCHandler>();
            room.Second = Corpse;
            room.check = "Flipped";

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
            log.startNode = "Salt.Flip.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775004;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775004 };
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
            test.speakerName = "FlipGuy" + PathUtils.speakerDataSuffix;
            test.name = "FlipGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
            testBund.portrait = Front;
            testBund.bundleTextColor = Data.Speech;

            SpeakerBundle die = new SpeakerBundle();
            die.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
            die.portrait = Fell;
            die.bundleTextColor = Data.Speech;

            test._defaultBundle = testBund;
            test._emotionBundles = new SpeakerEmote[]
            {
                new SpeakerEmote()
                {
                    emotion = "Dead",
                    bundle = die
                }
            };
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
        }
        public static void Add()
        {
            AddSignType((SignType)775004, WNPivot);

        }

        public static void Flip(string[] info)
        {
            if (LisaNPC.info.Run.GetCurrentRoomInstance() is FlipNPCHandler flipRoom)
            {
                flipRoom.DoFlip();
            }
            else if(LisaNPC.info.Run.GetCurrentRoomInstance() is MultiNPCRoomHandler multi)
            {
                multi.DoSwap();
            }
            
        }
        public static void Setup(DialogueRunner dialogueRunner)
        {
            dialogueRunner.AddCommandHandler("CatsCradleFlip", Flip);
        }
    }

    public class FlipNPCHandler : NPCRoomHandler
    {
        public override void PopulateRoom(IGameCheckData gameData, IMinimalRunInfoData runData, IMinimalZoneInfoData zoneData, int dataID)
        {
            DialogueDataReference args = new DialogueDataReference(dataID, _dialogueMusic);
            _npcSelectable.SetClickData(Utils.startDialogNtf, args);
            _extraSelectable.SetClickData(Utils.startDialogNtf, args);
            _extraSelectable.HideItem();
            refer = dataID;
            _entityData = zoneData.GetTalkingEntityData(dataID);
            if (SavePerRun.Check(check))
            {
                DoFlip();
            }
        }
        public string check;

        public int refer;

        public Sprite Second;

        public bool Shake = true;
        
        public void DoFlip()
        {
            this._npcSelectable.HideItem();
            this._extraSelectable.ShowItem();
            if (Shake)
                ScreenShake.Shake(0.25f);
        }
    }

    public static class WeedNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("miniweed.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("miniweed.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("smokeweedeveryday.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/WeedGuy/weed.yarn");
                return y;
            }
        }
        public static void Smoke()
        {
            string roomName = "CannibisRoom";
            string convoName = "CannibisConvo";
            string encounterName = "CannibisEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/WeedGuy/WeedRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Weed.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775021;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775021 };
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
            test.speakerName = "WeedGuy" + PathUtils.speakerDataSuffix;
            test.name = "WeedGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Player/Griffin/CHR_PLR_Griffin_Dx";
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
            AddSignType((SignType)775021, WNPivot);
        }
    }
}
