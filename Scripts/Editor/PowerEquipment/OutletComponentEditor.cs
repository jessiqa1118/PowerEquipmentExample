using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace PowerEquipment.Editor
{
    [CustomEditor(typeof(OutletComponent))]
    public class OutletComponentEditor : UnityEditor.Editor
    {
        public override VisualElement CreateInspectorGUI()
        {
            var root = new VisualElement();

            root.Add(CreateCapacityGUI());
            root.Add(CreatePowerSocketsGUI());

            return root;
        }

        private VisualElement CreateCapacityGUI()
        {
            var element = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                }
            };

            var labelField = new Label
            {
                text = "最大消費電力 [W]",
                style =
                {
                    width = 120,
                    paddingTop = 1,
                }
            };

            var property = serializedObject.FindProperty(OutletComponent.CapacityFieldName);
            var capacityField = new PropertyField(property)
            {
                label = string.Empty,
                style =
                {
                    paddingRight = 3,
                    flexGrow = 1,
                    flexShrink = 1,
                }
            };

            element.Add(labelField);
            element.Add(capacityField);

            return element;
        }

        private VisualElement CreatePowerSocketsGUI()
        {
            var element = new VisualElement();

            var socketProperty = serializedObject.FindProperty(OutletComponent.SocketFieldsFieldName);
            var listView = new ListView
            {
                headerTitle = "接続機器",
                showFoldoutHeader = true,
                showBoundCollectionSize = false,
                showAddRemoveFooter = true,
                showBorder = true,

                bindingPath = OutletComponent.SocketFieldsFieldName,
                reorderable = true,
                reorderMode = ListViewReorderMode.Animated,

                makeItem = () => new PropertyField(),

                bindItem = (item, index) =>
                {
                    var property = socketProperty.GetArrayElementAtIndex(index);
                    (item as PropertyField)?.BindProperty(property);
                },
            };

            listView.Bind(serializedObject);

            element.Add(listView);

            return element;
        }
    }
}