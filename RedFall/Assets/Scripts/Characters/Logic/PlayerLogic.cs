using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : Character
{
    public Team team;

    public PlayerLogic(string name)
    {
        this.Name = name;

        this.team = new Team();
        team.AddMember(this);
        team.AddMember(new NonPlayerLogic("Pat"));
        team.AddMember(new NonPlayerLogic("John"));

        Debug.Log(team);
    }
    
}
