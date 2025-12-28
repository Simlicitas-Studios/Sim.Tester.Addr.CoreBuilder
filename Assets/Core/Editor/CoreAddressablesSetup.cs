using UnityEditor;
using UnityEditor.AddressableAssets;
using UnityEditor.AddressableAssets.Settings;
using UnityEditor.AddressableAssets.Settings.GroupSchemas;
using UnityEngine;

namespace Core.Editor
{
    public static class CoreAddressablesSetup
    {
        public static void SetupCoreAddressables()
        {
            var settings = AddressableAssetSettingsDefaultObject.Settings;
            if (settings == null) return;

            var groupName = "Sim.Tester.Addr.Core";
            var group = settings.FindGroup(groupName);
            if (group == null)
            {
                group = settings.CreateGroup(
                    groupName,
                    false,
                    false,
                    false,
                    settings.DefaultGroup.Schemas
                );

                var schema = group.GetSchema<BundledAssetGroupSchema>();
                schema.BuildPath.SetVariableByName(settings, "CoreBuildPath");
                schema.LoadPath.SetVariableByName(settings, "CoreLoadPath");
                schema.BundleNaming = BundledAssetGroupSchema.BundleNamingStyle.FileNameHash;
                schema.IncludeInBuild = true;
            }

            // Add package assets
            string corePath = "Packages/com.sim.tester.addr.core"; // adjust
            var assetGUIDs = AssetDatabase.FindAssets("", new[] { corePath });
            foreach (var guid in assetGUIDs)
            {
                if (settings.FindAssetEntry(guid) == null)
                {
                    settings.CreateOrMoveEntry(guid, group);
                }
            }

            settings.SetDirty(AddressableAssetSettings.ModificationEvent.BatchModification, null, true);
            AssetDatabase.SaveAssets();
            Debug.Log("Core Addressables setup complete!");
        }
    }
}