using UnityEngine;

namespace Tutorial.Steps
{
    public abstract class BaseTutorialStep : MonoBehaviour
    {
        public string content;
        public bool canBeSkipped;

        public virtual void OnEnter()
        {
        }

        public virtual bool OnCondition(TutorialCondition condition)
        {
            return false;
        }
    }
}