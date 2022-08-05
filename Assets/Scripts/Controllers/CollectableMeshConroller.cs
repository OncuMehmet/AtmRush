using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class CollectableMeshConroller : MonoBehaviour
    {
        #region Self Variables
        #region Serialized Variables
        [SerializeField]
        private List<MeshFilter> meshFilter = new List<MeshFilter>();

        #endregion

        #endregion

        private void Awake()
        {
            gameObject.GetComponent<MeshFilter>().sharedMesh = meshFilter[0].sharedMesh;
        }
    
        public void SetMeshType(int id)
        {
            gameObject.GetComponent<MeshFilter>().sharedMesh = meshFilter[id].sharedMesh;
        }

    }
}
