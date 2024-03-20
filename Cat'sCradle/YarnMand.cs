// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.YarnMand
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using MonoMod.RuntimeDetour;
using System;
using System.Reflection;
using Yarn;
using Yarn.Unity;

#nullable disable
namespace Cat_sCradle
{
  public static class YarnMand
  {
    public static void InitializeDialogueFunctions(
      Action<InGameDataSO, DialogueRunner> orig,
      InGameDataSO self,
      DialogueRunner dialogueRunner)
    {
      orig(self, dialogueRunner);
      LisaNPC.Setup(dialogueRunner);
      BitchesHouse.Setup(dialogueRunner);
      BlueNPC.Setup(dialogueRunner);
      Bitem.Setup(dialogueRunner);
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      dialogueRunner.AddFunction("CatsCradleRunCheck", 1, YarnMand.\u003C\u003Ec.\u003C\u003E9__0_0 ?? (YarnMand.\u003C\u003Ec.\u003C\u003E9__0_0 = new ReturningFunction((object) YarnMand.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CInitializeDialogueFunctions\u003Eb__0_0))));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      dialogueRunner.AddCommandHandler("CatsCradleRunSet", YarnMand.\u003C\u003Ec.\u003C\u003E9__0_1 ?? (YarnMand.\u003C\u003Ec.\u003C\u003E9__0_1 = new DialogueRunner.CommandHandler((object) YarnMand.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CInitializeDialogueFunctions\u003Eb__0_1))));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      dialogueRunner.AddFunction("CatsCradleGameCheck", 1, YarnMand.\u003C\u003Ec.\u003C\u003E9__0_2 ?? (YarnMand.\u003C\u003Ec.\u003C\u003E9__0_2 = new ReturningFunction((object) YarnMand.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CInitializeDialogueFunctions\u003Eb__0_2))));
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: reference to a compiler-generated field
      // ISSUE: method pointer
      dialogueRunner.AddCommandHandler("CatsCradleGameSet", YarnMand.\u003C\u003Ec.\u003C\u003E9__0_3 ?? (YarnMand.\u003C\u003Ec.\u003C\u003E9__0_3 = new DialogueRunner.CommandHandler((object) YarnMand.\u003C\u003Ec.\u003C\u003E9, __methodptr(\u003CInitializeDialogueFunctions\u003Eb__0_3))));
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (InGameDataSO).GetMethod("InitializeDialogueFunctions", ~BindingFlags.Default), typeof (YarnMand).GetMethod("InitializeDialogueFunctions", ~BindingFlags.Default));
      SavePerRun.Setup();
      SaveGame.Setup();
    }
  }
}
