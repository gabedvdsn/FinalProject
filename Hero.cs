using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hero : MonoBehaviour
{
    public SpriteRenderer HeroRenderer;
    public BowShooter BowShooter;

    void Start()
    {
        Debug.Log(Screen.width);
        Debug.Log(Screen.height);
    }

    public void Shoot()
    {
        BowShooter.Shoot_();
    }

    public void Move(Vector2 dir)
    {
        Vector3 amountToMove = CalculateAmountToMove(dir);
        HeroRenderer.transform.Translate(amountToMove);
        FaceCorrectDirection(dir);
        KeepOnScreen();
    }

    private Vector3 CalculateAmountToMove(Vector2 dir)
    {
        float amountX = dir.x * GameParameters.HeroMoveAmount;
        float amountY = dir.y * GameParameters.HeroMoveAmount;

        return new Vector3(amountX, amountY, 0);
    }

    public void FaceCorrectDirection(Vector2 dir)
    {
        if (dir.x == 1)
        {
            HeroRenderer.flipX = false;
        }
        else if (dir.x == -1)
        {
            HeroRenderer.flipX = true;
        }
    }

    private void KeepOnScreen()
    {
        SpriteTools.ConstrainToScreen(HeroRenderer);
    }
}
