using Managers;
using UnityEngine;

namespace Controllers
{
    public class CollectablePhysicsController : MonoBehaviour
    {
        #region Self Variables
        #region Serializefield Variables
    
        [SerializeField] private CollectableManager manager;
        // [SerializeField] private Collider col;
        // [SerializeField] private new Rigidbody rigidbody;

        #endregion


        #endregion
   

        private void OnTriggerEnter(Collider other)
        {
        
            if(other.CompareTag("MoneyTransform"))
            {
                CollisionWithBand();
            }

            if (other.CompareTag("ATM"))
            {
                CollisionWithAtm();
            }

            if (other.CompareTag("Gate"))
            {
                CollisionWithGate();
            }

            if (other.CompareTag("Collectable") && CompareTag("Collected"))
            {
                other.tag = "Collected";
                CollisionWithCollectable(other.transform.parent.gameObject);
            }

            if (other.CompareTag("Obstacle"))
            {
                CollisionWithObstacle();
            }

            if (other.CompareTag("Stack") && CompareTag("Collectable"))
            {
                tag = "Collected";
                CollisionWithStack();
            }
        }
        private void CollisionWithAtm()
        {
            manager.CollisionWithAtm();
        }

        private void CollisionWithCollectable(GameObject gO)
        {
            manager.CollisionWithCollectable(gO);
        }

        private void CollisionWithObstacle()
        {
            manager.CollisionWithObstacle();
        }
    
        private void CollisionWithGate()
        {
            manager.CollisionWithGate();
        }

        private void CollisionWithStack()
        {
            manager.CollisionWithStack();
        }

        private void CollisionWithBand()
        {
            manager.CollisionWithBand();
        }
    }
}
