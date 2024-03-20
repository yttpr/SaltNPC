using System;
using System.Collections.Generic;
using System.Text;
using Tools;
using UnityEngine;
using UnityEngine.Assertions;

namespace Cat_sCradle
{
    public static class Data
    {
        static AssetBundle _assets;
        public static AssetBundle Assets
        {
            get
            {
                if (_assets == null)
                {
                    _assets = AssetBundle.LoadFromMemory(ResourceLoader.ResourceBinary("npcjak"));
                }
                return _assets;
            }
        }

        public static Color Speech
        {
            get
            {
                SpeakerData admo = LoadedAssetsHandler.GetSpeakerData("Admo" + PathUtils.speakerDataSuffix);
                return admo._defaultBundle.bundleTextColor;
            }
        }
        public static Color Bosch
        {
            get
            {
                SpeakerData bosch = LoadedAssetsHandler.GetSpeakerData("Bosch" + PathUtils.speakerDataSuffix);
                return bosch._defaultBundle.bundleTextColor;
            }
        }
        public static Color Dimitri
        {
            get
            {
                SpeakerData dimitri = LoadedAssetsHandler.GetSpeakerData("Dimitri" + PathUtils.speakerDataSuffix);
                return dimitri._defaultBundle.bundleTextColor;
            }
        }
    }

}
