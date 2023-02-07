using UnityEngine;
using UnityEngine.AI;

public class EnemyAiTutorialDave : MonoBehaviour
{
    public NavMeshAgent enemigo;

    public Transform player;

    public LayerMask whatIsGround, whatIsPlayer;

    //Variables de la patrulla
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;


    //Para que ataque el enemigo
    public float tiemporEntreAtaques;
    bool yaDisparado;
    public GameObject proyectilEnemigo;

    //Estados 
    public float rangoDeVision, rangoDeAtaque;
    public bool playerEnRangoDeVision, playerEnRangoDeAtaque;


    private void Awake()
    {
        //esto asigna qué y quién es el jugador
        player = GameObject.Find("Player").transform;
        //esto asigna quien es el enemigo, va a necesitar el NavMeshAgent
        enemigo = GetComponent<NavMeshAgent>();


    }


    private void Update()
    {
        //Que compruebe el rango de vision y ataque
        playerEnRangoDeVision = Physics.CheckSphere(transform.position, rangoDeVision, whatIsPlayer);
        playerEnRangoDeAtaque = Physics.CheckSphere(transform.position, rangoDeAtaque, whatIsPlayer);

        if (!playerEnRangoDeVision && !playerEnRangoDeAtaque) Patroling();
        if (playerEnRangoDeVision && !playerEnRangoDeAtaque) SeguirPlayer();
        if (playerEnRangoDeVision && playerEnRangoDeAtaque) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            enemigo.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //esto significa que ha llegado al walkpoint
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }

    private void SearchWalkPoint()
    {
        //Con esto calcula puntos random en el rango como walkpoints
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        //aquí verificamos que el walkpoint no se va del mapa
        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void SeguirPlayer()
    {
        enemigo.SetDestination(player.position);
    }

    private void AttackPlayer()
    {
        //para asegurarnos de que el enemigo no se mueve
        enemigo.SetDestination(transform.position);

        transform.LookAt(player);

        if (!yaDisparado)
        {
            ///código de ataque aqui 
            Rigidbody rb = Instantiate(proyectilEnemigo, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///


            yaDisparado = true;
            Invoke(nameof(ResetAttack), tiemporEntreAtaques);

        }
    }

    private void ResetAttack()
    {
        yaDisparado = false;

    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, rangoDeAtaque);
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, rangoDeVision);
    }
}
