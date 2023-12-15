using BepInEx;
using System.Linq;
using System.Runtime.InteropServices;
using Zeekerss;
using Zeekerss.Core;
using Zeekerss.Core.Singletons;
using System;
using HarmonyLib;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using System.Reflection;
using GameNetcodeStuff;
using ModelReplacement;
using BepInEx.Configuration;
using MoreCompany.Cosmetics;
using MoreCompany.Utils;

//using System.Numerics;

namespace SpaceGirlModelReplacement
{




    [BepInPlugin("mina.SpaceGirlModelReplacement", "Space Girl", "1.0.0")]
    [BepInDependency("meow.ModelReplacementAPI", BepInDependency.DependencyFlags.HardDependency)]
    public class Plugin : BaseUnityPlugin
    {
        public static ConfigFile config;
        public static ConfigEntry<float> UpdateRate { get; private set; }
        public static ConfigEntry<float> distanceDisablePhysics { get; private set; }
        public static ConfigEntry<bool> disablePhysicsAtRange { get; private set; }

        private static void InitConfig()
        {
            UpdateRate = config.Bind<float>("Dynamic Bone Settings", "Update rate", 60, "Refreshes dynamic bones more times per second the higher the number");
            disablePhysicsAtRange = config.Bind<bool>("Dynamic Bone Settings", "Disable physics at range", false, "Enable to disable physics past the specified range");
            distanceDisablePhysics = config.Bind<float>("Dynamic Bone Settings", "Distance to disable physics", 20, "If Disable physics at range is enabled, this is the range after which physics is disabled.");
            

        }
        private void Awake()
        {

            config = base.Config;
            InitConfig();
            // Plugin startup logic
            AssetBundle cosmeticsBundle = BundleUtilities.LoadBundleFromInternalAssembly("hair", Assembly.GetExecutingAssembly());
            CosmeticRegistry.LoadCosmeticsFromAssembly(Assembly.GetExecutingAssembly(), cosmeticsBundle);
            //ModelReplacementAPI.RegisterSuitModelReplacement("Green suit", typeof(BodyReplacementMiku));
            ModelReplacement.ModelReplacementAPI.RegisterSuitModelReplacement("Default", typeof(BodyReplacementSpaceGirl));
            ModelReplacement.ModelReplacementAPI.RegisterSuitModelReplacement("주황색 슈트", typeof(BodyReplacementSpaceGirl));

            ModelReplacement.ModelReplacementAPI.RegisterSuitModelReplacement("Orange suit", typeof(BodyReplacementSpaceGirl));
            //ModelReplacementAPI.RegisterSuitModelReplacement("Pajama suit", typeof(BodyReplacementMiku));
            //ModelReplacementAPI.RegisterSuitModelReplacement("Hazard suit", typeof(BodyReplacementMiku));

            Assets.PopulateAssets();

            Harmony harmony = new Harmony("mina.SpaceGirlModelReplacement");
            harmony.PatchAll();
            Logger.LogInfo($"Plugin {"mina.SpaceGirlModelReplacement"} is loaded!");
        }



        [HarmonyPatch(typeof(PlayerControllerB))]
        public class PlayerControllerBPatch
        {

            [HarmonyPatch("Update")]
            [HarmonyPostfix]
            public static void UpdatePatch(ref PlayerControllerB __instance)
            {
                if (__instance.playerSteamId == 0) { return; }
                //ModelReplacementAPI.SetPlayerModelReplacement(__instance, typeof(BodyReplacementMinahoshi));

            }

        }



    }
    public static class Assets
    {
        public static string mainAssetBundleName = "mbundle";
        public static AssetBundle MainAssetBundle = null;

        private static string GetAssemblyName() => Assembly.GetExecutingAssembly().FullName.Split(',')[0];
        public static void PopulateAssets()
        {
            if (MainAssetBundle == null)
            {
                using (var assetStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(GetAssemblyName() + "." + mainAssetBundleName))
                {
                    MainAssetBundle = AssetBundle.LoadFromStream(assetStream);
                }

            }
        }
    }

}