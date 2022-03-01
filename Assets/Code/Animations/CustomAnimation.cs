using System.Collections.Generic;
using UnityEngine;

public class CustomAnimation:IExecute
{
    public AnimationType AnimType;
    public List<Sprite> Sprites;
    public bool Loop = false;
    public float AnimationSpeed = 10;
    public float Counter;
    public bool Sleeps;

    public void Execute(float deltaTime)
    {
        if (Sleeps)
            return;

        Counter += Time.deltaTime * System.Math.Abs(AnimationSpeed);

        if (Loop)
        {
            while (Counter > Sprites.Count)
                Counter -= Sprites.Count;
        }
        else if (Counter > Sprites.Count)
        {
            Counter = Sprites.Count - 1;
            Sleeps = true;
        }
    }


    public void Update()
    {

        if (Sleeps)
            return;

        Counter += Time.deltaTime * AnimationSpeed;

        if (Loop)
        {
            while (Counter > Sprites.Count)
                Counter -= Sprites.Count;
        }
        else if (Counter > Sprites.Count)
        {
            Counter = Sprites.Count - 1;
            Sleeps = true;
        }
    }
}
