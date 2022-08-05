using UnityEngine;
using DG.Tweening;
using Signals;


namespace Controllers
{
    public class BackgroundAnimationController : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("StairStep"))
            {
                PlayForwardAnim(other.gameObject);
                MiniGameSignals.Instance.onCollisionWithBlock?.Invoke(other.gameObject);
            }
        }
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("StairStep"))
            {
                PlayBackAnim(other.gameObject);
            }
        }

        private void PlayForwardAnim(GameObject gameObject)
        {
            gameObject.transform.DOLocalMoveZ(4.0f, .2f);
        }

        private void PlayBackAnim(GameObject gameObject)
        {
            gameObject.transform.DOLocalMoveZ(0f, 1.2f);
        }

    }
}
