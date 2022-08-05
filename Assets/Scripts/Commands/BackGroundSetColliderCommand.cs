using Data.ValueObject;
using Enums;
using UnityEngine;


namespace Commands
{
    public class BackGroundSetColliderCommand
    {
        private LetterPathData _data;

        public BackGroundSetColliderCommand(ref LetterPathData data) => _data = data;

        public void SetTowerCollider(BackGroundAxis _backgroundAxis, GameObject gO)
        {
            BoxCollider cubeCollider = gO.GetComponent<BoxCollider>();

            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                cubeCollider.center = _data.cubeColliderCenter;
                cubeCollider.size = _data.cubeColliderSize;
            }
            else
            {
                cubeCollider.center = _data.cubeColliderCenter;
                cubeCollider.size = _data.cubeColliderSize;
            }
        }
    }
}
