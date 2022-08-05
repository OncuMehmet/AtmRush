using System;
using System.Collections.Generic;
using Commands;
using UnityEngine;
namespace Keys
{
    public class AddStackKeyParams
    {
        public ShakeStackCommand _shakeStackCommand;
        public List<GameObject> _collectables;
        public Transform _transform;
        public MonoBehaviour _monoBehaviour;

        //ctor
        public AddStackKeyParams(ref List<GameObject> collectables, Transform transform, MonoBehaviour monoBehaviour, ref ShakeStackCommand shakeStackCommand)
        {
            _collectables = collectables;
            _transform = transform;
            _monoBehaviour = monoBehaviour;
            _shakeStackCommand = shakeStackCommand;
        }
        
    }
}
