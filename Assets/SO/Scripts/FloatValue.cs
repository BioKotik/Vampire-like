using UnityEngine;

namespace SO.Scripts
{
    [CreateAssetMenu]
    public class FloatValue : ScriptableObject, ISerializationCallbackReceiver
    {
        [SerializeField]
        private float initialValue;

        [HideInInspector]
        public float runtimeValue;

        public void OnBeforeSerialize()
        {

        }

        public void OnAfterDeserialize()
        {
            runtimeValue = initialValue;
        }
    }
}