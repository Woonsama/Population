using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Citizen : ObjectBase, IMove
{
    public enum ECitizenType
    {
        Young = 0,
        Man, Women,
        Old,

        Count = Old,
    };

    [Header("시민 종류")]
    public ECitizenType eCitizenType;

    [Header("스테이트")]
    public CitizenState citizenState;

    private float behiviourDelayTime = 0;

    private SkeletonAnimation skeletonAnimation;

    public AudioSource audioSource;

    protected override IEnumerator OnAwakeCoroutine()
    {
        audioSource = GetComponent<AudioSource>();
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.state.SetAnimation(0, "idle", true);

        StartCoroutine(Behaviour_Coroutine());
        return base.OnAwakeCoroutine();
    }

    private IEnumerator Behaviour_Coroutine()
    {
        ChangeState();
        SetBehaviourChangeTime();
        float time = 0;

        while (!citizenState.isDie)
        {
            if(time >= behiviourDelayTime)
            {
                ChangeState();
                SetBehaviourChangeTime();
                time = 0;
            }
            else
            {
                if(citizenState.eState == CitizenState.EState.ALIVE)
                {
                    Move();
                }
                time += Time.deltaTime;
            }

            yield return null;
        }
    }

    public void SetAnimation(string name, bool loop)
    {
        skeletonAnimation.AnimationName = name;
        skeletonAnimation.loop = loop;
    }

    public void Move()
    {
        switch (citizenState.eMoveState)
        {
            case CitizenState.EMoveState.LEFT:
                transform.position += (Vector3)(Vector2.left * citizenState.moveSpeed * Time.deltaTime);
                transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
                SetAnimation("walk", true);
                break;
            case CitizenState.EMoveState.RIGHT:
                transform.position += (Vector3)(Vector2.right * citizenState.moveSpeed * Time.deltaTime);
                transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);
                SetAnimation("walk", true);
                break;
            case CitizenState.EMoveState.UP:
                transform.position += (Vector3)(Vector2.up * citizenState.moveSpeed * Time.deltaTime);
                SetAnimation("walk", true);
                break;
            case CitizenState.EMoveState.DOWN:
                transform.position += (Vector3)(Vector2.down * citizenState.moveSpeed * Time.deltaTime);
                SetAnimation("walk", true);
                break;
            case CitizenState.EMoveState.STOP:
                transform.position += (Vector3)Vector2.zero;
                SetAnimation("idle", true);
                break;
            default:
                break;
        }
    }

    private void ChangeState()
    {
        citizenState.eMoveState = (CitizenState.EMoveState)Random.Range((int)CitizenState.EMoveState.START, (int)CitizenState.EMoveState.END);
    }

    private void SetBehaviourChangeTime()
    {
        behiviourDelayTime = Random.Range(Const.c_Min_Citizen_StateChangeTime, Const.c_Max_Citizen_StateChangeTime);
    }

}

[System.Serializable]

public class CitizenState
{
    public enum EState {ALIVE, CATCHED, DIE }
    public enum EMoveState {  LEFT, RIGHT, UP, DOWN, STOP , START = LEFT, END = STOP + 1, }

    public EState eState = EState.ALIVE;
    public EMoveState eMoveState = EMoveState.STOP;
    public float moveSpeed;
    public bool isDie;
}