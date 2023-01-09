using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ui
{
    public class MainMenu : MonoBehaviour
    {
        public void PlayGame()
        {
            SceneManager.LoadScene("Game");
        }
    }
}