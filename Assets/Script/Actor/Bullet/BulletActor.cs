using UnityEngine;

namespace TD.Actor
{
	public class BulletActor : IActor<BulletActorParameters>
	{
		#region Fields
		[SerializeField] private Rigidbody _rigidbody = null;
		#endregion Fields

		#region Methods
		public override void Initialize(IActorParameters actorParameters)
		{
			base.Initialize(actorParameters);

			Destroy(gameObject, 10.0f);
		}

		protected override void Update()
		{
			base.Update();

			_rigidbody.velocity = transform.forward * 10.0f;
		}
		#endregion Methods
	}
}