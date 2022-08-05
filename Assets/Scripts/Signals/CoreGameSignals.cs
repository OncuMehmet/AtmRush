using System;
using Enums;
using Extentions;
using Keys;
using UnityEngine.Events;

namespace Signals
{
    public class CoreGameSignals : MonoSingleton<CoreGameSignals>
    {
        public UnityAction<GameStates> onChangeGameState = delegate { };
        public UnityAction onLevelInitialize = delegate { };
        public UnityAction onClearActiveLevel = delegate { };
        public UnityAction onLevelFailed = delegate { };
        public UnityAction onLevelSuccessful = delegate { };
        public UnityAction onNextLevel = delegate { };
        public UnityAction onRestartLevel = delegate { };
        public UnityAction onPlay = delegate { };
        public UnityAction onReset = delegate { };
        public UnityAction onSetCameraTarget = delegate { };
        public UnityAction<CameraStates> onSetCameraState = delegate { };

        public Func<int> onGetLevelID = delegate { return 0; };

        //save references
        public  Action<SaveStates, int> onSaveGameData = delegate { };
        public  Func<SaveStates, int> onLoadGameData = delegate { return 0; };

        public Action onAnimateBandTile = delegate { };

        protected override void Awake()
        {
            base.Awake();
        }
    }
}