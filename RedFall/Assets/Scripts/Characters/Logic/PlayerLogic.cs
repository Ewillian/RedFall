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
        team.Add(this);
        team.Add(new NonPlayerLogic("Pat"));
        team.Add(new NonPlayerLogic("John"));

        foreach (Character character in this.team)
        {
            Debug.Log(character.Name);
        }
    }
    
}
