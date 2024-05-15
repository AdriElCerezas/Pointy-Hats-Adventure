using UnityEngine;

[CreateAssetMenu(menuName = "Game/Stats")]
public class Stats : ScriptableObject
{
    public int maxLife; //Hits que puede recibir
    public float baseSpeed; //Velocidad base
    public float speed; //Velocidad
    public float baseDashSpeed; //Dasheo base
    public float dashSpeed; //Dasheo
    public int acuracy; //Punteria (0 -> No da, 100 -> Muy precisa) 
    public float rangeRadius; //Quanto duran las balas hasta que despawnean
    public bool isFreezed; //Esta congelado
    public bool isBurning; //Esta quemado
    public bool isPoisoned; //Esta envenenado
}