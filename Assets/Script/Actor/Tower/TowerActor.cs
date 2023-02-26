using UnityEngine;

namespace TD.Actor
{
	public class TowerActor : IActor<TowerActorParameters>
	{
		#region Fields
		[SerializeField] private float _cooldown = 0.0f;
		[SerializeField] private BulletActor _bulletActorPrefab = null;

		private float _currentCooldown = 0.0f;
		#endregion Fields

		#region Methods
		protected override void Update()
		{
			base.Update();

			_currentCooldown += Time.deltaTime;
			if (_currentCooldown < _cooldown)
			{
				return;
			}

			_currentCooldown -= _cooldown;

			SpawnDataParameters spawnDataParameters = new SpawnDataParameters(_bulletActorPrefab, transform.position + Vector3.forward * 2.0f, Quaternion.identity);
			BulletActorParameters actorParameters = new BulletActorParameters(spawnDataParameters);
			ActorFactory.CreateActor(actorParameters);
		}
		#endregion Methods
	}
}
