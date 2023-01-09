using UnityEngine;

namespace Entities
{
    public class TutorialEnemy : Enemy
    {
        private void Update()
        {
            if (Freezer.Instance.Frozen)
            {
                return;
            }

            if (Mathf.Abs(transform.position.z - Base.Base.Instance.transform.position.z) <= 5f)
            {
                return;
            }
            
            MoveForward();
        }
    }
}