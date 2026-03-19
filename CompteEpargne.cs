class CompteEpargne : Compte
{
    private double tauxInteret;
    private DateTime dateOuverture;

    // Constructeur
    public CompteEpargne(int numero, string nom, double solde, double tauxInteret, DateTime dateOuverture)
        : base(numero, nom, solde)
    {
        this.tauxInteret = tauxInteret;
        this.dateOuverture = dateOuverture;
    }

    public CompteEpargne()
    {
    }

    // Getters / Setters spécifiques
    public double GetTauxInteret() 
    { 
        return tauxInteret;
    }
    public void SetTauxInteret(double taux) 
    { 
        this.tauxInteret = taux; 
    }

    public DateTime GetDateOuverture() 
    {
         return dateOuverture; 
    }
    public void SetDateOuverture(DateTime date)
    { 
        this.dateOuverture = date; 
    }

    // Redéfinir le débit pour interdire tout solde négatif
    public override bool Debiter(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Erreur : montant à débiter doit être positif.");
            return false;
        }

        if (GetSolde() - montant < 0)
        {
            Console.WriteLine("Débit refusé : solde insuffisant pour Compte Epargne.");
            return false;
        }

        SetSolde(GetSolde() - montant);
        return true;
    }

    public override void Afficher()
    {
        Console.WriteLine($"{GetNumero()} / {GetNom()} / {GetSolde()} / Taux : {tauxInteret} / Ouverture : {dateOuverture.ToShortDateString()}");
    }
}