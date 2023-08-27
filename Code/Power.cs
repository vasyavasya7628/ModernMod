using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using NCMS;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;
using static Config;

namespace ModernMod
{
    public partial class WorldBoxMod : MonoBehaviour
    {
        private void initPower()
        {	
			godPower();
			buttonUpgradeBuilding();
			buttonDowngradeBuilding();
			
        }
		
		private void buttonUpgradeBuilding()
		{
			var spriteUpgrade = NCMS.Utils.Sprites.LoadSprite(
                $"{Mod.Info.Path}/EmbededResources/images/icon/UpgradeBuilding.png");
            

            var buttonUpgradeBuilding = NCMS.Utils.PowerButtons.CreateButton("Button_UpgradeBuilding",
                spriteUpgrade, 
				"Upgrade Button", 
                "This is the example button",
                Vector2.zero,
                NCMS.Utils.ButtonType.Click,
                null);

            NCMS.Utils.PowerButtons.AddButtonToTab(buttonUpgradeBuilding,
                NCMS.Utils.PowerTab.Drawing,
                new Vector2(512f, -18));
		}

		private void buttonDowngradeBuilding()
		{
			var spriteDowngrade = NCMS.Utils.Sprites.LoadSprite(
                $"{Mod.Info.Path}/EmbededResources/images/icon/DowngradeBuilding.png");
				
            var buttonDowngradeBuilding = NCMS.Utils.PowerButtons.CreateButton("Button_DowngradeBuilding",
                spriteDowngrade, 
				"Downgrade Button", 
                "This is the example",
                Vector2.zero,
                NCMS.Utils.ButtonType.Click,
                null);

            NCMS.Utils.PowerButtons.AddButtonToTab(buttonDowngradeBuilding,
                NCMS.Utils.PowerTab.Drawing,
                new Vector2(412f, 18));
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
				Building construction = new Building();
                if (stats.canBeUpgraded && !((data.state == BuildingState.Ruins) || construction.isUnderConstruction() || data.state == BuildingState.CivAbandoned))
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
                    var curStats = Reflection.GetField(building.GetType(), building, "curStats") as BuildingAsset;
                    data.health = (int)curStats.base_stats[S.health];
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
				Building construction = new Building();
                if (downgradeTo != null && !((data.state == BuildingState.Ruins) || construction.isUnderConstruction() || data.state == BuildingState.CivAbandoned))
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

                    var curStats = Reflection.GetField(building.GetType(), building, "curStats") as BuildingAsset;
                    data.health = (int)curStats.base_stats[S.health];
                }

            }
        }
    }
}
