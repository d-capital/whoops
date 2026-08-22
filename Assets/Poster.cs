using UnityEngine;

public class Poster: DropAction
{
    public override void Activate()
    {
        Debug.Log("Poster: drop action initiated");
        gameObject.SetActive(false);
    }
}
