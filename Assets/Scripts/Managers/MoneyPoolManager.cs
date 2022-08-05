using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Managers
{
    public class MoneyPoolManager : MonoBehaviour
    {
        #region Self Variable
        #region Public Variables

        public static MoneyPoolManager Instance;

        #endregion

        #region Serialize Variable

        [SerializeField] GameObject moneyPrefab;//prefab
        [SerializeField] GameObject moneyContainer;
        [SerializeField] List<GameObject> moneyPool = new List<GameObject>();
        [SerializeField] int poolSize;

        #endregion
        #endregion

        private void Awake()
        {
            if (Instance != null && Instance != this) Destroy(gameObject);
            Instance = this;
        }

        private void Start()
        {
            moneyPool = Setup(poolSize);
        }

        public List<GameObject> Setup(int poolSize)
        {
            for (int i = 0; i < poolSize; i++)
            {
                GameObject money = Instantiate(moneyPrefab);
                money.transform.parent = moneyContainer.transform;
                money.SetActive(false);
                moneyPool.Add(money);
            }

            return moneyPool;
        }

        public GameObject GetMoneyFromPool()
        {
            //cheack any in active ball from pool
            foreach (var money in moneyPool)
            {
                if (money.activeInHierarchy == false)
                {
                    money.SetActive(true);
                    return money;
                   
                }
            }
            //if doesnt have extra ball in pool creat new ball and pool
            GameObject newMoney = Instantiate(moneyPrefab);
            newMoney.transform.parent = moneyContainer.transform;
            moneyPool.Add(newMoney);
            return newMoney;
        }

        //add money used in level to pool
        public void AddMoneyToPool(GameObject money)
        {
            if (money.active)
            { 
                money.SetActive(false); 
            }

            moneyPool.Add(money);
        }

        public void HideAllActiveMoney()
        {
            foreach(GameObject money in moneyPool)
            {
                if(money.active)
                {
                    money.SetActive(false);
                    money.transform.parent = moneyContainer.transform;
                }
            }
        }

    }
}