using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : Character
{
    public Team team;

    public PlayerLogic(string name, Class playerClass , int Health_points , int Strenght)
    {
        
        this.Name = name;
        this.Class = playerClass;
        this.Health_points = Health_points;
        this.Mana_points = Mana_points;
        this.Strenght = Strenght;

        team = new Team();
        team.AddMember(this);
        team.AddMember(new NonPlayerLogic("Pat", Class.Wizard));
        team.AddMember(new NonPlayerLogic("John", Class.Priest));

        Debug.Log(team);
    }
    
}
