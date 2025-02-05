using UnityEngine;

public class BookScript : MonoBehaviour
{
    public int gemsPlaced;
    public Animator bookAnimator;
    public Transform cluePosition;
    public GameObject paperClue;

    public void OnGemPlaced()
    {
        gemsPlaced++;

        if(gemsPlaced == 3)
        {
            bookAnimator.SetTrigger("openBook");
        }
    }

    public void SpawnClue()
    {
        paperClue.SetActive(true);
        paperClue.transform.position = cluePosition.position;
    }
}
