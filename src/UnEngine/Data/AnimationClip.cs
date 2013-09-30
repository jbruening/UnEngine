#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public sealed class AnimationClip : Motion
    {
        private Bounds _bounds;
        public float length { get; private set; }
        public float frameRate { get; private set; }
        public WrapMode wrapMode { get; set; }

        public Bounds localBounds
        {
            get
            {
                AssertNull();
                return _bounds;
            }
            set
            {
                AssertNull();
                _bounds = value;
            }
        }
    }
}