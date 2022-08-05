using DG.Tweening;
using UnityEngine;

namespace Commands
{
    public class AtmAnimationCommand : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if(other.CompareTag("Player"))
            {
                transform.DOMoveY(-10, 1f).SetEase(Ease.Linear);
            }
            if(other.CompareTag("Collected"))
            {
                transform.DOShakePosition(0.02f, 0.4f, 2);
            }
        }
    }
}