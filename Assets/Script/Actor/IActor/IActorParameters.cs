namespace TD.Actor
{
	using System;

	public abstract class IActorParameters : IDisposable
	{
		#region Fields
		private SpawnDataParameters _spawnDataParameters = null;
		#endregion Fields

		#region Properties
		public SpawnDataParameters BulletPrefab { get => _spawnDataParameters; }
		#endregion Properties

		#region Constructor
		protected IActorParameters(SpawnDataParameters spawnDataParameters)
		{
			_spawnDataParameters = spawnDataParameters;
		}
		#endregion Constructor

		#region Methods
		public virtual void Dispose()
		{
			_spawnDataParameters = null;
		}
		#endregion Methods
	}
}