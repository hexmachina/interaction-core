using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Localization;

namespace TW.Interaction
{
	[Serializable]
	public partial class InteractableActivity
	{
		[SerializeField] private InteractStageInstruction _stageInstruction;
		[SerializeField] private InteractAnimatorInstruction _animatorInstruction;
		[SerializeField] private Transform _handle;
		[SerializeField] private LocalizedString _verb;
		[SerializeField] private UnityEvent<InteractOperator> _onInteractPerformed = new();
		[SerializeField] private UnityEvent _onInteractCancelled = new();

		public event Action<InteractOperator> OnInteractPerformed;

		public Transform Handle { get => _handle; set => _handle = value; }

		public LocalizedString Verb => _verb;

		public void PerformInteract(InteractOperator interactOperator)
		{
			_onInteractPerformed.Invoke(interactOperator);
			OnInteractPerformed?.Invoke(interactOperator);
		}

		public void CancelInteract()
		{
			_onInteractCancelled.Invoke();
		}

		public virtual Transform OperatingTarget(Transform origin)
		{
			return _handle ? _handle : origin;
		}
	}
}
