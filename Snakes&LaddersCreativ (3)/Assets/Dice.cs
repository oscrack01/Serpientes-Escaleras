using System.Collections;
using UnityEngine;

public class Dice : MonoBehaviour
{
    private Sprite[] diceSides;
    private SpriteRenderer rend;
    public int whosTurn = 1;
    private bool coroutineAllowed = true;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
        diceSides = Resources.LoadAll<Sprite>("DiceSides/");
        rend.sprite = diceSides[5];
    }
    private void OnMouseDown()
    {
        if (!GameControl.gameOver && coroutineAllowed && GameControl.player1.GetComponent<FollowThePath>().moveAllowed == false && GameControl.player2.GetComponent<FollowThePath>().moveAllowed == false)
            StartCoroutine("RollTheDice");
    } 
    private IEnumerator RollTheDice()
    {
        GameControl.pregunta1.gameObject.SetActive(false);
        coroutineAllowed = false;
        int randomDiceSide = 0;
        for(int i = 0; i <= 20; i++)
        {
            randomDiceSide = Random.Range(0, 6);
            rend.sprite = diceSides[randomDiceSide];
            yield return new WaitForSeconds(0.05f);
        }

        GameControl.diceSideThrown = randomDiceSide + 1;
        if (whosTurn == 1)
        {
            GameControl.player1MoveText.gameObject.SetActive(false);
            GameControl.player2MoveText.gameObject.SetActive(true);
            GameControl.MovePlayer(1);
        }else if (whosTurn == -1)
        {
            GameControl.player1MoveText.gameObject.SetActive(true);
            GameControl.player2MoveText.gameObject.SetActive(false);
            GameControl.MovePlayer(2);
        }
        whosTurn *= -1;
        coroutineAllowed = true;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
