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
        private static void loadSprites(BuildingAsset pTemplate)
        {   
            AssetManager.buildings.loadSprites(pTemplate);
            //AssetManager.buildings.CallMethod("loadSprites", pTemplate);

            return;
            
            // for(int i = 0; i < pTemplate.sprites.animationData.Count; i++){
            //     var sprites = pTemplate.sprites.animationData[i];
            //     for(int j = 0; j < sprites.list_main.Count; j++){
            //         var sprite = sprites.list_main[j];
                    
            //         sprites.list_main[j] = Sprite.Create(sprite.texture, new Rect(0.0f, 0.0f, (float)sprite.texture.width, (float)sprite.texture.height), new Vector2(0.5f, 0f), 1f);
            //     }

                
            //     // for(int j = 0; j < sprites.list_shadows.Count; j++){
            //     //     var sprite = sprites.list_shadows[j];
                    
            //     //     sprites.list_shadows[j] = Sprite.Create(sprite.texture, new Rect(0.0f, 0.0f, (float)sprite.texture.width, (float)sprite.texture.height), new Vector2(0.5f, 0f), 1f);
            //     // }

                
            //     for(int j = 0; j < sprites.list_ruins.Count; j++){
            //         var sprite = sprites.list_ruins[j];
                    
            //         sprites.list_ruins[j] = Sprite.Create(sprite.texture, new Rect(0.0f, 0.0f, (float)sprite.texture.width, (float)sprite.texture.height), new Vector2(0.5f, 0f), 1f);
            //     }

                
            //     for(int j = 0; j < sprites.list_special.Count; j++){
            //         var sprite = sprites.list_special[j];
                    
            //         sprites.list_special[j] = Sprite.Create(sprite.texture, new Rect(0.0f, 0.0f, (float)sprite.texture.width, (float)sprite.texture.height), new Vector2(0.5f, 0f), 1f);
            //     }

                
            // }

            // foreach (BuildingAnimationDataNew animationDataNew in pTemplate.sprites.animationData)
            // {
            //     animationDataNew.main = animationDataNew.list_main.ToArray();
            //     animationDataNew.ruins = animationDataNew.list_ruins.ToArray();
            //     //animationDataNew.shadows = animationDataNew.list_shadows.ToArray();
            //     animationDataNew.special = animationDataNew.list_special.ToArray();
            // }
        }
    }
}
