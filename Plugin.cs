using System;
using System.Reflection;
using HarmonyLib;
using System.Collections.Generic;
using MelonLoader;
using UnityEngine;
using SlipperyIce.Behaviours;

[assembly: MelonInfo(typeof(SlipperyIce.Plugin), "SlipperyIce", "1.0.3", "fchb1239 / xvfraudd")]
[assembly: MelonGame("Another Axiom", "Gorilla Tag")]
namespace SlipperyIce
{
    public class Plugin : MelonMod
    {
        public static bool modLoaded;
        public static bool modEnabledTemp = false;

        public override void OnLateInitializeMelon()
        {
            IceHandler.instance.Enable();
            IceHandler.instance.JoinedModded();
        }

        void OnEnable()
        {
            if (modLoaded)
                IceHandler.instance.Enable();
            else
                modEnabledTemp = true;

            Console.WriteLine("Enabled the ice");
        }

        void OnDisable()
        {
            if (modLoaded)
                IceHandler.instance.Disable();
            else
                modEnabledTemp = false;

            Console.WriteLine("Disabled the ice");
        }

        void JoinedModded()
        {
            IceHandler.instance.JoinedModded();
            Console.WriteLine("Joined modded room");
        }

        void LeftModded()
        {
            IceHandler.instance.LeftModded();
            Console.WriteLine("Left modded room");
        }
    }
}
