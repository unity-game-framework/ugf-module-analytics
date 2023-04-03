using UGF.EditorTools.Editor.Assets;
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
        private AssetIdReferenceListDrawer m_listEvents;
        private ReorderableListSelectionDrawerByPath m_listEventsSelection;

        private void OnEnable()
        {
            m_propertyEnableOnInitializeAsync = serializedObject.FindProperty("m_enableOnInitializeAsync");
            m_listEvents = new AssetIdReferenceListDrawer(serializedObject.FindProperty("m_events"));

            m_listEventsSelection = new ReorderableListSelectionDrawerByPath(m_listEvents, "m_asset")
            {
                Drawer = { DisplayTitlebar = true }
            };

            m_listEvents.Enable();
            m_listEventsSelection.Enable();
        }

        private void OnDisable()
        {
            m_listEvents.Disable();
            m_listEventsSelection.Disable();
        }

        public override void OnInspectorGUI()
        {
            using (new SerializedObjectUpdateScope(serializedObject))
            {
                EditorIMGUIUtility.DrawScriptProperty(serializedObject);

                EditorGUILayout.PropertyField(m_propertyEnableOnInitializeAsync);

                m_listEvents.DrawGUILayout();
                m_listEventsSelection.DrawGUILayout();
            }
        }
    }
}
