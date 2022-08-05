using Enums;
using Data.ValueObject;
using TMPro;
using UnityEngine;

namespace Commands
{
    public class BackGroundTextCommand
    {
        private LetterPathData _data;
        private float _indexMinFactor;

        public BackGroundTextCommand(ref LetterPathData data, float indexMinFactor)
        {
            _data = data;
            _indexMinFactor = indexMinFactor;
        }

        public void SetTextOnCubes(GameObject gO, BackGroundAxis _backgroundAxis)
        {
            
            if (_indexMinFactor > _data.indexMaxFactor)
            {
                return;
            }

            float _value = _indexMinFactor / 10;

            if (_backgroundAxis == BackGroundAxis.Vertical)
            {
                gO.transform.GetChild(0).gameObject.SetActive(true);

                gO.transform.GetChild(0).GetComponentInChildren<TextMeshPro>().text = _value.ToString() + "X";
            }
            else
            {
                gO.transform.GetChild(1).gameObject.SetActive(true);

                gO.transform.GetChild(1).GetComponentInChildren<TextMeshPro>().text = _value.ToString() + "X";
            }

            _indexMinFactor++;
        }
    }
}
