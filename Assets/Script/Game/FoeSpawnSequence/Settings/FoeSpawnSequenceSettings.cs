namespace TD.Game
{
	using System.Collections.Generic;
	using UnityEngine;

	[CreateAssetMenu(fileName = "FoeSpawnSequenceSettings", menuName = "ScriptableObjects/FoeSpawnSequenceSettings")]
	public class FoeSpawnSequenceSettings : ScriptableObject
	{
		#region Fields
		[SerializeField] private List<FoeWaveSettings> _foeWavesSettings = null;
		#endregion Fields

		#region Properties
		public List<FoeWaveSettings> FoeWavesSettings { get => _foeWavesSettings; }
		#endregion Properties

		#region Methods
		public FoeSpawnSequence CreateFoeSpawnSequence()
		{
			return new FoeSpawnSequence(_foeWavesSettings);
		}
		#endregion Methods
	}

#region Inner Class
	#endregion Inner Class
}