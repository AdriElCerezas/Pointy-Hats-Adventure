using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cyclops_Decision : DecisionMaker
{
    public override States Decide(States priviousState)
    {
        switch(priviousState)
        {
            case States.Idle:
                newState = IdleTo();
                break;
            case States.Chase:
                newState = ChaseTo();
                break;
        }
        return newState;
    }

    States IdleTo()
    {
        if(sm.choosenPlayer == null)
        {
            return States.Idle;
        }
        else if(Vector2.Distance(sm.choosenPlayer.transform.position, transform.position) <= 5 && sm.choosenPlayer != null)
        {
            return States.Chase;
        }
        else
        {
            return States.Idle;
        }
    }
    States ChaseTo()
    {
        if(Vector2.Distance(sm.choosenPlayer.transform.position, transform.position) >= 5 || sm.choosenPlayer == null)
        {
            return States.Idle;
        }
        else
        {
            return States.Chase;
        }
    }
}
