using UGF.EditorTools.Editor.IMGUI;
using UGF.EditorTools.Editor.IMGUI.Scopes;
using UGF.Module.Analytics.Runtime.Unity;
using UnityEditor;

namespace UGF.Module.Analytics.Editor.Unity
{
    [CustomEditor(typeof(AnalyticsUnityModuleAsset), true)]
    internal class AnalyticsUnityModuleAssetEditor : UnityEditor.Editor
    {
        private SerializedProperty m_propertyEnableOnInitializeAsync;

        private void OnEnable()
        {
            m_propertyEnableOnInitializeAsync = serializedObject.FindProperty("m_enableOnInitializeAsync");
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyEnableOnInitializeAsync);
            }

#if !UGF_MODULE_ANALYTICS_ANALYTICS_INSTALLED
            EditorGUILayout.HelpBox("Analytics Unity Module: Analytics package required.", MessageType.Warning);
#endif
        }
    }
}
