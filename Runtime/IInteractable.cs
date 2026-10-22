using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace TW.Interaction
{
	public interface IInteractable
	{
		Transform transform { get; }
		LocalizedString Title { get; }
		IReadOnlyList<InteractableActivity> Activities { get; }

		InteractOperator Bidder { get; set; }
		InteractOperator Acquirer { get; }

		bool IsAvailable { get; }

		event EventHandler<InteractOperator> OnClaimedChanged;
		event EventHandler<InteractOperator> OnAcquirerChanged;

		void SetAcquirer(InteractOperator acquirer);
		bool ValidateInteract(InteractOperator user);

		void Interact(InteractActivityEvent interactActivityEvent);
		void CancelInteract(InteractActivityEvent interactActivityEvent);
	}
}
