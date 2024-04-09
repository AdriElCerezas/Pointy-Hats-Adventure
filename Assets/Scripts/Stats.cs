using UnityEngine;

[CreateAssetMenu(menuName = "Game/Stats")]
public class Stats : ScriptableObject
{
    public int life;
    public int baseSpeed;
    public int speed;
    public int acuracy;
    public int amo;
    public int maxAmo;
    public int charger;
    public float rangeRadius;
    public float fireRate;
    public bool isFreezed;
    public bool isBurning;
    public bool isPoisoned;
    public bool facingRight;

    public void Update()
    {
        if (isFreezed)
        {
            speed = baseSpeed / 2;
        } else
        {
            speed = baseSpeed;
        }
    }
}

    /*public int GetLife()
    {
        return life;
    }
    public int GetSpeed()
    {
        return speed;
    }
    public int GetAccuracy()
    {
        return acuracy;
    }
    public int GetAmo()
    {
        return amo;
    }
    public int GetMaxAmo()
    {
        return maxAmo;
    }
    public int GetCharger()
    {
        return charger;
    }
    public float GetRangeRadius()
    {
        return rangeRadius;
    }
    public float GetFireRate()
    {
        return fireRate;
    }
    public bool IsFreezed()
    {
        return isFreezed;
    }
    public bool IsBurning()
    {
        return isBurning;
    }
    public bool IsPoisoned()
    {
        return isPoisoned;
    }
    public bool IsFacingRight()
    {
        return facingRight;
    }
    public void SetLife(int value)
    {
        life = value;
    }
    public void SetSpeed(int value)
    {
        speed = value;
    }
    public void SetAccuracy(int value)
    {
        acuracy = value;
    }
    public void SetAmo(int value)
    {
        amo = value;
    }
    public void SetMaxAmo(int value)
    {
        maxAmo = value;
    }
    public void SetCharger(int value)
    {
        charger = value;
    }
    public void SetRangeRadius(float value)
    {
        rangeRadius = value;
    }
    public void SetFireRate(float value)
    {
        fireRate = value;
    }
    public void SetFreezed(bool value)
    {
        isFreezed = value;
    }
    public void SetBurning(bool value)
    {
        isBurning = value;
    }
    public void SetPoisoned(bool value)
    {
        isPoisoned = value;
    }
    public void SetFacingRight(bool value)
    {
        facingRight = value;
    }

}
*/