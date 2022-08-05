using UnityEngine;
using Signals;

namespace Commands
{
    public class BandAnimationCommand : MonoBehaviour
    {
        #region Self Variables

        #region Serialize Variables
        [SerializeField] private float scrollSpeed = 0.05f;
        [SerializeField] private Renderer renderer;
        #endregion

        #endregion

        private void Awake()
        {
            renderer = GetComponent<Renderer>();
        }

        #region Subscription

        private void OnEnable()
        {
            CoreGameSignals.Instance.onAnimateBandTile += OnAnimateBandTile;
        }

        private void OnDisable()
        {
            CoreGameSignals.Instance.onAnimateBandTile -= OnAnimateBandTile;
        }

        #endregion

        private void OnAnimateBandTile()
        {
            float offset = Time.time * scrollSpeed;
            renderer.material.SetTextureOffset("_BaseMap", new Vector2(0, -offset));
        }
    }
}