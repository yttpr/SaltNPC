// Decompiled with JetBrains decompiler
// Type: Cat_sCradle.ScreenShake
// Assembly: "Cat'sCradle", Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 0655AEEE-5A60-4F93-BDB6-92433D76888B
// Assembly location: C:\Users\windows\Downloads\Cat'sCradle\Cat'sCradle.dll

using MonoMod.RuntimeDetour;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

#nullable disable
namespace Cat_sCradle
{
  public static class ScreenShake
  {
    public static MainMenuController mainCont;
    public static OverworldManagerBG overMan;

    public static AnimationCurve curve()
    {
      Keyframe keyframe1;
      // ISSUE: explicit constructor call
      ((Keyframe) ref keyframe1).\u002Ector(0.0f, 0.0f);
      Keyframe keyframe2;
      // ISSUE: explicit constructor call
      ((Keyframe) ref keyframe2).\u002Ector(0.15f, 50f);
      Keyframe keyframe3;
      // ISSUE: explicit constructor call
      ((Keyframe) ref keyframe3).\u002Ector(0.225f, 45f);
      Keyframe keyframe4;
      // ISSUE: explicit constructor call
      ((Keyframe) ref keyframe4).\u002Ector(1f, 0.0f);
      return new AnimationCurve(new Keyframe[4]
      {
        keyframe1,
        keyframe2,
        keyframe3,
        keyframe4
      });
    }

    public static void Shake(float duration = 5f)
    {
      foreach (Camera camera in Object.FindObjectsOfType<Camera>(true))
        ;
      ((MonoBehaviour) ScreenShake.overMan).StartCoroutine(ScreenShake.Shaking(duration));
    }

    public static IEnumerator Shaking(float duration)
    {
      Dictionary<Camera, Vector3> cams = new Dictionary<Camera, Vector3>();
      Camera[] cameraArray = Object.FindObjectsOfType<Camera>();
      for (int index = 0; index < cameraArray.Length; ++index)
      {
        Camera cam = cameraArray[index];
        cams.Add(cam, ((Component) cam).transform.position);
        cam = (Camera) null;
      }
      cameraArray = (Camera[]) null;
      float elapsedTime = 0.0f;
      AnimationCurve Curve = ScreenShake.curve();
      while ((double) elapsedTime < (double) duration)
      {
        elapsedTime += Time.deltaTime;
        float strnegth = Curve.Evaluate(elapsedTime / duration);
        foreach (Camera cam in cams.Keys)
          ((Component) cam).transform.position = Vector3.op_Addition(cams[cam], Random.insideUnitSphere);
        yield return (object) null;
      }
      foreach (Camera cam in cams.Keys)
        ((Component) cam).transform.position = cams[cam];
    }

    public static void Setup()
    {
      IDetour idetour = (IDetour) new Hook((MethodBase) typeof (OverworldManagerBG).GetMethod("Awake", ~BindingFlags.Default), typeof (ScreenShake).GetMethod("Awake", ~BindingFlags.Default));
    }

    public static void Awake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
    {
      orig(self);
      ScreenShake.overMan = self;
      BlueNPC.overManager = self;
    }
  }
}
