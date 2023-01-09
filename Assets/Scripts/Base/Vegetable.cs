using UnityEngine;

namespace Base
{
    [CreateAssetMenu(fileName = "Vegetable", menuName = "Custom/Vegetable", order = 0)]
    public class Vegetable : ScriptableObject
    {
        public string label;
        public Sprite[] sprites;
        public int score = 1;
    }
}