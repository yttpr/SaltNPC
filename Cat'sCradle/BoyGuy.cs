using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using UnityEngine;
using Yarn.Unity;
using static BrutalAPI.BrutalAPI;
using System.Reflection;

namespace Cat_sCradle
{
    //Wogwo
    public static class BoyGuyNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("MenuGuy_1.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("MenuGuy_1.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("FrontGuy_1.png", 32);
        public static Sprite Piss => ResourceLoader.LoadSprite("FrontGuy_2.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/GuyGuy/guy.yarn");
                return y;
            }
        }
        public static void Urination()
        {
            string roomName = "RedBoyGuyRoom";
            string convoName = "RedBoyGuyConvo";
            string encounterName = "RedBoyGuyEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/GuyGuy/GuyRoom.prefab").AddComponent<NPCRoomHandler>();
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
            log.startNode = "Salt.Piss.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775018;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775018 };
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
            test.speakerName = "PissGuy" + PathUtils.speakerDataSuffix;
            test.name = "PissGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Enemies/DLC_01/GlidedGulper/CHR_ENM_GlidedGulper_Dmg";
            testBund.portrait = Front;
            testBund.bundleTextColor = new Color32(207, 0, 0, 255);

            SpeakerBundle peeb = new SpeakerBundle();
            peeb.dialogueSound = "event:/Characters/Enemies/DLC_01/GlidedGulper/CHR_ENM_GlidedGulper_Dmg";
            peeb.portrait = Piss;
            peeb.bundleTextColor = new Color32(207, 0, 0, 255);


            test._defaultBundle = testBund;
            test.portraitLooksLeft = false;
            test.portraitLooksCenter = false;
            test._emotionBundles = new SpeakerEmote[]
            {
                new SpeakerEmote(){emotion = "Piss", bundle = peeb},
                new SpeakerEmote(){emotion = "Default", bundle = testBund}
            };

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;
        }
        public static void Add()
        {
            AddSignType((SignType)775018, WNPivot);
            Bitem.gruh();
        }
    }

    public static class Bitem
    {
        public static void gruh()
        {
            EffectItem effectItem = new EffectItem();
            effectItem.name = "Ugly Painting";
            effectItem.flavorText = "\"Who made this *#%@!?\"";
            effectItem.description = "boYguY always delivers. You can count on boYguY.";
            effectItem.sprite = ResourceLoader.LoadSprite("itemguy.png", 32);
            effectItem.unlockableID = (UnlockableID)695374;
            effectItem.namePopup = true;
            effectItem.itemPools = ItemPools.Extra;

            effectItem.effects = new Effect[]
            {
                new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 69420, null, Slots.SlotTarget(new int[] { -4,-3,-2,-1,0,1,2,3,4 }, false)),
                new Effect(ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 69420, null, Slots.SlotTarget(new int[] { -4,-3,-2,-1,0,1,2,3,4 }, true)),
                new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 69, null, Slots.Self, Conditions.Chance(8)),
                new Effect(ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 69, null, Slots.Front, Conditions.Chance(2))
            };
            effectItem.trigger = TriggerCalls.OnTurnStart;
            effectItem.AddItem();
        }

        public static void FreeStuff(string[] info)
        {
            BlueNPC.AddCopy(LoadedAssetsHandler.GetWearable("UglyPainting_EW"));
        }
        public static void Setup(DialogueRunner dialogueRunner)
        {
            dialogueRunner.AddCommandHandler("CatsCradlePissItem", FreeStuff);
            IDetour hook = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.Awake), ~BindingFlags.Default), typeof(Bitem).GetMethod(nameof(Awake), ~BindingFlags.Default));
        }

        public static void Awake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
            BlueNPC.overManager = self;
        }
    }
}
