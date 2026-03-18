namespace tp2;
using System;

class Program
{
    static void Main()
    {
        // 1. Créer trois comptes
        Compte compte1 = new Compte();
        Compte compte2 = new Compte();
        Compte compte3 = new Compte();

        // 2. Initialiser les propriétés de compte1
        compte1.SetNumero(1);
        compte1.SetNom("Alice");
        compte1.SetSolde(1000);

        // 3. Initialiser aussi compte2 et compte3
        compte2.SetNumero(2);
        compte2.SetNom("Bob");
        compte2.SetSolde(300);

        compte3.SetNumero(3);
        compte3.SetNom("Charlie");
        compte3.SetSolde(50);

        // 4. Afficher un en-tête puis tous les comptes
        Console.WriteLine("=== LISTE DES COMPTES ===");
        Compte[] comptes = { compte1, compte2, compte3 };

        foreach (Compte compte in comptes)
        {
            compte.Afficher();
        }

        // 5. Référence vs copie
        Compte compte4 = compte1;

        // 6. Créditer compte1 de 500 €
        Console.WriteLine();
        Console.WriteLine("=== REFERENCE VS COPIE ===");
        compte1.Crediter(500);

        Console.WriteLine("Après crédit de 500 sur compte1 :");
        Console.WriteLine("Solde compte1 : " + compte1.GetSolde());
        Console.WriteLine("Solde compte4 : " + compte4.GetSolde());

        // 7. Débiter compte4 de 100 €
        compte4.Debiter(100);

        Console.WriteLine("Après débit de 100 sur compte4 :");
        Console.WriteLine("Solde compte1 : " + compte1.GetSolde());
        Console.WriteLine("Solde compte4 : " + compte4.GetSolde());

        // 8. Observation
        Console.WriteLine();
        Console.WriteLine("Remarque : compte1 et compte4 désignent le même objet.");
        Console.WriteLine("Modifier l'un modifie donc aussi l'autre.");

        // 9 et 10. Contrôles et validations
        Console.WriteLine();
        Console.WriteLine("=== TESTS DE VALIDATION ===");

        compte2.Crediter(-50);   // refus
        compte2.Debiter(-30);    // refus

        // 11 et 12. Méthode de transfert
        Console.WriteLine();
        Console.WriteLine("=== TESTS DE TRANSFERT ===");

        Console.WriteLine("Avant transfert valide :");
        compte1.Afficher();
        compte2.Afficher();

        Compte.Transferer(compte1, compte2, 200);

        Console.WriteLine("Après transfert valide :");
        compte1.Afficher();
        compte2.Afficher();

        Console.WriteLine();
        Console.WriteLine("Test transfert refusé (solde insuffisant / découvert dépassé) :");
        Compte.Transferer(compte3, compte2, 500);

        Console.WriteLine();
        Console.WriteLine("Test transfert vers le même compte :");
        Compte.Transferer(compte2, compte2, 50);

        // 13 et 14. Test du découvert autorisé jusqu'à -200 €
        Console.WriteLine();
        Console.WriteLine("=== TEST DU DECOUVERT ===");

        Console.WriteLine("Avant débit :");
        compte3.Afficher();

        Console.WriteLine("Débit de 200 sur compte3 :");
        compte3.Debiter(200); // 50 - 200 = -150 => autorisé
        compte3.Afficher();

        Console.WriteLine("Débit de 100 sur compte3 :");
        compte3.Debiter(100); // -150 - 100 = -250 => refusé
        compte3.Afficher();

        // 15. Méthode Afficher() déjà utilisée
        Console.WriteLine();
        Console.WriteLine("=== AFFICHAGE FINAL ===");
        compte1.Afficher();
        compte2.Afficher();
        compte3.Afficher();
    }

    /*
    
    
    
    
    */
}