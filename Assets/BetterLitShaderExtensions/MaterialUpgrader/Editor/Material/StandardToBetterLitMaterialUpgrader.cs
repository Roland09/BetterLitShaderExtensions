using UnityEditor;
using UnityEngine;

namespace Rowlan.BetterLitShaderExtensions.MaterialUpgrader
{
    class StandardToBetterLitMaterialUpgrader : MaterialUpgrader
    {
#if !USING_HDRP && !USING_URP

        public StandardToBetterLitMaterialUpgrader(string sourceShaderName, string destShaderName, MaterialFinalizer finalizer = null)
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

			Texture mainTex = srcMaterial.GetTexture("_MainTex");
            if (mainTex != null) {
                dstMaterial.SetTexture("_AlbedoMap", mainTex);
            }

            Color baseColor = srcMaterial.GetColor("_Color");
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
