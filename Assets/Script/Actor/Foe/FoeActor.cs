namespace TD.Actor
{
	using Cinemachine;
	using UnityEngine;

	public class FoeActor : IActor
	{
		#region Fields
		private CinemachineSmoothPath _track = null;

		private float _pathLength = 0.0f;

		private float _currentPosition = 0.0f;

		CinemachinePathBase.PositionUnits _positionUnits = CinemachinePathBase.PositionUnits.PathUnits;

		private float _speed = 10.0f;
		#endregion Fields

		#region Methods
		#region MonoBehaviour
		protected override void OnDestroy()
		{
			base.OnDestroy();
			_track = null;
		}

		protected override void Update()
		{
			base.Update();

			_currentPosition = Mathf.Clamp(_currentPosition + _speed * Time.deltaTime, 0.0f, _pathLength);

			float trackPorcent = _currentPosition / _pathLength;

			SetPosition(trackPorcent);
			if (trackPorcent >= 1.0f)
			{
				GameObject.Destroy(gameObject, 0.5f);
			}
		}
		#endregion MonoBehaviour

		#region Publics
		public override void Initialize(IActorParameters parameters)
		{
			FoeActorParameters foeParameters = parameters as FoeActorParameters;
			if (foeParameters == null)
			{
				Debug.LogError("Parameters should be FoeActorParameters");
				return;
			}

			_track = foeParameters.Track;
			_pathLength = foeParameters.Track.PathLength;

			_positionUnits = foeParameters.PositionUnits;
			_currentPosition = _track.PathLength * foeParameters.StartNormalizedPosition;

			SetPosition(_currentPosition);
		}
		#endregion Publics

		#region Internals
		private void SetPosition(float trackPorcent)
		{
			transform.position = _track.EvaluatePositionAtUnit(trackPorcent, _positionUnits);
		}
		#endregion Internals
		#endregion Methods
	}
}