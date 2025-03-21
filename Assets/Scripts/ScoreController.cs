using System;
using UnityEngine;
/// <summary>
/// check if all enemies killed or not
/// </summary>
    public class ScoreController : Element
    {
        [SerializeField] int score;
        public Action OnWin;
        public void setScore(int score)
        {
            this.score = score;
        }

        public void DecreaseScore()
        {
            score--;
            if (score <= 0)
            {
                TopShooterApplication.topShooterModel.isRunning = false;
                OnWin?.Invoke();
            }
        }
    }