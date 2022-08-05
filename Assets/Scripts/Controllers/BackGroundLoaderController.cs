using System;
using System.Collections.Generic;
using Data.UnityObject;
using Data.ValueObject;
using Enums;
using Extentions;
using Signals;
using UnityEngine;
using TMPro;

namespace Controllers
{
    public class BackGroundLoaderController : MonoSingleton<BackGroundLoaderController>
    {
        #region Self Variables

        #region Public Variables
        
        public BackGroundAxis BackgroundAxis = BackGroundAxis.Vertical;

        public Transform TargetTransform;
        
        
        #endregion

        #region Serialized Variables

        [SerializeField] private List<GameObject> cubeList = new List<GameObject>();
        
        [SerializeField] private int predictedCubeCount;
        
        [SerializeField] private int mostValuableObjectValue = 3;

        [SerializeField] private Transform levelCollactableHolder ;
        
        #endregion

        #region Private Variables

        private LetterPathData _data;
        
        private float _colorValue;
            
        private Vector3 _forwardStack;

        private Vector3 _upwardsStack;

        private float _indexMinFactor;
        
        private int _levelCollactableCount = 80;

        #endregion

        #endregion


        protected override void Awake()
        {
            _data = GetLetterPathData();
            _indexMinFactor = _data.indexMinFactor;
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            MiniGameSignals.Instance.onCollisionWithBlock += OnSetColor;
        }

        private void UnsubscribeEvents()
        {
            MiniGameSignals.Instance.onCollisionWithBlock -= OnSetColor;
        }
        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion
        
        private void Start()
        {

            _data.cubePrefab.transform.localScale = _data.CubeScale;
            
            TargetTransform.position = new Vector3(0,(_data.cubePrefab.transform.localScale.y / 2) -1f,195);

            SetCubesToScene(SetPredictedCubeCount()); 
            
            OnLoadTower(BackgroundAxis); 
        }

        private LetterPathData GetLetterPathData() => Resources.Load<CD_LetterPath>("Data/CD_LetterPath").LetterPathData;
        
        private int SetPredictedCubeCount() // Set cube count base level
        {
            return predictedCubeCount = (_levelCollactableCount * mostValuableObjectValue) / _data.cubeScaleFactor;
        }
        
        private void SetCubesToScene(int cubeCount)
        {
            for (int i = 0; i < cubeCount; i++)
            {
                cubeList.Add(Instantiate(_data.cubePrefab,TargetTransform));
                
            }
        }
        private void OnSetColor(GameObject gO)
        {
            _colorValue += 0.05f;
            
            if (_colorValue>= 0.9f)
            {
                _colorValue = 0;
            }
            
            gO.GetComponent<Renderer>().material.color = Color.HSVToRGB(_colorValue, 1, 1); // DoColor
        }
        private void SetTowerCollider(BackGroundAxis _backgroundAxis,GameObject gO)
        {   
            BoxCollider cubeCollider = gO.GetComponent<BoxCollider>();
            
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                cubeCollider.center = _data.cubeColliderCenter;
                cubeCollider.size = _data.cubeColliderSize;
            }
            else
            {
                cubeCollider.center = _data.cubeColliderCenter;
                cubeCollider.size = _data.cubeColliderSize;
            }
        }
        private void SetTextOnCubes(GameObject gO,BackGroundAxis _backgroundAxis)
        {   
            
            
            if (_indexMinFactor > _data.indexMaxFactor)
            {
                return;
            }
         
            float _value = _indexMinFactor / 10;
            
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                gO.transform.GetChild(0).gameObject.SetActive(true);
                
                gO.transform.GetChild(0).GetComponentInChildren<TextMeshPro>().text = _value.ToString() + "X";
            }
            else
            {
                gO.transform.GetChild(1).gameObject.SetActive(true);
                
                gO.transform.GetChild(1).GetComponentInChildren<TextMeshPro>().text = _value.ToString() + "X";
            }

            _indexMinFactor++;
        }
        private Vector3 SetStackDirection(BackGroundAxis _backgroundAxis,int index)
        {
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
               return _forwardStack = cubeList[index].transform.localScale.y * Vector3.up;
            }
            else
            {
                return _upwardsStack = cubeList[index].transform.localScale.z * Vector3.forward;
            }
        }
        private void SetBuild(BackGroundAxis backgroundAxis)
        {
            for (int i = 0; i < cubeList.Count; i++)
            {   
                SetTextOnCubes(cubeList[i].gameObject,backgroundAxis);
                
                SetTowerCollider(backgroundAxis,cubeList[i]);
                
                if (i == 0)
                {
                    cubeList[i].transform.position = TargetTransform.position;
                }
                else
                {
                    cubeList[i].transform.position = cubeList[i - 1].transform.position + SetStackDirection(backgroundAxis,i);
                }
            }
        }
        private void OnLoadTower(BackGroundAxis backgroundAxis)
        {
            if (backgroundAxis == BackGroundAxis.Vertical)
            {
                SetBuild(backgroundAxis);
            }
            else
            {   
                SetBuild(backgroundAxis);
            }
        }
    }
}