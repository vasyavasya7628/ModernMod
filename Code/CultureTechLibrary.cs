using System.Collections.Generic;
using UnityEngine;
using ReflectionUtility;
using System.Reflection;
using HarmonyLib;
using System.IO;
using System.Linq;

namespace ModernMod
{
    public partial class WorldBoxMod : MonoBehaviour
    {
        private static void initCultureTech()
        {
            var house6 = new CultureTechAsset();
            house6.id = "house_tier_6";
            house6.path_icon = "tech/icon_tech_house_tier_5";
            house6.required_level = 21;
            house6.requirements = new List<string>{"house_tier_5"};
            AssetManager.culture_tech.add(house6);

            var house7 = new CultureTechAsset();
            house7.id = "house_tier_7";
            house7.path_icon = "tech/icon_tech_house_tier_5";
            house7.required_level = 22;
            house7.requirements = new List<string>{"house_tier_6"};
            AssetManager.culture_tech.add(house7);

            var house8 = new CultureTechAsset();
            house8.id = "house_tier_8";
            house8.path_icon = "tech/icon_tech_house_tier_5";
            house8.required_level = 23;
            house8.requirements = new List<string>{"house_tier_7"};
            AssetManager.culture_tech.add(house8);

            var house9 = new CultureTechAsset();
            house9.id = "house_tier_9";
            house9.path_icon = "tech/icon_tech_house_tier_5";
            house9.required_level = 24;
            house9.requirements = new List<string>{"house_tier_8"};
            AssetManager.culture_tech.add(house9);

            var house10 = new CultureTechAsset();
            house10.id = "house_tier_10";
            house10.path_icon = "tech/icon_tech_house_tier_5";
            house10.required_level = 25;
            house10.requirements = new List<string>{"house_tier_9"};
            AssetManager.culture_tech.add(house10);

            var house11 = new CultureTechAsset();
            house11.id = "house_tier_11";
            house11.path_icon = "tech/icon_tech_house_tier_5";
            house11.required_level = 26;
            house11.requirements = new List<string>{"house_tier_10"};
            AssetManager.culture_tech.add(house11);
        }
    }
}
