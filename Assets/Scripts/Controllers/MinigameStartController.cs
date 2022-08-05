using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Managers;
using Signals;
using UnityEngine;

namespace Controllers
{
    public class MinigameStartController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables
    
        [SerializeField] private GameObject fakePlayer;

        #endregion

        #region Private Variables

        #endregion

        #endregion
        

        private void Start()
        {   
            fakePlayer.SetActive(false);
        }

        #region Event Subscription

        private void OnEnable()
        {
            SubscribeEvents();

        }

        private void SubscribeEvents()
        {
            MiniGameSignals.Instance.onStartMiniGame += OnRaiseFakePlayer;
        }
        private void UnsubscribeEvents()
        {
            MiniGameSignals.Instance.onStartMiniGame -= OnRaiseFakePlayer;
        }
    
        private void OnDisable()
        {
            UnsubscribeEvents();
        }
        #endregion

        private IEnumerator StartMiniGame(int score)
        {
            fakePlayer.SetActive(true);
            
            fakePlayer.GetComponent<BoxCollider>().enabled = true;
            
            for (int i = 0; i < score; i++)
            {
                GameObject obj = MoneyPoolManager.Instance.GetMoneyFromPool();
               
                obj.SetActive(true);
                
                obj.transform.position = fakePlayer.transform.position;

                fakePlayer.transform.DOMoveY(.75f, 0.1f).SetRelative(obj.transform)
                 .OnComplete(() =>
                 {   
                     CoreGameSignals.Instance.onLevelSuccessful();
                 });
                yield return new WaitForSeconds(0.05f);

            }
        }
        
        private void OnRaiseFakePlayer(int score)
        {
            StartCoroutine(StartMiniGame(score));
        }
    }
}
