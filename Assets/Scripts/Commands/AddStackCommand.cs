using System;
using System.Collections.Generic;
using Keys;
using UnityEngine;

namespace Commands
{
    public class AddStackCommand
    {
        private AddStackKeyParams _params;

        public AddStackCommand(AddStackKeyParams param)
        {
            _params = param;
        }

        public void OnAddOnStack(GameObject gO)
        {
            
            gO.transform.SetParent(_params._transform);
            
            if (_params._collectables.Count < 1)
            {
                gO.transform.position = _params._transform.position + Vector3.forward;
                
                _params._collectables.Add(gO);
                
                return;
            }

            gO.transform.position =
                _params._collectables[_params._collectables.Count - 1].transform.position + Vector3.forward;
            
            _params._collectables.Add(gO);

            _params._monoBehaviour.StartCoroutine(_params._shakeStackCommand.HandleShakeOfStack());

        }
    }
}
