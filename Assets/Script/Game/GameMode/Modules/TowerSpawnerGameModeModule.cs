namespace TD.GameMode
{
	using TD.Actor;
	using UnityEngine;

	public class TowerSpawnerGameModeModule : IGameModeModule
	{
		#region Fields
		private TowerActor _towerActorPrefab = null;

		private Vector3 _spawnPosition = Vector3.negativeInfinity;
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
				Vector3 mousePosition = Input.mousePosition;
				Vector3 spawnPosition = Camera.main.ScreenToWorldPoint(mousePosition);
				if (Physics.Raycast(spawnPosition, Vector3.down, out RaycastHit raycastHit) == false)
				{
					return;
				}

				SpawnDataParameters spawnDataParameters = new SpawnDataParameters(_towerActorPrefab, raycastHit.point, Quaternion.identity);
				ActorFactory.CreateActor(new TowerActorParameters(spawnDataParameters));
			}
		}
		#endregion IGameModeModule
		#endregion Methods
	}
}
