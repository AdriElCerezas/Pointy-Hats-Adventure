using UnityEngine;

[CreateAssetMenu(menuName = "Game/Stats")]
public class Stats : ScriptableObject
{
    //General
    public int life;
    public int baseSpeed;
    public int speed;
    public int baseDashSpeed;
    public int dashSpeed;
    public int acuracy;
    public int amo;
    public int maxAmo;
    public int charger;
    public float rangeRadius;
    public float fireRate;
    public bool isFreezed;
    public bool isBurning;
    public bool isPoisoned;
}