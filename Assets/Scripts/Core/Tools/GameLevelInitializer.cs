using Assets.Scripts.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Core.Tools
{
    public class GameLevelInitializer : MonoBehaviour
    {
        [SerializeField] private PlayerEntity _playerEntity;
        [SerializeField] private GameUIInputView _gameUIInputView;

        private ExternalDevicesInputReader _externalDevicesInput;
        private PlayerBrain _playerBrain;

        private bool _onPause;

        private void Awake()
        {
            _externalDevicesInput = new ExternalDevicesInputReader();
            _playerBrain = new PlayerBrain(_playerEntity, new List<IEntityInputSource>
            {
                _gameUIInputView,
                _externalDevicesInput
            });
        }

        private void Update()
        {
            if (_onPause)
            {
                return;
            }
            _externalDevicesInput.OnUpdate();
        }
        private void FixedUpdate()
        {
            if (_onPause)
            {
                return;
            }
            _playerBrain.OnFixedUpdate();
        }
    }
}
