using UnityEngine;

namespace Commands
{
    public class BackGroundColorCommand
    {
        float _colorValue;

        public BackGroundColorCommand(float colorValue) => _colorValue = colorValue;

        public void SetColor(GameObject gO)
        {
            _colorValue += 0.05f;

            if (_colorValue >= 0.9f)
            {
                _colorValue = 0;
            }

            gO.GetComponent<Renderer>().material.color = Color.HSVToRGB(_colorValue, 1, 1);
        }
    }
}
