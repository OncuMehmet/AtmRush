using System;
using UnityEditor;
using Extentions;
using UnityEngine;
using UnityEngine.Events;

namespace Signals
{
    public class ScoreSignals : MonoSingleton<ScoreSignals>
    {
        public UnityAction<int> onChangeAtmScore = delegate { };
        public UnityAction<int> onChangePlayerScore = delegate { };

        protected override void Awake()
        {
            base.Awake();
        }
    }
}
