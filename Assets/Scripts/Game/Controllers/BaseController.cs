using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseController : MonoBehaviour
{
	[SerializeField]
	protected Vector3 _destPos;

	[SerializeField]
	protected Define.State _state = Define.State.Idle;

	[SerializeField]
	protected GameObject _lockTarget;
	[SerializeField]
	protected Animator _anim;

	public Define.WorldObject WorldObjectType { get; protected set; } = Define.WorldObject.Unknown;

	public virtual Define.State State
	{
		get { return _state; }
		set
		{
			_state = value;

			switch (_state)
			{
				case Define.State.Die:
					break;
				case Define.State.Idle:
					_anim.CrossFade("WAIT", 0.1f);
					break;
				case Define.State.Moving:
					_anim.CrossFade("RUN", 0.1f);
					break;
				case Define.State.Skill:
					_anim.CrossFade("ATTACK", 0.1f, -1, 0);
					break;
			}
		}
	}

    private void Start()
	{
		_anim = gameObject.GetComponent<Animator>();
		Init();
    }

	void Update()
	{
		switch (State)
		{
			case Define.State.Die:
				UpdateDie();
				break;
			case Define.State.Idle:
				UpdateIdle();
				break;
			case Define.State.Moving:
				UpdateMoving();
				break;
			case Define.State.Skill:
				UpdateSkill();
				break;
		}
	}

	public abstract void Init();
	protected virtual void UpdateDie() { }
	protected virtual void UpdateIdle() { }
	protected virtual void UpdateMoving() { }
	protected virtual void UpdateSkill() { }
}
