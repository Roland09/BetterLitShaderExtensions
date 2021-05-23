using UnityEditor;
using UnityEngine;

namespace Rowlan.BetterLitShaderExtensions.MaterialUpgrader
{
    class HDRPLitToBetterLitMaterialUpgrader : MaterialUpgrader
    {
#if USING_HDRP
        public HDRPLitToBetterLitMaterialUpgrader(string sourceShaderName, string destShaderName, MaterialFinalizer finalizer = null)
        {
            RenameShader(sourceShaderName, destShaderName, finalizer);

            RenameTexture("_MainTex", "_AlbedoMap");
            RenameColor("_BaseColor", "_Tint");
            RenameTexture("_BumpMap", "_NormalMap");

        }

        public override void Convert(Material srcMaterial, Material dstMaterial)
        {
            dstMaterial.hideFlags = HideFlags.DontUnloadUnusedAsset;

            base.Convert(srcMaterial, dstMaterial);

            #region Mapping of material properties

            // add additional remapping code here
            // as an example of e. g. convert the to mask map see 
            // the code in Unity's own StandardsToHDLitMaterialUpgrader of the HDRP upgrader
            // ...
            
            #endregion Mapping of material properties

            MaterialEditor.ApplyMaterialPropertyDrawers(dstMaterial);
            EditorUtility.SetDirty(dstMaterial);
        }
#endif

    }
}
