using UnityEngine;

namespace Tutorial.Steps
{
    public class ControlYourGunStep : BaseTutorialStep
    {
        public GameObject playerGun;

        public override void OnEnter()
        {
            playerGun.SetActive(true);
        }
    }
}