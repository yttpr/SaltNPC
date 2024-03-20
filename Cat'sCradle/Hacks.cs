// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.Hacks
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public static class Hacks
  {
    public static void Setup()
    {
      IDetour idetour1 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("LoadOldRun", ~BindingFlags.Default), typeof (Hacks).GetMethod("LoadOldRun", ~BindingFlags.Default));
      IDetour idetour2 = (IDetour) new Hook((MethodBase) typeof (MainMenuController).GetMethod("OnEmbarkPressed", ~BindingFlags.Default), typeof (Hacks).GetMethod("LoadOldRun", ~BindingFlags.Default));
      ScreenShake.Setup();
    }

    public static BaseRoomHandler PopulateRoomInstance(
      Func<RunDataSO, Card, BaseRoomHandler> orig,
      RunDataSO self,
      Card card)
    {
      if (card.RoomPrefabName == "TestRoom")
        TestNPC.Test(false);
      else if (card.RoomPrefabName == "PitRoom")
      {
        PitNPC.Pit();
      }
      else
      {
        if (!(card.RoomPrefabName == "BucketRoom"))
          return orig(self, card);
        BucketNPC.Fish();
      }
      BaseRoomHandler baseRoomHandler = orig(self, card);
      if (baseRoomHandler is NPCRoomHandler npcRoomHandler)
        ((Renderer) npcRoomHandler._npcSelectable._renderers[0]).enabled = true;
      return baseRoomHandler;
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
}
