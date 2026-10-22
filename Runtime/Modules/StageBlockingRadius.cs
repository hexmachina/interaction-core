using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;
#endif

namespace TW.Interaction
{
	[System.Serializable]
	public class StageBlockingRadius : StageBlockingBase
	{
		[SerializeField] private float radius = 0.2f;
		public override bool EvaluateStaging(Transform origin, Vector3 target, float distance, out Vector3 output)
		{
			var org = origin.position;
			var pos = org;
			pos.y = target.y;

			var heading = target - pos;
			if (heading.magnitude < radius)
			{
				output = target;
				return true;
			}

			output = org + (heading.normalized * radius);
			var mag = (pos - output).magnitude;
			if (heading.magnitude < mag)
			{
				mag = heading.magnitude;
			}
			Debug.DrawRay(pos, heading, Color.red, 2f);
			return mag > distance;
		}

		public override void OnDrawGizmos(Transform origin)
		{
#if UNITY_EDITOR
			Handles.color = Color.red;
			Handles.DrawWireDisc(origin.position, Vector3.up, radius);
#endif
		}

		public override Vector3 GetStagePosition(Transform origin, Vector3 target)
		{
			return GetStagingRadiusPoint(origin, target);
		}

		private Vector3 GetStagingRadiusPoint(Transform origin, Vector3 target)
		{
			var pos = origin.position;
			pos.y = target.y;
			var heading = target - pos;
			if (heading.magnitude < radius)
			{
				return target;
			}
			var staging = pos + (heading.normalized * radius);

			return staging;
		}
	}

}
