using UnityEngine;

namespace TW.Interaction
{
	[System.Serializable]
	public class StageBlockingObject : StageBlockingBase
	{
		[SerializeField] private StageMonoBehaviourBase _object;
		public override bool EvaluateStaging(Transform origin, Vector3 target, float distance, out Vector3 output)
		{
			return _object.EvaluateStaging(origin, target, distance, out output);
		}

		public override void OnDrawGizmos(Transform origin)
		{
			return;
		}

		public override Vector3 GetStagePosition(Transform origin, Vector3 target)
		{
			return _object.StagingPosition(origin, target);
		}
	}

}

