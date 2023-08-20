using System.Collections.Generic;
using UnityEngine;
using ReflectionUtility;
using System.Reflection;
using HarmonyLib;
using System.IO;
using System.Linq;
using UnityEngine.UI;
using static Config;
//using Helper;
using NCMS.Utils;

namespace ModernMod
{
    public partial class WorldBoxMod : MonoBehaviour
    {
        private void initPower()
        {
            Debug.LogWarning("TESTEST");
            //godPower();

            //var spriteUpgrade = Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.images.icon.UpgradeBuilding.png");
            //var newButtonUpgrade = PowerButtons.CreateButton("upgradeBuilding", spriteUpgrade, "Upgrade Building", "Upgrade building level right now without any cost to villagers", Vector2.zero, ButtonType.GodPower);      
            //PowerButtons.AddButtonToTab(newButtonUpgrade, PowerTab.Drawing, new Vector2(464.60f, 18));

            //var spriteDowngrade = Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.images.icon.DowngradeBuilding.png");
            //var newButtonDowngrade = PowerButtons.CreateButton("downgradeBuilding", spriteDowngrade, "Downgrade Building", "Downgrade building level right now without any payback to villagers", Vector2.zero, ButtonType.GodPower);      
            //PowerButtons.AddButtonToTab(newButtonDowngrade, PowerTab.Drawing, new Vector2(464.60f, -18));
        }

        private void godPower()
        {
            GodPower upgradeBuilding = AssetManager.powers.clone("upgradeBuilding", "_drops");
            //upgradeBuilding.id = "upgradeBuilding";
            upgradeBuilding.holdAction = true; 
            upgradeBuilding.showToolSizes = true;
            upgradeBuilding.unselectWhenWindow = true;
            upgradeBuilding.name = "upgradeBuilding";
            upgradeBuilding.dropID = "upgradeBuilding";
            upgradeBuilding.fallingChance = 0.01f;
            upgradeBuilding.click_power_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool)AssetManager.powers.CallMethod("spawnDrops", pTile, pPower); });
            upgradeBuilding.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
            //AssetManager.powers.add(upgradeBuilding);


            DropAsset upgradebuildingDrop = new DropAsset();
            upgradebuildingDrop.id = "upgradeBuilding";
            upgradebuildingDrop.path_texture = "drops/drop_snow";
            upgradebuildingDrop.animated = true;
            upgradebuildingDrop.animation_speed = 0.03f;
            upgradebuildingDrop.default_scale = 0.1f;
            upgradebuildingDrop.action_landed = new DropsAction(action_upgradeBuilding);
            AssetManager.drops.add(upgradebuildingDrop);



            GodPower downgradeBuilding = AssetManager.powers.clone("downgradeBuilding", "_drops");
            //downgradeBuilding.id = "downgradeBuilding";
            downgradeBuilding.holdAction = true;
            downgradeBuilding.showToolSizes = true;
            downgradeBuilding.unselectWhenWindow = true;
            downgradeBuilding.name = "downgradeBuilding";
            downgradeBuilding.dropID = "downgradeBuilding";
            downgradeBuilding.fallingChance = 0.01f;
            downgradeBuilding.click_power_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool)AssetManager.powers.CallMethod("spawnDrops", pTile, pPower); });
            downgradeBuilding.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
            //AssetManager.powers.add(downgradeBuilding);


            DropAsset downgradeBuildingDrop = new DropAsset();
            downgradeBuildingDrop.id = "downgradeBuilding";
            downgradeBuildingDrop.path_texture = "drops/drop_snow";
            downgradeBuildingDrop.animated = true;
            downgradeBuildingDrop.animation_speed = 0.03f;
            downgradeBuildingDrop.default_scale = 0.1f;
            downgradeBuildingDrop.action_landed = new DropsAction(action_downgradeBuilding);
            AssetManager.drops.add(downgradeBuildingDrop);
        }

        public static void action_upgradeBuilding(WorldTile pTile = null, string pDropID = null)
        {
            if(pTile.building != null)
            {
                
                var building = pTile.building;
                
                var spriteAnimation = Reflection.GetField(building.GetType(), building, "spriteAnimation") as SpriteAnimation;
                var stats = Reflection.GetField(building.GetType(), building, "stats") as BuildingAsset;
                var data = Reflection.GetField(building.GetType(), building, "data") as BuildingData;
                Building buildingObj = new Building();
                bool isUnderConstruction = buildingObj.isUnderConstruction(); 
                if (stats.canBeUpgraded && !((data.state == BuildingState.Ruins) || isUnderConstruction || data.state == BuildingState.CivAbandoned))
                {

                    BuildingAsset pTemplate = AssetManager.buildings.get(stats.upgradeTo);
                    if (building.city != null)
                    {
                        building.city.CallMethod("setBuildingDictID", building, false);
                    }
                    building.CallMethod("setTemplate", pTemplate);

                    if (building.city != null)
                    {
                        building.city.CallMethod("setBuildingDictID", building, true);
                    }


                    spriteAnimation.stopAt(0, true);
                    building.CallMethod("setSpriteMain", true);
                    building.CallMethod("updateStats");
                    // var curStats = Reflection.GetField(building.GetType(), building, "curStats") as BaseStats;
                    //
                    // data.health = curStats.base_stats[S.health];
                    data.health = 1000;
                }

            }
        }

        public static void action_downgradeBuilding(WorldTile pTile = null, string pDropID = null)
        {
            if(pTile.building != null)
            {
                var building = pTile.building;
                
                var spriteAnimation = Reflection.GetField(building.GetType(), building, "spriteAnimation") as SpriteAnimation;
                //spriteAnimation.currentFrameIndex = 0;

                var stats = Reflection.GetField(building.GetType(), building, "stats") as BuildingAsset;
                var data = Reflection.GetField(building.GetType(), building, "data") as BuildingData;


                var downgradeTo = AssetManager.buildings.list.Find(b => b.upgradeTo == stats.id);
                Building buildingObj = new Building();
                bool isUnderConstruction = buildingObj.isUnderConstruction(); 
                if (downgradeTo != null && !((data.state == BuildingState.Ruins) || isUnderConstruction || data.state == BuildingState.CivAbandoned))
                {
                    BuildingAsset pTemplate = AssetManager.buildings.get(downgradeTo.id);

                    if (building.city != null)
                    {
                        building.city.CallMethod("setBuildingDictID", building, false);
                    }
                    building.CallMethod("setTemplate", pTemplate);

                    if (building.city != null)
                    {
                        building.city.CallMethod("setBuildingDictID", building, true);
                    }


                    spriteAnimation.stopAt(0, true);
                    building.CallMethod("setSpriteMain", true);
                    building.CallMethod("updateStats");

                   

                    data.health = 1000;
                }

            }
        }
    }
}
