using System;
using TW.Attributes;
using UnityEngine;

namespace TW.Interaction
{
	[Serializable]
	public class InteractStageInstruction
	{
		[SerializeField] private bool _exactPosition;
		[SerializeReference, SR] private StageBlockingBase _stageDestination = new StageBlockingRadius();

		[SerializeField, Range(0.01f, 360f)] private float _turnThreshold = 0.15f;
		[SerializeReference, SR] private StageDirectionBase stageDirection = new DefaultDirection();

		public bool ExactPosition { get => _exactPosition; }
		public float TurnThreshold { get => _turnThreshold; }

		public virtual Vector3 GetStagingPosition(Transform origin, Vector3 target)
		{
			if (_stageDestination != null)
			{
				return _stageDestination.GetStagePosition(origin, target);
			}
			return origin.position;
		}

		public bool EvaluateStaging(Transform origin, Vector3 target, float distance, out Vector3 output)
		{
			if (_stageDestination != null)
			{
				var value = _stageDestination.EvaluateStaging(origin, target, distance, out output);
				return value;
			}
			output = origin.position;
			return false;
		}

		public Vector3 StagingDirection(Transform origin, Vector3 target)
		{
			return stageDirection.GetStageDirection(origin, target);
		}
	}
}
