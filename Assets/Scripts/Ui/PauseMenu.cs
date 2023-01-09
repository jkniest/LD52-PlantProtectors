using UnityEngine;

namespace Ui
{
    public class PauseMenu : MonoBehaviour
    {
         public GameObject pauseScreen;
        
        public void Update()
        {
            if (!Input.GetKeyDown(KeyCode.P)
                && !Input.GetKeyDown(KeyCode.Backspace) &&
                !Input.GetKeyDown(KeyCode.Escape))
            {
                return;
            }

            TogglePause();   
        }

        public void TogglePause()
        {
            if (pauseScreen.activeSelf)
            {
                pauseScreen.SetActive(false);
                Freezer.Instance.UnFreeze(FreezeSource.PauseMenu);
                return;
            }
            
            pauseScreen.SetActive(true);
            Freezer.Instance.Freeze(FreezeSource.PauseMenu);
        }
    }
}