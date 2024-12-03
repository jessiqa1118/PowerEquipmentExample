using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace PowerEquipment
{
    public class OutletComponent : MonoBehaviour
    {
        [SerializeField] private int capacity = 1500;
        [SerializeField] private List<PowerSocketField> socketFields;

        private IPowerSupplier _supplier;

        private void OnEnable()
        {
            try
            {
                var sockets = socketFields
                    .Select(field => new PowerSocket(field.ConsumerComponent))
                    .Cast<IPowerSocket>()
                    .ToList();

                _supplier = new OutletModule(sockets, new Power(capacity));
            }
            catch (Exception e)
            {
                Debug.LogError($"モジュールの初期化に失敗しました: {e.Message}");
                return;
            }

            Debug.Log($"最大消費電力: {_supplier.Capacity.Watts} [W]");
            Debug.Log($"現在の消費電力: {_supplier.Consumption.Watts} [W]");
        }

        private void OnDisable()
        {
            _supplier = null;
        }

#if UNITY_EDITOR
        public const string CapacityFieldName = nameof(capacity);
        public const string SocketFieldsFieldName = nameof(socketFields);
#endif
    }
}