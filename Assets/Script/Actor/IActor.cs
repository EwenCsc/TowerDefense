namespace TD.Actor
{
	using System;
	using UnityEngine;

	public abstract class IActor : MonoBehaviour
	{
		#region Methods
		protected virtual void OnDestroy() { }

		protected virtual void Start() { }

		protected virtual void Update() { }

		public abstract void Initialize(IActorParameters actorParameters);
		#endregion Methods
	}
}
