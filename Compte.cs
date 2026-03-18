namespace tp2;
using System;

class Compte
{
    private int numero;
    private string nom;
    private double solde;

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

    public bool Crediter(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Erreur : le montant à créditer doit être strictement positif.");
            return false;
        }

        solde += montant;
        return true;
    }

    public bool Debiter(double montant)
    {
        if (montant <= 0)
        {
            Console.WriteLine("Erreur : le montant à débiter doit être strictement positif.");
            return false;
        }

        // Règle finale du sujet : découvert autorisé jusqu'à -200 €
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
        if (source == null || destination == null)
        {
            Console.WriteLine("Erreur : compte source ou destination invalide.");
            return false;
        }

        if (montant <= 0)
        {
            Console.WriteLine("Erreur : le montant du transfert doit être strictement positif.");
            return false;
        }

        if (source == destination)
        {
            Console.WriteLine("Erreur : transfert vers le même compte interdit.");
            return false;
        }

        bool debitOk = source.Debiter(montant);

        if (!debitOk)
        {
            Console.WriteLine("Erreur : transfert refusé car le débit a échoué.");
            return false;
        }

        bool creditOk = destination.Crediter(montant);

        if (!creditOk)
        {
            Console.WriteLine("Erreur : transfert refusé car le crédit a échoué.");
            return false;
        }

        return true;
    }

    public void Afficher()
    {
        Console.WriteLine(numero + " / " + nom + " / " + solde);
    }
}