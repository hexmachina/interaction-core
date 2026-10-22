using UnityEngine;

namespace TW.Interaction
{
	[System.Serializable]
	public abstract class StageBlockingBase
	{

		public abstract Vector3 GetStagePosition(Transform origin, Vector3 target);

		public abstract bool EvaluateStaging(Transform origin, Vector3 target, float distance, out Vector3 output);

		public abstract void OnDrawGizmos(Transform origin);
	}
}
