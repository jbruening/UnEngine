namespace UnityEngine {
    public interface ISerializationCallbackReceiver {
        void OnAfterDeserialize();
        void OnBeforeSerialize();
    }

}
