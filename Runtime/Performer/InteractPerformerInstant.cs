namespace TW.Interaction
{
	public class InteractPerformerInstant : InteractPerformerBase
	{
		public override void Interacting(InteractOperator interactOperator, InteractActivityEvent activityEvent)
		{
			interactOperator.PerformInteract();
			interactOperator.CompleteInteract();
		}
	}
}
