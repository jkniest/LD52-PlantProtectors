using UnityEngine;
using UnityEngine.UI;

namespace Ui
{
    [RequireComponent(typeof(Image))]
    public class ButtonHover : MonoBehaviour
    {
        private Image _image;

        private void Awake()
        {
            _image = GetComponent<Image>();
        }

        public void OnHover(bool hovering)
        {
            _image.color = hovering ? new Color(.8f, .8f, .8f) : Color.white;
        }
    }
}