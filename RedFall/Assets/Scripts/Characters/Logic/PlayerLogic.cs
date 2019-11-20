using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : Character
{
    public Team team;

    public PlayerLogic(string name, Class playerClass)
    {
        this.Name = name;
        this.Class = playerClass;

        this.team = new Team();
        team.AddMember(this);
        team.AddMember(new NonPlayerLogic("Pat", Class.Wizard));
        team.AddMember(new NonPlayerLogic("John", Class.Priest));

        Debug.Log(team);
    }
    
}
