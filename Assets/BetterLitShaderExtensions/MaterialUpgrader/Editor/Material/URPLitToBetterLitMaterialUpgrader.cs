using UnityEditor;
using UnityEngine;

namespace Rowlan.BetterLitShaderExtensions.MaterialUpgrader
{
    class URPLitToBetterLitMaterialUpgrader : MaterialUpgrader
    {
#if USING_URP
        public URPLitToBetterLitMaterialUpgrader(string sourceShaderName, string destShaderName, MaterialFinalizer finalizer = null)
        {
            RenameShader(sourceShaderName, destShaderName, finalizer);
        }

        public override void Convert(Material srcMaterial, Material dstMaterial)
        {
            dstMaterial.hideFlags = HideFlags.DontUnloadUnusedAsset;

            base.Convert(srcMaterial, dstMaterial);

            #region Mapping of material properties

			// perform manual conversion. BetterLit Shaders would support automatic conversion when you click on a material,
			// but if you have multiple materials, you'd have to click on every single one of them.
			// => we do manual conversion

			Texture mainTex = srcMaterial.GetTexture("_BaseMap");
            if (mainTex != null) {
                dstMaterial.SetTexture("_AlbedoMap", mainTex);
            }

            Color baseColor = srcMaterial.GetColor("_BaseColor");
            if( baseColor != null) {
                dstMaterial.SetColor("_Tint", baseColor);
			}

            Texture bumpMap = srcMaterial.GetTexture("_BumpMap");
            if (bumpMap != null)
            {
                dstMaterial.SetTexture("_NormalMap", bumpMap);
            }

            #endregion Mapping of material properties

            MaterialEditor.ApplyMaterialPropertyDrawers(dstMaterial);
            EditorUtility.SetDirty(dstMaterial);
        }
#endif

    }
}
