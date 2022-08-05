using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerAnimationController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
    
        [SerializeField] private PlayerManager playerManager;
        [SerializeField] private Animator animator;
    

        #endregion

        #region Private Variables

        #endregion

        #endregion
    

        public void ActivatePlayerMovementAnimation()
        {
            animator.SetBool("isRunning",true);
        }

        public void DeactivatePlayerMovementAnimation()
        {
            animator.SetBool("isRunning",false);
        }
    

        public void DeactivatePlayerMesh()
        {
            gameObject.SetActive(false);
        }
    }
}
