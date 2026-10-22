using UnityEngine;

namespace TW.Interaction
{
	public abstract class StageMonoBehaviourBase : MonoBehaviour
	{
		public abstract Vector3 StagingPosition(Transform origin, Vector3 target);

		public abstract bool EvaluateStaging(Transform origin, Vector3 target, float distance, out Vector3 output);

		public abstract Vector3 StagingDirection(Transform origin, Vector3 target);
	}
}

