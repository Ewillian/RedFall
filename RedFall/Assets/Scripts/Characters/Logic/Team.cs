 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Team : List<Character>
{
    public const int MAX_SIZE = 4;

    public void AddMember(Character character)
    {
        if (this.Count == MAX_SIZE)
        {
            Debug.Log("Max team capacity. Can't add " + character.Name);
        }
        else
        {
            this.Add(character);
        }
    }

    public override string ToString()
    {
        string value = "The team is composed of:\r\n";
        foreach(Character character in this)
        {
            value += " - " + character.ToString() + "\r\n";
        }
        return value;
    }

}
