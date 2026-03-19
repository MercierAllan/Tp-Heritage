class CompteEpargne
{
    private int numero;
    private string nom;
    private double solde;

    private double tauxInteret;
    private DateTime dateOuverture;

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

    // Méthodes
    public bool Crediter(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Montant invalide");
            return false;
        }

        solde += montant;
        return true;
    }

    public bool Debiter(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Montant invalide");
            return false;
        }

        // PAS DE DÉCOUVERT
        if (solde - montant < 0)
        {
            Console.WriteLine("Débit refusé (pas de découvert)");
            return false;
        }

        solde -= montant;
        return true;
    }

    public void Afficher()
    {
        Console.WriteLine($"Compte Epargne numero : {numero} - Titulaire : {nom} - Solde : {solde} euros - Taux : {tauxInteret}% - Ouvert le : {dateOuverture.ToShortDateString()}");
    }
}