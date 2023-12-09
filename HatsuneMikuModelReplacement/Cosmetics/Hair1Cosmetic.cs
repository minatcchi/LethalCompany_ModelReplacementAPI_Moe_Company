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
    public class Hair1 : CosmeticGeneric
    {
        public override string gameObjectPath => "Assets/hair/Hair1.prefab";
        public override string cosmeticId => "mina.hair1";
        public override string textureIconPath => "Assets/hair/hair1_icon.png";

        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }

}