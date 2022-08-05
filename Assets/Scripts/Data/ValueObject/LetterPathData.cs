using System;
using UnityEngine;

namespace Data.ValueObject
{   
    [Serializable]
    public class LetterPathData
    {   
        public Vector3 CubeScale;

        public Vector3 cubeColliderCenter;

        public Vector3 cubeColliderSize;

        public GameObject cubePrefab;
        
        public int cubeScaleFactor = 10;
        
        public float indexMinFactor = 10.0f;
        
        public float indexMaxFactor = 100.0f;
        
        public float colliderSize = 2.0f;

        public float colliderCenter = 0.5f;
        
    }
}