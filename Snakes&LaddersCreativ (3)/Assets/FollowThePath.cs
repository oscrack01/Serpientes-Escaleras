using UnityEngine.SceneManagement;
using UnityEngine;

public class FollowThePath : MonoBehaviour
{
    public Transform[] waypoints;

    [SerializeField]
    private float moveSpeed = 1f;

    [HideInInspector]
    public int waypointIndex = 0;

    public bool moveAllowed = false;
    public bool jump = false;
    public bool ans=true;

    public int actualIndex = 0;
    public int ladderIndex = 0;
    private int[] ladderStart = new int[20];


    // Start is called before the first frame update
    void Start()
    {

        transform.position = waypoints[waypointIndex].transform.position;
        //Escaleras
        ladderStart[0] = 2;
        ladderStart[1] = 14;
        ladderStart[2] = 43;
        ladderStart[3] = 52;
        //Serpientes
        ladderStart[4] = 59;
        ladderStart[5] = 85;
        ladderStart[6] = 87;
        //Especiales
        ladderStart[7] = 15;
        ladderStart[8] = 30;
        ladderStart[9] = 57;
        ladderStart[10] = 86;



    }

    // Update is called once per frame
    void Update()
    {
        if (moveAllowed == true) Move();
    }
    private void Move()
    {
        
        if (ans)
        {
            if (actualIndex <= Mathf.Min(98, waypointIndex - 1) && (jump == false))
            {
                transform.position = Vector2.MoveTowards(transform.position, waypoints[actualIndex + 1].transform.position, moveSpeed * Time.deltaTime);
                if (transform.position == waypoints[actualIndex + 1].transform.position) actualIndex++;
            }
            else
            {
                if (jump == false)
                {
                    for (int i = 0; i < 11; i++)
                    {
                        if (actualIndex == ladderStart[i])
                        {
                            if(i<4)GameControl.questionIndex = Random.Range(0,4);
                            if(i>=4 && i<7)GameControl.questionIndex = Random.Range(4, 11);
                            if(i>=7) GameControl.questionIndex = Random.Range(11, 18);

                            ///Cambia imagen imagenDeLaTarjeta = arregloDeImagenes[GameControl.questionIndex];

                            GameControl.pregunta1.gameObject.SetActive(true);
                            ans = false;
                            jump = true;
                            ladderIndex = i;
                        }
                    }
                }
                if (jump == true && ans==true)
                {
                    transform.position = Vector2.MoveTowards(transform.position, waypoints[waypointIndex].transform.position, moveSpeed * Time.deltaTime);
                    if (transform.position == waypoints[waypointIndex].transform.position)
                    {
                        jump = false;
                        moveAllowed = false;
                        actualIndex = waypointIndex;
                    }
                }
                else
                {
                    if(ans == true)moveAllowed = false;
                }
            }
        }
        if (actualIndex >= 99)
        {
            string currentSceneName = SceneManager.GetActiveScene().name;
            SceneManager.LoadScene(currentSceneName);
        }
    }
}

