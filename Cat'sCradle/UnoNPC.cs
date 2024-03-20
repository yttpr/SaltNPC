// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.UnoNPC
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using System.Collections.Generic;
using System.Linq;
using Tools;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public static class UnoNPC
  {
    public static Sprite World
    {
      get
      {
        return ResourceLoader.LoadSprite("Uno_Overworld.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
      }
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("Uno_Overworld.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("Uno_Front.png", 32);

    public static Sprite Down => ResourceLoader.LoadSprite("Uno_Down.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/SquintGuy/fatty.yarn");
    }

    public static void Piss()
    {
      string str = "NumeroUnoRoom";
      string key1 = "NumeroUnoConvo";
      string key2 = "NumeroUnoEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/UnoGuy/UnoRoom.prefab").AddComponent<NPCRoomHandler>();
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
      instance1.dialog = UnoNPC.Script;
      instance1.startNode = "Salt.Uno.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      BasicEncounterSO instance2 = ScriptableObject.CreateInstance<BasicEncounterSO>();
      ((Object) instance2).name = key2;
      instance2._dialogue = key1;
      instance2.encounterRoom = str;
      instance2.signType = (SignType) 775010;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775010
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = instance2;
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
      if (!((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key2))
        zoneDb1._FlavourPool = new List<string>((IEnumerable<string>) zoneDb1._FlavourPool)
        {
          key2
        }.ToArray();
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key2))
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key2
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "UnoGuy" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "UnoGuy" + PathUtils.speakerDataSuffix;
      SpeakerBundle speakerBundle1 = new SpeakerBundle();
      speakerBundle1.dialogueSound = "event:/Characters/NPC/CHR_NPC_Pervert_Dx";
      speakerBundle1.portrait = UnoNPC.Front;
      speakerBundle1.bundleTextColor = Data.Speech;
      SpeakerBundle speakerBundle2 = new SpeakerBundle();
      speakerBundle2.dialogueSound = "event:/Characters/NPC/CHR_NPC_Pervert_Dx";
      speakerBundle2.portrait = UnoNPC.Down;
      speakerBundle2.bundleTextColor = Data.Speech;
      instance3._defaultBundle = speakerBundle1;
      instance3.portraitLooksLeft = true;
      instance3.portraitLooksCenter = false;
      instance3._emotionBundles = new SpeakerEmote[2]
      {
        new SpeakerEmote()
        {
          emotion = "Front",
          bundle = speakerBundle1
        },
        new SpeakerEmote()
        {
          emotion = "Down",
          bundle = speakerBundle2
        }
      };
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }

    public static void Add() => BrutalAPI.BrutalAPI.AddSignType((SignType) 775010, UnoNPC.WNPivot);
  }
}
