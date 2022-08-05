using Enums;
using Signals;
using UnityEngine;
using DG.Tweening;
namespace Controllers
{
    public class MiniGamePhysicController: MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Stack"))
            {
                MiniGameSignals.Instance.onCollisionWithStack?.Invoke();
                DOVirtual.DelayedCall(1,() =>
                    CoreGameSignals.Instance.onSetCameraState?.Invoke(CameraStates.Runner));
            }
        }
    }
}