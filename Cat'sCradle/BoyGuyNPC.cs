// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.BoyGuyNPC
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
  public static class BoyGuyNPC
  {
    public static Sprite World
    {
      get => ResourceLoader.LoadSprite("MenuGuy_1.png", 32, new Vector2?(new Vector2(0.5f, 0.0f)));
    }

    public static Sprite WNPivot => ResourceLoader.LoadSprite("MenuGuy_1.png", 32);

    public static Sprite Front => ResourceLoader.LoadSprite("FrontGuy_1.png", 32);

    public static Sprite Piss => ResourceLoader.LoadSprite("FrontGuy_2.png", 32);

    public static YarnProgram Script
    {
      get => Data.Assets.LoadAsset<YarnProgram>("assets/GuyGuy/guy.yarn");
    }

    public static void Urination()
    {
      string str = "RedBoyGuyRoom";
      string key1 = "RedBoyGuyConvo";
      string key2 = "RedBoyGuyEncounter";
      NPCRoomHandler npcRoomHandler = Data.Assets.LoadAsset<GameObject>("assets/GuyGuy/GuyRoom.prefab").AddComponent<NPCRoomHandler>();
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
      instance1.dialog = BoyGuyNPC.Script;
      instance1.startNode = "Salt.Piss.Start";
      if (!LoadedAssetsHandler.LoadedDialogues.Keys.Contains<string>(key1))
        LoadedAssetsHandler.LoadedDialogues.Add(key1, instance1);
      else
        LoadedAssetsHandler.LoadedDialogues[key1] = instance1;
      BasicEncounterSO instance2 = ScriptableObject.CreateInstance<BasicEncounterSO>();
      ((Object) instance2).name = key2;
      instance2._dialogue = key1;
      instance2.encounterRoom = str;
      instance2.signType = (SignType) 775018;
      instance2.npcEntityIDs = new EntityIDs[1]
      {
        (EntityIDs) 775018
      };
      if (!LoadedAssetsHandler.LoadedBasicEncounters.Keys.Contains<string>(key2))
        LoadedAssetsHandler.LoadedBasicEncounters.Add(key2, instance2);
      else
        LoadedAssetsHandler.LoadedBasicEncounters[key2] = instance2;
      ZoneBGDataBaseSO zoneDb1 = LoadedAssetsHandler.GetZoneDB("ZoneDB_03") as ZoneBGDataBaseSO;
      ZoneBGDataBaseSO zoneDb2 = LoadedAssetsHandler.GetZoneDB("ZoneDB_Hard_03") as ZoneBGDataBaseSO;
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
      if (((IEnumerable<string>) zoneDb1._FlavourPool).Contains<string>(key2))
        ;
      if (!((IEnumerable<string>) zoneDb2._FlavourPool).Contains<string>(key2))
        zoneDb2._FlavourPool = new List<string>((IEnumerable<string>) zoneDb2._FlavourPool)
        {
          key2
        }.ToArray();
      SpeakerData instance3 = ScriptableObject.CreateInstance<SpeakerData>();
      instance3.speakerName = "PissGuy" + PathUtils.speakerDataSuffix;
      ((Object) instance3).name = "PissGuy" + PathUtils.speakerDataSuffix;
      SpeakerBundle speakerBundle1 = new SpeakerBundle();
      speakerBundle1.dialogueSound = "event:/Characters/Enemies/DLC_01/GlidedGulper/CHR_ENM_GlidedGulper_Dmg";
      speakerBundle1.portrait = BoyGuyNPC.Front;
      speakerBundle1.bundleTextColor = Color32.op_Implicit(new Color32((byte) 207, (byte) 0, (byte) 0, byte.MaxValue));
      SpeakerBundle speakerBundle2 = new SpeakerBundle();
      speakerBundle2.dialogueSound = "event:/Characters/Enemies/DLC_01/GlidedGulper/CHR_ENM_GlidedGulper_Dmg";
      speakerBundle2.portrait = BoyGuyNPC.Piss;
      speakerBundle2.bundleTextColor = Color32.op_Implicit(new Color32((byte) 207, (byte) 0, (byte) 0, byte.MaxValue));
      instance3._defaultBundle = speakerBundle1;
      instance3.portraitLooksLeft = false;
      instance3.portraitLooksCenter = false;
      instance3._emotionBundles = new SpeakerEmote[2]
      {
        new SpeakerEmote()
        {
          emotion = "Piss",
          bundle = speakerBundle2
        },
        new SpeakerEmote()
        {
          emotion = "Default",
          bundle = speakerBundle1
        }
      };
      if (!LoadedAssetsHandler.LoadedSpeakers.Keys.Contains<string>(instance3.speakerName))
        LoadedAssetsHandler.LoadedSpeakers.Add(instance3.speakerName, instance3);
      else
        LoadedAssetsHandler.LoadedSpeakers[instance3.speakerName] = instance3;
    }

    public static void Add()
    {
      BrutalAPI.BrutalAPI.AddSignType((SignType) 775018, BoyGuyNPC.WNPivot);
      Bitem.gruh();
    }
  }
}
