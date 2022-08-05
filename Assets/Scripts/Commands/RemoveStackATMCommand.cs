using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Managers;
using Signals;
using UnityEngine;

namespace Commands
{
    public class RemoveStackATMCommand
    {
        private List<GameObject> _collectables;
        private GameObject _tempHolder;

        public RemoveStackATMCommand(ref List<GameObject> collectables, GameObject tempHolder)
        {
            _collectables = collectables;
            _tempHolder = tempHolder;
        }

        public void OnCollisionWithATM(int index, int value)
        {
            if (index == _collectables.Count -1)
            {
                _collectables[index].transform.SetParent(_tempHolder.transform);

                MoneyPoolManager.Instance.AddMoneyToPool(_collectables[index]);

                ScoreSignals.Instance.onChangeAtmScore?.Invoke(value);

                _collectables.Remove(_collectables[index]);

                _collectables.TrimExcess();
            }

        }
    }
}
