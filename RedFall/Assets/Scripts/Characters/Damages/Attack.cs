public abstract class Attack : Character
{

    public int Damages { get; set; }
    public bool SuccessRate { get; set; }

    public int damagesCalc()
    {
        Damages = Strenght;
        return Damages;
    }
    
    public override string ToString()
    {
        return  "Basic attack deal " + this.Damages + " !!!";
    }
}
