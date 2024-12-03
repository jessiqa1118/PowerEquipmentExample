using UnityEditor;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

namespace PowerEquipment.Editor
{
    [CustomPropertyDrawer(typeof(PowerSocketField))]
    public class PowerSocketFieldDrawer : PropertyDrawer
    {
        public override VisualElement CreatePropertyGUI(SerializedProperty property)
        {
            var element = new VisualElement
            {
                style =
                {
                    flexDirection = FlexDirection.Row,
                }
            };

            var consumerProperty = property.FindPropertyRelative(PowerSocketField.ConsumerComponentFieldName);

            var green = new Color(0.0f, 0.75f, 0.0f);
            var red = new Color(0.75f, 0.0f, 0.0f);

            var lamp = new VisualElement
            {
                style =
                {
                    width = 10,
                    height = 10,
                    marginTop = 4,
                    marginRight = 2,
                    borderBottomLeftRadius = new StyleLength(50),
                    borderBottomRightRadius = new StyleLength(50),
                    borderTopLeftRadius = new StyleLength(50),
                    borderTopRightRadius = new StyleLength(50),
                    backgroundColor = consumerProperty?.objectReferenceValue ? green : red,
                }
            };

            var consumerField = new PropertyField(consumerProperty)
            {
                label = string.Empty,
                style =
                {
                    paddingRight = 5,
                    flexGrow = 1,
                    flexShrink = 1,
                }
            };

            consumerField.RegisterValueChangeCallback(_ =>
            {
                lamp.style.backgroundColor = consumerProperty?.objectReferenceValue != null ? green : red;
            });

            element.Add(lamp);
            element.Add(consumerField);

            return element;
        }
    }
}