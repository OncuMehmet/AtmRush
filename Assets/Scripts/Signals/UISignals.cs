using Enums;
using System;
using Extentions;
using UnityEngine.Events;

namespace Signals
{
    public class UISignals : MonoSingleton<UISignals>
    {
        public UnityAction<UIPanels> onOpenPanel;
        public UnityAction<UIPanels> onClosePanel;
        public UnityAction<int> onSetLevelText;
        //score and level signals
        public Action<int> onChangeLevelText;
        public Action<int> onChangeScoreText;

        protected override void Awake()
        {
            base.Awake();
            
        }
    }
    
}