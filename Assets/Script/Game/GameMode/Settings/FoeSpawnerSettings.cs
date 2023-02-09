namespace TD.GameMode
{
	using Cinemachine;
	using System;
	using TD.Game;
	using UnityEngine;

	[Serializable]
	public class FoeSpawnerSettings
	{
		#region Fields
		[SerializeField] private FoeSpawnSequenceSettings _foeSpawnSequenceSettings = null;
		[SerializeField] private CinemachineSmoothPath _track = null;
		#endregion Fields

		#region Properties
		public FoeSpawnSequenceSettings FoeSpawnSequenceSettings { get => _foeSpawnSequenceSettings; }
		public CinemachineSmoothPath Track { get => _track; }
		#endregion Properties
	}
}
