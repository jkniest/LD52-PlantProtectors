using Tutorial.Steps;
using Ui;
using UnityEngine;

namespace Tutorial
{
    public class TutorialManager : MonoBehaviour
    {
        public static TutorialManager Instance { get; private set; }

        public BaseTutorialStep[] steps;
        public GameObject tutorialUi;
        public GameObject[] enableAfterTutorial;

        public bool Finished { get; private set; } = false;

        private int _currentStep;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            PrepareStep(0);
        }

        private void PrepareStep(int step)
        {
            if (step >= steps.Length)
            {
                Finished = true;

                tutorialUi.SetActive(false);
                
                foreach (var obj in enableAfterTutorial)
                {
                    obj.SetActive(true);
                }
                
                EnemySpawner.Instance.spawnerActive = true;
                EnemySpawner.Instance.bossesActive = true;
                
                return;
            }
            
            _currentStep = step;
            steps[_currentStep].OnEnter();

            TutorialDialog.Instance.SetContent(
                dialog: steps[_currentStep].content,
                canBeContinued: steps[_currentStep].canBeSkipped,
                onContinue: () => PrepareStep(_currentStep + 1)
            );
        }

        public void OnCondition(TutorialCondition condition)
        {
            if (steps[_currentStep].OnCondition(condition))
            {
                PrepareStep(_currentStep + 1);
            }
        }
    }
}