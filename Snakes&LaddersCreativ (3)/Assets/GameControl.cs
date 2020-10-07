using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.Video;

public class GameControl : MonoBehaviour
{
    public static GameObject whoWinsText, player1MoveText, player2MoveText;
    public static GameObject player1, player2;
    public static GameObject pregunta1;

    public static int diceSideThrown=0;
    public static int player1StartWaypoint = 0;
    public static int player2StartWaypoint = 0;
    public static int questionIndex = 18;
    private static int[] answers = new int[20];
    private static int[] ladderEnd1 = new int[20];
    private static int[] ladderEnd2 = new int[20];


    public static bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        ladderEnd1[0] = 21;
        ladderEnd1[1] = 46;
        ladderEnd1[2] = 82;
        ladderEnd1[3] = 73;
        ladderEnd1[4] = 59;
        ladderEnd1[5] = 85;
        ladderEnd1[6] = 87;
        ladderEnd1[7] = 15;
        ladderEnd1[8] = 30;
        ladderEnd1[9] = 57;
        ladderEnd1[10] = 86;

        ladderEnd2[0] = 2;
        ladderEnd2[1] = 14;
        ladderEnd2[2] = 43;
        ladderEnd2[3] = 52;
        ladderEnd2[4] = 24;
        ladderEnd2[5] = 63;
        ladderEnd2[6] = 27;
        ladderEnd2[7] = 15;
        ladderEnd2[8] = 30;
        ladderEnd2[9] = 57;
        ladderEnd2[10] = 86;

        ///Buenos Habitos
        answers[0] = 1;
        answers[1] = 2;
        answers[2] = 0;
        answers[3] = 1;
        ///Malos Habitos
        answers[4] = 2;
        answers[5] = 0;
        answers[6] = 2;

        answers[7] = 1;

        answers[8] = 0;
        answers[9] = 0;
        answers[10] = 1;
        ///Especiales
        answers[11] = 1;
        answers[12] = 1;
        answers[13] = 1;
        answers[14] = 1;
        answers[15] = 1;
        answers[16] = 1;
        answers[17] = 1;

        whoWinsText = GameObject.Find("WhoWinsText");
        player1MoveText = GameObject.Find("Player1MoveText");
        player2MoveText = GameObject.Find("Player2MoveText");

        pregunta1 = GameObject.Find("Pregunta1");
        pregunta1.gameObject.SetActive(true);

        player1 = GameObject.Find("Player1");
        player2 = GameObject.Find("Player2");

        player1.GetComponent<FollowThePath>().moveAllowed = false;
        player2.GetComponent<FollowThePath>().moveAllowed = false;

        whoWinsText.gameObject.SetActive(false);
        player1MoveText.gameObject.SetActive(true);
        player2MoveText.gameObject.SetActive(false);
    }


    // Update is called once per frame
    public static void buttonResponse(int answer)
    {
        if (questionIndex != 18)
        {
            if (answers[questionIndex] == answer || questionIndex >= 11)
            {
                if (player1.GetComponent<FollowThePath>().moveAllowed == true)
                {
                    player1.GetComponent<FollowThePath>().ans = true;
                    player1.GetComponent<FollowThePath>().waypointIndex = ladderEnd1[player1.GetComponent<FollowThePath>().ladderIndex];
                }
                else
                {
                    player2.GetComponent<FollowThePath>().ans = true;
                    player2.GetComponent<FollowThePath>().waypointIndex = ladderEnd1[player2.GetComponent<FollowThePath>().ladderIndex];
                }

            }
            else
            {
                if (player1.GetComponent<FollowThePath>().moveAllowed == true)
                {
                    player1.GetComponent<FollowThePath>().ans = true;
                    player1.GetComponent<FollowThePath>().waypointIndex = ladderEnd2[player1.GetComponent<FollowThePath>().ladderIndex];
                }
                else
                {
                    player2.GetComponent<FollowThePath>().ans = true;
                    player2.GetComponent<FollowThePath>().waypointIndex = ladderEnd2[player2.GetComponent<FollowThePath>().ladderIndex];
                }
            }
        }
        pregunta1.gameObject.SetActive(false);

    }


    public static void MovePlayer(int playerToMove)
    {
        switch (playerToMove)
        {
            case 1:
                player1.GetComponent<FollowThePath>().moveAllowed = true;
                player1.GetComponent<FollowThePath>().waypointIndex += diceSideThrown;
                break;

            case 2:
                player2.GetComponent<FollowThePath>().moveAllowed = true;
                player2.GetComponent<FollowThePath>().waypointIndex += diceSideThrown;
                break;
        }
    }
}
