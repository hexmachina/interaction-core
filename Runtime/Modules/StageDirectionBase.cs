using UnityEngine;

namespace TW.Interaction
{
	[System.Serializable]
	public abstract class StageDirectionBase
	{
		public abstract Vector3 GetStageDirection(Transform origin, Vector3 target);

	}
}