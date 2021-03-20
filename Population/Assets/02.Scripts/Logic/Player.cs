using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Player : ObjectBase, IMove, ICatch
{
    [Header("스테이터스")]
    public PlayerState state;

    [Header("확인용 - 지금 시민을 잡고 있는지")]
    [SerializeField] private bool isCatch = false;

    [Header("확인용 - 적과 가까이 있는지")]
    [SerializeField] private bool isNear = false;

    private Truck truck;

    private GameObject target;
    private Vector2 targetInitialPos;

    private SkeletonAnimation skeletonAnimation;

    protected override IEnumerator OnAwakeCoroutine()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.state.SetAnimation(0, "idle", true);

        truck = GameObject.Find("Truck").GetComponent<Truck>();
        truck.SetPlayer(this);
        return base.OnAwakeCoroutine();
    }

    private void Update()
    {
        Move();
        Catch();

        if(transform.childCount == 3)
        {
            transform.GetChild(2).transform.position = transform.GetChild(0).transform.position;
        }
    }

    private void SetAnimation(string name, bool loop)
    {
        skeletonAnimation.AnimationName = name;
        skeletonAnimation.loop = loop;
    }

    public void Move()
    {
        float x = Input.GetAxisRaw("Horizontal") * 0.1f * state.moveSpeed;
        float y = Input.GetAxisRaw("Vertical") * 0.1f * state.moveSpeed;

        if (x > 0) transform.localScale = new Vector2(Mathf.Abs(transform.localScale.x), transform.localScale.y);
        else if (x < 0) transform.localScale = new Vector2(-Mathf.Abs(transform.localScale.x), transform.localScale.y);

        //transform.Translate(new Vector2(x, y));
        transform.position += (Vector3)(new Vector2(x, y));

        if(x != 0 || y != 0)
        {
            SetAnimation("walk", true);
        }
        else if(x == 0 && y == 0)
        {
            //skeletonAnimation.name = "idle";
            SetAnimation("idle", true);
        }

    }

    public void Catch()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            if (isNear && !isCatch)
            {
                if(target)
                {
                    target.transform.parent = transform;
                    target.GetComponent<BoxCollider2D>().enabled = false;
                    "시민을 잡았습니다".Log();
                    target.GetComponent<Citizen>().citizenState.eState = CitizenState.EState.CATCHED;
                    target.GetComponent<Citizen>().SetAnimation("badoongbadoong", true);
                    target.transform.position = transform.GetChild(0).transform.position;
                    target.transform.eulerAngles = new Vector3(target.transform.eulerAngles.x, target.transform.eulerAngles.y, 90);
                    isCatch = true;
                }
            }
            else if (isNear && isCatch || !isNear && isCatch)
            {
                target.GetComponent<BoxCollider2D>().enabled = true;
                "시민을 놓아주었습니다".Log();

                truck.Lift();
                if(truck.isNear)
                {
                    target.GetComponent<Citizen>().citizenState.eState = CitizenState.EState.DIE;
                }
                else
                {
                    target.GetComponent<Citizen>().citizenState.eState = CitizenState.EState.ALIVE;
                }
                target = null;
                isCatch = false;

            }
            else if(!isNear && !isCatch)
            {

            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Citizen")
        {
            if(!isCatch)
            {
                target = collision.collider.gameObject;
                targetInitialPos = target.transform.position;
            }

            isNear = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.tag == "Citizen")
        {
            isNear = false;
        }
    }
}

[System.Serializable]

public class PlayerState
{
    [Header("이동 속도")]
    public float moveSpeed;
}