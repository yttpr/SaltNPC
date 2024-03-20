using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Bootstrap;
using BrutalAPI;
using static BrutalAPI.BrutalAPI;
using UnityEngine;
using UnityEngine.UIElements;
using MonoMod.RuntimeDetour;
using JetBrains.Annotations;
using System.Text;
using System.Threading;
using System.Runtime.CompilerServices;
using Tools;
using UnityEngine.SceneManagement;
using System.Timers;
using UnityEngine.Diagnostics;
using UnityEngine.UI;
using System.Xml;
using System.Dynamic;
using Yarn.Unity;
using UnityEngine.Playables;

namespace Cat_sCradle
{
    [BepInPlugin("Salt.KurtVonnegut", "Flavor Text NPCs Question Mark", "1.0.0")]
    [BepInDependency("Bones404.BrutalAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class Vonnegut : BaseUnityPlugin
    {
        public const bool increaseNPC = false;
        
        public void Awake()
        {
            Add();
            Hacks.Setup();
            

            //Filing.CreateYarnFile("test.yarn");
            YarnMand.Setup();
            
            TestNPC.Test();//Salt
            PitNPC.Pit();//Peep
            BucketNPC.Fish();//Tair
            LisaNPC.Bomb();//Mungeater
            MinisterNPC.Giggle();//Peep
            SmileNPC.Smile();//Mats
            MirrorNPC.Doppel();//Chilly
            KetchupNPC.Sauce();//Venuz
            BitchesHouse.bitcheshouse();//Anzyll +21 Anzyllion comedy points
            MeatBaby.Fuck();//Lorac
            BlueNPC.Red();//Chilly
            HeartNPC.Click();//Chilly
            FlipNPC.Dies();//Mungeater
            ChestNPC.Troll();//Tair
            HelpNPC.Song();//Salt
            FishNPC.Bowl();//Ember
            LostNPC.Found();//Salt
            SquintNPC.Squinto();//Fatty
            UnoNPC.Piss();//Fatty
            MagicNPC.Lobotomite();//Fatty
            MaskNPC.Schizo();//Devron
            GenericGardenNPC.Hopeless();//Peep
            FleshNPC.Curse();//Croc/Chilly
            CryptoNPC.Rich();//Blob
            LevisNPC.Levi();//Blob
            ScaryNPC.Fear();//Blob
            BoyGuyNPC.Urination();//Wogwo
            GamerNPC.Shore();//Salt
            NoNPC.Empty();//Salt
            WeedNPC.Smoke();//Mirage/Mungeater
            BallNPC.Orb();//Ember
            ToyNPC.Doll();//Ember

            //search();
            Logger.LogInfo("Salt.KurtVonnegut loaded successfully!");

            if (!increaseNPC) return;

            MoreFlavor();
            Morbiud();
            TheJarden();
        }
        public static void Add()
        {
            AddSignType((SignType)774992, TestNPC.WNPivot);
            PitNPC.Add();
            BucketNPC.Add();
            LisaNPC.Add();
            MinisterNPC.Add();
            SmileNPC.Add();
            MirrorNPC.Add();
            KetchupNPC.Add();
            BitchesHouse.Add();
            MeatBaby.Add();
            BlueNPC.Add();
            new BlueItem(ItemPools.Extra).BlueDisciple.AddItem();
            HeartNPC.Add();
            FlipNPC.Add();
            ChestNPC.Add();
            SoundClass.Setup();
            HelpNPC.Add();
            FishNPC.Add();
            LostNPC.Add();
            SquintNPC.Add();
            UnoNPC.Add();
            MagicNPC.Add();
            MaskNPC.Add();
            GenericGardenNPC.Add();
            FleshNPC.Add();
            CryptoNPC.Add();
            LevisNPC.Add();
            ScaryNPC.Add();
            BoyGuyNPC.Add();
            GamerNPC.Add();
            NoNPC.Add();
            WeedNPC.Add();
            BallNPC.Add();
            ToyNPC.Add();
        }

        public static void search()
        {
            
            
            /*
            
            
            

            */
            return;
            Debug.Log(LoadedAssetsHandler.GetEnemy("OsmanSinnoks_BOSS").deathSound);
            Debug.Log(LoadedAssetsHandler.GetSpeakerData("Hans_SpeakerData")._defaultBundle.dialogueSound);
            Debug.Log(LoadedAssetsHandler.GetSpeakerData("Leviat_SpeakerData")._defaultBundle.dialogueSound);
            return;
            SpeakerData itchy = LoadedAssetsHandler.GetSpeakerData("ItchyGuy_SpeakerData");
            Debug.Log(itchy._defaultBundle.dialogueSound);
            SpeakerData jebus = LoadedAssetsHandler.GetSpeakerData("PervertMessiah_SpeakerData");
            Debug.Log(jebus._defaultBundle.dialogueSound);
            Debug.Log(LoadedAssetsHandler.GetEnemy("GildedGulper_EN").damageSound);
            Debug.Log(LoadedAssetsHandler.GetEnemyAbility("Sob_A").visuals.audioReference);
            Debug.Log(LoadedAssetsHandler.GetEnemyBundle("Zone02_Scrungie_Hard_EnemyBundle")._roarReference.roarEvent);
            SpeakerData mord = LoadedAssetsHandler.GetSpeakerData("Mordrake" + PathUtils.speakerDataSuffix);
            Debug.Log("main mordrake");
            Debug.Log(mord._defaultBundle.dialogueSound);
            SpeakerData gragon = LoadedAssetsHandler.GetSpeakerData("Agon_SpeakerData");
            Debug.Log(gragon._defaultBundle.dialogueSound);
            foreach (SpeakerEmote emote in mord._emotionBundles)
            {
                Debug.Log(emote.emotion);
                Debug.Log(emote.bundle.dialogueSound);
            }
            /*
            
            
            
            
            
            
            
            */
        }
        public static void AdmoEncounter()
        {
            BasicEncounterSO encounter = LoadedAssetsHandler.GetBasicEncounter("Admo_Flavour");
            Debug.Log(encounter.DialoguePath);
            Debug.Log(encounter.encounterRoom);
            DialogueSO logg = LoadedAssetsHandler.GetDialogueData(encounter.DialoguePath);
            Debug.Log(logg.dialog);
            //Debug.Log(logg.dialog.baseLocalisationStringTable);
            //Debug.Log(logg.dialog.baseLocalisationStringTable.ToString());
            Debug.Log(logg.startNode);
            NPCRoomHandler room = LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, encounter.encounterRoom) as NPCRoomHandler;
            BasicRoomItem admoSelf = room._npcSelectable as BasicRoomItem;
            Debug.Log(admoSelf);
            
        }
        public static void Test()
        {
            string roomName = "TestRoom";
            string convoName = "TestConvo";
            string encounterName = "TestEncounter";

            BaseRoomHandler room = new BasicRoomHandler();
            //pull this from an assetbunldle
            if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(roomName)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(roomName, room);

            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            //set the YarnProgram
            //set the Start Node
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);

            BasicEncounterSO ret = ScriptableObject.CreateInstance<BasicEncounterSO>();
            ret._dialogue = convoName;
            ret.encounterRoom = encounterName;
            ret.signType = (SignType)774992;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)774992 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);

            AddSignType((SignType)774992, ResourceLoader.LoadSprite("spriteNotReal"));

            ZoneBGDataBaseSO orphE = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO orphH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.First };

            List<string> oldEF = new List<string>(orphE._FlavourPool);
            oldEF.Add(encounterName);
            orphE._FlavourPool = oldEF.ToArray();
            List<CardTypeInfo> oldEC = new List<CardTypeInfo>(orphE._deckInfo._possibleCards);
            oldEC.Add(card);
            orphE._deckInfo._possibleCards = oldEC.ToArray();

            List<string> oldHF = new List<string>(orphH._FlavourPool);
            oldHF.Add(encounterName);
            orphH._FlavourPool = oldHF.ToArray();
            List<CardTypeInfo> oldHC = new List<CardTypeInfo>(orphH._deckInfo._possibleCards);
            oldHC.Add(card);
            orphH._deckInfo._possibleCards = oldHC.ToArray();

            SpeakerData test = new SpeakerData();
            test.speakerName = "TESTER";

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "";
            testBund.portrait = ResourceLoader.LoadSprite("FaceNotReal");

            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
        }
        public static void MoreFlavor()
        {
            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.First };
            card._minimumAmount = 20;
            card._maximumAmount = 40;

            ZoneBGDataBaseSO shoreH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;

            List<CardTypeInfo> oldHC = new List<CardTypeInfo>(shoreH._deckInfo._possibleCards);
            oldHC.Add(card);
            shoreH._deckInfo._possibleCards = oldHC.ToArray();
        }
        public static void TheJarden()
        {
            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.First };
            card._minimumAmount = 20;
            card._maximumAmount = 40;

            ZoneBGDataBaseSO shoreH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;

            List<CardTypeInfo> oldHC = new List<CardTypeInfo>(shoreH._deckInfo._possibleCards);
            oldHC.Add(card);
            shoreH._deckInfo._possibleCards = oldHC.ToArray();
        }
        public static void Morbiud()
        {
            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.First };
            card._minimumAmount = 20;
            card._maximumAmount = 40;

            ZoneBGDataBaseSO shoreH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;

            List<CardTypeInfo> oldHC = new List<CardTypeInfo>(shoreH._deckInfo._possibleCards);
            oldHC.Add(card);
            shoreH._deckInfo._possibleCards = oldHC.ToArray();
        }
        public const string ForceDialogNtf = "ForceDialogeNotif";
    }

    public static class Hacks
    {
        public static void Setup()
        {
            //DONT NEED???
            //IDetour hook = new Hook(typeof(RunDataSO).GetMethod(nameof(RunDataSO.PopulateRoomInstance), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(PopulateRoomInstance), ~BindingFlags.Default));
            IDetour cont = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.LoadOldRun), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(LoadOldRun), ~BindingFlags.Default));
            IDetour emba = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(Hacks).GetMethod(nameof(LoadOldRun), ~BindingFlags.Default));
            ScreenShake.Setup();
        }
        public static BaseRoomHandler PopulateRoomInstance(Func<RunDataSO, Card, BaseRoomHandler> orig, RunDataSO self, Card card)
        {
            if (card.RoomPrefabName == "TestRoom")
            {
                TestNPC.Test(false);
            }
            else if (card.RoomPrefabName == "PitRoom")
            {
                PitNPC.Pit();
            }
            else if (card.RoomPrefabName == "BucketRoom")
            {
                BucketNPC.Fish();
            }
            else return orig(self, card);
            BaseRoomHandler ret = orig(self, card);
            if (ret is NPCRoomHandler npcRoom)
            {
                npcRoom._npcSelectable._renderers[0].enabled = true;
            }
            return ret;
            
            Debug.Log(card.CardType); Debug.Log(card.RoomPrefabName);
            BaseRoomHandler first = LoadedAssetsHandler.GetRoomPrefab(card.CardType, card.RoomPrefabName);
            Debug.Log(first);
            BaseRoomHandler second = UnityEngine.Object.Instantiate(first);
            Debug.Log(second);

            BaseRoomHandler baseRoomHandler2 = (card.RoomInstance = second);
            Debug.Log(baseRoomHandler2);
            card.RoomInstance.FullyPopulateRoom(self._gameData, self, self.zoneData[self._currentZoneID], card.IDInfo);
            Debug.Log(card.RoomInstance);
            return card.RoomInstance;
        }
        public static void LoadOldRun(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            TestNPC.Test(false);
            PitNPC.Pit();
            BucketNPC.Fish();
            LisaNPC.Bomb();
            LisaNPC.info = self._informationHolder;
            ScreenShake.mainCont = self;
            MinisterNPC.Giggle();
            SmileNPC.Smile();
            MirrorNPC.Doppel();
            KetchupNPC.Sauce();
            BitchesHouse.bitcheshouse();
            MeatBaby.Fuck();
            BlueNPC.Red();
            HeartNPC.Click();
            FlipNPC.Dies();
            ChestNPC.Troll();
            HelpNPC.Song();
            FishNPC.Bowl();
            LostNPC.Found();
            SquintNPC.Squinto();
            UnoNPC.Piss();
            MagicNPC.Lobotomite();
            MaskNPC.Schizo();
            GenericGardenNPC.Hopeless();
            FleshNPC.Curse();
            CryptoNPC.Rich();
            LevisNPC.Levi();
            ScaryNPC.Fear();
            BoyGuyNPC.Urination();
            GamerNPC.Shore();
            NoNPC.Empty();
            WeedNPC.Smoke();
            BallNPC.Orb();
            ToyNPC.Doll();
        }
    }

    public static class ResourceLoader
    {
        public static Texture2D LoadTexture(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
            var resource = assembly.GetManifestResourceStream(resourceName);
            using var memoryStream = new MemoryStream();
            var buffer = new byte[16384];
            int count;
            while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                memoryStream.Write(buffer, 0, count);
            var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
            {
                anisoLevel = 1,
                filterMode = 0
            };

            spriteTexture.LoadImage(memoryStream.ToArray());
            return spriteTexture;
        }

        public static Sprite LoadSprite(string name, int ppu = 1, Vector2? pivot = null)
        {
            if (pivot == null) { pivot = new Vector2(0.5f, 0.5f); }
            var assembly = Assembly.GetExecutingAssembly();

            Sprite sprite;

            try
            {
                var resourceName = assembly.GetManifestResourceNames().First(r => r.Contains(name));
                var resource = assembly.GetManifestResourceStream(resourceName);
                using var memoryStream = new MemoryStream();
                var buffer = new byte[16384];
                int count;
                while ((count = resource!.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);
                var spriteTexture = new Texture2D(0, 0, TextureFormat.ARGB32, false)
                {
                    anisoLevel = 1,
                    filterMode = 0
                };

                spriteTexture.LoadImage(memoryStream.ToArray());
                sprite = Sprite.Create(spriteTexture, new Rect(0, 0, spriteTexture.width, spriteTexture.height), (Vector2)pivot, ppu);

            }
            catch (InvalidOperationException)
            {
                throw new Exception("Missing Texture! Check for typos when using ResourceLoader.LoadSprite() and that all of your textures have their build action as Embedded Resource.");
            }

            return sprite;
        }

        public static byte[] ResourceBinary(string name)
        {
            Assembly a = Assembly.GetExecutingAssembly();
            var resourceName = a.GetManifestResourceNames().First(r => r.Contains(name));
            using (Stream resFilestream = a.GetManifestResourceStream(resourceName))
            {
                if (resFilestream == null) return null;
                byte[] ba = new byte[resFilestream.Length];
                resFilestream.Read(ba, 0, ba.Length);
                return ba;
            }
        }

    } //Resource Loader!
}
