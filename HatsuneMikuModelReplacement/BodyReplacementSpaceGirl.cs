using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using Newtonsoft.Json;
using System.Linq;
using System.Xml;
using System.IO;
using GameNetcodeStuff;
using UnityEngine.PlayerLoop;
using System.Reflection;
using ModelReplacement;

namespace SpaceGirlModelReplacement
{
    public class BodyReplacementSpaceGirl : BodyReplacementBase
    {
        public override string boneMapFileName => "boneMapSpacegirl.json";

        public override GameObject LoadAssetsAndReturnModel()
        {
            string model_name = "space girl";
            return Assets.MainAssetBundle.LoadAsset<GameObject>(model_name);
        }  

        public override void AddModelScripts()
        {
 
        }

 
    }
}
