namespace TD.GameMode
{
	using TD.Actor;
	using UnityEngine;

	public class TowerSpawnerGameModeModule : IGameModeModule
	{
		#region Fields
		private TowerActor _towerActorPrefab = null;
		#endregion Fields

		#region Constructor
		public TowerSpawnerGameModeModule(TowerActor towerActorPrefab)
		{
			_towerActorPrefab = towerActorPrefab;
		}
		#endregion Constructor

		#region Methods
		#region IGameModeModule
		public void Delete()
		{
			_towerActorPrefab = null;
		}

		public void Initialize()
		{
		}

		public void Update()
		{
			if (Input.GetMouseButtonDown(0))
			{
				ActorFactory.CreateActor(new TowerActorParameters(_towerActorPrefab.gameObject));
			}
		}
		#endregion IGameModeModule
		#endregion Methods
	}
}
