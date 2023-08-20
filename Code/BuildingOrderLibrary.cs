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
            var human = AssetManager.race_build_orders.get("human");
            human.addUpgrade("5house_human");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("3hall_human", "4house_human");
            human.addUpgrade("6house_human");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("3hall_human", "5house_human");
            human.addUpgrade("7house_human");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("4hall_human", "6house_human");
            human.addUpgrade("8house_human");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("4hall_human", "7house_human");
            human.addUpgrade("9house_human");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("5hall_human", "8house_human");
            human.addUpgrade("10house_human");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("5hall_human", "9house_human");
            human.addUpgrade("2hall_human", pPop: 100, pBuildings: 20);
            human.addUpgrade("3hall_human", pPop: 150, pBuildings: 20);
            human.addUpgrade("4hall_human", pPop: 200, pBuildings: 20);
            human.addUpgrade("5hall_human", pPop: 250, pBuildings: 20);

            //ORCS
            
            var orc = AssetManager.race_build_orders.get("orc");
            orc.addUpgrade("5house_orc");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("3hall_orc", "4house_orc");
            orc.addUpgrade("6house_orc");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("3hall_orc", "5house_orc");
            orc.addUpgrade("7house_orc");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("4hall_orc", "6house_orc");
            orc.addUpgrade("8house_orc");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("4hall_orc", "7house_orc");
            orc.addUpgrade("9house_orc");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("5hall_orc", "8house_orc");
            orc.addUpgrade("10house_orc");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("5hall_orc", "9house_orc");
            orc.addUpgrade("2hall_orc", pPop: 100, pBuildings: 20);
            orc.addUpgrade("3hall_orc", pPop: 150, pBuildings: 20);
            orc.addUpgrade("4hall_orc", pPop: 200, pBuildings: 20);
            orc.addUpgrade("5hall_orc", pPop: 250, pBuildings: 20);
            
            //ELF
            
            var elf = AssetManager.race_build_orders.get("elf");
            elf.addUpgrade("5house_elf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("3hall_elf", "4house_elf");
            elf.addUpgrade("6house_elf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("3hall_elf", "5house_elf");
            elf.addUpgrade("7house_elf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("4hall_elf", "6house_elf");
            elf.addUpgrade("8house_elf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("4hall_elf", "7house_elf");
            elf.addUpgrade("9house_elf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("5hall_elf", "8house_elf");
            elf.addUpgrade("10house_elf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("5hall_elf", "9house_elf");
            elf.addUpgrade("2hall_elf", pPop: 100, pBuildings: 20);
            elf.addUpgrade("3hall_elf", pPop: 150, pBuildings: 20);
            elf.addUpgrade("4hall_elf", pPop: 200, pBuildings: 20);
            elf.addUpgrade("5hall_elf", pPop: 250, pBuildings: 20);
            
            //DWARF
            
            var dwarf = AssetManager.race_build_orders.get("dwarf");
            dwarf.addUpgrade("5house_dwarf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("3hall_dwarf", "4house_dwarf");
            dwarf.addUpgrade("6house_dwarf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("3hall_dwarf", "5house_dwarf");
            dwarf.addUpgrade("7house_dwarf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("4hall_dwarf", "6house_dwarf");
            dwarf.addUpgrade("8house_dwarf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("4hall_dwarf", "7house_dwarf");
            dwarf.addUpgrade("9house_dwarf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("5hall_dwarf", "8house_dwarf");
            dwarf.addUpgrade("10house_dwarf");
            BuildOrderLibrary.b.requirements_types = List.Of<string>("5hall_dwarf", "9house_dwarf");
            dwarf.addUpgrade("2hall_dwarf", pPop: 100, pBuildings: 20);
            dwarf.addUpgrade("3hall_dwarf", pPop: 150, pBuildings: 20);
            dwarf.addUpgrade("4hall_dwarf", pPop: 200, pBuildings: 20);
            dwarf.addUpgrade("5hall_dwarf", pPop: 250, pBuildings: 20);
        }
    }
}
