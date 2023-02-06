using Cinemachine;
using UnityEngine;

public class Actor : MonoBehaviour
{
	#region Fields
	private CinemachineSmoothPath _track = null;

	private float _currentPosition = 0.0f;

	private float _timeToReachTrackEnd = 5.0f;
	private float _currentTimeOnTrack = 0.0f;
	CinemachinePathBase.PositionUnits _positionUnits = CinemachinePathBase.PositionUnits.PathUnits;

	private bool _reachedHalf = false;
	private bool _reachedEnd = false;
	#endregion Fields

	#region Methods
	#region MonoBehaviour
	private void Update()
	{
		_currentTimeOnTrack += Time.deltaTime;
		_currentPosition = _currentTimeOnTrack / _timeToReachTrackEnd;

		SetPosition(_currentPosition);

		CinemachineSmoothPath.Waypoint lastWaypoint = _track.m_Waypoints[_track.m_Waypoints.Length - 1];
		if (Vector2.Distance(transform.position, lastWaypoint.position) <= Vector3.kEpsilon)
		{
			GameObject.Destroy(gameObject, 0.5f);
		}
	}
	#endregion MonoBehaviour

	public void Init(CinemachineSmoothPath track, float startPosition, CinemachinePathBase.PositionUnits positionUnits)
	{
		_track = track;

		_positionUnits = positionUnits;
		_currentPosition = _track.PathLength * startPosition;
		_currentTimeOnTrack = startPosition * _timeToReachTrackEnd;
		SetPosition(_currentPosition);
	}

	private void SetPosition(float trackPorcent)
	{
		transform.position = _track.EvaluatePositionAtUnit(trackPorcent, _positionUnits);
	}
	#endregion Methods
}