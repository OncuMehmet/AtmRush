using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class CollectableSignals : MonoSingleton<CollectableSignals>
    {
        public UnityAction<int> onCollisionWithObstacle = delegate(int arg0) {  };

        public UnityAction<int, int> onCollisionWithAtm = delegate (int index, int value) { };

        public UnityAction<int,int> onCollisionWithBand = delegate (int index,int value) { };

        public UnityAction<GameObject> onCollisionWithCollectable = delegate{ };
    
        public UnityAction<GameObject> onCollissionWithStack = delegate(GameObject arg0) {  };
    
        public UnityAction onMovementWithLerp = delegate {  };

        protected override void Awake()
        {
            base.Awake();
        }
    }
}
