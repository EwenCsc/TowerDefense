namespace TD.Actor
{
	using UnityEngine;

	public static class ActorFactory
	{
		#region Methods
		public static t_actor CreateActor<t_actor>(IActorParameters actorParameters)
			where t_actor : IActor
		{
			SpawnDataParameters spawnDataParameters = actorParameters.BulletPrefab;

			IActor actor = IActor.Instantiate(spawnDataParameters.ActorPrefab, spawnDataParameters.ActorParent);
			actor.transform.localPosition = spawnDataParameters.ActorPosition;
			actor.transform.localRotation = spawnDataParameters.ActorRotation;

			actor.Initialize(actorParameters);

			if (actor is t_actor == false)
			{
				Debug.LogError($"Actor is not {typeof(t_actor)}. Actor is {actor.GetType()}");
			}

			return actor as t_actor;
		}

		public static IActor CreateActor(IActorParameters actorParameters)
		{
			return CreateActor<IActor>(actorParameters);
		}
		#endregion Methods
	}
}
