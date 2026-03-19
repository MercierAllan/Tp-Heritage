class ComptePayant
{
    private int numero;
    private string nom;
    private double solde;

    private double commission;
    private int nombreOperations;

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
        this.nombreOperations = n; 
    }

    // Méthodes
    public bool Crediter(double montant)
    {
        if (montant <= 0) return false;

        solde += (montant - commission);
        nombreOperations++;
        return true;
    }

    public bool Debiter(double montant)
    {
        if (montant <= 0) return false;

        if (solde - montant - commission < -200)
        {
            Console.WriteLine("Débit refusé");
            return false;
        }

        solde -= (montant + commission);
        nombreOperations++;
        return true;
    }

    public void Afficher()
    {
        Console.WriteLine($"Compte Payant numero : {numero} - Titulaire : {nom} - Solde : {solde} euros - Commission : {commission} euros - Nombre d'opérations : {nombreOperations}");
    }
}