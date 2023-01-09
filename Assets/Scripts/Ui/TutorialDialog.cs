using System;
using TMPro;
using UnityEngine;

namespace Ui
{
    public class TutorialDialog : MonoBehaviour
    {
        public static TutorialDialog Instance { get; private set; }

        public TextMeshProUGUI content;
        public GameObject canContinueIcon;

        private Action _onContinue;
        private bool _canContinue;

        private void Awake()
        {
            Instance = this;
        }

        public void SetContent(string dialog, bool canBeContinued = false, Action onContinue = null)
        {
            content.text = dialog;
            canContinueIcon.SetActive(canBeContinued);
            _onContinue = onContinue;
            _canContinue = canBeContinued;
        }

        private void Update()
        {
            if (!_canContinue || !Input.GetKeyDown(KeyCode.Space))
            {
                return;
            }
            
            _onContinue?.Invoke();
        }
    }
}