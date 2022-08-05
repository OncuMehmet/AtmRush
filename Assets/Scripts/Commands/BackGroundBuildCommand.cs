using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Enums;
using UnityEngine;

namespace Commands
{
    public class BackGroundBuildCommand
    {
        private BackGroundTextCommand _backGroundTextCommand;
        private BackGroundSetColliderCommand _backGroundSetColliderCommand;
        private BackGroundDirectionCommand _backGroundDirectionCommand;
        private List<GameObject> _cubes;
        private Transform _targerTransform;

        public BackGroundBuildCommand(ref BackGroundTextCommand backGroundTextCommand, ref BackGroundSetColliderCommand backGroundSetColliderCommand
,ref BackGroundDirectionCommand backGroundDirectionCommand, ref List<GameObject> cubes, Transform targetTransform)
        {
            _backGroundTextCommand = backGroundTextCommand;
            _backGroundSetColliderCommand = backGroundSetColliderCommand;
            _backGroundDirectionCommand = backGroundDirectionCommand;
            _cubes = cubes;
            _targerTransform = targetTransform;
        }

        public void SetBuild(BackGroundAxis _backgroundAxis)
        {
            for (int i = 0; i < _cubes.Count; i++)
            {
                _backGroundTextCommand.SetTextOnCubes(_cubes[i].gameObject, _backgroundAxis);

                _backGroundSetColliderCommand.SetTowerCollider(_backgroundAxis, _cubes[i]);

                if (i == 0)
                {
                    _cubes[i].transform.position = _targerTransform.position;
                }
                else
                {

                    _cubes[i].transform.position = _cubes[i - 1].transform.position + _backGroundDirectionCommand.SetStackDirection(_backgroundAxis, i);
                }
            }
        }
    }
}
