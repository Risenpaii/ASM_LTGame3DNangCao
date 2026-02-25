using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    private StateMachine stateMachine;
    private NavMeshAgent agent;
    private GameObject player;
    //public GameObject debuggShere;
    public GameObject particlePrefab;
    //public GameObject spawnKey;
    public float timeStopPar;
    private Vector3 lastKnowPos;
    public NavMeshAgent Agent { get => agent; }
    public GameObject Player { get => player; }
    public Vector3 LastKnowPos { get => lastKnowPos; set => lastKnowPos = value; }

    public Path path;
    [Header("Sight Value")]
    public float sighDistance = 20f;
    public float fieldOfView = 85f;
    public float eyeHeight;
    [Header("Weapon Value")]
    public Transform gunBarrel;
    [Range(0.1f, 10)]
    public float fireRate;
    [SerializeField]
    private string currentState;
    public AudioSource boomSound;

    private EnemyHealth enemyHealth;
    void Start()
    {
        stateMachine = GetComponent<StateMachine>();
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
        stateMachine.Initialise();
        boomSound = GetComponent<AudioSource>();
        enemyHealth = GetComponent<EnemyHealth>();

    }

    // Update is called once per frame
    void Update()
    {
        CanSeePlayer();
        currentState = stateMachine.activeState.ToString();
        //debuggShere.transform.position = lastKnowPos;
    }
    public bool CanSeePlayer()
    {
        if (player != null)
        {
            if (Vector3.Distance(transform.position, player.transform.position) < sighDistance)
            {
                Vector3 targetDirection = player.transform.position - transform.position - (Vector3.up * eyeHeight);
                float angelToPlayer = Vector3.Angle(targetDirection, transform.forward);
                if (angelToPlayer >= -fieldOfView && angelToPlayer <= fieldOfView)
                {
                    Ray ray = new Ray(transform.position + (Vector3.up * eyeHeight), targetDirection);
                    RaycastHit hitInfo = new RaycastHit();
                    if (Physics.Raycast(ray, out hitInfo, sighDistance))
                    {
                        if (hitInfo.transform.gameObject == player)
                        {
                            return true;
                        }
                    }
                    Debug.DrawRay(ray.origin, ray.direction * sighDistance);
                }
            }
        }
        return false;
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.transform.CompareTag("Bullett"))
        {
            transform.GetComponent<EnemyHealth>().TakeDamage(10);
        }
    }
    public void DestroyObject()
    {
        // Tạo Particle System tại vị trí hiện tại
        if (particlePrefab != null)
        {
            GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);

            // Chạy Particle System
            ParticleSystem ps = particle.GetComponent<ParticleSystem>();
            if (ps != null)
            {
                ps.Play();
            }

            // Hủy Particle System sau khi nó kết thúc
            Destroy(particle, ps.main.duration + ps.main.startLifetime.constantMax);
        }
        //Instantiate(spawnKey, transform.position, Quaternion.identity);
        // Hủy GameObject này
        Destroy(gameObject);
    }
}
