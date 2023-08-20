using System.Collections.Generic;
using UnityEngine;
using System.Reflection;
using HarmonyLib;
using System.IO;
using System.Linq;
using NCMS;
using ReflectionUtility;
using static Config;

namespace ModernMod
{
    [ModEntry]
    public partial class WorldBoxMod : MonoBehaviour
    {
        private bool initialized = false;

        public void Awake()
        {
            Harmony harmony = new Harmony("nikon.worldbox.modernmod");
            
            //harmony.Patch(AccessTools.Method(typeof(Building), "setSpriteMain"), prefix: new HarmonyMethod(AccessTools.Method(typeof(WorldBoxMod), nameof(setSpriteMain))));
        }

        public void Update()
        {
            if (!gameLoaded) return;
            if (!initialized)
            {
                MODDED = true;
                initBuildings();
                initPower();
                initBuildingOrder();
                //initCultureTech();
            }

            initialized = true;
        }

        

        private static void setSpriteMain(bool pTween, BuildingAsset ___stats){

            Debug.Log(___stats.id);
            //Debug.Log($"Sprite is null for: {stats.id}: {pSprite?.name is null}");
        }

        // [HarmonyPatch(typeof(Building), "setSpriteMain")]
        // [HarmonyPrefix]
        // public static bool setSpriteMain_Prefix(Building __instance, SpriteAnimation ___spriteAnimation)
        // {
        //     //__instance.spriteAnimation.currentFrameIndex = 0;
        //     ___spriteAnimation.currentFrameIndex = 0;

        //     return true;
        // }
    }
}
