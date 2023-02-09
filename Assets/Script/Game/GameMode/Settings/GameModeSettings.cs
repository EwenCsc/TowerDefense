namespace TD.GameMode
{
	using System;
	using System.Collections.Generic;
	using UnityEngine;

	[Serializable]
	public class GameModeSettings
	{
		#region Fields
		[SerializeField] private List<FoeSpawnerSettings> _foeSpawnersSettings = null;
		#endregion Fields

		#region Properties
		public List<FoeSpawnerSettings> FoeSpawnersSettings { get => _foeSpawnersSettings; }
		#endregion Properties
	}
}
