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
    public class TwintailsBackBlack : CosmeticGeneric
    {
        public override string gameObjectPath => "Assets/twintailsback/twintailsback_black.prefab";
        public override string cosmeticId => "mina.twintailsbackblack";
        public override string textureIconPath => "Assets/icons/twintailsback_black.png";

        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }

}