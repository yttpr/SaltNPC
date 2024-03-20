using BrutalAPI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Tools;
using UnityEngine;
using Yarn.Unity;
using static BrutalAPI.BrutalAPI;

namespace Cat_sCradle
{
    //also ChillyBonez
    public static class BlueNPC
    {
        public static Sprite World => ResourceLoader.LoadSprite("BlueWorld.png", 32, new Vector2(0.5f, 0));
        public static Sprite WNPivot => ResourceLoader.LoadSprite("BlueWorld.png", 32);
        public static Sprite Front => ResourceLoader.LoadSprite("BlueFace.png", 32);
        public static YarnProgram Script
        {
            get
            {
                YarnProgram y = Data.Assets.LoadAsset<YarnProgram>("assets/BlueGuy/blue.yarn");
                return y;
            }
        }
        public static void Red()
        {
            string roomName = "BlueRoom";
            string convoName = "BlueConvo";
            string encounterName = "BlueEncounter";

            NPCRoomHandler room = Data.Assets.LoadAsset<GameObject>("assets/BlueGuy/BlueRoom.prefab").AddComponent<NPCRoomHandler>();

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
            log.startNode = "Salt.Blue.Start";
            if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains(convoName)) LoadedAssetsHandler.LoadedDialogues.Add(convoName, log);
            else LoadedAssetsHandler.LoadedDialogues[convoName] = log;


            ConditionEncounterSO ret = ScriptableObject.CreateInstance<ConditionEncounterSO>();
            ret.questName = (QuestIDs)775002;
            ret.name = encounterName;
            ret._dialogue = convoName;
            ret.encounterRoom = roomName;
            ret.signType = (SignType)775002;
            ret.npcEntityIDs = new EntityIDs[] { (EntityIDs)775002 };
            ret.questsCompletedNeeded = new QuestIDs[0];
            if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains(encounterName)) LoadedAssetsHandler.LoadedBasicEncounters.Add(encounterName, ret);
            else LoadedAssetsHandler.LoadedBasicEncounters[encounterName] = ret;


            ZoneBGDataBaseSO gardE = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
            ZoneBGDataBaseSO gardH = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;

            CardTypeInfo card = new CardTypeInfo();
            card._cardInfo = new CardInfo() { cardType = CardType.Flavour, pilePosition = PilePositionType.Any };
            card._percentage = 350;
            card._usePercentage = true;


            /*if (!gardE._FlavourPool.Contains(encounterName))
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
            test.speakerName = "BlueGuy" + PathUtils.speakerDataSuffix;
            test.name = "BlueGuy" + PathUtils.speakerDataSuffix;

            SpeakerBundle testBund = new SpeakerBundle();
            testBund.dialogueSound = "event:/Characters/NPC/CHR_NPC_Indecisive_Dx";
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
            AddSignType((SignType)775002, WNPivot);

        }


        public static OverworldManagerBG overManager;
        public static bool AddCopy(BaseWearableSO item)
        {
            overManager.StartCoroutine(AddCopyAction(overManager, item));
            return true;
        }
        public static IEnumerator AddCopyAction(OverworldManagerBG overManager, BaseWearableSO item)
        {
            RunDataSO run = overManager._informationHolder.Run;
            bool hasItemSpace = run.playerData.HasItemSpace;
            StringTrioData itemLocData = item.GetItemLocData();
            string text = string.Format(LocUtils.LocDB.GetUIData(UILocID.PrizeGetLabel), itemLocData.text);
            if (!hasItemSpace)
            {
                text = text + "\n" + LocUtils.LocDB.GetUIData(UILocID.ItemNotEnoughSpace);
            }

            string uIData3 = LocUtils.LocDB.GetUIData(UILocID.ContinueButton);
            ConfirmDialogReference dialogReference3 = new ConfirmDialogReference(text, uIData3, "", item.wearableImage, itemLocData.description);
            NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, null, dialogReference3);
            while (dialogReference3.result == DialogResult.Abort)
            {
                yield return null;
                NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, null, dialogReference3);
            }


            overManager._soundManager.PlayOneshotSound(overManager._soundManager.itemGet);
            while (dialogReference3.result == DialogResult.None)
            {
                yield return null;
            }

            if (hasItemSpace)
            {
                run.playerData.AddNewItem(item);
            }
            else
            {
                overManager._extraItemMenuIsOpen = true;
                overManager._extraUIHandler.OpenItemExchangeMenu(new BaseWearableSO[1] { item });
                while (overManager._extraItemMenuIsOpen)
                {
                    yield return null;
                }
            }
            overManager.SaveProgress(fullySave: true);
        }
        public static bool AddCopyOld(BaseWearableSO item)
        {
            bool hasItemSpace = overManager._informationHolder.Run.playerData.HasItemSpace;
            if (hasItemSpace)
            {
                LisaNPC.info.Run.playerData.AddNewItem(item);
                return true;
            }
            StringTrioData itemLocData = item.GetItemLocData();
            string dialog = string.Format(LocUtils.LocDB.GetUIData(UILocID.PrizeGetLabel), (object)itemLocData.text);
            if (!hasItemSpace)
                dialog = dialog + "\n" + LocUtils.LocDB.GetUIData(UILocID.ItemNotEnoughSpace);
            string uiData = LocUtils.LocDB.GetUIData(UILocID.ContinueButton);
            ConfirmDialogReference confirmDialogReference = new ConfirmDialogReference(dialog, uiData, "", item.wearableImage, itemLocData.description);
            NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, (object)null, (object)confirmDialogReference);
            if (confirmDialogReference.result != DialogResult.Abort)
            {
                overManager._soundManager.PlayOneshotSound(overManager._soundManager.itemGet);
                if (hasItemSpace)
                {
                    //this._informationHolder.Run.GetPrizeItem(num);
                    //this.StartCoroutine(this.WaitForConfirmationForOWNotification(confirmDialogReference, OverworldTriggerCalls.PrizeChestDirectOpened));
                }
                else
                    overManager.StartCoroutine(overManager.OpenExchangeItemsOnConfirmation(confirmDialogReference, new BaseWearableSO[1]
                    {
                        item
                    }));
            }
            return false;
        }
        public static void FreeStuff(string[] info)
        {
            AddCopy(LoadedAssetsHandler.GetWearable("BlueDisciple_EW"));
        }
        public static void Setup(DialogueRunner dialogueRunner)
        {
            dialogueRunner.AddCommandHandler("CatsCradleBlueItem", FreeStuff);
            GamerNPC.Setup(dialogueRunner);
        }
    }

    public class BlueItem
    {
        public Sprite ability;
        public Sprite item;
        public EffectSO indirect;
        public WearableStaticModifierSetterSO slap;
        public BlueItem(ItemPools pool)
        {
            ability = ResourceLoader.LoadSprite("BlueFist.png", 32);
            item = ResourceLoader.LoadSprite("BlueMask.png", 32);
            indirect = ScriptableObject.CreateInstance<DamageEffect>();
            (indirect as DamageEffect)._indirect = true;
            FlowingJab = new Ability()
            {
                name = "Flowing Jab",
                description = "Deal 4 indirect damage to the Opposing enemy. \nFor every Blue pigment in the pigment tray, there is a 10% chance to refresh this party member's abilities.",
                sprite = ability,
                cost = new ManaColorSO[] { Pigments.Blue },
                effects = new Effect[]
                {
                    new Effect(indirect, 4, IntentType.Damage_3_6, Slots.Front),
                    new Effect(ScriptableObject.CreateInstance<RefreshAbilityUseEffect>(), 1, IntentType.Misc, Slots.Self, ScriptableObject.CreateInstance<BlueEffectCondition>())
                },
                visuals = LoadedAssetsHandler.GetCharacterAbility("Parry_1_A").visuals,
                animationTarget = Slots.Front
            };
            slap = ScriptableObject.CreateInstance<BasicAbilityChange_Wearable_SMS>();
            ((BasicAbilityChange_Wearable_SMS)slap)._basicAbility = FlowingJab.CharacterAbility();
            BlueDisciple = new EffectItem()
            {
                name = "Blue Disciple",
                flavorText = "\"Let it flow inside you.\"",
                description = "Replaces slap on this party member with \"Flowing Jab\".",
                sprite = item,
                consumeTrigger = TriggerCalls.Count,
                unlockableID = (UnlockableID)775002,
                namePopup = false,
                consumedOnUse = false,
                itemPools = pool,
                shopPrice = 6,
                startsLocked = false,
                immediate = true,
                equippedModifiers = new WearableStaticModifierSetterSO[1] { slap }
            };
        }

        public Ability FlowingJab;

        public Item BlueDisciple;
    }

    public class BlueEffectCondition: EffectConditionSO
    {
        public override bool MeetCondition(IUnit caster, EffectInfo[] effects, int currentIndex)
        {
            CombatStats stats = CombatManager.Instance._stats;
            ManaBar main = stats.MainManaBar;
            int blues = 0;
            foreach (ManaBarSlot slot in main.ManaBarSlots)
            {
                if (!slot.IsEmpty && slot.ManaColor == Pigments.Blue)
                {
                    blues++;
                }
            }
            return UnityEngine.Random.Range(0, 100) < (blues * 10);

        }
    }
}
