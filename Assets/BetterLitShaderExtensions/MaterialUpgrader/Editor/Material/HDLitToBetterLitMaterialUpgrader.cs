using UnityEditor;
using UnityEngine;

namespace Rowlan.BetterLitShaderExtensions.MaterialUpgrader
{
    class HDLitToBetterLitMaterialUpgrader : MaterialUpgrader
    {
        public HDLitToBetterLitMaterialUpgrader(string sourceShaderName, string destShaderName, MaterialFinalizer finalizer = null)
        {
            RenameShader(sourceShaderName, destShaderName, finalizer);
        }

        public override void Convert(Material srcMaterial, Material dstMaterial)
        {
            dstMaterial.hideFlags = HideFlags.DontUnloadUnusedAsset;

            base.Convert(srcMaterial, dstMaterial);
        }
    }
}
