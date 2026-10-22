using UnityEngine;

namespace TW.Interaction
{
	[System.Serializable]
	public class StageBlockingNone : StageBlockingBase
	{
		public override bool EvaluateStaging(Transform origin, Vector3 target, float distance, out Vector3 output)
		{
			output = target;
			return true;
		}

		public override void OnDrawGizmos(Transform origin)
		{
		}

		public override Vector3 GetStagePosition(Transform origin, Vector3 target)
		{
			return target;
		}
	}

}
