using Tutorial;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    public static TimeManager Instance { get; private set; }

    public float Time { get; private set; }
    
    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (!TutorialManager.Instance.Finished)
        {
            return;
        }
        
        Time += UnityEngine.Time.deltaTime;
    }
}