using Controllers;
using Enums;
using Signals;
using UnityEngine;

namespace Managers
{
    public class UIManager : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private UIPanelController uiPanelController;
        
        [SerializeField] private LevelPanelController levelPanelController;


        #endregion

        #endregion

        private void Start()
        {
            ReplaceSaveDatasToUI();
        }

        #region Event Subscriptions

        private void OnEnable()
        {
            SubscribeEvents();
        }

        private void SubscribeEvents()
        {
            UISignals.Instance.onOpenPanel += OnOpenPanel;
            UISignals.Instance.onClosePanel += OnClosePanel;
            UISignals.Instance.onSetLevelText += OnSetLevelText;
            UISignals.Instance.onChangeLevelText += OnChangeLevelText;
            UISignals.Instance.onChangeScoreText += OnChangeScoreText;
            CoreGameSignals.Instance.onPlay += OnPlay;
            CoreGameSignals.Instance.onLevelFailed += OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful += OnLevelSuccessful;
        }

        private void UnsubscribeEvents()
        {
            UISignals.Instance.onOpenPanel -= OnOpenPanel;
            UISignals.Instance.onClosePanel -= OnClosePanel;
            UISignals.Instance.onSetLevelText -= OnSetLevelText;
            UISignals.Instance.onChangeLevelText -= OnChangeLevelText;
            UISignals.Instance.onChangeScoreText -= OnChangeScoreText;
            CoreGameSignals.Instance.onPlay -= OnPlay;
            CoreGameSignals.Instance.onLevelFailed -= OnLevelFailed;
            CoreGameSignals.Instance.onLevelSuccessful -= OnLevelSuccessful;
        }

        private void OnDisable()
        {
            UnsubscribeEvents();
        }

        #endregion

        private void OnOpenPanel(UIPanels panelParam)
        {
            uiPanelController.OpenPanel(panelParam);
        }

        private void OnClosePanel(UIPanels panelParam)
        {
            uiPanelController.ClosePanel(panelParam);
        }
        

        private void OnSetLevelText(int value)
        {
            levelPanelController.SetLevelText(value);
        }

        private void OnChangeScoreText(int score)
        {
           levelPanelController.SetScoreText(score);
        }

        private void OnChangeLevelText(int level)
        {
            levelPanelController.SetLevelText(level);
        }

        public void OnPlay()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.LevelPanel);
            
        }

        private void OnLevelFailed()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.FailPanel);
        }

        private void OnLevelSuccessful()
        {
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.WinPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
        }

        public void Play()
        {
            CoreGameSignals.Instance.onPlay?.Invoke();
            CoreGameSignals.Instance.onSetCameraState?.Invoke(CameraStates.Initial);
        }

        public void NextLevel()
        {
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.WinPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.LevelPanel);
            CoreGameSignals.Instance.onClearActiveLevel?.Invoke();
            CoreGameSignals.Instance.onNextLevel?.Invoke();
            CoreGameSignals.Instance.onSetCameraState?.Invoke(CameraStates.MiniGame);
        }

        public void RestartLevel()
        {
            CoreGameSignals.Instance.onRestartLevel?.Invoke();
            UISignals.Instance.onClosePanel?.Invoke(UIPanels.FailPanel);
            UISignals.Instance.onOpenPanel?.Invoke(UIPanels.StartPanel);
        }

        private void ReplaceSaveDatasToUI()
        {
            if (!ES3.FileExists()) return;
            OnChangeLevelText(ES3.Load<int>("Level"));
            OnChangeScoreText(ES3.Load<int>("Score"));
        }
    }
}