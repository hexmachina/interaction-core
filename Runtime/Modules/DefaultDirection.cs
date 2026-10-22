using UnityEngine;

namespace TW.Interaction
{
	[System.Serializable]
	public class DefaultDirection : StageDirectionBase
	{

		public override Vector3 GetStageDirection(Transform origin, Vector3 target)
		{
			var pos = origin.position;
			pos.y = target.y;
			var heading = pos - target;
			return heading;
		}
	}
}