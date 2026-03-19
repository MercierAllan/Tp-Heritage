class Compte
{
    private int numero;
    private string nom;
    private double solde;

    // Constructeur
    public Compte(int numero, string nom, double solde)
    {
        this.numero = numero;
        this.nom = nom;
        this.solde = solde;
    }
    public Compte()
    {
    }

    // Getters / Setters
    public int GetNumero() 
    { 
        return numero; 
    }
    public void SetNumero(int numero)
    {
        this.numero = numero; 
    }

    public string GetNom() 
    { 
        return nom; 
    }
    public void SetNom(string nom) 
    { 
        this.nom = nom; 
    }

    public double GetSolde() 
    { 
        return solde; 
    }
    public void SetSolde(double solde) 
    { 
        this.solde = solde; 
    }

    // Méthodes
    public virtual bool Crediter(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Erreur : montant à créditer doit être positif.");
            return false;
        }
        solde += montant;
        return true;
    }

    public virtual bool Debiter(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Erreur : montant à débiter doit être positif.");
            return false;
        }

        // Découvert autorisé jusqu'à -200 €
        if (solde - montant < -200)
        {
            Console.WriteLine("Erreur : débit refusé, découvert maximal dépassé.");
            return false;
        }

        solde -= montant;
        return true;
    }

    public static bool Transferer(Compte source, Compte destination, double montant)
    {
        if (source == null || destination == null || montant <= 0 || source == destination)
        {
            Console.WriteLine("Erreur transfert invalide");
            return false;
        }

        if (!source.Debiter(montant)) return false;
        if (!destination.Crediter(montant)) return false;

        return true;
    }

    public virtual void Afficher()
    {
        Console.WriteLine($"{numero} / {nom} / {solde}");
    }
}