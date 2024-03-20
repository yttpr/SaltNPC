// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.BlueNPC
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;
using Yarn.Unity;

#nullable disable
namespace Cat_sCradle
{
  public static class BlueNPC
  {
    public static OverworldManagerBG overManager;

    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("BlueWorld.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("BlueWorld.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("BlueFace.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/BlueGuy/blue.yarn");
    }

    public static void Red()
    {
      string str = "BlueRoom";
      string key1 = "BlueConvo";
      string key2 = "BlueEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/BlueGuy/BlueRoom.prefab").AddComponent<NPCRoomHandler>();
      npcRoomHandler._npcSelectable = (BaseRoomItem) ((Component) ((Component) npcRoomHandler).transform.GetChild(0)).gameObject.AddComponent<BasicRoomItem>();
      npcRoomHandler._npcSelectable._renderers = new SpriteRenderer[1]
      {
        ((Component) ((Component) npcRoomHandler._npcSelectable).transform.GetChild(0)).GetComponent<SpriteRenderer>()
      };
      ((Renderer) npcRoomHandler._npcSelectable._renderers[0]).material = TestNPC.SpriteMat;
      if (!LoadedAssetsHandler.LoadedRoomPrefabs.Keys.Contains<string>(PathUtils.encounterRoomsResPath + str))
        LoadedAssetsHandler.LoadedRoomPrefabs.Add(PathUtils.encounterRoomsResPath + str, (BaseRoomHandler) npcRoomHandler);
      else
        LoadedAssetsHandler.LoadedRoomPrefabs[PathUtils.encounterRoomsResPath + str] = (BaseRoomHandler) npcRoomHandler;
      DialogueSO instance1 = ScriptableObject.CreateInstance<DialogueSO>();
      ((Object) instance1).name = key1;
      instance1.dialog = BlueNPC.Script;
      instance1.startNode = "Salt.Blue.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      ConditionEncounterSO instance2 = ScriptableObject.CreateInstance<ConditionEncounterSO>();
      instance2.questName = (QuestIDs) 775002;
      ((Object) instance2).name = key2;
      ((BasicEncounterSO) instance2)._dialogue = key1;
      ((BasicEncounterSO) instance2).encounterRoom = str;
      ((BasicEncounterSO) instance2).signType = (SignType) 775002;
      ((BasicEncounterSO) instance2).npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775002
      };
      instance2.questsCompletedNeeded = new QuestIDs[0];
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, (BasicEncounterSO) instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = (BasicEncounterSO) instance2;
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB("ZoneDB_01") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_01") as ZoneBGDataBaseSO;
      CardTypeInfo cardTypeInfo = new CardTypeInfo()
      {
        _cardInfo = new CardInfo()
        {
          cardType = (CardType) 300,
          pilePosition = (PilePositionType) 0
        },
        _percentage = 350,
        _usePercentage = true
      };
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key2))
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key2
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "BlueGuy" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "BlueGuy" + PathUtils.speakerDataSuffix;
      instance3._defaultBundle = new SpeakerBundle()
      {
        dialogueSound = "event:/Characters/NPC/CHR_NPC_Indecisive_Dx",
        portrait = BlueNPC.Front,
        bundleTextColor = Data.Speech
      };
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 775002, BlueNPC.WNPivot);

    public static bool AddCopy(BaseWearableSO item)
    {
      ((MonoBehaviour) BlueNPC.overManager).StartCoroutine(BlueNPC.AddCopyAction(BlueNPC.overManager, item));
      return true;
    }

    public static IEnumerator AddCopyAction(OverworldManagerBG overManager, BaseWearableSO item)
    {
      RunDataSO run = overManager._informationHolder.Run;
      bool hasItemSpace = run.playerData.HasItemSpace;
      StringTrioData itemLocData = item.GetItemLocData();
      string text = string.Format(LocUtils.LocDB.GetUIData((UILocID) 122), (object) itemLocData.text);
      if (!hasItemSpace)
        text = text + "\n" + LocUtils.LocDB.GetUIData((UILocID) 74);
      string uIData3 = LocUtils.LocDB.GetUIData((UILocID) 37);
      ConfirmDialogReference dialogReference3 = new ConfirmDialogReference(text, uIData3, "", item.wearableImage, itemLocData.description);
      NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, (object) null, (object) dialogReference3);
      while (dialogReference3.result == 1)
      {
        yield return (object) null;
        NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, (object) null, (object) dialogReference3);
      }
      overManager._soundManager.PlayOneshotSound(overManager._soundManager.itemGet);
      while (dialogReference3.result == 0)
        yield return (object) null;
      if (hasItemSpace)
      {
        run.playerData.AddNewItem(item);
      }
      else
      {
        overManager._extraItemMenuIsOpen = true;
        overManager._extraUIHandler.OpenItemExchangeMenu(new BaseWearableSO[1]
        {
          item
        });
        while (overManager._extraItemMenuIsOpen)
          yield return (object) null;
      }
      overManager.SaveProgress(true);
    }

    public static bool AddCopyOld(BaseWearableSO item)
    {
      bool hasItemSpace = BlueNPC.overManager._informationHolder.Run.playerData.HasItemSpace;
      if (hasItemSpace)
      {
        LisaNPC.info.Run.playerData.AddNewItem(item);
        return true;
      }
      StringTrioData itemLocData = item.GetItemLocData();
      string str = string.Format(LocUtils.LocDB.GetUIData((UILocID) 122), (object) itemLocData.text);
      if (!hasItemSpace)
        str = str + "\n" + LocUtils.LocDB.GetUIData((UILocID) 74);
      string uiData = LocUtils.LocDB.GetUIData((UILocID) 37);
      ConfirmDialogReference confirmDialogReference = new ConfirmDialogReference(str, uiData, "", item.wearableImage, itemLocData.description);
      NtfUtils.notifications.PostNotification(Utils.showConfirmDialogNtf, (object) null, (object) confirmDialogReference);
      if (confirmDialogReference.result != 1)
      {
        BlueNPC.overManager._soundManager.PlayOneshotSound(BlueNPC.overManager._soundManager.itemGet);
        if (!hasItemSpace)
          ((MonoBehaviour) BlueNPC.overManager).StartCoroutine(BlueNPC.overManager.OpenExchangeItemsOnConfirmation(confirmDialogReference, new BaseWearableSO[1]
          {
            item
          }));
      }
      return false;
    }

    public static void FreeStuff(string[] info)
    {
      BlueNPC.AddCopy(LoadedAssetsHandler.GetWearable("BlueDisciple_EW"));
    }

    public static void Setup(DialogueRunner dialogueRunner)
    {
      // ISSUE: method pointer
      dialogueRunner.AddCommandHandler("CatsCradleBlueItem", new DialogueRunner.CommandHandler((object) null, __methodptr(FreeStuff)));
      GamerNPC.Setup(dialogueRunner);
    }
  }
}
