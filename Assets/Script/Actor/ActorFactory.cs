namespace TD.Actor
{
	using UnityEngine;

	public static class ActorFactory
	{
		#region Methods
		public static t_actor CreateActor<t_actor>(IActorParameters actorParameters)
			where t_actor : IActor
		{
			GameObject gameObject = GameObject.Instantiate(actorParameters.ActorPrefab);

			if (gameObject.TryGetComponent(out t_actor actor) == false)
			{
				return null;
			}

			actor.Initialize(actorParameters);

			return actor;
		}

		public static IActor CreateActor(IActorParameters actorParameters)
		{
			return CreateActor<IActor>(actorParameters);
		}
		#endregion Methods
	}
}
