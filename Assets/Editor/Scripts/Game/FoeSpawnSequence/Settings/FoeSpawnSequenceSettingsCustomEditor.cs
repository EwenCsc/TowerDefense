namespace TD.Game
{
	using System.Collections.Generic;
	using UnityEditor;
	using UnityEngine;

	[CustomEditor(typeof(FoeSpawnSequenceSettings))]
	public class FoeSpawnSequenceSettingsCustomEditor : Editor
	{
		#region Fields
		private SerializedProperty _foeWavesSettings = null;
		#endregion Fields

		private void OnEnable()
		{
			_foeWavesSettings = serializedObject.FindProperty("_foeWavesSettings");
		}

		private void OnDisable()
		{
			_foeWavesSettings = null;
		}

		public override void OnInspectorGUI()
		{
			base.OnInspectorGUI();

			if (GUILayout.Button("CC"))
			{
				List<FoeWaveSettings> foeWaveSettings = _foeWavesSettings.managedReferenceValue as List<FoeWaveSettings>;
				foeWaveSettings.Add(new FoeWaveSettings());
			}
		}
	}
}