using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPuzzle : MonoBehaviour
{
    // Start is called before the first frame update
    public changeScene changeS;
    public BoxCollider box;
    public CheckKey r,g,b;
    public Animator anime;
    void Start()
    {
        StartCoroutine(doStuff());
    }

    IEnumerator doStuff()
    {
        yield return new WaitUntil(()=> r.startMovement && g.startMovement && b.startMovement);
        anime.SetBool("start", true);
        yield return new WaitForSeconds(5);
        box.enabled = true;
        changeS.enabled = true;
    }
}
