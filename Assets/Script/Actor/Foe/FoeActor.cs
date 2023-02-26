namespace TD.Actor
{
	using Cinemachine;
	using UnityEngine;

	public class FoeActor : IActor<FoeActorParameters>
	{
		#region Fields
		private float _pathLength = 0.0f;

		private float _currentPosition = 0.0f;

		private float _speed = 10.0f;
		#endregion Fields

		#region Methods
		#region MonoBehaviour
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
			base.Initialize(parameters);

			CinemachineSmoothPath track = ActorParameters.Track;

			_pathLength = track.PathLength;
			_currentPosition = track.PathLength * ActorParameters.StartNormalizedPosition;

			SetPosition(_currentPosition);
		}
		#endregion Publics

		#region Internals
		private void SetPosition(float trackPorcent)
		{
			transform.position = ActorParameters.Track.EvaluatePositionAtUnit(trackPorcent, ActorParameters.PositionUnits);
		}
		#endregion Internals
		#endregion Methods
	}
}