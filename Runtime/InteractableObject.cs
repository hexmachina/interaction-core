using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Localization;

namespace TW.Interaction
{
	[DisallowMultipleComponent]
	public class InteractableObject : MonoBehaviour, IInteractable
	{
		[SerializeField] private LocalizedString _title;
		[SerializeField] private List<InteractableActivity> _activities = new();
		[SerializeField] private InteractOperator _bidder;
		[SerializeField] private bool _isAcquirable = true;
		[SerializeField] private InteractOperator _acquirer;

		public event EventHandler<InteractOperator> OnAcquirerChanged;
		public event EventHandler<InteractOperator> OnClaimedChanged;

		public InteractOperator Bidder
		{
			get => _bidder;
			set
			{
				if (_bidder == value || (value != null && _acquirer != null))
				{
					return;
				}
				_bidder = value;
				OnClaimedChanged?.Invoke(this, _bidder);
			}
		}

		public InteractOperator Acquirer => _acquirer;

		public IReadOnlyList<InteractableActivity> Activities => _activities;

		public bool IsAvailable => _bidder == null && _acquirer == null;

		public LocalizedString Title => _title;

		public void SetAcquirer(InteractOperator acquirer)
		{
			if (!_isAcquirable || acquirer == _acquirer)
			{
				return;
			}
			_acquirer = acquirer;
			if (_acquirer != null)
			{
				_bidder = null;
			}
			OnAcquirerChanged?.Invoke(this, acquirer);
		}

		public bool ValidateInteract(InteractOperator user)
		{
			return true;
		}

		public void Interact(InteractActivityEvent interactActivityEvent)
		{
			if (!isActiveAndEnabled)
			{
				return;
			}
			SetAcquirer(interactActivityEvent.user);
			interactActivityEvent.activity.PerformInteract(interactActivityEvent.user);
		}

		public void CancelInteract(InteractActivityEvent interactActivityEvent)
		{
			if (!isActiveAndEnabled)
			{
				return;
			}
			interactActivityEvent.activity.CancelInteract();
		}
	}
}
