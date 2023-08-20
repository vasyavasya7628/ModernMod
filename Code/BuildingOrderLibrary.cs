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
        private static void initBuildingOrder()
        {   
            
            //HUMAN
            var kingdromBase = AssetManager.race_build_orders.get("kingdom_base");
            kingdromBase.addUpgrade("order_house_5");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("order_hall_2", "order_house_5");
            kingdromBase.addUpgrade("order_house_6");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("order_hall_3", "order_house_6");
            kingdromBase.addUpgrade("order_house_7");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("order_hall_3", "order_house_7");
            kingdromBase.addUpgrade("order_house_8");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("order_hall_4", "order_house_8");
            kingdromBase.addUpgrade("order_house_9");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("order_hall_4", "order_house_9");
            kingdromBase.addUpgrade("order_house_10");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("order_hall_5", "order_house_10");
            kingdromBase.addUpgrade("order_house_11");
            BuildOrderLibrary.b.requirements_orders = List.Of<string>("order_hall_6", "order_house_11");
            
            kingdromBase.addUpgrade("order_hall_2", pPop: 100, pBuildings: 20);
            kingdromBase.addUpgrade("order_hall_3", pPop: 150, pBuildings: 20);
            kingdromBase.addUpgrade("order_hall_4", pPop: 200, pBuildings: 20);
            kingdromBase.addUpgrade("order_hall_5", pPop: 250, pBuildings: 20);
        }
    }
}
