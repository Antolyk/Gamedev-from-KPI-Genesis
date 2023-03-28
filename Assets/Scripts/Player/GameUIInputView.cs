using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Player
{
    class GameUIInputView : MonoBehaviour, IEntityInputSource
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private Button _jumpButton;

        public float HorizontalDirection => _joystick.Horizontal;
        public bool Jump { get; private set; }

        private void Awake()
        {
            _jumpButton.onClick.AddListener(()=> Jump = true);
        }

        private void OnDestroy()
        {
            _jumpButton.onClick.RemoveAllListeners();
        }

        public void ResetOneTimeActions()
        {
            Jump = false;
        }
    }
}
