using UnityEditor;
using UnityEditor.AddressableAssets;

namespace Core.Editor
{
    [InitializeOnLoad]
    public static class CoreAddressablesChecker
    {
        static CoreAddressablesChecker()
        {
            // Delay to avoid domain reload issues
            EditorApplication.delayCall += CheckCoreGroup;
        }
        
        private static void CheckCoreGroup()
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            if (settings == null) return;

            var groupName = "Sim.Tester.Addr.Core";
            if (settings.FindGroup(groupName) == null)
            {
                bool setup = EditorUtility.DisplayDialog(
                    "Core Addressables Setup",
                    "The Core Addressables group is missing. Would you like to create it now?",
                    "Yes",
                    "No"
                );

                if (setup)
                {
                    CoreAddressablesSetup.SetupCoreAddressables();
                }
            }
        }
    }
}