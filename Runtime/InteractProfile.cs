using System;
using UnityEngine;

namespace TW.Interaction
{
	[CreateAssetMenu(menuName = "Data/Interaction/Profile")]
	public class InteractProfile : ScriptableObject
	{
		public event Action<InteractActivityEvent> OnInteractStarted;

		public event Action OnInteractReleased;

		public event Action<bool> OnCanInteract;
		public event Action OnEvaluation;

		private bool _canInteract = true;

		public bool CanInteract
		{
			get { return _canInteract; }
			set
			{
				if (value != _canInteract)
				{
					_canInteract = value;
					OnCanInteract?.Invoke(_canInteract);
				}
			}
		}

		public void Interact(InteractActivityEvent interactable)
		{
			OnInteractStarted?.Invoke(interactable);
		}

		public void InteractReleased()
		{
			OnInteractReleased?.Invoke();
		}

		public void TriggerEvaluation()
		{
			OnEvaluation?.Invoke();
		}
	}
}

