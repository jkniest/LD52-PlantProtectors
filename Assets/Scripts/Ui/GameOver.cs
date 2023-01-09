using GameJolt.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class GameOver : MonoBehaviour
    {
        private const int GamejoltTableID = 787559;

        public TMP_InputField nameInput;
        public GameObject submitForm;

        public void SubmitScore()
        {
            if (nameInput.text.Trim() == "")
            {
                return;
            }

            submitForm.SetActive(false);
            
            var minutes = (int)(TimeManager.Instance.Time / 60);
            var seconds = (int)(TimeManager.Instance.Time % 60);

            var scoreText = minutes + ":" + seconds.ToString("D2");

            GameJolt.API.Scores.Add(
                Mathf.RoundToInt(TimeManager.Instance.Time),
                scoreText,
                nameInput.text,
                GamejoltTableID,
                null,
                (bool success) =>
                {
                    GameJoltUI.Instance.ShowLeaderboards((_) => {}, GamejoltTableID);
                });
        }

        public void Retry()
        {
            SceneManager.LoadScene("Menu");
        }
    }
}