using UnityEngine;

namespace TW.Interaction
{
	public abstract class InteractPerformerBase : MonoBehaviour
	{
		public abstract void Interacting(InteractOperator interactOperator, InteractActivityEvent activityEvent);

	}
}
