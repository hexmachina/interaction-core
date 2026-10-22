using System;
using UnityEngine;
using UnityEngine.Events;

namespace TW.Interaction
{
	[DisallowMultipleComponent]
	public class InteractOperator : MonoBehaviour
	{
		[SerializeField] private InteractPerformerBase _performer;
		public UnityEvent<InteractActivityEvent> OnStarted = new();
		public UnityEvent<InteractActivityEvent> OnPerformed = new();
		public UnityEvent OnCancelled = new();
		public event Action<InteractActivityEvent> OnCompleted;

		public bool CanInteract { get; set; } = true;
		public bool IsInteracting { get; private set; }


		private InteractActivityEvent _currentTarget;
		private InteractActivityEvent _releaseTarget;
		public void StartInteract(InteractActivityEvent activityEvent)
		{
			IInteractable interactable = activityEvent.interactable;
			if (interactable == null || !CanInteract)
			{
				return;
			}
			if (interactable.Acquirer == this)
			{
				CancelInteract();
				return;
			}

			_currentTarget = activityEvent;
			IsInteracting = true;
			interactable.OnAcquirerChanged += OnAcquirerChanged;
			interactable.Bidder = this;
			OnStarted.Invoke(activityEvent);
			if (_performer)
			{
				_performer.Interacting(this, activityEvent);
			}
		}

		private void OnAcquirerChanged(object sender, InteractOperator e)
		{
			if (_currentTarget.interactable == null)
			{
				((IInteractable)sender).OnAcquirerChanged -= OnAcquirerChanged;
				return;
			}
			if (e != this)
			{
				CancelInteract();
			}
		}

		public void PerformInteract()
		{
			if (_currentTarget.interactable == null)
			{
				return;
			}

			OnPerformed.Invoke(_currentTarget);
			IInteractable interactable = _currentTarget.interactable;
			interactable.Interact(_currentTarget);
			_releaseTarget = _currentTarget;
			_currentTarget = InteractActivityEvent.Empty();
		}

		public void CancelInteract()
		{
			if (_currentTarget.interactable == null)
			{
				return;
			}
			IInteractable interactable = _currentTarget.interactable;
			if (interactable.Bidder == this)
			{
				interactable.Bidder = null;
			}
			if (interactable.Acquirer == this)
			{
				interactable.SetAcquirer(null);
			}
			interactable.OnAcquirerChanged -= OnAcquirerChanged;
			OnCancelled.Invoke();
			_releaseTarget = _currentTarget;
			_currentTarget = InteractActivityEvent.Empty();
			CompleteInteract();

		}

		public void CompleteInteract()
		{
			IsInteracting = false;
			OnCompleted?.Invoke(_releaseTarget);
			_releaseTarget = InteractActivityEvent.Empty();
		}
	}
}