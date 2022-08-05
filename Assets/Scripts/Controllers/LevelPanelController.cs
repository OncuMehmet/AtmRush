using TMPro;
using UnityEngine;

namespace Controllers
{
    public class LevelPanelController : MonoBehaviour
    {
        #region Self Variables

        #region Serialized Variables

        [SerializeField] private TextMeshProUGUI levelText;

        [SerializeField] private TMP_Text score;
        

        #endregion

        #endregion


        public void SetLevelText(int value)
        {
            levelText.text = "level "+ value.ToString();
        }

        public void SetScoreText(int value)
        {
            score.text = value.ToString();
        }

    }
}