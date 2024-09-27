using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMoveAI : MonoBehaviour
{
    [SerializeField] private Transform graveStone;
    [SerializeField] private Transform exitGate;
    [SerializeField] private NavMeshAgent agent;

    [SerializeField] private float graveDistance = 2.0f;
    [SerializeField] private float exitGateDistance = 3.0f;

    private bool atLocation = false; 

    private bool runningAway = false;

    public Animator anim;

     
    // Start is called before the first frame update
    void Start()
    {
        anim = this.transform.GetChild(0).GetComponent<Animator>();
        anim.SetBool("IsWalk", true); 

        graveStone = GameObject.FindWithTag("Grave").transform;
        agent = GetComponent<NavMeshAgent>();

        exitGate = GameObject.FindWithTag("Gate").transform;


    }

    // Update is called once per frame
    void Update()
    {
        if (!runningAway)
        {
            //look at the grave stone
            transform.LookAt(graveStone);

            agent.SetDestination(graveStone.transform.position);

            if (Vector3.Distance(transform.position, graveStone.position) < graveDistance && !atLocation)
            {
                atLocation = true;
                StartDigging();
            }
        }

        if (runningAway == true)
        {
            transform.LookAt(exitGate);
            agent.SetDestination(exitGate.transform.position);

            if (Vector3.Distance(transform.position, exitGate.position) < exitGateDistance)
            {
                Destroy(this.gameObject);
                Debug.Log("Made it to the exit!"); 
            }
        }
        
    }

    private void StartDigging()
    {
        anim.SetBool("IsWalk", false);
        anim.SetBool("IsDig", true);

        Digging digging = this.GetComponent<Digging>();
        digging.StartDigging();
        Debug.Log("enemy made it to point A");
    }

    public void RunToExit()
    {
        anim.SetBool("IsDig", false);
        anim.SetBool("IsRun", true); 
        runningAway = true;
    }
}
