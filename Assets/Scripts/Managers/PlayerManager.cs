using Controllers;
using Data.UnityObject;
using Data.ValueObject;
using Keys;
using Signals;
using DG.Tweening;
using Enums;
using UnityEngine;

namespace Managers
{
    public class PlayerManager : MonoBehaviour
    {
        #region Self Variables

        #region Public Variables
        
        [Header("Data")] public PlayerData Data;

        public PlayerScoreController playerScoreController;


        #endregion

        #region Serialized Variables

        [Space] [SerializeField] private PlayerMovementController movementController;
        
        [SerializeField] private PlayerPhysicsController physicsController;
        
        [SerializeField] private PlayerAnimationController animationController;

        [SerializeField] private PlayerScoreController scoreController;

        #endregion

        #region MyRegion
        
        private MinigameStartController _miniGame = new MinigameStartController();
        

        #endregion
        #endregion


        private void Awake()
        {
            Data = GetPlayerData();
            
            SendPlayerDataToControllers();

        }

        private PlayerData GetPlayerData() => Resources.Load<CD_Player>("Data/CD_Player").data;

        private void SendPlayerDataToControllers()
        {
            movementController.SetMovementData(Data.MovementData);
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            InputSignals.Instance.onInputTaken += OnActivateMovement;
            InputSignals.Instance.onInputReleased += OnDeactiveMovement;
            InputSignals.Instance.onInputDragged += OnGetInputValues;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onReset += OnReset;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            ScoreSignals.Instance.onChangePlayerScore += OnChangePlayerScore;
            MiniGameSignals.Instance.onCollisionWithStack += OnStartMiniGame;
            MiniGameSignals.Instance.onCollisionWithStack += OnSetPlayerScore;

        }

        private void UnsubscribeEvents()
        {
            InputSignals.Instance.onInputTaken -= OnActivateMovement;
            InputSignals.Instance.onInputReleased -= OnDeactiveMovement;
            InputSignals.Instance.onInputDragged -= OnGetInputValues;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onReset -= OnReset;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            ScoreSignals.Instance.onChangePlayerScore -= OnChangePlayerScore;
            MiniGameSignals.Instance.onCollisionWithStack -= OnStartMiniGame;
            MiniGameSignals.Instance.onCollisionWithStack -= OnSetPlayerScore;

        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        #region Movement Controller

        private void OnActivateMovement()
        {
            movementController.EnableMovement();
        }

        private void OnDeactiveMovement()
        {
            movementController.DeactiveMovement();
        }

        private void OnGetInputValues(HorizontalInputParams inputParams)
        {
            movementController.UpdateInputValue(inputParams);
        }

        #endregion

        private void OnPlay()
        {
            movementController.IsReadyToPlay(true);
            
            animationController.ActivatePlayerMovementAnimation();
        }

        private void OnLevelSuccessful()
        {
            movementController.IsReadyToPlay(false);
        }

        private void OnLevelFailed()
        {
            movementController.IsReadyToPlay(false);
        }

        private void OnReset()
        {
            movementController.OnReset();
        }

        private void OnChangePlayerScore(int score)
        {
            scoreController.ChangePlayerScore(score);
        }

        public void PushAndShakeThePlayer()
        {
            movementController.IsReadyToPlay(false);
            transform.DOShakePosition(0.5f, 0.6f, 6);
            transform.DOMoveZ(transform.position.z - 8, 0.5f).OnComplete(() =>
            movementController.IsReadyToPlay(true));
        }

        public void OnStartMiniGame()
        {
            animationController.DeactivatePlayerMovementAnimation();
            
            movementController.IsReadyToPlay(false);
            
            DOVirtual.DelayedCall(1, () =>
            {
                MiniGameSignals.Instance.onStartMiniGame?.Invoke(playerScoreController._playerScore);
                
                gameObject.SetActive(false);
            });

        }

        private void OnSetPlayerScore()
        {
            CoreGameSignals.Instance.onSaveGameData(SaveStates.Score, playerScoreController._playerScore);
        
            UISignals.Instance.onChangeScoreText(playerScoreController._playerScore);
        }
        
        public void StopPlayerMove() => movementController.OnReset();
        
    }
}
