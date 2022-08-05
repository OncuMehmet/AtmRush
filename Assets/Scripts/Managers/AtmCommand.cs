using Signals;
using TMPro;
using UnityEngine;

namespace Controllers
{
    public class AtmCommand : MonoBehaviour
    {
        #region Self Variables
        #region Serialize
        [SerializeField] private TMP_Text _atmScoreText;
        private int _atmScore;
        #endregion
        #endregion

        #region Subscriptions

        private void OnEnable()
        {
            Subscribe();
        }

        private void OnDisable()
        {
            UnSubscribe();
        }

        private void Subscribe()
        {
            ScoreSignals.Instance.onChangeAtmScore += OnChangeAtmScore;
        }
        private void UnSubscribe()
        {
            ScoreSignals.Instance.onChangeAtmScore -= OnChangeAtmScore;
        }
        #endregion

        private void OnChangeAtmScore(int moneyValue)
        {
            _atmScore += moneyValue;
            _atmScoreText.text = _atmScore.ToString();
        }
    }
}