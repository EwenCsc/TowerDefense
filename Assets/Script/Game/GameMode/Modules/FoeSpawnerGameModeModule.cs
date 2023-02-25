namespace TD.GameMode
{
	using Cinemachine;
	using TD.Actor;
	using TD.Game;
	using UnityEngine;

	public class FoeSpawnerGameModeModule : IGameModeModule
	{
		#region Fields
		private FoeSpawnerSettings _foeSpawnerSettings = null;
		private FoeSpawnSequence _foeSpawnSequence = null;
		#endregion Fields

		#region Constructor
		public FoeSpawnerGameModeModule(FoeSpawnerSettings foeSpawnerSettings)
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
		private void OnFoeSpawnRequested(FoeActor actorPrefab)
		{
			FoeActorParameters parameters = new FoeActorParameters(actorPrefab.gameObject, _foeSpawnerSettings.Track, 0.0f, CinemachinePathBase.PositionUnits.Normalized);
			ActorFactory.CreateActor(parameters);
		}
		#endregion Callbacks
		#endregion Methods
	}
}