using Cinemachine;
using Managers;
using Enums;
using Signals;
using UnityEngine;

public class CameraManager : MonoBehaviour
{

    #region Self Variables

    #region Serialized Variables

    public CinemachineVirtualCamera virtualCamera;
    public CinemachineVirtualCamera MiniGameCamera;

    public CinemachineStateDrivenCamera stateDrivenCamera;
    
    public Animator animator;
    

    #endregion

    #region Private Variables

    [SerializeField] private Vector3 _initialPosition;

    private CameraStates _currentState = CameraStates.Initial;

    private CinemachineTransposer minigameTransposer;
    
    #endregion

    #endregion
    
    
    
    #region Event Subscriptions

    private void Awake()
    {
        stateDrivenCamera = GetComponent<CinemachineStateDrivenCamera>();
        animator = GetComponent<Animator>();
        minigameTransposer = MiniGameCamera.GetCinemachineComponent<CinemachineTransposer>();
        GetInitialPosition();
    }

    private void OnEnable()
    {
        SubscribeEvents();
    }

    private void SubscribeEvents()
    {
        CoreGameSignals.Instance.onPlay += SetCameraTarget;
        CoreGameSignals.Instance.onSetCameraState += OnSetCameraState;
        CoreGameSignals.Instance.onSetCameraTarget += OnSetCameraTarget;
        CoreGameSignals.Instance.onReset += OnReset;
    }

    private void UnsubscribeEvents()
    {
        CoreGameSignals.Instance.onPlay -= SetCameraTarget;
        CoreGameSignals.Instance.onSetCameraState -= OnSetCameraState;
        CoreGameSignals.Instance.onSetCameraTarget -= OnSetCameraTarget;
        CoreGameSignals.Instance.onReset -= OnReset;
    }

    private void OnDisable()
    {
        UnsubscribeEvents();
    }

    #endregion
    
    private void GetInitialPosition()
    {
        _initialPosition = transform.localPosition;
    }

    private void OnMoveToInitialPosition()
    {
        transform.localPosition = _initialPosition;
    }

    private void SetCameraTarget()
    {
        CoreGameSignals.Instance.onSetCameraTarget?.Invoke();
    }

    private void OnSetCameraTarget()
    {
        var playerManager = FindObjectOfType<PlayerManager>().transform;
        
        virtualCamera.Follow = playerManager;

    }

    private void OnReset()
    {
        virtualCamera.Follow = null;
        virtualCamera.LookAt = null;
        OnMoveToInitialPosition();
    }

    public void OnSetCameraState(CameraStates state)
    {
        if(state == CameraStates.Initial)
        {
            _currentState = CameraStates.Runner;
            animator.Play("RunnerCam");
        }
        else if(state == CameraStates.Runner)
        {
            _currentState = CameraStates.MiniGame;

            var _fakePlayer = GameObject.FindGameObjectWithTag("FakePlayer");
            
            MiniGameCamera.m_Follow = _fakePlayer.transform;
            
            animator.Play("MiniGameCam");
        }
        else if(state == CameraStates.MiniGame)
        {
            _currentState = CameraStates.Initial;
            animator.Play("InitializeCam");
        }
    }
    
}
