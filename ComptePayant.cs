class ComptePayant : Compte
{
    private double commission;
    private int nombreOperations;

    // Constructeur
    public ComptePayant(int numero, string nom, double solde, double commission)
        : base(numero, nom, solde)
    {
        this.commission = commission;
        this.nombreOperations = 0;
    }

    public ComptePayant()
    {
    }

    // Getters / Setters 
    public double GetCommission() 
    { 
        return commission; 
    }
    public void SetCommission(double commission)
    { 
        this.commission = commission; 
    }

    public int GetNombreOperations() 
    { 
        return nombreOperations; 
    }
    public void SetNombreOperations(int n) 
    { 
        nombreOperations = n; 
    }

    // Redéfinir les méthodes pour appliquer la commission et compter les opérations
    public override bool Crediter(double montant)
    {
        if (montant <= 0) return false;

        SetSolde(GetSolde() + montant - commission);
        nombreOperations++;
        return true;
    }

    public override bool Debiter(double montant)
    {
        if (montant <= 0) return false;

        if (GetSolde() - montant - commission < -200)
        {
            Console.WriteLine("Débit refusé : solde insuffisant pour Compte Payant.");
            return false;
        }

        SetSolde(GetSolde() - montant - commission);
        nombreOperations++;
        return true;
    }

    public override void Afficher()
    {
        Console.WriteLine($"{GetNumero()} / {GetNom()} / {GetSolde()} / Commission : {commission} / Opérations : {nombreOperations}");
    }
}