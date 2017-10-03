using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class UIControl : MonoBehaviour
    {
        [SerializeField]
        private Text startText;

        [SerializeField]
        private GameObject startMenuPanel;
        [SerializeField]
        private GameObject tapToStartPanel;
        [SerializeField]
        private GameObject autoplayPanel;
        [SerializeField]
        private GameObject gameOverPanel;
        [SerializeField]
        private GameObject winPanel;

        [SerializeField]
        private GameObject scorePanel;
        [SerializeField]
        private Text scoreText;
        [SerializeField]
        private Text multiplierText;

        // Use this for initialization
        void Start()
        {

        }

        public void HideStartText()
        {
            startText.enabled = false;
        }

        public void EnableStartText()
        {
            startText.enabled = true;
        }

        public void ToggleTapToStartPanel(bool enabled)
        {
            tapToStartPanel.SetActive(enabled);
        }

        public void ToggleStartMenuPanel(bool enabled)
        {
            startMenuPanel.SetActive(enabled);
        }

        public void ToggleGameOverPanel(bool enabled)
        {
            gameOverPanel.SetActive(enabled);
        }

        public void ToggleWinPanel(bool enabled)
        {
            winPanel.SetActive(enabled);
        }

        public void ToggleAutoPlayPanel(bool enabled)
        {
            autoplayPanel.SetActive(true);
        }

        public void ToggleScorePanel(bool enabled)
        {
            scorePanel.SetActive(true);
        }

        public void SetScoreText(int score)
        {
            scoreText.text = "" + score;
        }

        public void SetMultiplierText(int score)
        {
            multiplierText.text = "x" + score;
        }
    }
}
