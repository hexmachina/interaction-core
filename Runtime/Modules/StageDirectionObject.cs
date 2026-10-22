using UnityEngine;

namespace TW.Interaction
{
	[System.Serializable]
	public class StageDirectionObject : StageDirectionBase
	{
		[SerializeField] private StageMonoBehaviourBase _object;
		public override Vector3 GetStageDirection(Transform origin, Vector3 target)
		{
			return _object.StagingDirection(origin, target);
		}
	}
}
