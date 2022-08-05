using System;
using System.Collections.Generic;
using Signals;
using DG.Tweening;
using UnityEngine;

namespace Commands
{
    public class RemoveStackBand
    {
        private List<GameObject> _collectables;
        private GameObject _tempHolder;
        private Transform _transform;

        public RemoveStackBand(ref List<GameObject> collectables, GameObject tempHolder, Transform transform)
        {
            _collectables = collectables;
            _tempHolder = tempHolder;
            _transform = transform;
        }

        public void OnCollisionWithBand(int index, int value)
        {
            if (index == _collectables.Count - 1)
            {
                GameObject temp = _transform.GetChild(index).gameObject;

                temp.gameObject.transform.SetParent(_tempHolder.transform);

                _collectables.Remove(_collectables[index]);

                temp.transform.DOMoveX(-4, 0.4f).OnComplete(() =>
                {
                    temp.SetActive(false);

                    ScoreSignals.Instance.onChangeAtmScore?.Invoke(value);

                });

                return;
            }
        }
    }
}
