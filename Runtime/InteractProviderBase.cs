using System;
using UnityEngine;
using UnityEngine.Events;

namespace TW.Interaction
{
	public abstract class InteractProviderBase : MonoBehaviour
	{
		[SerializeField] protected InteractOperator _operator;

		public UnityEvent<GameObject> onPerformingChanged = new();
		public UnityEvent<bool> onCompletedChanged = new();
		public UnityEvent<IInteractable> onInteract = new();
		public event Action<InteractActivityEvent> OnTargetChanged;

		protected IInteractable _target;
		protected GameObject _targetGameObject;
		protected bool _canListen = true;

		public IInteractable Target => _target;

		public abstract void Interact(int index);

		public void SetOperatorByComponent(Component component)
		{
			InteractOperator old = _operator;

			component.TryGetComponent(out _operator);
			if (old == _operator)
			{
				return;
			}
			if (old != null)
			{
				old.OnCompleted -= OnInteractCompleted;
			}
			_operator.OnCompleted += OnInteractCompleted;
			OnTargetChanged?.Invoke(new InteractActivityEvent() { user = _operator, interactable = _target });

		}

		public void SetTarget(GameObject gameObject)
		{
			if (_targetGameObject == gameObject)
			{
				return;
			}
			_targetGameObject = gameObject;
			IInteractable old = _target;
			gameObject.TryGetComponent(out _target);

			if (old == _target)
			{
				return;
			}
			OnTargetChanged?.Invoke(new InteractActivityEvent() { user = _operator, interactable = _target });
		}

		public void SetTarget(Component component)
		{
			if (component == null)
			{
				if (_target != null)
				{
					_target = null;
					_targetGameObject = null;
					OnTargetChanged?.Invoke(new InteractActivityEvent() { user = _operator, interactable = _target });
				}
				return;
			}
			IInteractable old = _target;
			if (component is IInteractable interactable)
			{
				_target = interactable;

			}
			else
			{
				gameObject.TryGetComponent(out _target);
			}

			if (old == _target)
			{
				return;
			}
			_targetGameObject = _target.transform.gameObject;
			OnTargetChanged?.Invoke(new InteractActivityEvent() { user = _operator, interactable = _target });
		}

		public void ClearTarget()
		{
			if (_target == null)
			{
				return;
			}
			_target = null;
			_targetGameObject = null;
			OnTargetChanged?.Invoke(new InteractActivityEvent() { user = _operator, interactable = _target });
		}

		protected virtual void OnInteractCompleted(InteractActivityEvent interactActivityEvent)
		{

			_canListen = true;

			onCompletedChanged.Invoke(true);
		}
	}
}
