using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using BrutalAPI;
using static BrutalAPI.BrutalAPI;
using Tools;
using Yarn.Compiler;
using Yarn;
using System.IO;
using Yarn.Unity;

namespace Cat_sCradle
{
    public static class TestNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("OverworldPlaceholder.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("OverworldPlaceholder.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("PlaceholderFront.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/TestGuy/test.yarn");
                return y;
            }
        }
        public static Material SpriteMat
        {
            get
            {
                BasicEncounterSO jesus = LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour");

                NPCRoomHandler hJesus = LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, jesus.encounterRoom) as NPCRoomHandler;

                BasicRoomItem hje = hJesus._npcSelectable as BasicRoomItem;

                return hje._renderers[0].material;
            }
        }
        public static bool TestCardAdded = false;
        public static void Test(bool initial = true)
        {
            string roomName = "TestRoom";
            string convoName = "TestConvo";
            string encounterName = "TestEncounter";

            BasicEncounterSO jesus = LoadedAssetsHandler.GetBasicEncounter("PervertMessiah_Flavour");

            NPCRoomHandler hJesus = LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, jesus.encounterRoom) as NPCRoomHandler;
            //if (hJesus != null) { Debug.Log(hJesus); } else Debug.Log("gay!");

            //Transform newer = GameObject.Instantiate(hJesus.transform);

            Transform je = hJesus.transform.GetChild(0);
            //Debug.Log(je.gameObject);
            //Debug.Log(je.gameObject.activeSelf);

            //RunDataSO.PopulateRoomInstance()

            NPCRoomHandler room = //UnityEngine.Object.Instantiate<NPCRoomHandler>(hJesus, hJesus.transform.parent);
                Data.Assets.LoadAsset<GameObject>("assets/TestGuy/TestRoom.prefab").AddComponent<NPCRoomHandler>();
            room._npcSelectable = room.transform.GetChild(0).gameObject.AddComponent<BasicRoomItem>();
            room._npcSelectable._renderers = new SpriteRenderer[]
            {
                room._npcSelectable.transform.GetChild(0).GetComponent<SpriteRenderer>()
            };
            room._npcSelectable._renderers[0].material = SpriteMat;
            /*
            room.name = "TestGuy_Room";
            room._npcSelectable = room.transform.GetChild(0).GetComponent<BasicRoomItem>();
            Vector3 pos = room._npcSelectable.transform.localPosition;
            pos.x += 2;
            room._npcSelectable.transform.localPosition = pos;
            room._npcSelectable._renderers[0].sprite = World;
            room._npcSelectable._renderers[0].enabled = false;
            Vector3 center = room._npcSelectable._detector.bounds.center;
            center.y += 2;
            Vector3 ext = room._npcSelectable._detector.bounds.extents;
            room._npcSelectable._detector.bounds.center = center;
            */
            //room._entityData = new TalkingEntityContentData(convoName);
            //room.GenerateAllSelectables();
            //room.PrepareRoom();
            //foreach (Component comp in room._npcSelectable.GetComponents<Component>())
            //{
            //Debug.Log(comp);
            //}
            //return;
            //pull this from an assetbunldle
            if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(PathUtils.encounterRoomsResPath + roomName)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + roomName, room);
            else LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + roomName] = room;
            //if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains(roomName)) LoadedAssetsHandler.LoadedRoomPrefabs.Add(roomName, room);

            DialogueSO log = ScriptableObject.CreateInstance<DialogueSO>();
            log.name = convoName;
            log.dialog = Script;
            log.startNode = "Salt.Test.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.questName = (QuestIDs)774992;
            ret.questsCompletedNeeded = new QuestIDs[0];
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)774992;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)774992 };
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;

            //if (!TestCardAdded)
            //    AddSignType((SignType)774992, WNPivot);

            ZoneBGDataBaseSO orphE = LoadedAssetsHandler.GetZoneDB("ZoneDB_02") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO orphH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_02") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.First };
            card._minimumAmount = 0;

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
            //TestCardAdded = true;
            
            SpeakerData test = ScriptableObject.CreateInstance<SpeakerData>();
            test.speakerName = "TestGuy" + PathUtils.speakerDataSuffix;
            test.name = "TestGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/Player/Anton/CHR_PLR_Anton_Dx";
            testBund.portrait = Front;

            test._defaultBundle = testBund;
            test.portraitLooksLeft = true;
            test.portraitLooksCenter = false;

            if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains(test.speakerName)) LoadedAssetsHandler.LoadedSpeakers.Add(test.speakerName, test);
            else LoadedAssetsHandler.LoadedSpeakers[test.speakerName] = test;

            /*

            Card c = new Card(77, 78, CardType.Flavour, PilePositionType.First, ret.signType, ret.encounterRoom);
            BaseRoomHandler h = (c.RoomInstance = UnityEngine.Object.Instantiate(LoadedAssetsHandler.GetRoomPrefab(c.CardType, c.RoomPrefabName)));
            Debug.Log("g");
            //UnityEngine.Object.Instantiate(LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, "bb)"));

            CardInfo finfo = new CardInfo();
            Card fard = new Card(69, 79, finfo.cardType, PilePositionType.First, c.SignIconType, c.RoomPrefabName);
            Debug.Log("fake card");
            BaseRoomHandler bb = (fard.RoomInstance = UnityEngine.Object.Instantiate(LoadedAssetsHandler.GetRoomPrefab(fard.CardType, fard.RoomPrefabName)));
            Debug.Log("fake room");
            Debug.Log(bb);
            */
            return;
            if (LoadedAssetsHandler.GetBasicEncounter(encounterName) != null) Debug.Log(LoadedAssetsHandler.GetBasicEncounter(encounterName));
            else Debug.Log(encounterName + " is null");
            if (LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, roomName) != null) Debug.Log(LoadedAssetsHandler.GetRoomPrefab(CardType.Flavour, roomName));
            else Debug.Log(roomName + " is null");
            if (LoadedAssetsHandler.GetDialogueData(convoName) != null) Debug.Log(LoadedAssetsHandler.GetDialogueData(convoName));
            else Debug.Log(convoName + " is null");
            if (LoadedAssetsHandler.GetSpeakerData(test.speakerName) != null) Debug.Log(LoadedAssetsHandler.GetSpeakerData(test.speakerName));
            else Debug.Log(test.speakerName + " is null");
        }
    }

    public static class Filing
    {
        public static string Path = Application.dataPath + "/StreamingAssets";

        public static void CreateResourceFile(string resourceName, string path, string outputName, bool onlyIfNotExist = false)
        {
            byte[] resource = new byte[0] { };
            try
            {
                resource = ResourceLoader.ResourceBinary(resourceName);
            }
            catch (Exception ex)
            {
                Debug.Log(ex.Message);
                Debug.Log("THIS IS A RESOURCE LOADER ERROR, YOU LOADED THE RESOURCE WRONG 4HEAD");
                Debug.Log(ex.StackTrace);
            }
            if (resource.Length > 0 && !(onlyIfNotExist && File.Exists(path + "/" + outputName)))
            {
                File.WriteAllBytes(path + "/" + outputName, resource);
            }
        }
        public static void CreateYarnFile(string resourceName, bool onlyIfNotExist = false)
        {
            CreateResourceFile(resourceName, Path, resourceName, onlyIfNotExist);
        }
    }
}
