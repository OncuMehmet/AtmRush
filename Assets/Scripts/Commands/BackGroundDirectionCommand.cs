using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using Enums;

namespace Commands
{
    public class BackGroundDirectionCommand
    {

        private Vector3 _forwardStack;
        private Vector3 _upwardsStack;
        private List<GameObject> _cubeList;

        public BackGroundDirectionCommand(ref Vector3 forwardStack , ref Vector3 upwardsStack, ref List<GameObject> cubeList)
        {
            _forwardStack = forwardStack;
            _upwardsStack = upwardsStack;
            _cubeList = cubeList;
        }

        public Vector3 SetStackDirection(BackGroundAxis _backgroundAxis, int index)
        {
            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                return _forwardStack = _cubeList[index].transform.localScale.y * Vector3.up;
            }
            else
            {
                return _upwardsStack = _cubeList[index].transform.localScale.z * Vector3.forward;
            }
        }
    }
}
