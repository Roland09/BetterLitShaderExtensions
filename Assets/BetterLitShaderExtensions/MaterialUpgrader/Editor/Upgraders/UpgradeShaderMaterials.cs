using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace Rowlan.BetterLitShaderExtensions.MaterialUpgrader
{
    public class UpgradeShaderMaterials
    {

        static List<MaterialUpgrader> GetBetterLitUpgraders()
        {
            var upgraders = new List<MaterialUpgrader>();

#if USING_HDRP

            upgraders.Add(new HDLitToBetterLitMaterialUpgrader("HDRP/Lit", "Better Lit/Lit"));

#elif USING_URP

            upgraders.Add(new URPLitToBetterLitMaterialUpgrader("Universal Render Pipeline/Lit", "Better Lit/Lit"));

#else

            upgraders.Add(new StandardToBetterLitMaterialUpgrader("Standard", "Better Lit/Lit"));

#endif


            return upgraders;
        }

#if USING_HDRP

        [MenuItem("Window/BetterLitShader Extensions/Upgrade Selected HDRP Lit Materials")]
        internal static void UpgradeMaterialsSelection()
        {
            MaterialUpgrader.UpgradeSelection(GetBetterLitUpgraders(), "Upgrade to BetterLit Material");
        }

        [MenuItem("Window/BetterLitShader Extensions/Upgrade All Project HDRP Lit Materials")]
        internal static void UpgradeMaterialsProject()
        {
            MaterialUpgrader.UpgradeProjectFolder(GetBetterLitUpgraders(), "Upgrade to BetterLit Material");
        }

#elif USING_URP

        [MenuItem("Window/BetterLitShader Extensions/Upgrade Selected URP Lit Materials")]
        internal static void UpgradeMaterialsSelection()
        {
            MaterialUpgrader.UpgradeSelection(GetBetterLitUpgraders(), "Upgrade to BetterLit Material");
        }

        [MenuItem("Window/BetterLitShader Extensions/Upgrade All Project URP Lit Materials")]
        internal static void UpgradeMaterialsProject()
        {
            MaterialUpgrader.UpgradeProjectFolder(GetBetterLitUpgraders(), "Upgrade to BetterLit Material");
        }

#else

        [MenuItem("Window/BetterLitShader Extensions/Upgrade Selected Standard Materials")]
        internal static void UpgradeMaterialsSelection()
        {
            MaterialUpgrader.UpgradeSelection(GetBetterLitUpgraders(), "Upgrade to BetterLit Material");
        }

        [MenuItem("Window/BetterLitShader Extensions/Upgrade All Project Standard Materials")]
        internal static void UpgradeMaterialsProject()
        {
            MaterialUpgrader.UpgradeProjectFolder(GetBetterLitUpgraders(), "Upgrade to BetterLit Material");
        }

#endif

    }
}