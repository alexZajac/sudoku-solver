using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sudoku
{
    public class Sudoku
    {
        private Cellule[,] Grille = new Cellule[9, 9]; // Grille est donc une matrice de cellules.

        // CONSTRUCTEURS

        public Sudoku(int[,] grille) // Crée une instance de la classe Sudoku à partir d'une matrice (en dur).
        {
            for (int ligne = 0; ligne < grille.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < grille.GetLength(1); colonne++)
                {
                    this.Grille[ligne, colonne] = new Cellule(ligne, colonne, grille[ligne, colonne]); 
                }
            }
        }

        public Sudoku(string fichier) // Crée une instance de la classe Sudoku à partir d'un fichier.
        {
            StreamReader flux = new StreamReader(fichier); // Ouverture d'un fichier en lecture.
            string[,] TableauString = GrilleStringDuFichier(flux); // On accède à la grille d'un fichier et en retour on obtient cette même grille en strings.
            for (int ligne = 0; ligne < TableauString.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < TableauString.GetLength(1); colonne++)
                {
                    this.Grille[ligne, colonne] = new Cellule(ligne, colonne, Int32.Parse(TableauString[ligne, colonne])); // Conversion de chaque valeur string en int.
                }
            }
        }

        // PROPRIETE

        public Cellule[,] PropGrille
        {
            get { return Grille; }
            set { Grille = value; }
        }

        // METHODES

        public string ToSTring() // Cette méthode permet d'afficher la Grille.
        {
            string valeur = "";
            for (int ligne = 0; ligne < Grille.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < Grille.GetLength(1); colonne++)
                {
                    valeur = Grille[ligne, colonne].PropValeur.ToString(); // Convertit la valeur de chaque Cellule en string pour pouvoir l'afficher.
                    if (valeur == "0")
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(valeur);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("-----------------------------------");
            }
            return valeur;
        }

        public void EcritureFichier(string fichier)
        {
            string valeur = "";
            try
            {
                StreamWriter flux = new StreamWriter("Solution.csv"); // On ouvre un flux en écriture.
                for (int ligne = 0; ligne < Grille.GetLength(0); ligne++)
                {
                    for (int colonne = 0; colonne < Grille.GetLength(1); colonne++)
                    {
                        valeur = Grille[ligne, colonne].PropValeur.ToString(); // On convertit l'entier contenu dans la grille de solution en string.
                        flux.Write(valeur + ";"); // On l'écrit ensuite dans le fichier.
                    }
                    flux.WriteLine();
                }
                flux.Close();
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message); // Si le fichier n'est pas trouvé, on arrête le programme et on avertit l'utilisateur.
            }
        } // Cette méthode remplit un fichier externe en fonction d'une grille d'entiers.

        static StreamReader FluxLecture(string fichier)
        {
            StreamReader flux = null;
            try
            {
                flux = new StreamReader(fichier); // On ouvre un flux en lecture avec le fichier passé en paramètre.
            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine(e.Message); // Si le fichier n'est pas trouvé, on arrête le programme et on avertit l'utilisateur.
            }
            return flux;
        } // Cette méthode ouvre un flux en lecture à partir d'un fichier.

        public string[,] GrilleStringDuFichier(StreamReader fichier)
        {
            string ligne; //Variable temporaire qui nous servira pour la lecture du flux 'fichier'.
            string[] tab = new string[9]; // Cela correspond a chaque ligne de la grille (il y en a donc 9).
            string[,] grille = new string[9, 9]; // retour de la méthode, un tableau de string contenant les valeurs du fichier passé en paramètre.
            char separateur = ';'; // On définit l'élément qui va servir de séparateur au programme pour chaque case de la grille et le fichier étant un .csv, il s'agit de point-virgule.
            int i = 0; // ligne de la grille.
            try
            {
                while ((ligne = fichier.ReadLine()) != null && i < 9) // Tant que le string lu du fichier n'est pas 'null' et que la ligne n'est pas supérieure à 9.
                {
                    tab = ligne.Split(separateur); //La ligne de la grille se mets à jour avec la première ligne de strings du fichier.
                    for (int j = 0; j < tab.Length; j++)
                    {
                        grille[i, j] = tab[j]; //Etant que donné à chaque étape i est fixé, on affecte a chaque valeur de la grille d'une ligne considérée, la valeur du string du fichier, colonne par colonne. 
                    }
                    i++; //On passe à la ligne suivante.
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message); // S'il y a une erreur alors le programme rentre dans la boucle et s'arrête avec un message utilisateur.
            }
            finally
            {
                if (fichier != null) { fichier.Close(); } //On ferme le flux s'il n'est pas 'null'.
            }
            return grille;
        } // Cette méthode accède à la grille d'un fichier et retourne cette même grille en strings.

        #region Méthode 1

        public void RemplirCasesUnePossibilite() //algorithme qui consiste à remplir les cases qui ont un ensemble de valeurs possibles réduit à une seule valeur
        {
            int compteur;
            int position = 0;
            for (int ligne = 0; ligne < Grille.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < Grille.GetLength(1); colonne++)
                {
                    if (Grille[ligne, colonne].PropValeur == 0) // Si la valeur de la case est 0.
                    {
                        compteur = 0;
                        for (int IndexTabPossible = 0; IndexTabPossible < Grille[ligne, colonne].PropValPossibles.Length; IndexTabPossible++) // On parcours son champs des possibles.
                        {
                            if (Grille[ligne, colonne].PropValPossibles[IndexTabPossible] == 1) // Si une valeur est possible on incrémente le compteur et on stocke la position.
                            {
                                compteur++;
                                position = IndexTabPossible;
                            }
                            if (compteur == 1 && IndexTabPossible == Grille[ligne, colonne].PropValPossibles.Length - 1) // Si il n'y a qu'une valeur possible (compteur == 1), et on a fini le parcours du champs.
                            {
                                Grille[ligne, colonne].PropValeur = position + 1; // La case prend la valeur.
                            }
                        }
                    }
                }
            }
        }

        #endregion 

        #region Methode 2

        public void PrendreValeur()
        {
            for (int ligne = 0; ligne < Grille.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < Grille.GetLength(1); colonne++)
                {  
                    if (Grille[ligne, colonne].PropValeur == 0) // Pour chaque case nulle de la grille.
                    {
                        bool fin = false;
                        if (UneSeuleValeurLigne(ligne, colonne) != 0 && !fin) 
                        {
                            Grille[ligne, colonne].PropValeur = UneSeuleValeurLigne(ligne,colonne); // S'il n'y a qu'une valeur possible dans cette case, on la lui affecte.
                            Grille[ligne, colonne].Initialise(); // On réinitialise son champs de possibles.
                            fin = true; // On arrête les tests.
                        }
                        if (UneSeuleValeurColonne(ligne, colonne) != 0 && !fin)
                        {
                            Grille[ligne, colonne].PropValeur = UneSeuleValeurColonne(ligne, colonne); // S'il n'y a qu'une valeur possible dans cette case, on la lui affecte.
                            Grille[ligne, colonne].Initialise(); // On réinitialise son champs de possibles.
                            fin = true; // On arrête les tests.
                        }
                        if(UneSeuleValeurRegion(ligne, colonne) != 0 && !fin)
                        {
                            Grille[ligne, colonne].PropValeur = UneSeuleValeurRegion(ligne, colonne); // S'il n'y a qu'une valeur possible dans cette case, on la lui affecte.
                            Grille[ligne, colonne].Initialise(); // On réinitialise son champs de possibles.
                            fin = true; // On arrête les tests.
                        } // A chaque fois la condition !fin car si on a placé une valeur pour une certaine case, alors on ne peut plus en placer une autre.
                    }
                }
            }
        } //  Sur une même ligne, ou même colonne ou même région, si une valeur n’est possible que dans une seule case alors cette case prend cette valeur.

        public int UneSeuleValeurLigne(int ligne, int colonne)
        {
            int ValeurLigne = 0;
            int[] temp = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //Tableau qui nous serira a rechercher la valeur unique.
            for (int Parcourscolonne = 0; Parcourscolonne < Grille.GetLength(1); Parcourscolonne++)
            {
                if (Grille[ligne, Parcourscolonne].PropValeur == 0) // Pour chaque valeur nulle de la ligne.
                {
                    for (int i = 0; i < Grille[ligne, Parcourscolonne].PropValPossibles.Length; i++)
                    {
                        temp[i] += Grille[ligne, Parcourscolonne].PropValPossibles[i]; // On affecte les valeurs du champs des possibles de cette case à notre tableau.
                    }
                }
            }
            bool fin = false;
            for (int index = 0; index < temp.Length; index++)
            {
                if(temp[index] == 1) // S'il n'y a qu'une seule valeur possible.
                {
                    if(!LigneContientValeur(index+1, ligne) && !ColonneContientValeur(index+1, colonne) && !RegionContientValeur(index + 1,ligne, colonne) && !fin) // Et que cette valeur n'est ni sur la ligne, ni sur la colonne, ni dans la region et que nous n'avons pas déjà placé une valeur.
                    {
                        ValeurLigne = index + 1; // On retourne cette valeur unique.
                        fin = true;
                    }
                }
            }
            return ValeurLigne;
        } // Cette méthode recherche une éventuelle unique valeur possible dans une case par rapport à sa ligne (retourne 0 s'il n'y en pas).

        public int UneSeuleValeurColonne(int ligne, int colonne)
        {
            int ValeurColonne = 0;
            int[] temp = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //Tableau qui nous serira a rechercher la valeur unique.
            for (int Parcoursligne = 0; Parcoursligne < Grille.GetLength(0); Parcoursligne++)
            {
                if (Grille[Parcoursligne, colonne].PropValeur == 0) // Pour chaque valeur nulle de la colonne.
                {
                    for (int i = 0; i < Grille[Parcoursligne, colonne].PropValPossibles.Length; i++)
                    {
                        temp[i] += Grille[Parcoursligne, colonne].PropValPossibles[i]; // On affecte les valeurs du champs des possibles de cette case à notre tableau.
                    }
                }

            }
            bool fin = false;
            for (int index = 0; index < temp.Length; index++)
            {
                if (temp[index] == 1) // S'il n'y a qu'une seule valeur possible.
                {
                    if (!LigneContientValeur(index + 1, ligne) && !ColonneContientValeur(index + 1, colonne) && !RegionContientValeur(index + 1, ligne, colonne) && !fin) // Et que cette valeur n'est ni sur la ligne, ni sur la colonne, ni dans la region et que nous n'avons pas déjà placé une valeur.
                    {
                        ValeurColonne = index + 1; // On retourne cette valeur unique.
                        fin = true;
                    }
                }
            }
            return ValeurColonne;
        } // Cette méthode recherche une éventuelle unique valeur possible dans une case par rapport à sa colonne (retourne 0 s'il n'y en pas).

        public int UneSeuleValeurRegion(int ligne, int colonne)
        {
            int ValeurRegion = 0;
            int[] temp = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; //Tableau qui nous serira a rechercher la valeur unique.
            int ligneBloc = ligne - (ligne % 3);
            int colonneBloc = colonne - (colonne % 3);
            for (int i = ligneBloc; i < ligneBloc + 3; i++) // Parcours de région.
            {
                for (int j = colonneBloc; j < colonneBloc + 3; j++)
                {
                    if (Grille[i, j].PropValeur == 0) // Pour chaque valeur nulle de la région.
                    {
                        for (int index = 0; index < Grille[i, j].PropValPossibles.Length; index++)
                        {
                            temp[index] += Grille[i, j].PropValPossibles[index]; // On affecte les valeurs du champs des possibles de cette case à notre tableau.
                        }
                    }
                }
            }
            bool fin = false;
            for (int index = 0; index < temp.Length; index++)
            {
                if (temp[index] == 1) // S'il n'y a qu'une seule valeur possible.
                {
                    if (!LigneContientValeur(index + 1, ligne) && !ColonneContientValeur(index + 1, colonne) && !RegionContientValeur(index + 1, ligne, colonne) && !fin) // Et que cette valeur n'est ni sur la ligne, ni sur la colonne, ni dans la region et que nous n'avons pas déjà placé une valeur.
                    {
                        ValeurRegion = index + 1; // On retourne cette valeur unique.
                        fin = true;
                    }
                }
            }
            return ValeurRegion;
        } // Cette méthode recherche une éventuelle unique valeur possible dans une case par rapport à sa région (retourne 0 s'il n'y en pas).

        #endregion

        #region Methode 3

        public void Methode3() // Si 2 cases (sur la même ligne, ou même colonne ou même région) ont les 2 mêmes valeurs possibles a et b, alors si une 3ème case (sur la même ligne, ou même colonne ou même région) a ces 2 mêmes valeurs a et b plus une valeur c alors cette dernière case prendra la valeur c.

        {
            for (int ligne = 0; ligne < Grille.GetLength(0); ligne++) 
            {
                for (int colonne = 0; colonne < Grille.GetLength(1); colonne++)
                {
                    if (Grille[ligne, colonne].PropValeur == 0) // Pour chaque case nulle.
                    {
                        bool fin = false;
                        for (int i = 0; i < CellulesEgalesLigne(ligne, colonne).Length && !fin; i++) 
                        {
                            if (CellulesEgalesLigne(ligne, colonne)[i] != 0) // Si il y a des cases non nulles cela veut dire que les deux cellules sur la ligne comportent deux mêmes valeurs A et B.
                            {
                                int[] tab = RechercherCaseABCLigne(ligne, colonne, CellulesEgalesLigne(ligne, colonne)); // On crée un tableau contenant dans sa première case l'index de la case à changer et dans la deuxième la valeur à y inscrire. 
                                
                                if (tab[1] != 0) // Si la valeur à placer est non nulle, c'est qu'il existe bien une Cellule dont le champs comporte les valeurs A, B et C.
                                {
                                    Grille[ligne, tab[0]].PropValeur = tab[1]; // On affecte la valeur C à la case.
                                    Grille[ligne, tab[0]].Initialise(); // On réinitialise son champs des possbiles.
                                    fin = true;
                                }
                            }
                            if (CellulesEgalesColonne(ligne, colonne)[i] != 0) // Si il y a des cases non nulles cela veut dire que les deux cellules sur la ligne comportent deux mêmes valeurs A et B.
                            {
                                int[] tab = RechercherCaseABCColonne(ligne, colonne, CellulesEgalesColonne(ligne, colonne)); // On crée un tableau contenant dans sa première case l'index de la case à changer et dans la deuxième la valeur à y inscrire. 

                                if (tab[1] != 0) // Si la valeur à placer est non nulle, c'est qu'il existe bien une Cellule dont le champs comporte les valeurs A, B et C.
                                {
                                    Grille[tab[0], colonne].PropValeur = tab[1]; // On affecte la valeur C à la case.
                                    Grille[tab[0], colonne].Initialise(); // On réinitialise son champs des possbiles.
                                    fin = true;
                                }
                            }
                            if (CellulesEgalesRegion(ligne, colonne)[i] != 0) // Si il y a des cases non nulles cela veut dire que les deux cellules sur la ligne comportent deux mêmes valeurs A et B.
                            {
                                int[] tab = RechercherCaseABCRegion(ligne, colonne, CellulesEgalesRegion(ligne, colonne)); // On crée un tableau contenant dans sa première case l'index de la case à changer et dans la deuxième la valeur à y inscrire. 

                                if (tab[2] != 0) // Si la valeur à placer est non nulle, c'est qu'il existe bien une Cellule dont le champs comporte les valeurs A, B et C.
                                {
                                    Grille[tab[0], tab[1]].PropValeur = tab[2]; // On affecte la valeur C à la case.
                                    Grille[tab[0], tab[1]].Initialise(); // On réinitialise son champs des possbiles.
                                    fin = true;
                                }
                            }
                        }
                    }
                }
            }
        }

        public int[] CellulesEgalesLigne(int ligne, int colonne)
        {
            int[] res = { 0, 0, 0, 0, 0, 0, 0, 0, 0 }; // On parcours les colonnes pour une ligne fixée.
            for (int index = colonne; index < Grille.GetLength(1) - 1; index++)
            {
                if (Grille[ligne, colonne].Egal(Grille[ligne, index + 1])) // Si le champs de possibles de deux cases est égal (deux valeurs A et B).
                {
                    for (int i = 0; i < Grille[ligne, colonne].PropValPossibles.Length; i++)
                    {
                        res[i] = Grille[ligne, colonne].PropValPossibles[i]; // On retourne ce champs.
                    }
                }
            }
            return res;
        } // Si deux cellules ont le même champs des possibles avec deux valeurs A et B sur la même ligne, la méthode retourne ce champs.

        public int[] CellulesEgalesColonne(int ligne, int colonne)
        {
            int[] res = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            for (int index = ligne; index < Grille.GetLength(1) - 1; index++) // On parcours les lignes pour une colonne fixée.
            {
                if (Grille[ligne, colonne].Egal(Grille[index + 1, colonne])) // Si le champs de possibles de deux cases est égal (deux valeurs A et B).
                {
                    for (int i = 0; i < Grille[ligne, colonne].PropValPossibles.Length; i++)
                    {
                        res[i] = Grille[ligne, colonne].PropValPossibles[i]; // On retourne ce champs.
                    }
                }
            }
            return res;
        } // Si deux cellules ont le même champs des possibles avec deux valeurs A et B sur la même colonne, la méthode retourne ce champs.

        public int[] CellulesEgalesRegion(int ligne, int colonne)
        {
            int[] res = { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int ligneBloc = ligne - (ligne % 3);
            int colonneBloc = colonne - (colonne % 3);
            for (int i = ligneBloc; i < ligneBloc + 3; i++)
            {
                for (int j = colonneBloc; j < colonneBloc + 3; j++) // Parcours de région (vu précedemment).
                {
                    if (Grille[ligne, colonne].Egal(Grille[i, j]) && (i != ligne && j != colonne)) // Si le champs de possibles de deux cases est égal (deux valeurs A et B) et qu'il ne s'agit pas de la case courante.
                    {
                        for (int index = 0; index < Grille[ligne, colonne].PropValPossibles.Length; index++)
                        {
                            res[index] = Grille[ligne, colonne].PropValPossibles[index]; // On retourne ce champs.
                        }
                    }
                }
            }
            return res;
        } // Si deux cellules ont le même champs des possibles avec deux valeurs A et B dasn la même région, la méthode retourne ce champs.

        public int[] RechercherCaseABCLigne(int ligne, int colonne, int[] TabReference)
        {
            int[] tabRetour = { 0, 0 }; // Première valeur est l'index de la colonne de la case à modifier (la ligne étant fixée) et la deuxième est la valeur à placer dans cette-dernière.
            for (int index = colonne; index < Grille.GetLength(1) - 1; index++)
            {
                if (EgalPlusValeurC(Grille[ligne, index + 1], TabReference)) // Si il existe une case qui contient A et B + une SEULE valeur C dans son champs des possibles.
                {
                    tabRetour[0] = index + 1; // On mémorise son index.
                    for (int i = 0; i < Grille[ligne, index + 1].PropValPossibles.Length; i++)
                    {
                        if (Grille[ligne, index + 1].PropValPossibles[i] != TabReference[i]) // On recherche la valeur C.
                        {
                            int position = i;
                            tabRetour[1] = position + 1; // On l'affecte au tableau de retour.
                        }
                    }
                }
            }
            return tabRetour;
        } // Si il y a une cellule dont le champs des possibles contient A et B + une valeur C sur la même ligne, la méthode retourne un tableau dont la première valeur est l'index (colonne) de la case, et la deuxième valeur la valeur C à changer.

        public int[] RechercherCaseABCColonne(int ligne, int colonne, int[] TabReference)
        {
            int[] tabRetour = { 0, 0 }; // Première valeur est l'index de la colonne de la case à modifier (la ligne étant fixée) et la deuxième est la valeur à placer dans cette-dernière.
            for (int index = ligne; index < Grille.GetLength(1) - 1; index++)
            {
                if (EgalPlusValeurC(Grille[index + 1, colonne], TabReference)) // Si il existe une case qui contient A et B + une SEULE valeur C dans son champs des possibles.
                {
                    tabRetour[0] = index + 1; // On mémorise son index.
                    for (int i = 0; i < Grille[index + 1, colonne].PropValPossibles.Length; i++)
                    {
                        if (Grille[index + 1, colonne].PropValPossibles[i] != TabReference[i]) // On recherche la valeur C.
                        {
                            int position = i;
                            tabRetour[1] = position + 1; // On l'affecte au tableau de retour.
                        }
                    }
                }
            }
            return tabRetour;
        } // Si il y a une cellule dont le champs des possibles contient A et B + une valeur C sur la même colonne, la méthode retourne un tableau dont la première valeur est l'index (ligne) de la case, et la deuxième valeur la valeur C à changer.

        public int[] RechercherCaseABCRegion(int ligne, int colonne, int[] TabReference)
        {
            int[] tabRetour = { 0, 0, 0 }; // Première valeur est l'index de la ligne de la case à modifier, la deuxième est celle de l'index de la colonne, et la dernière est la valeur à placer dans la case considérée.
            int ligneBloc = ligne - (ligne % 3);
            int colonneBloc = colonne - (colonne % 3);
            for (int i = ligneBloc; i < ligneBloc + 3; i++)
            {
                for (int j = colonneBloc; j < colonneBloc + 3; j++)
                {
                    if (EgalPlusValeurC(Grille[ligneBloc, colonneBloc], TabReference)) // Si il existe une case qui contient A et B + une SEULE valeur C dans son champs des possibles.
                    {
                        tabRetour[0] = ligneBloc; // On mémorise sa ligne dans la région.
                        tabRetour[1] = colonneBloc; // On mémorise sa colonne dans la région.
                        for (int k = 0; k < Grille[ligneBloc, colonneBloc].PropValPossibles.Length; k++)
                        {
                            if (Grille[ligneBloc, colonneBloc].PropValPossibles[i] != TabReference[i]) // On recherche la valeur C.
                            {
                                int position = i;
                                tabRetour[2] = position + 1; // On l'affecte au tableau de retour.
                            }
                        }
                    }
                }
            }
            return tabRetour;
        } // Si il y a une cellule dont le champs des possibles contient A et B + une valeur C dans la même région, la méthode retourne un tableau dont la première valeur est l'index (ligne) de la case, la deuxième valeur l'index (colonne) de la case et la troisième la valeur C à changer.

        public bool EgalPlusValeurC(Cellule a, int[] tabref) // On compare le champs de possible d'une cellule avec un champs de possibles de référence contentant deux valeurs A et B, en espérant trouver une valeur C.
        {
            bool egal = false;
            int compteur = 0;
            int compteur2 = 0;
            for (int i = 0; i < tabref.Length; i++)
            {
                if (a.PropValPossibles[i] == tabref[i] && tabref[i] != 0)
                {
                    compteur++;
                }
                if (a.PropValPossibles[i] != tabref[i] && tabref[i] == 0)
                {
                    compteur2++;
                }
                if (compteur == 2 && i == tabref.Length - 1 && compteur2 == 1)
                {
                    egal = true;
                }
            }
            return egal;
        }

        #endregion

        #region Methode 4

        public void ReInitialiseTableauPossiblesAChaqueCellule()
        {
            for (int ligne = 0; ligne < Grille.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < Grille.GetLength(1); colonne++)
                {
                    Grille[ligne, colonne].Initialise(); // On initialise le champs des possibles avec la méthode de la classe Cellule. A noter que si la case possède la valeur 0, son champs des possibles est initialisé avec toutes les valeurs.
                    if (Grille[ligne, colonne].PropValeur == 0) // Justement, si la case vaut 0.
                    {
                        for (int IndexTabPossible = 0; IndexTabPossible < Grille[ligne, colonne].PropValPossibles.Length; IndexTabPossible++) // On parcours son champs de possibles.
                        {
                            if (LigneContientValeur(IndexTabPossible + 1, ligne) || ColonneContientValeur(IndexTabPossible + 1, colonne) || RegionContientValeur(IndexTabPossible + 1, ligne, colonne)) // Si la ligne, colonne ou region contient une valeur, alors on la supprime du champs des possibles de notre cellule courante.
                            {
                                Grille[ligne, colonne].SupprimeValeur(IndexTabPossible);
                            }
                        }
                    }
                }
            }
        } // Cette méthode réinitialise le champs des possibles de chaque case en fonction des valeurs 'fixes'.

        public bool LigneContientValeur(int valeur, int ligne)
        {
            bool res = false;
            for (int colonne = 0; colonne < Grille.GetLength(1); colonne++) // Ligne fixée on parcours la colonne.
            {
                if (Grille[ligne, colonne].PropValeur == valeur)
                {
                    res = true;
                }
            }
            return res;
        } // Cette méthode teste si une ligne fixée contient une certaine valeur.

        public bool ColonneContientValeur(int valeur, int colonne)
        {
            bool res = false;
            for (int ligne = 0; ligne < Grille.GetLength(0); ligne++) // Colonne fixée on parcours la ligne.
            {
                if (Grille[ligne, colonne].PropValeur == valeur)
                {
                    res = true;
                }
            }
            return res;
        } // Cette méthode teste si une colonne fixée contient une certaine valeur.

        public bool RegionContientValeur(int valeur, int ligne, int colonne)
        {
            bool estpresent = false;
            int ligneBloc = ligne - (ligne % 3); // Pour n'importe quelle ligne, ligneBloc représente la première ligne de la region.
            int colonneBloc = colonne - (colonne % 3); // Pour n'importe quelle colonne, colonneBloc représente la première colonne de la region.
            for (int i = ligneBloc; i < ligneBloc + 3; i++) // On parcours comme expliqué dans la classe Program, la région de la ligne et colonne courante.
            {
                for (int j = colonneBloc; j < colonneBloc + 3; j++)
                {
                    int ChiffreCellule = Grille[i, j].PropValeur;
                    if (ChiffreCellule == valeur)
                    {
                        estpresent = true;
                    }
                }
            }
            return estpresent;
        } // Cette méthode teste si une region fixée contient une certaine valeur.

        #endregion

        public bool Finie() // Cette méthode vérifie si la Grille est résolue.
        {
            bool finie = true;
            for (int ligne = 0; ligne < Grille.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < Grille.GetLength(1); colonne++)
                {
                    if (Grille[ligne, colonne].PropValeur == 0)
                    {
                        finie = false;
                    }
                }
            }
            return finie;
        }

        public void Resolution() // Cette méthode appelle toutes les autres afin de résoudre le sudoku.
        {
            do
            {
                Console.Clear();
                ReInitialiseTableauPossiblesAChaqueCellule(); // Méthode 4
                PrendreValeur(); // Méthode 2
                Methode3(); 
                RemplirCasesUnePossibilite(); // Méthode 1
                ToSTring();
                System.Threading.Thread.Sleep(1000);          
            }
            while (!Finie()); // Tant que la grille n'est pas complète, on continue.
            Console.Clear();
            ToSTring();
        }

        public int CompteurResolution() // Cette méthode appelle toutes les autres afin de résoudre le sudoku.
        {
            int compteur = 0;
            do
            {
                ReInitialiseTableauPossiblesAChaqueCellule(); // Méthode 4
                PrendreValeur(); // Méthode 2
                Methode3();
                RemplirCasesUnePossibilite(); // Méthode 1
                 
                compteur++;
            }
            while (!Finie()); // Tant que la grille n'est pas complète, on continue.
         
            return compteur; // On aura ainsi le nombre d'étapes.
        }

        public void Difficulte()
        {
            int compte = 0;
            for (int i = 0; i < Grille.GetLength(0); i++)
            {
                for (int j = 0; j < Grille.GetLength(0); j++)
                {
                    
                    if (Grille[i,j].PropValeur != 0)
                    {
                        compte++;
                    }
                }
            }
            if (compte < 17 )
            {
                Console.WriteLine("Cette grille n'est pas valide, sa résolution est impossible. \n\n");
            }
            if (compte > 17 && compte <= 26)
            {
                Console.WriteLine("Cette grille est de niveau diabolique, sa résolution ne sera pas évidente, voire impossible en POO.\n\n ");
            }
            if (compte > 26 && compte <= 33)
            {
                Console.WriteLine("Cette grille est de niveau difficile/moyen, mais sa résolution s'effectuera sans problèmes.\n\n ");
            }
            if (compte > 33)
            {
                Console.WriteLine("Cette grille est de niveau facile, sa résolution s'effectuera sans problèmes et très rapidement.\n\n ");
            }

        } // Plus il a de valeur au départ, plus le suddoku est censé être facile.

    }
}

