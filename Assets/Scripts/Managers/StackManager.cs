using System.Collections.Generic;
using Data.UnityObject;
using UnityEngine;
using Commands;
using Keys;
using Signals;

namespace Managers
{
    public class StackManager : MonoBehaviour
    {
       
        #region Self Variables
        #region Public Variables
        [Header("Data")] public StackData Data;
        public GameObject _tempHolder;
        [Space]
        public List<GameObject> Collectables = new List<GameObject>();
        #endregion
        #region Serialized Variables
        [SerializeField] private StackScoreData scoreData;
        [SerializeField] private StackScaleData scaleData;
        #endregion
        #region Private Variables
        private LerpStackCommand _lerpStackCommand;
        private ShakeStackCommand _shakeStackCommand;
        private AddStackCommand _addStackCommand;
        private RemoveStackCommand _removeStackCommand;
        private RemoveStackATMCommand _removeStackATMCommand;
        private RemoveStackBand _removeStackBand;
        #endregion
        #endregion
        private void Awake()
        {
            Data = GetStackData();

            _tempHolder = GameObject.FindGameObjectWithTag("PoolHolder").transform.GetChild(0).gameObject;

            SetStackData();

            _shakeStackCommand = new ShakeStackCommand(ref Collectables);
            _addStackCommand = new AddStackCommand(new AddStackKeyParams(ref Collectables, transform, this, ref _shakeStackCommand));
            _lerpStackCommand = new LerpStackCommand(ref Collectables);
            _removeStackCommand = new RemoveStackCommand(transform, gameObject, _tempHolder, ref Collectables);
            _removeStackATMCommand = new RemoveStackATMCommand(ref Collectables, _tempHolder);
            _removeStackBand = new RemoveStackBand(ref Collectables, _tempHolder, transform);
        }
        private StackData GetStackData() => Resources.Load<CD_Stack>("Data/CD_Stack").data;

        private void SetStackData()
        {
            scoreData = Data.scoreData;
            scaleData = Data.scaleData;
        }
        #region Event Subscription
        private void OnEnable()
        {
            SubscribeEvents();
        }
        private void SubscribeEvents()
        {
            CollectableSignals.Instance.onCollisionWithCollectable += _addStackCommand.OnAddOnStack;
            CollectableSignals.Instance.onCollisionWithObstacle += _removeStackCommand.OnRemoveFromStack;
            CollectableSignals.Instance.onCollissionWithStack += _addStackCommand.OnAddOnStack;
            CollectableSignals.Instance.onMovementWithLerp += _lerpStackCommand.OnLerpTheStack;
            CollectableSignals.Instance.onCollisionWithAtm += _removeStackATMCommand.OnCollisionWithATM;
            CollectableSignals.Instance.onCollisionWithBand += _removeStackBand.OnCollisionWithBand;
        }
        private void UnsubscribeEvents()
        {
            CollectableSignals.Instance.onCollisionWithCollectable -= _addStackCommand.OnAddOnStack;
            CollectableSignals.Instance.onCollisionWithObstacle -= _removeStackCommand.OnRemoveFromStack;
            CollectableSignals.Instance.onCollissionWithStack -= _addStackCommand.OnAddOnStack;
            CollectableSignals.Instance.onMovementWithLerp -= _lerpStackCommand.OnLerpTheStack;
            CollectableSignals.Instance.onCollisionWithAtm -= _removeStackATMCommand.OnCollisionWithATM;
            CollectableSignals.Instance.onCollisionWithBand -= _removeStackBand.OnCollisionWithBand;
        }
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion
    }
}