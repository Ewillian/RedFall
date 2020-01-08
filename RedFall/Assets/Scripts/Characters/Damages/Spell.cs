public abstract class Spell
{
    public string Name { get; set; }

    public int Damages { get; set; }
    public int ManaCost { get; set; }
    public bool SuccessRate { get; set; }



    public override string ToString()
    {
        return this.Name + " " + this.Damages + " (Mana Cost = " + this.ManaCost + ")";
    }
}
