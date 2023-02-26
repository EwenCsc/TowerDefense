namespace TD.Actor
{
	using UnityEngine;

	public sealed class SpawnDataParameters
	{
		#region Fields
		private IActor _actorPrefab = null;

		private Vector3 _actorPosition = Vector3.zero;
		private Quaternion _actorRotation = Quaternion.identity;
		private Transform _actorParent = null;
		#endregion Fields

		#region Properties
		public IActor ActorPrefab { get => _actorPrefab; }

		public Vector3 ActorPosition { get => _actorPosition; }
		public Quaternion ActorRotation { get => _actorRotation; }
		public Transform ActorParent { get => _actorParent; }
		#endregion Properties

		#region Constructor
		public SpawnDataParameters(IActor actorPrefab)
		{
			_actorPrefab = actorPrefab;
			_actorPosition = Vector3.zero;
			_actorRotation = Quaternion.identity;
			_actorParent = null;
		}

		public SpawnDataParameters(IActor actorPrefab, Vector3 actorPosition, Quaternion actorRotation)
		{
			_actorPrefab = actorPrefab;
			_actorPosition = actorPosition;
			_actorRotation = actorRotation;
			_actorParent = null;
		}

		public SpawnDataParameters(IActor actorPrefab, Transform actorParent)
		{
			_actorPrefab = actorPrefab;
			_actorPosition = Vector3.zero;
			_actorRotation = Quaternion.identity;
			_actorParent = actorParent;
		}

		public SpawnDataParameters(IActor actorPrefab, Vector3 actorPosition, Quaternion actorRotation, Transform actorParent)
		{
			_actorPrefab = actorPrefab;
			_actorPosition = actorPosition;
			_actorRotation = actorRotation;
			_actorParent = actorParent;
		}
		#endregion Constructor
	}
}