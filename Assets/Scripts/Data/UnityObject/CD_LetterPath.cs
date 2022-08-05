using Data.ValueObject;
using UnityEngine;

namespace Data.UnityObject
{
    [CreateAssetMenu(fileName = "CD_LetterPath", menuName = "ATMRush/CD_LetterPath", order = 0)]
    public class CD_LetterPath : ScriptableObject
    {
        public LetterPathData LetterPathData;
    }
}