using UnityEngine;

/*
Author: Logan Brown
Description:
Handles proximity checking and animating for trash can
*/

public class trash : MonoBehaviour
{
    Animator trashbinAnimator;
    private bool isCloseToTrash(GameObject block, GameObject trashbin)
    {
        return Vector2.Distance(block.transform.position, trashbin.transform.position) < .75f;
    }

    public void trashProxChecker(GameObject block, GameObject trashbin)
    {
        trashbinAnimator = trashbin.GetComponent<Animator>();
        if (isCloseToTrash(block, trashbin) && !trashbinAnimator.GetBool("Open"))
        {
            trashbinAnimator.SetBool("Open", true);
            trashbinAnimator.SetBool("Close", false);
        }
        else if (!isCloseToTrash(block, trashbin) && !trashbinAnimator.GetBool("Close"))
        {
            trashbinAnimator.SetBool("Open", false);
            trashbinAnimator.SetBool("Close", true);
        }
    }

    public void delete(GameObject block, GameObject trashbin)
    {
        if (Vector2.Distance(block.transform.position, trashbin.transform.position) < 1.5)
        {
            Destroy(block);
            trashbinAnimator.SetBool("Open", false);
            trashbinAnimator.SetBool("Close", true);
        }
    }
}
