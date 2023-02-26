namespace TD.Actor
{
	using Cinemachine;
	using UnityEngine;

	public class FoeActorParameters : IActorParameters
	{
		#region Fields
		private CinemachineSmoothPath _track;
		private float _startNormalizedPosition;
		private CinemachinePathBase.PositionUnits _positionUnits;
		#endregion Fields

		#region Properties
		public CinemachineSmoothPath Track { get => _track; }
		public float StartNormalizedPosition { get => _startNormalizedPosition; }
		public CinemachinePathBase.PositionUnits PositionUnits { get => _positionUnits; }
		#endregion Properties

		#region Constructor
		public FoeActorParameters(SpawnDataParameters spawnDataParameters, CinemachineSmoothPath track, float startNormalizedPosition, CinemachinePathBase.PositionUnits positionUnits)
			: base(spawnDataParameters)
		{
			_track = track;
			_startNormalizedPosition = startNormalizedPosition;
			_positionUnits = positionUnits;
		}
		#endregion Constructor

		#region Methods
		public override void Dispose()
		{
			base.Dispose();

			_track = null;
		}
		#endregion Methods
	}
}