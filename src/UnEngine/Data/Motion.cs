using System;

#if UNENG
namespace UnEngine
#else
namespace UnityEngine
#endif
{
    public class Motion : Object
    {
        public float averageDuration { get; private set; }
        public float averageAngularSpeed { get; private set; }
        public Vector3 averageSpeed { get; private set; }
        public float apparentSpeed { get; private set; }
        public bool isLooping { get; private set; }
        public bool isAnimatorMotion { get; private set; }
        public bool isHumanMotion { get; private set; }

        public bool ValidateIfRetargetable(bool showWarning)
        {
            AssertNull();
            throw new NotImplementedException();
        }
    }
}