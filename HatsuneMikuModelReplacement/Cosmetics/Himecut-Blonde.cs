using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using BepInEx;
using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using MoreCompany.Cosmetics;
using MoreCompany.Utils;
using Unity.Netcode;
using UnityEngine;
using UnityEngine.Audio;
using Logger = BepInEx.Logging.Logger;
using Object = UnityEngine.Object;
namespace Mina.Cosmetics
{
    public class HimecutBlonde : CosmeticGeneric
    {
        public override string gameObjectPath => "Assets/himecut/himecut_blonde.prefab";
        public override string cosmeticId => "mina.himecutblonde";
        public override string textureIconPath => "Assets/icons/himecut_blonde.png";

        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }

}