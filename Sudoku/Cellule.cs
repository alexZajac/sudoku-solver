using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sudoku
{
    public class Cellule
    {
        public int Valeur;
        private int[] ValPossibles = new int[9];
        private int ligne;
        private int colonne;

        // CONSTRUCTEUR

        public Cellule(int ligne, int colonne, int Valeur)
        {
            this.Valeur = Valeur;
            this.ligne = ligne;
            this.colonne = colonne;
        }

        // PROPRIETES

        public int[] PropValPossibles
        {
            get { return ValPossibles; }
            set { ValPossibles = value; }
        }

        public int Propligne
        {
            get { return ligne; }
        }

        public int Propcolonne
        {
            get { return colonne; }
        }

        public int PropValeur
        {
            get { return Valeur; }
            set { Valeur = value; }
        }

        // METHODES

        public string toString() // Retourne une chaîne de caractères caractérisant une cellule.
        {
            return "La case située à la ligne " + ligne + " et à la colonne " + colonne + "a pour valeur " + Valeur + "."; 
        }

        public void SupprimeValeur(int valeur) // Cette méthode sert a supprimer une valeur du champs des possibles.
        {    
                ValPossibles[valeur] = 0;   
        }

        public void AjouteValeur(int valeur) // Cette méthode sert a ajouter une valeur du champs des possibles.
        {
            ValPossibles[valeur] = 0;
        }

        public void Initialise() // Initialise le champs des possibles et le mets à jour.
        {
            if (Valeur != 0) // Si il ya une valeur dans la case
            {
                for (int i = 0; i < ValPossibles.Length; i++)
                {
                    if (i == Valeur - 1) // On réinitialise tout son champs de possibles à 0 sauf à l'index de la valeur en question.
                    {
                        ValPossibles[i] = 1;
                    }
                    else
                    {
                        ValPossibles[i] = 0;
                    }
                }
            }
            else
            {
                for (int i = 0; i < ValPossibles.Length; i++)
                {
                    ValPossibles[i] = 1;
                }
            }
        }

        public bool Egal(Cellule c) // On compare le champs des possibles de deux cellules, elle retourne true si il y a deux valeur A et B au même endroit dans le champs des possibles des deux cellules.
        {
            bool egal = false;
            bool CaseDifferentes = false;
            int compteur = 0;
            for (int i = 0; i < ValPossibles.Length; i++)
            {
                    if (c.PropValPossibles[i] == ValPossibles[i] && c.PropValPossibles[i] != 0) // Si les deux valeurs des champs sont égales et différentes de 0.
                    {
                        compteur++;
                    }
                    if (c.PropValPossibles[i] != ValPossibles[i]) // Si il y une valeur différente alors le champs des possibles est forcément différent.
                    {
                        CaseDifferentes = true;
                    }
                    if (compteur == 2 && i == ValPossibles.Length - 1 && !CaseDifferentes) // S'il y a deux valeurs possibles et que l'on a fini le parcours alors leurs champs sont considérés égaux.
                    {
                        egal = true;
                    }
            }
            return egal;
        }
    }
}
