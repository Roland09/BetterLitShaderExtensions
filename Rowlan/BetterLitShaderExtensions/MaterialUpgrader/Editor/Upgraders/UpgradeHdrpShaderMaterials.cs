using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rowlan.BetterLitShaderExtensions.MaterialUpgrader
{
    public class UpgradeHdrpShaderMaterials
    {

        static List<MaterialUpgrader> GetHDUpgraders()
        {
            var upgraders = new List<MaterialUpgrader>();
            upgraders.Add(new HDLitToBetterLitMaterialUpgrader("HDRP/Lit", "Better Lit/Lit"));

            return upgraders;
        }

        [MenuItem("Window/BetterLitShader Extensions/Upgrade Selected HDRP Lit Materials")]
        internal static void UpgradeMaterialsSelection()
        {
            MaterialUpgrader.UpgradeSelection(GetHDUpgraders(), "Upgrade to HD Material");
        }

        [MenuItem("Window/BetterLitShader Extensions/Upgrade All Project HDRP Lit Materials")]
        internal static void UpgradeMaterialsProject()
        {
            MaterialUpgrader.UpgradeProjectFolder(GetHDUpgraders(), "Upgrade to HD Material");
        }
    }
}