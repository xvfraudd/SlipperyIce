using System;
using HarmonyLib;
using UnityEngine;
using SlipperyIce.Behaviours;

namespace SlipperyIce.Patches
{
    //i need to make sure the scene is loaded
    [HarmonyPatch(typeof(GorillaLocomotion.GTPlayer))]
    [HarmonyPatch("Awake")]
    class PlayerPatch
    {
        private static void Postfix()
        {
            //just incase lemming pulls a Level/Forest to Level/forest - and he did
            try
            {
                //this guy really changed Level/Forest to Level/forest/Uncover ForestCombined/CombinedMesh-GameObject (1)-mesh/GameObject (1)-mesh-mesh bruh
                if (IceHandler.instance == null)
                    GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/Uncover ForestCombined").AddComponent<IceHandler>();
                else
                    Console.WriteLine("What the hell, how did this happen?");
                GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground bottom").AddComponent<Ice>();
                GameObject.Find("Environment Objects/LocalObjects_Prefab/Forest/Terrain/pitgeo/pit ground top").AddComponent<Ice>();

                /*
                GameObject.Find("Level/treeroom/tree/Tree").AddComponent<AxisInverter>();
                foreach (Transform child in GameObject.Find("Level/Forest/SmallTrees").transform)
                    GameObject.Find(string.Format("Level/Forest/SmallTrees/{0}/SmallTree", child.gameObject.name)).AddComponent<AxisInverter>();
                */

                if (Plugin.modEnabledTemp)
                    IceHandler.instance.Enable();

                Plugin.modLoaded = true;
            }
            catch { Console.Write("What the aaaaaaa"); }
        }
    }
}
