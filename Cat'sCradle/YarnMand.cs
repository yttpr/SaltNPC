using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Yarn;
using Yarn.Unity;
using Yarn.Analysis;
using Yarn.Compiler;
using Tools;
using System.IO;
using System.Xml;
using static UnityEngine.EventSystems.EventTrigger;
using System.Text.RegularExpressions;
using System.Linq;
using MonoMod.RuntimeDetour;
using System.Reflection;

namespace Cat_sCradle
{
    public static class YarnMand
    {
        public static void InitializeDialogueFunctions(Action<InGameDataSO, DialogueRunner> orig, InGameDataSO self, DialogueRunner dialogueRunner)
        {
            orig(self, dialogueRunner);
            LisaNPC.Setup(dialogueRunner);
            BitchesHouse.Setup(dialogueRunner);
            BlueNPC.Setup(dialogueRunner);
            Bitem.Setup(dialogueRunner);
            dialogueRunner.AddFunction("CatsCradleRunCheck", 1, delegate (Value[] parameters)
            {
                Value val = parameters[0];
                return SavePerRun.Check(val.AsString);
            });
            dialogueRunner.AddCommandHandler("CatsCradleRunSet", delegate (string[] info) 
            {
                if (info.Length >= 2)
                {
                    string key = info[0];
                    bool value = info[1].Contains("true");
                    SavePerRun.Set(key, value);
                }
            });
            dialogueRunner.AddFunction("CatsCradleGameCheck", 1, delegate (Value[] parameters)
            {
                Value val = parameters[0];
                return SaveGame.Check(val.AsString);
            });
            dialogueRunner.AddCommandHandler("CatsCradleGameSet", delegate (string[] info)
            {
                if (info.Length >= 2)
                {
                    string key = info[0];
                    bool value = info[1].Contains("true");
                    SaveGame.Set(key, value);
                }
            });
        }

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(InGameDataSO).GetMethod(nameof(InGameDataSO.InitializeDialogueFunctions), ~BindingFlags.Default), 
                typeof(YarnMand).GetMethod(nameof(InitializeDialogueFunctions), ~BindingFlags.Default));
            SavePerRun.Setup();
            SaveGame.Setup();
            DialogueHandler d; RunInGameData r;
        }
    }

    public static class SavePerRun
    {
        public const string ModID = "SaltTestNPC";//CHANGE THIS
        public const string FileName = "RunData";
        static string baseSave
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
            }
        }
        static string pathPlus
        {
            get
            {
                if (!Directory.Exists(baseSave + "Mods\\"))
                {
                    Directory.CreateDirectory(baseSave + "Mods\\");
                }
                return baseSave + "Mods\\";
            }
        }
        public static string SavePath
        {
            get
            {
                if (!Directory.Exists(pathPlus + ModID + "\\"))
                {
                    Directory.CreateDirectory(pathPlus + ModID + "\\");
                }
                return pathPlus + ModID + "\\";
            }
        }
        public static string SaveName
        {
            get
            {
                if (!File.Exists(SavePath + FileName + ".config"))
                {
                    WriteConfig(SavePath + FileName + ".config");
                }
                return SavePath + FileName + ".config";
            }
        }

        public static Dictionary<string, bool> SaveConfigNames;

        public static void WriteConfig(string location)
        {
            StreamWriter text = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string xml = "<config";
            foreach (string key in SaveConfigNames.Keys)
            {
                xml += " ";
                xml += key;
                xml += "='";
                xml += SaveConfigNames[key].ToString().ToLower();
                xml += "'";
            }
            xml += "> </config>";
            xmlDocument.LoadXml(xml);
            xmlDocument.Save((TextWriter)text);
            text.Close();
        }

        public static bool Check(string name)
        {
            if (SaveConfigNames == null)
            {
                SaveConfigNames = new Dictionary<string, bool>();
            }
            string l = SaveName;
            bool add = false;
            FileStream inStream = File.Open(SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load((Stream)inStream);
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {
                
                if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
                {
                    add = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);
                    
                }
                if (!SaveConfigNames.Keys.Contains(name))
                    SaveConfigNames.Add(name, add);
                else
                    SaveConfigNames[name] = add;
            }
            inStream.Close();
            return add;
        }

        public static void Set(string name, bool value)
        {
            if (Check(name) != value)
            { 
                SaveConfigNames[name] = value;
                WriteConfig(SaveName);
            }
        }

        public static void OnEmbarkPressed(Action<MainMenuController> orig, MainMenuController self)
        {
            orig(self);
            List<string> keys = new List<string>();
            foreach(string key in SaveConfigNames.Keys)
            {
                keys.Add(key);
                
            }
            foreach (string key in keys)
            {
                SaveConfigNames[key] = false;
            }
            WriteConfig(SaveName);
            
        }

        public static void Setup()
        {
            IDetour hook = new Hook(typeof(MainMenuController).GetMethod(nameof(MainMenuController.OnEmbarkPressed), ~BindingFlags.Default), typeof(SavePerRun).GetMethod(nameof(OnEmbarkPressed), ~BindingFlags.Default));
            //Check all the bools you have in your config at the start of loading the game, since there's no way to like, grab all nodes or something as far as i can tell
            Check("TestGuy");
            Check("PitGuy");
            Check("BucketOne");
            Check("BucketTwo");
            Check("BucketThree");
            Check("LisaGuy");
            Check("LisaExplode");
            Check("MinisterFirst");
            Check("SmileOne");
            Check("SmileTwo");
            Check("MirrorOne");
            Check("MirrorTwo");
            Check("Ketchup");
            Check("Blue");
            Check("HeartOne");
            Check("HeartTwo");
            Check("FlipStart");
            Check("Flipped");
            Check("FlipOne");
            Check("FlipTwo");
            Check("FlipThree");
            Check("ChestOne");
            Check("ChestTwo");
            Check("Help");
            Check("NoHelp");
            Check("Off");
            Check("FishCheck");
            Check("Found");
            Check("Squint");
            Check("Uno");
            Check("MagicRock");
            Check("Dusted");
            Check("GardenGuy");
            Check("Fleshless");
            Check("Crypto");
            Check("Levis");
            Check("ScaryGuy");
            Check("PissOne");
            Check("PissTwo");
            Check("PissItem");
            Check("GamerFirst");
            Check("GamerCoin");
            Check("WEED");
            Check("Balls");
            Check("Clueless");
            Check("Peep");
        }
    }

    public static class SaveGame
    {
        public const string ModID = "SaltTestNPC";//CHANGE THIS
        public const string FileName = "GameData";
        static string baseSave
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData).Replace("Roaming", "LocalLow") + "\\ItsTheMaceo\\BrutalOrchestra\\";
            }
        }
        static string pathPlus
        {
            get
            {
                if (!Directory.Exists(baseSave + "Mods\\"))
                {
                    Directory.CreateDirectory(baseSave + "Mods\\");
                }
                return baseSave + "Mods\\";
            }
        }
        public static string SavePath
        {
            get
            {
                if (!Directory.Exists(pathPlus + ModID + "\\"))
                {
                    Directory.CreateDirectory(pathPlus + ModID + "\\");
                }
                return pathPlus + ModID + "\\";
            }
        }
        public static string SaveName
        {
            get
            {
                if (!File.Exists(SavePath + FileName + ".config"))
                {
                    WriteConfig(SavePath + FileName + ".config");
                }
                return SavePath + FileName + ".config";
            }
        }

        public static Dictionary<string, bool> SaveConfigNames;

        public static void WriteConfig(string location)
        {
            StreamWriter text = File.CreateText(location);
            XmlDocument xmlDocument = new XmlDocument();
            string xml = "<config";
            foreach (string key in SaveConfigNames.Keys)
            {
                xml += " ";
                xml += key;
                xml += "='";
                xml += SaveConfigNames[key].ToString().ToLower();
                xml += "'";
            }
            xml += "> </config>";
            xmlDocument.LoadXml(xml);
            xmlDocument.Save((TextWriter)text);
            text.Close();
        }

        public static bool Check(string name)
        {
            if (SaveConfigNames == null)
            {
                SaveConfigNames = new Dictionary<string, bool>();
            }
            string l = SaveName;
            bool add = false;
            FileStream inStream = File.Open(SaveName, FileMode.Open);
            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.Load((Stream)inStream);
            if (xmlDocument.GetElementsByTagName("config").Count > 0)
            {

                if (xmlDocument.GetElementsByTagName("config")[0].Attributes[name] != null)
                {
                    add = bool.Parse(xmlDocument.GetElementsByTagName("config")[0].Attributes[name].Value);

                }
                if (!SaveConfigNames.Keys.Contains(name))
                    SaveConfigNames.Add(name, add);
                else
                    SaveConfigNames[name] = add;
            }
            inStream.Close();
            return add;
        }

        public static void Set(string name, bool value)
        {
            if (Check(name) != value)
            {
                SaveConfigNames[name] = value;
                WriteConfig(SaveName);
            }
        }

        public static void Setup()
        {
            Check("GamerShore");
            Check("GamerOrpheum");
            Check("GamerGarden");
        }
    }
}
