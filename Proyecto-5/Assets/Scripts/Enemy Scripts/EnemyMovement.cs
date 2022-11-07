using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private CharacterAnimation enemyAnim;

    private Rigidbody enemyBody;
    public float speed = 5f;

    private Transform playerTarget;

    public float attackDistance = 1f;
    public float chasePlayerAfterAttack = 0.5f;

    private float currentAttackTime;
    private float defaultAttackTime = 1f;

    private bool followPlayer, attackPlayer;

    void Awake()
    {
        enemyAnim = GetComponentInChildren<CharacterAnimation>();
        enemyBody = GetComponent<Rigidbody>();

        playerTarget = GameObject.FindGameObjectWithTag(Tags.PLAYER_TAG).transform;
    }

    // Start is called before the first frame update
    void Start()
    {
        followPlayer = true;
        currentAttackTime = defaultAttackTime;
            
    }

    // Update is called once per frame
    void Update()
    {
        Attack();
    }
    void FixedUpdate()
    {
        FollowTarget();
    }
    void FollowTarget()
    {
        if(!followPlayer)
            return;

        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance)
        {

            Vector3 dis = playerTarget.transform.position - transform.position;
            bool lookR = playerTarget.transform.position.x - transform.position.x < 0;

            if (lookR)
            {
                transform.localScale = new Vector3(Mathf.Abs( transform.localScale.x)*-1, transform.localScale.y, transform.localScale.z);
            }
            else
            {
                transform.localScale = new Vector3(Mathf.Abs(transform.localScale.x), transform.localScale.y, transform.localScale.z);
            }
            // transform.LookAt(playerTarget);
            enemyBody.velocity = dis.normalized * speed;

            if(enemyBody.velocity.sqrMagnitude != 0)
            {
                enemyAnim.Walk(true);
            }
        }
        else if (Vector3.Distance(transform.position, playerTarget.position) <= attackDistance)
        {
            enemyBody.velocity = Vector3.zero;
            enemyAnim.Walk(false);

            followPlayer = false;
            attackPlayer = true;

        }
    }
    void Attack()
    {
        if (!attackPlayer)
            return;
        currentAttackTime += Time.deltaTime; 
        if(currentAttackTime > defaultAttackTime)
        {
            enemyAnim.EnemyAttack(Random.Range(0, 3));

            currentAttackTime = 0f;
        }
        if(Vector3.Distance(transform.position, playerTarget.position) > attackDistance + chasePlayerAfterAttack)
        {
            attackPlayer = false;
            followPlayer = true;
        }
    }
}
