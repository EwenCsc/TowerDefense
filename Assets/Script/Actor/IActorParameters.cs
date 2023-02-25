namespace TD.Actor
{
	using System;
	using UnityEngine;

	public abstract class IActorParameters : IDisposable
	{
		#region Fields
		private GameObject _actorPrefab = null;
		#endregion Fields

		#region Properties
		public GameObject ActorPrefab { get => _actorPrefab; }
		#endregion Properties

		#region Constructor
		protected IActorParameters(GameObject actorPrefab)
		{
			_actorPrefab = actorPrefab;
		}
		#endregion Constructor

		#region Methods
		public virtual void Dispose()
		{
			_actorPrefab = null;
		}
		#endregion Methods
	}
}