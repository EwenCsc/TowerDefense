using Cinemachine;
using UnityEngine;

public class ActorSpawner : MonoBehaviour
{
	#region Fields
	[SerializeField] private Actor _actorPrefab = null;
	[SerializeField] private float _spawnCooldown = 2.0f;
	[SerializeField] private CinemachineSmoothPath _track = null;
	[SerializeField] private CinemachinePathBase.PositionUnits pathUnits = CinemachinePathBase.PositionUnits.PathUnits;

	private float _cooldown = 0.0f;
	#endregion Fields

	#region Methods
	private void Start()
	{
		Time.timeScale = 5;
	}

	private void Update()
	{
		_cooldown += Time.deltaTime;

		if (_cooldown < _spawnCooldown)
		{
			return;
		}

		_cooldown -= _spawnCooldown;
		Actor actor = GameObject.Instantiate(_actorPrefab);

		actor.Init(_track, 0.0f, pathUnits);
	}
	#endregion Methods
}
