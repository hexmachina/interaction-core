namespace TW.Interaction
{
	public struct InteractActivityEvent
	{
		public IInteractable interactable;
		public InteractableActivity activity;
		public InteractOperator user;

		public static InteractActivityEvent Empty() => new();
	}
}