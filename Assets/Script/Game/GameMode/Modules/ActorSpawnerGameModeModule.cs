namespace TD.GameMode
{
	using Cinemachine;
	using TD.Actor;
	using TD.Game;
	using UnityEngine;

	public class ActorSpawnerGameModeModule : IGameModeModule
	{
		#region Fields
		private FoeSpawnerSettings _foeSpawnerSettings = null;
		private FoeSpawnSequence _foeSpawnSequence = null;
		#endregion Fields

		#region Constructor

		public ActorSpawnerGameModeModule(FoeSpawnerSettings foeSpawnerSettings)
		{
			_foeSpawnerSettings = foeSpawnerSettings;
			_foeSpawnSequence = foeSpawnerSettings.FoeSpawnSequenceSettings.CreateFoeSpawnSequence();
			_foeSpawnSequence.FoeSpawnRequested += OnFoeSpawnRequested;
		}
		#endregion Constructor

		#region Methods
		#region IGameModeModule
		public void Delete()
		{
			_foeSpawnerSettings = null;

			if (_foeSpawnSequence != null)
			{
				_foeSpawnSequence.FoeSpawnRequested -= OnFoeSpawnRequested;
				_foeSpawnSequence.Delete();
				_foeSpawnSequence = null;
			}
		}

		public void Initialize() { }

		public void Update()
		{
			_foeSpawnSequence.Update(Time.deltaTime);
		}
		#endregion IGameModeModule

		#region Callbacks
		private void OnFoeSpawnRequested(Actor actorPrefab)
		{
			Actor actor = GameObject.Instantiate(actorPrefab);

			actor.Init(_foeSpawnerSettings.Track, 0.0f, CinemachinePathBase.PositionUnits.Normalized);
		}
		#endregion Callbacks
		#endregion Methods
	}
}