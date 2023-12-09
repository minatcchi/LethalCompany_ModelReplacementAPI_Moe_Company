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
    public class MessyWhite : CosmeticGeneric
    {
        public override string gameObjectPath => "Assets/hair/messyhair_white.prefab";
        public override string cosmeticId => "mina.messywhite";
        public override string textureIconPath => "Assets/icons/messy_white.png";

        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }

}