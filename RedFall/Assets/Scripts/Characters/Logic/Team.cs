using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : List<Character>
{
    private const int MAX_TEAM_SIZE = 4;

    public bool AddMember(Character character)
    {
        if (this.Count == MAX_TEAM_SIZE)
        {
            Debug.Log("Max team capacity. Can't add " + character.Name);
            return false;
        }
        else
        {
            this.Add(character);
            return true;
        }
    }

    public override string ToString()
    {
        string value = "The team is composed of:\r\n";
        foreach (Character character in this)
        {
            value += " - " + character.ToString() + "\r\n";
        }
        return value;
    }

}
