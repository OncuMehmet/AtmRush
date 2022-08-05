using System.Collections;
using System.Collections.Generic;
using TMPro;
using Managers;
using UnityEngine;

namespace Controllers
{
    public class PlayerScoreController : MonoBehaviour
    {
        #region Self Variables
        #region Serialize Variable

        [SerializeField] PlayerManager playerManager;
        [SerializeField] private TMP_Text playerScoreText;

        #endregion

        #region Private Variables

        public int _playerScore;
        
        #endregion
        #endregion

        public void ChangePlayerScore(int _score)
        { 
            _playerScore += _score;
            if (_playerScore < 0)
            {
                _playerScore = 0;
            }
            playerScoreText.text = _playerScore.ToString();  
        }

    }
}