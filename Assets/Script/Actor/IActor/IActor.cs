namespace TD.Actor
{
	using UnityEngine;

	public abstract class IActor : MonoBehaviour
	{
		#region Methods
		protected virtual void OnDestroy() { }

		protected virtual void Start() { }

		protected virtual void Update() { }

		public virtual void Initialize(IActorParameters actorParameters) { }
		#endregion Methods
	}

	public abstract class IActor<t_actorParameters> : IActor
		where t_actorParameters : IActorParameters
	{
		#region Fields
		private t_actorParameters _actorParameters = null;
		#endregion Fields

		#region Fields
		public t_actorParameters ActorParameters { get => _actorParameters; }
		#endregion Fields

		#region Methods
		protected override void OnDestroy()
		{
			base.OnDestroy();

			if (_actorParameters != null)
			{
				_actorParameters.Dispose();
				_actorParameters = null;
			}
		}

		public override void Initialize(IActorParameters actorParameters)
		{
			base.Initialize(actorParameters);

			_actorParameters = actorParameters as t_actorParameters;
			if (_actorParameters == null)
			{
				Debug.LogError($"Parameters should be {typeof(t_actorParameters)}");
				return;
			}
		}
		#endregion Methods
	}
}
