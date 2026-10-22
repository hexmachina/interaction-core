using UnityEngine;

namespace TW.Interaction
{
	[CreateAssetMenu(menuName = "Data/Interaction/Interact Animator Instruction")]

	class InteractAnimatorInstruction : ScriptableObject
	{
		public enum FollowThrough
		{
			None,
			Prefade,
			Postfade,
			Stop
		}

		public bool checkWaist = true;
		public bool checkHandiness = true;
		public bool lookAt = true;
		public bool instantInteract = false;
		public FollowThrough followThrough = FollowThrough.Postfade;

	}

}
