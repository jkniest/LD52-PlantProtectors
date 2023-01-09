using System.Collections.Generic;
using UnityEngine;

public class Freezer : MonoBehaviour
{
    public static Freezer Instance { get; private set; }

    private readonly HashSet<FreezeSource> _sources = new();

    public bool Frozen => _sources.Count > 0;

    private void Awake()
    {
        Instance = this;
        Time.timeScale = 1f;
    }

    public void Freeze(FreezeSource source)
    {
        _sources.Add(source);
        Time.timeScale = 0;
    }

    public void UnFreeze(FreezeSource source)
    {
        _sources.Remove(source);
        if (Frozen)
        {
            return;
        }
        
        Time.timeScale = 1;
    }
}