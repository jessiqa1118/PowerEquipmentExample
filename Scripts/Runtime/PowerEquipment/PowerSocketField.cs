using System;
using UnityEngine;

namespace PowerEquipment
{
    [Serializable]
    public class PowerSocketField
    {
        [SerializeField] private PowerConsumerComponent consumerComponent;
        
        public PowerConsumerComponent ConsumerComponent => consumerComponent;

#if UNITY_EDITOR
        public const string ConsumerComponentFieldName = nameof(consumerComponent);
#endif
    }
}