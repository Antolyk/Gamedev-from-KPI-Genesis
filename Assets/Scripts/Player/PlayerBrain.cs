using Core.Services.Updater;
using InputReader;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Assets.Scripts.Player
{
    public class PlayerBrain : IDisposable
    {
        private readonly PlayerEntity _playerEntity;
        private readonly List<IEntityInputSource> _inputSources;

        public PlayerBrain(PlayerEntity playerEntity, List<IEntityInputSource> inputSources)
        {
            _playerEntity = playerEntity;
            _inputSources = inputSources;
            ProjectUpdater.Instance.FixedUpdateCalled += OnFixedUpdate;
        }

        public void Dispose() => ProjectUpdater.Instance.FixedUpdateCalled -= OnFixedUpdate;

        private void OnFixedUpdate()
        {
            _playerEntity.Move(GetHorizontalDirection());
            if (IsJump)           
                _playerEntity.JumpButton();           

            foreach (var inputSource in _inputSources)
                inputSource.ResetOneTimeActions();
        }

        private float GetHorizontalDirection()
        {
            foreach(var inputSource in _inputSources)
            {
                if(inputSource.HorizontalDirection == 0)
                    continue;
                return inputSource.HorizontalDirection;
            }
            return 0;
        }

        private bool IsJump => _inputSources.Any(source => source.Jump);
    }
}
