using System;
using TW.Attributes;
using UnityEngine;

namespace TW.Interaction
{
	[Serializable]
	public class InteractAction
	{
		[SerializeReference, SR] private StageBlockingBase _staging;
		[SerializeField] private bool _exactPosition = false;
		[SerializeField, Range(0.01f, 360f)] private float _turnThreshold = 0.15f;

		[SerializeField] private Transform _handle;

		public bool ExactPosition => _exactPosition;
		public float TurnThreshold => _turnThreshold;
		public Transform Handle => _handle;
	}
}
