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
    public class SidetailBrown : CosmeticGeneric
    {
        public override string gameObjectPath => "Assets/sidetail/sidetail_brown.prefab";
        public override string cosmeticId => "mina.sidetailbrown";
        public override string textureIconPath => "Assets/icons/sidetail_brown.png";

        public override CosmeticType cosmeticType => CosmeticType.HAT;
    }

}