// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.Bitem
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using BrutalAPI;
using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using UnityEngine;
using Yarn.Unity;

#nullable disable
namespace Cat_sCradle
{
  public static class Bitem
  {
    public static void gruh()
    {
      EffectItem effectItem = new EffectItem();
      effectItem.name = "Ugly Painting";
      effectItem.flavorText = "\"Who made this *#%@!?\"";
      effectItem.description = "boYguY always delivers. You can count on boYguY.";
      effectItem.sprite = ResourceLoader.LoadSprite("itemguy.png", 32);
      effectItem.unlockableID = (UnlockableID) 695374;
      effectItem.namePopup = true;
      effectItem.itemPools = ItemPools.Extra;
      effectItem.effects = new Effect[4]
      {
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 69420, new IntentType?(), Slots.SlotTarget(new int[9]
        {
          -4,
          -3,
          -2,
          -1,
          0,
          1,
          2,
          3,
          4
        })),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyOilSlickedEffect>(), 69420, new IntentType?(), Slots.SlotTarget(new int[9]
        {
          -4,
          -3,
          -2,
          -1,
          0,
          1,
          2,
          3,
          4
        }, true)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 69, new IntentType?(), Slots.Self, (EffectConditionSO) Conditions.Chance(8)),
        new Effect((EffectSO) ScriptableObject.CreateInstance<ApplyFireSlotEffect>(), 69, new IntentType?(), Slots.Front, (EffectConditionSO) Conditions.Chance(2))
      };
      effectItem.trigger = (TriggerCalls) 21;
      effectItem.AddItem();
    }

    public static void FreeStuff(string[] info)
    {
      BlueNPC.AddCopy(LoadedAssetsHandler.GetWearable("UglyPainting_EW"));
    }

    public static void Setup(DialogueRunner dialogueRunner)
    {
      // ISSUE: method pointer
      dialogueRunner.AddCommandHandler("CatsCradlePissItem", new DialogueRunner.CommandHandler((object) null, __methodptr(FreeStuff)));
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (OverworldManagerBG).GetMethod("Awake", ~BindingFlags.Default), typeof (Bitem).GetMethod("Awake", ~BindingFlags.Default));
    }

    public static void Awake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
    {
      orig(self);
      BlueNPC.overManager = self;
    }
  }
}
