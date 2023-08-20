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
        public static void initBuildings()
        {
            #region Houses
            //house 5 HUMANS
            BuildingAsset humanH5 = AssetManager.buildings.get("5house_human");
            humanH5.canBeUpgraded = true;
            humanH5.upgradeTo = "6house_human";

            //house 5 ELVES
            BuildingAsset elfH5 = AssetManager.buildings.get("5house_elf");
            elfH5.canBeUpgraded = true;
            elfH5.upgradeTo = "6house_elf";

            //house 5 ORCS
            BuildingAsset orcH5 = AssetManager.buildings.get("5house_orc");
            orcH5.canBeUpgraded = true;
            orcH5.upgradeTo = "6house_orc";

            //house 5 DWARFES
            BuildingAsset dwarfH5 = AssetManager.buildings.get("5house_dwarf");
            dwarfH5.canBeUpgraded = true;
            dwarfH5.upgradeTo = "6house_dwarf";


            //construction between 5 and 7 HUMANS
            var constructionH6 = AssetManager.buildings.clone("6house_human", "5house_human");
            constructionH6.shadow = false;
            constructionH6.cost = new ConstructionCost(0, 10, 10, 10);
            constructionH6.fundament = new BuildingFundament(1, 1, 2, 0);
            constructionH6.housing = 1;
            //constructionH6.priority = 1;
            constructionH6.upgradeTo = "7house_human";
            constructionH6.upgradeLevel = 6;
            constructionH6.base_stats[S.health] = 425f;
            //constructionH6.tech = "house_tier_6";
            AssetManager.buildings.loadSprites(constructionH6);

            //construction between 5 and 7 ELVES
            var constructionE6 = AssetManager.buildings.clone("6house_elf", "6house_human");
            constructionE6.cost = new ConstructionCost(0, 10, 10, 10);
            constructionE6.fundament = new BuildingFundament(1, 1, 2, 0);
            constructionE6.race = "elf";
            constructionE6.upgradeTo = "7house_elf";
            AssetManager.buildings.loadSprites(constructionE6);

            //construction between 5 and 7 ORCS
            var constructionR6 = AssetManager.buildings.clone("6house_orc", "6house_human");
            constructionR6.cost = new ConstructionCost(0, 10, 10, 10);
            constructionR6.fundament = new BuildingFundament(1, 1, 2, 0);
            constructionR6.race = "orc";
            constructionR6.upgradeTo = "7house_orc";
            AssetManager.buildings.loadSprites(constructionR6);

            //construction between 5 and 7 DWARFES
            var constructionD6 = AssetManager.buildings.clone("6house_dwarf", "6house_human");
            constructionD6.cost = new ConstructionCost(0, 10, 10, 10);
            constructionD6.fundament = new BuildingFundament(1, 1, 2, 0);
            constructionD6.race = "dwarf";
            constructionD6.upgradeTo = "7house_dwarf";
            AssetManager.buildings.loadSprites(constructionD6);



            //house 7 HUMANS
            var humanH7 = AssetManager.buildings.clone("7house_human", "6house_human");
            humanH7.cost = new ConstructionCost(1, 1, 1, 1);
            humanH7.fundament = new BuildingFundament(1, 1, 2, 0);
            humanH7.housing = 9;
            humanH7.upgradeTo = "8house_human";
            humanH7.upgradeLevel = 7;
            humanH7.base_stats[S.health] = 450f;
            //humanH7.tech = "house_tier_7";
            AssetManager.buildings.loadSprites(humanH7);

            //house 7 ELVES
            var elfH7 = AssetManager.buildings.clone("7house_elf", "7house_human");
            elfH7.cost = new ConstructionCost(1, 1, 1, 1);
            elfH7.fundament = new BuildingFundament(1, 1, 2, 0);
            elfH7.race = "elf";
            elfH7.upgradeTo = "8house_elf";
            AssetManager.buildings.loadSprites(elfH7);

            //house 7 ORCS
            var orcH7 = AssetManager.buildings.clone("7house_orc", "7house_human");
            orcH7.cost = new ConstructionCost(1, 1, 1, 1);
            orcH7.fundament = new BuildingFundament(1, 1, 2, 0);
            orcH7.race = "orc";
            orcH7.upgradeTo = "8house_orc";
            AssetManager.buildings.loadSprites(orcH7);

            //house 7 DWARFES
            var dwarfH7 = AssetManager.buildings.clone("7house_dwarf", "7house_human");
            dwarfH7.cost = new ConstructionCost(1, 1, 1, 1);
            dwarfH7.fundament = new BuildingFundament(1, 1, 2, 0);
            dwarfH7.race = "dwarf";
            //dwarfH7.priority = 1;
            dwarfH7.canBeUpgraded = true;
            dwarfH7.upgradeTo = "8house_dwarf";
            AssetManager.buildings.loadSprites(dwarfH7);


            //house 8 HUMANS
            var humanH8 = AssetManager.buildings.clone("8house_human", "7house_human");
            humanH8.cost = new ConstructionCost(0, 15, 10, 15);
            humanH8.fundament = new BuildingFundament(1, 1, 2, 0);
            humanH8.housing = 11;
            humanH8.upgradeTo = "9house_human";
            humanH8.upgradeLevel = 8;
            humanH8.base_stats[S.health] = 500f;
            //humanH8.tech = "house_tier_8";
            AssetManager.buildings.loadSprites(humanH8);

            //house 8 ELVES
            var elfH8 = AssetManager.buildings.clone("8house_elf", "8house_human");
            elfH8.cost = new ConstructionCost(0, 15, 10, 15);
            elfH8.fundament = new BuildingFundament(1, 1, 2, 0);
            elfH8.race = "elf";
            elfH8.upgradeTo = "9house_elf";
            AssetManager.buildings.loadSprites(elfH8);

            //house 8 ORCS
            var orcH8 = AssetManager.buildings.clone("8house_orc", "8house_human");
            orcH8.cost = new ConstructionCost(0, 15, 10, 15);
            orcH8.fundament = new BuildingFundament(1, 1, 2, 0);
            orcH8.race = "orc";
            orcH8.upgradeTo = "9house_orc";
            AssetManager.buildings.loadSprites(orcH8);

            //house 8 DWARFES
            var dwarfH8 = AssetManager.buildings.clone("8house_dwarf", "8house_human");
            dwarfH8.cost = new ConstructionCost(0, 15, 10, 15);
            dwarfH8.fundament = new BuildingFundament(1, 1, 2, 0);
            dwarfH8.race = "dwarf";
            dwarfH8.canBeUpgraded = true;
            dwarfH8.upgradeTo = "9house_dwarf";
            AssetManager.buildings.loadSprites(dwarfH8);


            //house 9 HUMANS
            var humanH9 = AssetManager.buildings.clone("9house_human", "8house_human");
            humanH9.cost = new ConstructionCost(0, 15, 15, 20);
            humanH9.fundament = new BuildingFundament(1, 1, 2, 0);
            humanH9.housing = 13;
            humanH9.upgradeTo = "10house_human";
            humanH9.upgradeLevel = 9;
            humanH9.base_stats[S.health] = 550f;
            //humanH9.tech = "house_tier_9";
            AssetManager.buildings.loadSprites(humanH9);

            //house 9 ELVES
            var elfH9 = AssetManager.buildings.clone("9house_elf", "9house_human");
            elfH9.cost = new ConstructionCost(0, 15, 15, 20);
            elfH9.fundament = new BuildingFundament(1, 1, 2, 0);
            elfH9.race = "elf";
            elfH9.upgradeTo = "10house_elf";
            AssetManager.buildings.loadSprites(elfH9);

            //house 9 ORCS
            var orcH9 = AssetManager.buildings.clone("9house_orc", "9house_human");
            orcH9.cost = new ConstructionCost(0, 15, 15, 20);
            orcH9.fundament = new BuildingFundament(1, 1, 2, 0);
            orcH9.race = "orc";
            orcH9.upgradeTo = "10house_orc";
            AssetManager.buildings.loadSprites(orcH9);

            //house 9 DWARFES
            var dwarfH9 = AssetManager.buildings.clone("9house_dwarf", "9house_human");
            dwarfH9.cost = new ConstructionCost(0, 15, 15, 20);
            dwarfH9.fundament = new BuildingFundament(1, 1, 2, 0);
            dwarfH9.race = "dwarf";
            dwarfH9.upgradeTo = "10house_dwarf";
            AssetManager.buildings.loadSprites(dwarfH9);


            //house 10 HUMANS
            var humanH10 = AssetManager.buildings.clone("10house_human", "9house_human");
            humanH10.cost = new ConstructionCost(0, 20, 20, 25);
            humanH10.fundament = new BuildingFundament(1, 1, 2, 0);
            humanH10.housing = 15;
            humanH10.upgradeTo = "11house_human";
            humanH10.upgradeLevel = 10;
            humanH10.base_stats[S.health] = 600f;
            //humanH10.tech = "house_tier_10";
            AssetManager.buildings.loadSprites(humanH10);

            //house 10 ELVES
            var elfH10 = AssetManager.buildings.clone("10house_elf", "10house_human");
            elfH10.cost = new ConstructionCost(0, 20, 20, 25);
            elfH10.fundament = new BuildingFundament(1, 1, 2, 0);
            elfH10.race = "elf";
            elfH10.upgradeTo = "11house_elf";
            AssetManager.buildings.loadSprites(elfH10);

            //house 10 ORCS
            var orcH10 = AssetManager.buildings.clone("10house_orc", "10house_human");
            orcH10.cost = new ConstructionCost(0, 20, 20, 25);
            orcH10.fundament = new BuildingFundament(1, 1, 2, 0);
            orcH10.race = "orc";
            orcH10.upgradeTo = "11house_orc";
            AssetManager.buildings.loadSprites(orcH10);

            //house 10 DWARFES
            var dwarfH10 = AssetManager.buildings.clone("10house_dwarf", "10house_human");
            dwarfH10.cost = new ConstructionCost(0, 20, 20, 25);
            dwarfH10.fundament = new BuildingFundament(1, 1, 2, 0);
            dwarfH10.race = "dwarf";
            dwarfH10.upgradeTo = "11house_dwarf";
            AssetManager.buildings.loadSprites(dwarfH10);


            //house 11 HUMANS
            var humanH11 = AssetManager.buildings.clone("11house_human", "10house_human");
            humanH11.cost = new ConstructionCost(0, 25, 25, 25);
            humanH11.fundament = new BuildingFundament(1, 1, 2, 0);
            humanH11.housing = 17;
            humanH11.canBeUpgraded = false;
            humanH11.upgradeLevel = 11;
            humanH11.base_stats[S.health] = 650f;
            humanH11.upgradeTo = "";
            //humanH11.tech = "house_tier_11";
            AssetManager.buildings.loadSprites(humanH11);

            //house 11 ELVES
            var elfH11 = AssetManager.buildings.clone("11house_elf", "11house_human");
            elfH11.cost = new ConstructionCost(0, 25, 25, 25);
            elfH11.fundament = new BuildingFundament(1, 1, 2, 0);
            elfH11.race = "elf";
            elfH11.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(elfH11);

            //house 11 ORCS
            var orcH11 = AssetManager.buildings.clone("11house_orc", "11house_human");
            orcH11.cost = new ConstructionCost(0, 25, 25, 25);
            orcH11.fundament = new BuildingFundament(1, 1, 2, 0);
            orcH11.race = "orc";
            orcH11.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(orcH11);

            //house 11 DWARFES
            var dwarfH11 = AssetManager.buildings.clone("11house_dwarf", "11house_human");
            dwarfH11.cost = new ConstructionCost(0, 25, 25, 25);
            dwarfH11.fundament = new BuildingFundament(1, 1, 2, 0);
            dwarfH11.race = "dwarf";
            dwarfH11.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(dwarfH11);

            #endregion

            #region halls
            //hall 2 HUMANS
            BuildingAsset humanHall2 = AssetManager.buildings.get("2hall_human");
            humanHall2.canBeUpgraded = true;
            humanHall2.upgradeTo = "3hall_human";

            //hall 2 ELVES
            BuildingAsset elfHall2 = AssetManager.buildings.get("2hall_elf");
            elfHall2.canBeUpgraded = true;
            elfHall2.upgradeTo = "3hall_elf";

            //hall 2 ORCS
            BuildingAsset orcHall2 = AssetManager.buildings.get("2hall_orc");
            orcHall2.canBeUpgraded = true;
            orcHall2.upgradeTo = "3hall_orc";

            //hall 2 DWARFES
            BuildingAsset dwarfHall2 = AssetManager.buildings.get("2hall_dwarf");
            dwarfHall2.canBeUpgraded = true;
            dwarfHall2.upgradeTo = "3hall_dwarf";


            //hall 3 HUMANS
            var humanHall3 = AssetManager.buildings.clone("3hall_human", "2hall_human");
            humanHall3.cost = new ConstructionCost(0, 20, 1, 150);
            humanHall3.housing = 15;
            humanHall3.upgradeLevel = 3;
            humanHall3.base_stats[S.health] = 800f;
            humanHall3.canBeUpgraded = true;
            humanHall3.spawnUnits = false;
            humanHall3.upgradeTo = "4hall_human";
            //humanHall3.tech = "house_tier_6";
            AssetManager.buildings.loadSprites(humanHall3);

            //hall 3 ELVES
            var elfHall3 = AssetManager.buildings.clone("3hall_elf", "3hall_human");
            elfHall3.cost = new ConstructionCost(0, 20, 1, 150);
            elfHall3.race = "elf";
            elfHall3.upgradeTo = "4hall_elf";
            AssetManager.buildings.loadSprites(elfHall3);

            //hall 3 ORCS
            var orcHall3 = AssetManager.buildings.clone("3hall_orc", "3hall_human");
            orcHall3.cost = new ConstructionCost(0, 20, 1, 150);
            orcHall3.race = "orc";
            orcHall3.upgradeTo = "4hall_orc";
            AssetManager.buildings.loadSprites(orcHall3);

            //hall 3 DWARFES
            var dwarfHall3 = AssetManager.buildings.clone("3hall_dwarf", "3hall_human");
            dwarfHall3.cost = new ConstructionCost(0, 20, 1, 150);
            //dwarfHall3.fundament = new BuildingFundament(6, 6, 4, 0);
            dwarfHall3.race = "dwarf";
            dwarfHall3.upgradeTo = "4hall_dwarf";
            AssetManager.buildings.loadSprites(dwarfHall3);



            //hall 4 HUMANS
            var humanHall4 = AssetManager.buildings.clone("4hall_human", "3hall_human");
            humanHall4.cost = new ConstructionCost(0, 40, 1, 200);
            humanHall4.housing = 20;
            humanHall4.upgradeLevel = 4;
            humanHall4.base_stats[S.health] = 1000f;
            humanHall4.canBeUpgraded = true;
            humanHall4.upgradeTo = "5hall_human";
            //humanHall4.tech = "house_tier_7";
            AssetManager.buildings.loadSprites(humanHall4);

            //hall 4 ELVES
            var elfHall4 = AssetManager.buildings.clone("4hall_elf", "4hall_human");
            elfHall4.cost = new ConstructionCost(0, 40, 1, 200);
            elfHall4.race = "elf";
            elfHall4.upgradeTo = "5hall_elf";
            AssetManager.buildings.loadSprites(elfHall4);

            //hall 4 ORCS
            var orcHall4 = AssetManager.buildings.clone("4hall_orc", "4hall_human");
            orcHall4.cost = new ConstructionCost(0, 40, 1, 200);
            orcHall4.race = "orc";
            orcHall4.upgradeTo = "5hall_orc";
            AssetManager.buildings.loadSprites(orcHall4);

            //hall 4 DWARFES
            var dwarfHall4 = AssetManager.buildings.clone("4hall_dwarf", "4hall_human");
            dwarfHall4.cost = new ConstructionCost(0, 40, 1, 200);
            //dwarfHall4.fundament = new BuildingFundament(6, 6, 4, 0);
            dwarfHall4.race = "dwarf";
            dwarfHall4.upgradeTo = "5hall_dwarf";
            AssetManager.buildings.loadSprites(dwarfHall4);


            //hall 5 HUMANS
            var humanHall5 = AssetManager.buildings.clone("5hall_human", "4hall_human");
            humanHall5.cost = new ConstructionCost(0, 60, 1, 250);
            humanHall5.housing = 25;
            humanHall5.upgradeLevel = 5;
            humanHall5.base_stats[S.health] = 1200f;
            humanHall5.canBeUpgraded = true;
            humanHall5.upgradeTo = "6hall_human";
            //humanHall5.tech = "house_tier_8";
            AssetManager.buildings.loadSprites(humanHall5);

            //hall 5 ELVES
            var elfHall5 = AssetManager.buildings.clone("5hall_elf", "5hall_human");
            elfHall5.cost = new ConstructionCost(0, 60, 1, 250);
            elfHall5.race = "elf";
            elfHall4.upgradeTo = "6hall_elf";
            AssetManager.buildings.loadSprites(elfHall4);

            //hall 5 ORCS
            var orcHall5 = AssetManager.buildings.clone("5hall_orc", "5hall_human");
            orcHall5.cost = new ConstructionCost(0, 60, 1, 250);
            orcHall5.race = "orc";
            orcHall5.upgradeTo = "6hall_orc";
            AssetManager.buildings.loadSprites(orcHall5);

            //hall 5 DWARFES
            var dwarfHall5 = AssetManager.buildings.clone("5hall_dwarf", "5hall_human");
            dwarfHall5.cost = new ConstructionCost(0, 60, 1, 250);
            //dwarfHall5.fundament = new BuildingFundament(6, 6, 4, 0);
            dwarfHall5.race = "dwarf";
            dwarfHall5.upgradeTo = "6hall_dwarf";
            AssetManager.buildings.loadSprites(dwarfHall5);


            //hall 6 HUMANS
            var humanHall6 = AssetManager.buildings.clone("6hall_human", "5hall_human");
            humanHall6.cost = new ConstructionCost(0, 80, 20, 300);
            humanHall6.housing = 30;
            humanHall6.upgradeLevel = 6;
            humanHall6.base_stats[S.health] = 1200f;
            humanHall6.canBeUpgraded = false;
            humanHall6.upgradeTo = "";
            //humanHall6.upgradeTo = "";
            //humanHall6.tech = "house_tier_9";
            AssetManager.buildings.loadSprites(humanHall6);

            //hall 6 ELVES
            var elfHall6 = AssetManager.buildings.clone("6hall_elf", "6hall_human");
            elfHall6.cost = new ConstructionCost(0, 80, 20, 300);
            elfHall6.race = "elf";
            elfHall6.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(elfHall6);

            //hall 6 ORCS
            var orcHall6 = AssetManager.buildings.clone("6hall_orc", "6hall_human");
            orcHall6.cost = new ConstructionCost(0, 80, 20, 300);
            orcHall6.race = "orc";
            orcHall6.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(orcHall6);

            //hall 6 DWARFES
            var dwarfHall6 = AssetManager.buildings.clone("6hall_dwarf", "6hall_human");
            dwarfHall6.cost = new ConstructionCost(0, 80, 20, 300);
            //dwarfHall6.fundament = new BuildingFundament(6, 6, 4, 0);
            dwarfHall6.race = "dwarf";
            dwarfHall6.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(dwarfHall6);

            #endregion

            #region docks
            //docks 1 HUMANS
            BuildingAsset docks_human1 = AssetManager.buildings.get("docks_human");
            docks_human1.upgradeLevel = 1;
            docks_human1.canBeUpgraded = true;
            docks_human1.upgradeTo = "2docks_human";

            //docks 1 ELVES
            BuildingAsset docks_elf1 = AssetManager.buildings.get("docks_elf");
            docks_elf1.upgradeLevel = 1;
            docks_elf1.canBeUpgraded = true;
            docks_elf1.upgradeTo = "2docks_elf";

            //docks 1 ORCS
            BuildingAsset docks_orc1 = AssetManager.buildings.get("docks_orc");
            docks_orc1.upgradeLevel = 1;
            docks_orc1.canBeUpgraded = true;
            docks_orc1.upgradeTo = "2docks_orc";

            //docks 1 DWARFES
            //BuildingAsset docks_dwarf1 = AssetManager.buildings.get("docks_dwarf");
            //docks_dwarf1.upgradeLevel = 1;
            //docks_dwarf1.canBeUpgraded = true;
            //docks_dwarf1.upgradeTo = "2docks_dwarf";
            //AssetManager.buildings.loadSprites(docks_dwarf1);


            //construction between 1 and 3 HUMANS
            var docks_human2 = AssetManager.buildings.clone("2docks_human", "docks_human");
            docks_human2.cost = new ConstructionCost(10, 10, 30, 15);
            docks_human2.upgradeTo = "3docks_human";
            docks_human2.upgradeLevel = 2;
            docks_human2.base_stats[S.health] = 200f;
            AssetManager.buildings.loadSprites(docks_human2);

            //construction between 1 and 3 ELVES
            var docks_elf2 = AssetManager.buildings.clone("2docks_elf", "2docks_human");
            docks_elf2.cost = new ConstructionCost(10, 10, 30, 15);
            docks_elf2.race = "elf";
            docks_elf2.upgradeTo = "3docks_elf";
            AssetManager.buildings.loadSprites(docks_elf2);

            //construction between 1 and 3 ORCS
            var docks_orc2 = AssetManager.buildings.clone("2docks_orc", "2docks_human");
            docks_orc2.cost = new ConstructionCost(10, 10, 30, 15);
            docks_orc2.race = "orc";
            docks_orc2.upgradeTo = "3docks_orc";
            AssetManager.buildings.loadSprites(docks_orc2);

            //construction between 1 and 3 DWARFES
            //var docks_dwarf2 = AssetManager.buildings.clone("2docks_dwarf", "2docks_human");
            //docks_dwarf2.race = "dwarf";
            //docks_dwarf2.upgradeTo = "3docks_dwarf";
            //AssetManager.buildings.loadSprites(docks_dwarf2);


            //docks 3 HUMANS
            var docks_human3 = AssetManager.buildings.clone("3docks_human", "docks_human");
            docks_human3.cost = new ConstructionCost(1, 1, 1, 1);
            docks_human3.upgradeLevel = 3;
            docks_human3.base_stats[S.health] = 250f;
            docks_human2.priority = 1;
            docks_human3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(docks_human3);

            //docks 3 ELVES
            var docks_elf3 = AssetManager.buildings.clone("3docks_elf", "3docks_human");
            docks_elf3.cost = new ConstructionCost(1, 1, 1, 1);
            docks_elf3.race = "elf";
            docks_elf3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(docks_elf3);

            //docks 3 ORCS
            var docks_orc3 = AssetManager.buildings.clone("3docks_orc", "3docks_human");
            docks_orc3.cost = new ConstructionCost(1, 1, 1, 1);
            docks_orc3.race = "orc";
            docks_orc3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(docks_orc3);

            //docks 3 DWARFES
            //var docks_dwarf3 = AssetManager.buildings.clone("3docks_dwarf", "3docks_human");
            //docks_dwarf3.race = "dwarf";
            //docks_dwarf3.canBeUpgraded = false;
            //AssetManager.buildings.loadSprites(docks_dwarf3);

            #endregion

            #region barracks
            //barracks 1 HUMANS
            BuildingAsset humanBarracks1 = AssetManager.buildings.get("barracks_human");
            humanBarracks1.upgradeLevel = 1;
            humanBarracks1.canBeUpgraded = true;
            humanBarracks1.upgradeTo = "2barracks_human";

            //barracks 1 ELVES
            BuildingAsset elfBarracks1 = AssetManager.buildings.get("barracks_elf");
            elfBarracks1.upgradeLevel = 1;
            elfBarracks1.canBeUpgraded = true;
            elfBarracks1.upgradeTo = "2barracks_elf";

            //barracks 1 ORCS
            BuildingAsset orcBarracks1 = AssetManager.buildings.get("barracks_orc");
            orcBarracks1.upgradeLevel = 1;
            orcBarracks1.canBeUpgraded = true;
            orcBarracks1.upgradeTo = "2barracks_orc";

            //barracks 1 DWARFES
            //BuildingAsset dwarfBarracks1 = AssetManager.buildings.get("barracks_dwarf");
            //dwarfBarracks1.upgradeLevel = 1;
            //dwarfBarracks1.canBeUpgraded = true;
            //dwarfBarracks1.upgradeTo = "2barracks_dwarf";


            //construction between 1 and 3 HUMANS
            var humanBarracks2 = AssetManager.buildings.clone("2barracks_human", "barracks_human");
            humanBarracks2.cost = new ConstructionCost(0, 40, 40, 40);
            humanBarracks2.upgradeTo = "3barracks_human";
            humanBarracks2.upgradeLevel = 2;
            humanBarracks2.base_stats[S.health] = 150f;
            AssetManager.buildings.loadSprites(humanBarracks2);

            //construction between 1 and 3 ELVES
            var elfBarracks2 = AssetManager.buildings.clone("2barracks_elf", "2barracks_human");
            elfBarracks2.race = "elf";
            elfBarracks2.upgradeTo = "3barracks_elf";
            AssetManager.buildings.loadSprites(elfBarracks2);

            //construction between 1 and 3 ORCS
            var orcBarracks2 = AssetManager.buildings.clone("2barracks_orc", "2barracks_human");
            orcBarracks2.race = "orc";
            orcBarracks2.upgradeTo = "3barracks_orc";
            AssetManager.buildings.loadSprites(orcBarracks2);

            //construction between 1 and 3 DWARFES
            //var dwarfBarracks2 = AssetManager.buildings.clone("2barracks_dwarf", "2barracks_human");
            //dwarfBarracks2.race = "dwarf";
            //dwarfBarracks2.upgradeTo = "3barracks_dwarf";
            //AssetManager.buildings.loadSprites(dwarfBarracks2);



            //barracks 3 HUMANS
            var humanBarracks3 = AssetManager.buildings.clone("3barracks_human", "barracks_human");
            humanBarracks3.cost = new ConstructionCost(1, 1, 1, 1);
            humanBarracks3.upgradeLevel = 3;
            humanBarracks3.base_stats[S.health] = 200f;
            humanBarracks3.priority = 1;
            humanBarracks3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(humanBarracks3);

            //barracks 3 ELVES
            var elfBarracks3 = AssetManager.buildings.clone("3barracks_elf", "3barracks_human");
            elfBarracks3.race = "elf";
            elfBarracks3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(elfBarracks3);

            //barracks 3 ORCS
            var orcBarracks3 = AssetManager.buildings.clone("3barracks_orc", "3barracks_human");
            orcBarracks3.race = "orc";
            orcBarracks3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(orcBarracks3);

            //barracks 3 DWARFES
            //var dwarfBarracks3 = AssetManager.buildings.clone("3barracks_dwarf", "3barracks_human");
            //dwarfBarracks3.race = "dwarf";
            //dwarfBarracks3.canBeUpgraded = false;
            //AssetManager.buildings.loadSprites(dwarfBarracks3);

            #endregion

            #region temples
            //temple 1 HUMANS
            BuildingAsset humanTemple1 = AssetManager.buildings.get("temple_human");
            humanTemple1.upgradeLevel = 1;
            humanTemple1.canBeUpgraded = true;
            humanTemple1.upgradeTo = "2temple_human";

            //temple 1 ELVES
            BuildingAsset elfTemple1 = AssetManager.buildings.get("temple_elf");
            elfTemple1.upgradeLevel = 1;
            elfTemple1.canBeUpgraded = true;
            elfTemple1.upgradeTo = "2temple_elf";

            //temple 1 ORCS
            BuildingAsset orcTemple1 = AssetManager.buildings.get("temple_orc");
            orcTemple1.upgradeLevel = 1;
            orcTemple1.canBeUpgraded = true;
            orcTemple1.upgradeTo = "2temple_orc";

            //temple 1 DWARFES
            //BuildingAsset dwarfTemple1 = AssetManager.buildings.get("temple_dwarf");
            //dwarfTemple1.upgradeLevel = 1;
            //dwarfTemple1.canBeUpgraded = true;
            //dwarfTemple1.upgradeTo = "2temple_dwarf";


            //construction between 1 and 3 HUMANS
            var humanTemple2 = AssetManager.buildings.clone("2temple_human", "temple_human");
            humanTemple2.cost = new ConstructionCost(0, 20, 4, 60);
            humanTemple2.upgradeTo = "3temple_human";
            humanTemple2.upgradeLevel = 2;
            humanTemple2.base_stats[S.health] = 150f;
            AssetManager.buildings.loadSprites(humanTemple2);

            //construction between 1 and 3 ELVES
            BuildingAsset elfTemple2 = AssetManager.buildings.clone("2temple_elf", "2temple_human");
            elfTemple2.race = "elf";
            elfTemple2.upgradeTo = "3temple_elf";
            AssetManager.buildings.loadSprites(elfTemple2);

            //construction between 1 and 3 ORCS
            BuildingAsset orcTemple2 = AssetManager.buildings.clone("2temple_orc", "2temple_human");
            orcTemple2.race = "orc";
            orcTemple2.upgradeTo = "3temple_orc";
            AssetManager.buildings.loadSprites(orcTemple2);

            //construction between 1 and 3 DWARFES
            //BuildingAsset dwarfTemple2 = AssetManager.buildings.clone("2temple_dwarf", "2temple_human");
            //dwarfTemple2.race = "dwarf";
            //dwarfTemple2.upgradeTo = "3temple_dwarf";
            //AssetManager.buildings.loadSprites(dwarfTemple2);


            //temple 3 HUMANS
            var humanTemple3 = AssetManager.buildings.clone("3temple_human", "temple_human");
            humanTemple3.cost = new ConstructionCost(1, 1, 1, 1);
            humanTemple3.upgradeLevel = 3;
            humanTemple3.base_stats[S.health] = 200f;
            humanTemple3.priority = 1;
            humanTemple3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(humanTemple3);

            //temple 3 ELVES
            BuildingAsset elfTemple3 = AssetManager.buildings.clone("3temple_elf", "3temple_human");
            elfTemple3.race = "elf";
            elfTemple3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(elfTemple3);

            //temple 3 ORCS
            BuildingAsset orcTemple3 = AssetManager.buildings.clone("3temple_orc", "3temple_human");
            orcTemple3.race = "orc";
            orcTemple3.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(orcTemple3);

            //temple 3 DWARFES
            //BuildingAsset dwarfTemple3 = AssetManager.buildings.clone("3temple_dwarf", "3temple_human");
            //dwarfTemple3.race = "dwarf";
            //dwarfTemple3.canBeUpgraded = false;
            //AssetManager.buildings.loadSprites(dwarfTemple3);

            #endregion

            #region common
            //bonfire 1 ALL
            BuildingAsset bonfire1 = AssetManager.buildings.get("bonfire");
            bonfire1.upgradeLevel = 1;
            bonfire1.canBeUpgraded = true;
            bonfire1.upgradeTo = "2bonfire";

            //bonfire 2 ALL
            var bonfire2 = AssetManager.buildings.clone("2bonfire", "bonfire");
            bonfire2.cost = new ConstructionCost(0, 5, 5, 5);
            bonfire2.upgradeLevel = 2;
            bonfire2.smoke = false;
            bonfire2.base_stats[S.health] = 500f;
            bonfire2.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(bonfire2);


            //well 1 ALL
            BuildingAsset well1 = AssetManager.buildings.get("well");
            well1.upgradeLevel = 1;
            well1.canBeUpgraded = true;
            well1.upgradeTo = "2well";

            //well 2 ALL
            var well2 = AssetManager.buildings.clone("2well", "well");
            well2.cost = new ConstructionCost(0, 20, 20, 10);
            well2.upgradeLevel = 2;
            well2.base_stats[S.health] = 250f;
            well2.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(well2);


            //mine 1 ALL
            BuildingAsset mine1 = AssetManager.buildings.get("mine");
            mine1.upgradeLevel = 1;
            mine1.canBeUpgraded = true;
            mine1.upgradeTo = "2mine";

            //mine 2 ALL
            var mine2 = AssetManager.buildings.clone("2mine", "mine");
            mine2.cost = new ConstructionCost(0, 10, 25, 15);
            mine2.upgradeLevel = 2;
            mine2.base_stats[S.health] = 250f;
            mine2.canBeUpgraded = false;
            AssetManager.buildings.loadSprites(mine2);

            #endregion
        }
    }
}
