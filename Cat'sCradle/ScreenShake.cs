using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using System.Collections;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace Cat_sCradle
{
    public static class ScreenShake
    {
        public static MainMenuController mainCont;
        public static OverworldManagerBG overMan;
        
        public static AnimationCurve curve()
        {
            Keyframe start = new Keyframe(0f, 0f);
            Keyframe peak = new Keyframe(0.15f, 50f);
            Keyframe cap = new Keyframe(0.225f, 45f);
            Keyframe end = new Keyframe(1f, 0f);
            Keyframe[] array = new Keyframe[] {start, peak, cap, end };
            AnimationCurve ret = new AnimationCurve(array);
            return ret;
        }
        
        public static void Shake(float duration = 5f)
        {
            foreach (Camera cam in UnityEngine.Object.FindObjectsOfType<Camera>(includeInactive: true))
            {
                //Debug.Log(cam);
            }
            //Debug.Log("cam.main: " + Camera.main);
           // Debug.Log("cam.curr: " + Camera.current);
            
            overMan.StartCoroutine(Shaking(duration));
        }

        public static IEnumerator Shaking(float duration)
        {
            Dictionary<Camera, Vector3> cams = new Dictionary<Camera, Vector3>();
            foreach(Camera cam in UnityEngine.Object.FindObjectsOfType<Camera>())
            {
                cams.Add(cam, cam.transform.position);
            }
            //Debug.Log(1);
            //Vector3 startpos = cam.transform.position;
            //Debug.Log(2);
            float elapsedTime = 0f;
            AnimationCurve Curve = curve();
            //Debug.Log(3);
            while (elapsedTime < duration)
            {
                elapsedTime += Time.deltaTime;
                float strnegth = Curve.Evaluate(elapsedTime / duration);
                foreach(Camera cam in cams.Keys)
                    cam.transform.position = cams[cam] + UnityEngine.Random.insideUnitSphere;
                yield return null;
            }
            foreach (Camera cam in cams.Keys)
                cam.transform.position = cams[cam];
        }


        public static void Setup()
        {
            IDetour hook = new Hook(typeof(OverworldManagerBG).GetMethod(nameof(OverworldManagerBG.Awake), ~BindingFlags.Default), typeof(ScreenShake).GetMethod(nameof(Awake), ~BindingFlags.Default));
        }
        public static void Awake(Action<OverworldManagerBG> orig, OverworldManagerBG self)
        {
            orig(self);
            overMan = self;
            BlueNPC.overManager = self;
        }
    }
}
