using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Blockbreaker
{
    /// <summary>
    /// 
    /// </summary>
    public class GameManager : GenericSingleton<GameManager>
    {
        [SerializeField]
        private LevelManager levelManager;
        [SerializeField]
        private Ball ball;
        public Ball Ball { get { return ball; } }

        [SerializeField]
        private ParticleControl particleControl;
        public ParticleControl ParticleControl { get { return particleControl; } }

        [SerializeField]
        private UIControl uiControl;
        public UIControl UIControl { get { return uiControl; } }

        public bool waitingForInput = true;

        private PlayerInput playerInput;

        private int score = 0;
        public int Score { get{ return score; } }

        private int scoreMultiplier = 0;

        //public bool WaitingForInput { get { return waitingForInput; } }

        /// <summary>
        /// Use this for initialization
        /// </summary>
        void Start()
        {
            CheckForNullReferences();
        }

        /// <summary>
        /// 
        /// </summary>
        void CheckForNullReferences()
        {
            if (levelManager == null)
            {
                levelManager = FindObjectOfType<LevelManager>();
            }
            if (ball == null)
            {
                ball = FindObjectOfType<Ball>();
            }
            if (ParticleControl == null)
            {
                particleControl = FindObjectOfType<ParticleControl>();
            }
            if (uiControl == null)
            {
                uiControl = FindObjectOfType<UIControl>();
            }
            if (playerInput == null)
            {
                playerInput = FindObjectOfType<PlayerInput>();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void BrickDestroyed()
        {
            if (Brick.breakableCount <= 0)
            {
                LevelComplete();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="scoreToAdd"></param>
        public void AddToScore(int scoreToAdd)
        {
            //TODO add in score multiplier
            if (scoreMultiplier > 0)
                score += scoreToAdd * scoreMultiplier;
            else
                score += scoreToAdd;
            //update score
            uiControl.SetScoreText(score);
        }

        /// <summary>
        /// 
        /// </summary>
        public void IncreaseScoreMultiplier()
        {
            scoreMultiplier++;
            uiControl.SetMultiplierText(scoreMultiplier);
        }

        /// <summary>
        /// 
        /// </summary>
        public void ResetScoreMultiplier()
        {
            scoreMultiplier = 0;
            uiControl.SetMultiplierText(scoreMultiplier);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="win"></param>
        public void GameOver(bool win)
        {
            //disable player input
            playerInput.enabled = false;
            uiControl.ToggleAutoPlayPanel(false);
            if (win)
            {
                //update save score
                //Do game over lost things
                
                uiControl.ToggleWinPanel(true);
                return;
            }

            //update save score
            //Display game over 
            uiControl.ToggleGameOverPanel(true);
            //Do game over lost things
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        public void LoadScene(string name)
        {
            Debug.Log("New Level load: " + name);
            SceneManager.LoadScene(name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="index"></param>
        public void LoadScene(int index)
        {
            SceneManager.LoadScene(index);
        }

        /// <summary>
        /// 
        /// </summary>
        public void QuitRequest()
        {
            Debug.Log("Quit requested");
            Application.Quit();
        }

        /// <summary>
        /// 
        /// </summary>
        public void LevelComplete()
        {

            // TODO stop ball movement
            ball.ResetBall();
            //show wave complete and score

            // wait a while then load next level
            levelManager.LoadNextLevel();

            waitingForInput = true;

            UIControl.ToggleTapToStartPanel(true);
        }
    }
}
