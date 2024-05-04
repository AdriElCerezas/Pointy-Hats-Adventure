using UnityEngine;

[CreateAssetMenu(menuName = "Game/Stats")]
public class Stats : ScriptableObject
{
    public int maxLife; //Hits que puede recibir
    public int baseSpeed; //Velocidad base
    public int speed; //Velocidad
    public int baseDashSpeed; //Dasheo base
    public int dashSpeed; //Dasheo
    public int acuracy; //Punteria (0 -> No da, 100 -> Muy precisa) 
    public float rangeRadius; //Quanto duran las balas hasta que despawnean
    public bool isFreezed; //Esta congelado
    public bool isBurning; //Esta quemado
    public bool isPoisoned; //Esta envenenado
}