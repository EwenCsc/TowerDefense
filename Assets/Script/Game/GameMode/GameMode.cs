namespace TD.GameMode
{
	using System.Collections.Generic;
	using TD.Actor;
	using UnityEngine;
	using UnityEngine.Assertions;

	public class GameMode : MonoBehaviour
	{
		#region Fields
		[SerializeField] private GameModeSettings _gameModeSettings = null;
		[SerializeField] private TowerActor _towerPrefab = null;

		private List<IGameModeModule> _modules = null;
		#endregion Fields

		#region Methods
		private void OnDestroy()
		{
			DeleteModules();
		}

		private void Start()
		{
			BuildModules();
		}

		private void Update()
		{
			UpdateModules();
		}

		private void BuildModules()
		{
			_modules = new List<IGameModeModule>();

			List<FoeSpawnerSettings> foeSpawnersSettings = _gameModeSettings.FoeSpawnersSettings;
			foreach (FoeSpawnerSettings foeSpawnerSettings in foeSpawnersSettings)
			{
				_modules.Add(new FoeSpawnerGameModeModule(foeSpawnerSettings));
			}

			_modules.Add(new TowerSpawnerGameModeModule(_towerPrefab));

			InitializeModules();
		}

		private void InitializeModules()
		{
			Assert.IsNotNull(_modules, "Modules is null.");

			foreach (IGameModeModule gameModeModule in _modules)
			{
				gameModeModule.Initialize();
			}
		}

		private void UpdateModules()
		{
			if (_modules == null || _modules.Count == 0)
			{
				return;
			}

			foreach (IGameModeModule gameModeModule in _modules)
			{
				gameModeModule.Update();
			}
		}

		private void DeleteModules()
		{
			if (_modules == null)
			{
				return;
			}

			foreach (IGameModeModule gameModeModule in _modules)
			{
				gameModeModule.Delete();
			}

			_modules.Clear();
			_modules = null;
		}
		#endregion Methods
	}
}