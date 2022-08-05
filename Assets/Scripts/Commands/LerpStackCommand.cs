using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace Commands
{
    public class LerpStackCommand
    {
        private List<GameObject> _collectables;

        public LerpStackCommand(ref List<GameObject> Collectables)
        {
            _collectables = Collectables;
        }

        public void OnLerpTheStack()
        {
            if (_collectables.Count < 1)
            {
                return;
            }
            for (int i = 1; i <= _collectables.Count-1; i++)
            {
                _collectables[i].transform.DOMoveX(_collectables[i-1].transform.position.x, .1f);
            }

        }
    }
}
