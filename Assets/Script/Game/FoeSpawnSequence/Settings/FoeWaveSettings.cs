namespace TD.Game
{
	using System;
	using UnityEngine;
	using TD.Actor;

	[Serializable]
	public class FoeWaveSettings
	{
		#region Fields
		[SerializeField] private FoeActor _actorPrefab = null;
		[SerializeField] private uint _count = 0;
		[SerializeField] private float _delay = 0.0f;
		#endregion Fields

		#region Properties
		public FoeActor ActorPrefab { get => _actorPrefab; }
		public uint Count { get => _count; }
		public float Delay { get => _delay; }
		#endregion Properties
	}
}