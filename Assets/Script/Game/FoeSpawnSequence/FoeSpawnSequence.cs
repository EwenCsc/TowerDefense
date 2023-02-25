namespace TD.Game
{
	using System;
	using System.Collections.Generic;
	using TD.Actor;
	using UnityEngine;

	public class FoeSpawnSequence
	{
		#region Fields
		private List<FoeWaveSettings> _foeWavesSettings = null;

		private FoeWaveSettings _currentFoeWaveSettings = null;
		private int _currentFoeWaveIndex = 0;

		private float _cooldown = 0.0f;
		private int _currentSequenceStep = 0;
		#endregion Fields

		#region Events
		private Action<FoeActor> _foeSpawnRequestedEvent = null;
		public event Action<FoeActor> FoeSpawnRequested
		{
			add { _foeSpawnRequestedEvent -= value; _foeSpawnRequestedEvent += value; }
			remove { _foeSpawnRequestedEvent -= value; }
		}
		#endregion Events

		#region Constructor
		public FoeSpawnSequence(List<FoeWaveSettings> foeWavesSettings)
		{
			_foeWavesSettings = foeWavesSettings;
		}
		#endregion Constructor

		#region Methods
		public void Delete()
		{
			_foeWavesSettings = null;
			_currentFoeWaveSettings = null;

			_foeSpawnRequestedEvent = null;
		}

		public void Update(float deltaTime)
		{
			if (_currentFoeWaveSettings == null && TryGatherNewWaveSettings(out _currentFoeWaveSettings) == false)
			{
				return;
			}

			_cooldown += deltaTime;
			float delay = _currentFoeWaveSettings.Delay;

			if (_cooldown < delay)
			{
				return;
			}

			_cooldown -= delay;

			_foeSpawnRequestedEvent?.Invoke(_currentFoeWaveSettings.ActorPrefab);

			_currentSequenceStep++;
			if (_currentSequenceStep == _currentFoeWaveSettings.Count)
			{
				_currentFoeWaveSettings = null;
				_currentSequenceStep = 0;
			}
		}

		private bool TryGatherNewWaveSettings(out FoeWaveSettings foeWaveSettings)
		{
			foeWaveSettings = null;

			if (_foeWavesSettings == null || _foeWavesSettings.Count <= 0)
			{
				Debug.LogError("_foeWavesSettings not initialized.");
				return false;
			}

			if (_currentFoeWaveIndex == _foeWavesSettings.Count)
			{
				return false;
			}

			foeWaveSettings = _foeWavesSettings[_currentFoeWaveIndex];
			++_currentFoeWaveIndex;

			return true;
		}
		#endregion Methods
	}
}