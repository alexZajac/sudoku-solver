using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Sudoku
{
    class Program
    {

        public static void Main(string[] args)
        {
            bool Again = true;
            while (Again)
            {
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                CentrerTexte("Bienvenue sur le résolveur de Sudoku !\n\n\n");
                CentrerTexte("De quelle manière voulez-vous procéder à la résolution ? \n\n\n");
                CentrerTexte("Veuillez sélectionner une des deux options à l'aide des flèches directionnelles puis appuyez sur Entrée. \n\n\n");
                Console.SetCursorPosition(18, 15);
                Console.WriteLine("Solution Naïve (POO)");
                Console.SetCursorPosition(80, 15);
                Console.WriteLine("Solution Récursive (Backtracking)");
                ConsoleKeyInfo cki = Console.ReadKey();
                bool choix1 = false;
                string Methode = "";
                while (!choix1)
                {
                    if (cki.Key != ConsoleKey.RightArrow && cki.Key != ConsoleKey.LeftArrow)
                    {
                        cki = Console.ReadKey();
                        while (cki.Key == ConsoleKey.LeftArrow && !choix1)
                        {
                            Console.SetCursorPosition(18, 15);
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Solution Naïve (POO)");
                            Console.SetCursorPosition(80, 15);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Solution Récursive (Backtracking)");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                choix1 = true;
                                Console.WriteLine("Backtracking");
                                Methode = "POO";
                            }
                        }
                        while (cki.Key == ConsoleKey.RightArrow && !choix1)
                        {
                            Console.SetCursorPosition(80, 15);
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Solution Récursive (Backtracking)");
                            Console.SetCursorPosition(18, 15);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Solution Naïve (POO)");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                choix1 = true;
                                Methode = "Backtracking";
                            }
                        }
                    }
                    else
                    {
                        while (cki.Key == ConsoleKey.LeftArrow)
                        {
                            Console.SetCursorPosition(18, 15);
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Solution Naïve (POO)");
                            Console.SetCursorPosition(80, 15);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Solution Récursive (Backtracking)");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                choix1 = true;
                                Methode = "POO";
                            }
                        }
                        while (cki.Key == ConsoleKey.RightArrow)
                        {
                            Console.SetCursorPosition(80, 15);
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Solution Récursive (Backtracking)");
                            Console.SetCursorPosition(18, 15);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Solution Naïve (POO)");
                            cki = Console.ReadKey();
                            if (cki.Key == ConsoleKey.Enter)
                            {
                                choix1 = true;
                                Methode = "Backtracking";
                            }
                        }
                    }
                }
                Console.Clear();
                if (Methode == "POO")
                {
                    CentrerTexte("Vous avez opté pour la méthode de Programmation orientée Objet. \n\n\n");
                }
                else
                {
                    CentrerTexte("Vous avez opté pour la méthode du Backtracking. \n\n\n");
                }
                CentrerTexte("Comment voulez-vous accéder à la grille ? ");
                Console.SetCursorPosition(18, 15);
                Console.WriteLine("Grille rentrée en dur");
                Console.SetCursorPosition(80, 15);
                Console.WriteLine("A partir d'un fichier");
                Console.WriteLine("\n\n\n");
                CentrerTexte("Veuillez sélectionner une des deux options à l'aide des flèches directionnelles puis appuyez sur Entrée. \n\n\n");
                CentrerTexte("La solution avec fichier implique que le fichier se trouve dans le repertoire bin/Debug du projet.");
                ConsoleKeyInfo cki2 = Console.ReadKey();
                bool choix2 = false;
                while (!choix2)
                {
                    if (cki2.Key != ConsoleKey.RightArrow && cki2.Key != ConsoleKey.LeftArrow)
                    {
                        cki2 = Console.ReadKey();
                        while (cki.Key == ConsoleKey.LeftArrow && !choix2)
                        {
                            Console.SetCursorPosition(18, 15);
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Grille rentrée en dur");
                            Console.SetCursorPosition(80, 15);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("A partir d'un fichier");
                            cki2 = Console.ReadKey();
                            if (cki2.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("\n\n\n");
                                CentrerTexte("Vous avez choisi l'importation en dur !");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                if (Methode == "POO")
                                {
                                    Console.Clear();
                                    SudokuNaïfPOOEnDur();
                                    choix2 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Attention ! Pour le backtracking, certaines grilles peuvent s'avérer très complexe et le programme peut prendre jusqu'à quelques minutes pour la résolution !");
                                    System.Threading.Thread.Sleep(5000);
                                    Console.Clear();
                                    SudokuBacktrackingEnDur();
                                    choix2 = true;
                                }
                            }
                        }
                        while (cki2.Key == ConsoleKey.RightArrow && !choix2)
                        {
                            Console.SetCursorPosition(18, 15);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Grille rentrée en dur");
                            Console.SetCursorPosition(80, 15);
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("A partir d'un fichier");
                            cki2 = Console.ReadKey();
                            if (cki2.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Clear();
                                Console.WriteLine("\n\n\n");
                                CentrerTexte("Vous avez choisi l'importation par fichier !");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                if (Methode == "POO")
                                {
                                    Console.Clear();
                                    SudokuNaïfPOOFichier();
                                    choix2 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Attention ! Pour le backtracking, certaines grilles peuvent s'avérer très complexe et le programme peut prendre jusqu'à une minute pour la résolution !");
                                    System.Threading.Thread.Sleep(5000);
                                    Console.Clear();
                                    SudokuBacktrackingFichier();
                                    choix2 = true;
                                }
                            }
                        }
                    }
                    else
                    {
                        while (cki2.Key == ConsoleKey.LeftArrow)
                        {
                            Console.SetCursorPosition(18, 15);
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("Grille rentrée en dur");
                            Console.SetCursorPosition(80, 15);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("A partir d'un fichier");
                            cki2 = Console.ReadKey();
                            if (cki2.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.WriteLine("\n\n\n");
                                CentrerTexte("Vous avez choisi l'importation en dur !");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                if (Methode == "POO")
                                {
                                    Console.Clear();
                                    SudokuNaïfPOOEnDur();
                                    choix2 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Attention ! Pour le backtracking, certaines grilles peuvent s'avérer très complexe et le programme peut prendre jusqu'à une minute pour la résolution !");
                                    System.Threading.Thread.Sleep(5000);
                                    Console.Clear();
                                    SudokuBacktrackingEnDur();
                                    choix2 = true;
                                }
                            }
                        }
                        while (cki2.Key == ConsoleKey.RightArrow)
                        {
                            Console.SetCursorPosition(18, 15);
                            Console.BackgroundColor = ConsoleColor.White;
                            Console.WriteLine("Grille rentrée en dur");
                            Console.SetCursorPosition(80, 15);
                            Console.BackgroundColor = ConsoleColor.Cyan;
                            Console.WriteLine("A partir d'un fichier");
                            cki2 = Console.ReadKey();
                            if (cki2.Key == ConsoleKey.Enter)
                            {
                                Console.Clear();
                                Console.ForegroundColor = ConsoleColor.Black;
                                Console.BackgroundColor = ConsoleColor.White;
                                Console.Clear();
                                Console.WriteLine("\n\n\n");
                                CentrerTexte("Vous avez choisi l'importation par fichier !");
                                System.Threading.Thread.Sleep(2000);
                                Console.Clear();
                                if (Methode == "POO")
                                {
                                    Console.Clear();
                                    SudokuNaïfPOOFichier();
                                    choix2 = true;
                                }
                                else
                                {
                                    Console.WriteLine("Attention ! Pour le backtracking, certaines grilles peuvent s'avérer très complexe et le programme peut prendre jusqu'à une minute pour la résolution !");
                                    System.Threading.Thread.Sleep(5000);
                                    Console.Clear();
                                    SudokuBacktrackingFichier();
                                    choix2 = true;
                                }
                            }
                        }
                    }
                }
                Again = false;
                string resultat = Console.ReadLine();
                if (resultat == "oui" || resultat == "Oui")
                {
                    Again = true;
                }
                else
                {
                    Again = false;
                }  
            }
        }

        // RENTREZ ICI LA GRILLE EN DUR POUR LA POO
        static void SudokuNaïfPOOEnDur()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            int[,] grilleEnDur =
             {
            {2,0,0,0,9,0,3,0,0},
            {0,1,9,0,8,0,0,7,4},
            {0,0,8,4,0,0,6,2,0},
            {5,9,0,6,2,1,0,0,0},
            {0,2,7,0,0,0,1,6,0},
            {0,0,0,5,7,4,0,9,3},
            {0,8,5,0,0,9,7,0,0},
            {9,3,0,0,5,0,8,4,0},
            {0,0,2,0,6,0,0,0,1}
                };
            Sudoku Grille = new Sudoku(grilleEnDur);
            Console.WriteLine("Voici la grille de départ : \n");
            Grille.ToSTring();
            Console.ForegroundColor = ConsoleColor.Black;
            Grille.Difficulte();
            Console.WriteLine("Appuyez sur une touche pour résoudre ce Sudoku !");
            Console.ReadKey();
            Sudoku Test = new Sudoku(grilleEnDur);
            int valeur = Test.CompteurResolution();
            if (valeur > 10000) // Chiffre impossible d'étapes, la grille est bloquéée et ne peut pas être résolue.
            {
                Console.WriteLine("Vous êtes en présence d'un cas très rare, la grille est trop compliquée pour le programme POO, essayez-la donc avec le Backtracking !");
            }
            else
            {
                Grille.Resolution(); // La méthode résolution de la classe sudoku va résoudre la grille.
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Voici la solution : \n\n");
                Console.WriteLine("Le nombre d'étapes nécéssaires à la résolution est de " + valeur + "\n\n.");
                Console.WriteLine("Bravo, vous êtes très rapide ! \n\n");
                Grille.EcritureFichier("Solution.csv"); // Le programme écrit la solution de la grille dans le fichier 'Solution.csv' du répertoire Sudoku\bin\Debug du projet. 
                Console.WriteLine("La solution à été écrite dans le ficher SolutionSudoku.csv situé dans le même répertoire que le fichier 'Sudoku.csv'.\n");
                Console.WriteLine("Merci d'avoir utilisé le résolveur de Sudoku ! \n\n");
                Console.WriteLine("D'ailleurs, voulez-vous recommencer ? \n");
            }
        } // Cette méthode contient toutes les étapes nécéssaires à la résolution d'une grille de Sudoku par la méthode de Programmation orientée objet à partie d'une grille rentrée en dur.

        static void SudokuNaïfPOOFichier()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            Sudoku Grille = new Sudoku("Sudoku.csv");
            Console.WriteLine("Voici la grille de départ : \n");
            Grille.ToSTring();
            Console.ForegroundColor = ConsoleColor.Black;
            Grille.Difficulte();
            Console.WriteLine("Appuyez sur une touche pour résoudre ce Sudoku !");
            Console.ReadKey();
            Sudoku Test = new Sudoku("Sudoku.csv");
            int valeur = Test.CompteurResolution();
            if (valeur > 10000) // Chiffre impossible d'étapes, la grille est bloquée et ne peut pas être résolue.
            {
                Console.WriteLine("Vous êtes en présence d'un cas très rare, la grille est trop compliquée pour le programme POO, essayez-la donc avec le Backtracking !");
            }
            else
            {
                Grille.Resolution(); // La méthode résolution de la classe sudoku va résoudre la grille.
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("Voici la solution : \n\n");
                Console.WriteLine("Le nombre d'étapes nécéssaires à la résolution est de " + valeur + "\n\n.");
                Console.WriteLine("Bravo, vous êtes très rapide ! \n\n");
                Grille.EcritureFichier("Solution.csv"); // Le programme écrit la solution de la grille dans le fichier 'Solution.csv' du répertoire Sudoku\bin\Debug du projet. 
                Console.WriteLine("La solution à été écrite dans le ficher SolutionSudoku.csv situé dans le même répertoire que le fichier 'Sudoku.csv'.\n");
                Console.WriteLine("Merci d'avoir utilisé le résolveur de Sudoku ! \n\n");
                Console.WriteLine("D'ailleurs, voulez-vous recommencer ? \n");
            }   
        } // Cette méthode contient toutes les étapes nécéssaires à la résolution d'une grille de Sudoku par la méthode de Programmation orientée objet à partir d'une grille d'un fichier.
        // RENTREZ ICI LA GRILLE EN DUR POUR LE BACKTRACKING
        static void SudokuBacktrackingEnDur() 
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;          
            int[,] grilleEnDur =
              {
            {2,0,0,0,9,0,3,0,0},
            {0,1,9,0,8,0,0,7,4},
            {0,0,8,4,0,0,6,2,0},
            {5,9,0,6,2,1,0,0,0},
            {0,2,7,0,0,0,1,6,0},
            {0,0,0,5,7,4,0,9,3},
            {0,8,5,0,0,9,7,0,0},
            {9,3,0,0,5,0,8,4,0},
            {0,0,2,0,6,0,0,0,1}
                };
            Console.WriteLine("Voici la grille de départ : \n");
            AfficherGrille(grilleEnDur);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Appuyez sur une touche pour résoudre ce Sudoku !");
            Console.ReadKey();
            Resolution(grilleEnDur, 0); // On commence à la première position, et on résoud la grille.
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Voici la solution : \n");
            AfficherGrille(grilleEnDur);
            Console.ForegroundColor = ConsoleColor.Black;

            Console.WriteLine("Bravo, vous êtes très rapide ! \n\n");
            RemplirFichier(grilleEnDur); // Le programme écrit la solution de la grille dans le fichier 'Solution.csv' du répertoire Sudoku\bin\Debug du projet. 
            Console.WriteLine("La solution à été écrite dans le ficher SolutionSudoku.csv situé dans le même répertoire que le fichier'Sudoku.csv'.\n");
            Console.WriteLine("Merci d'avoir utilisé le résolveur de Sudoku ! \n\n");
            Console.WriteLine("D'ailleurs, voulez-vous recommencer ? \n");
        } // Cette méthode contient toutes les étapes nécéssaires à la résolution d'une grille de Sudoku par la méthode du Backtracking à partie d'une grille rentrée en dur.

        static void SudokuBacktrackingFichier()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.White;
            int[,] grilleFichier = ConversionGrilleStringEnEntier(GrilleStringDuFichier(FluxLecture("Sudoku.csv"))); // Grille qui correspond à celle rentrée dans le fichier 'sudokufacile.csv', qui doit être contenu dans le répertoire Sudoku\bin\Debug du projet. On la convertit de string en entier car notre backtracking travaille avec des grille d'entiers.
            Console.WriteLine("Voici la grille de départ : \n");
            AfficherGrille(grilleFichier);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Appuyez sur une touche pour résoudre ce Sudoku !");
            Console.ReadKey();
            Resolution(grilleFichier, 0); // On commence à la première position, et on résoud la grille.
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Voici la solution : \n");
            AfficherGrille(grilleFichier);
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Bravo, vous êtes très rapide ! \n\n");
            RemplirFichier(grilleFichier); // Le programme écrit la solution de la grille dans le fichier 'Solution.csv' du répertoire Sudoku\bin\Debug du projet. 
            Console.WriteLine("La solution à été écrite dans le ficher SolutionSudoku.csv situé dans le même répertoire que le fichier'Sudoku.csv'.\n");
            Console.WriteLine("Merci d'avoir utilisé le résolveur de Sudoku ! \n\n");
            Console.WriteLine("D'ailleurs, voulez-vous recommencer ? \n");
        } // Cette méthode contient toutes les étapes nécéssaires à la résolution d'une grille de Sudoku par la méthode du Backtracking à partir d'une grille d'un fichier.

        static void CentrerTexte(string texte)
        {
            int nbEspaces = (Console.WindowWidth - texte.Length) / 2; // On mets à jour le nombre d'espaces nécéssaires au texte.
            Console.SetCursorPosition(nbEspaces, Console.CursorTop); //On mets le curseur à cette position
            Console.WriteLine(texte); // On affiche.
        }

        static void AfficherGrille(int[,] grille)
        {
            for (int ligne = 0; ligne < grille.GetLength(0); ligne++)
            {
                for (int colonne = 0; colonne < grille.GetLength(1); colonne++) // Parcours de ligne et colonne de la matrice rentrée en paramètre.
                {
                    if (grille[ligne,colonne] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;    
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                    }
                    Console.Write(grille[ligne, colonne]);
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.Write(" | ");
                }
                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Black;
                Console.WriteLine("-----------------------------------");
            }
        } // Cette méthode affiche la grille.

        static void RemplirFichier(int[,]GrilleSolution)
        {
            string valeur;
            try
            {
                StreamWriter flux = new StreamWriter("Solution.csv"); // Ouverture d'un flux en écriture.
                for (int i = 0; i < GrilleSolution.GetLength(0); i++)
                {
                    for (int j = 0; j < GrilleSolution.GetLength(1); j++)
                    {
                        valeur = GrilleSolution[i, j].ToString(); // On convertit l'entier contenu dans la grille de solution en string.
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

        static string[,] GrilleStringDuFichier(StreamReader fichier)
        {
            string ligne; //Variable temporaire qui nous servira pour la lecture du flux 'fichier'.
            string[] tab = new string[9]; // Cela correspond a chaque ligne de la grille (il y en a donc 9).
            string [,] grille = new string[9,9]; // retour de la méthode, un tableau de string contenant les valeurs du fichier passé en paramètre.
            char separateur = ';' ; // On définit l'élément qui va servir de séparateur au programme pour chaque case de la grille et le fichier étant un .csv, il s'agit de point-virgule.
            int i = 0; // ligne de la grille.
            try
            {
                while ((ligne = fichier.ReadLine()) != null && i<9) // Tant que le string lu du fichier n'est pas 'null' et que la ligne n'est pas supérieure à 9.
                {
                    tab = ligne.Split(separateur); //La ligne de la grille se mets à jour avec la première ligne de strings du fichier.
                    for (int j = 0;  j < tab.Length; j++)
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

        static int[,] ConversionGrilleStringEnEntier(string[,] GrilleStrings)
        {
            int[,] GrilleEntiers = new int[9, 9]; // On déclare une grille d'entier de la même taille que celle rentrée en paramètre.
            for (int i = 0; i < GrilleStrings.GetLength(0); i++)
            {
                for (int j = 0; j < GrilleStrings.GetLength(1); j++)
                {
                    GrilleEntiers[i, j] = int.Parse(GrilleStrings[i, j]); // On convertit chaque string en entier, en les stockant dans la nouvelle grille d'entiers.
                }
            }
            return GrilleEntiers;
        } // Cette méthode convertit une grille de strings en grille d'entiers.

        #region Backtracking

        static bool TestLigne(int valeur, int[,] grille, int ligne) //On teste si dans une ligne fixée de la grille avec laquelle nous travaillons, une valeur est présente.
        {
            bool estpresent = false;
            for (int colonne = 0; colonne < grille.GetLength(1); colonne++) // On fait donc varier les colonnes.
            {
                if (grille[ligne, colonne] == valeur) 
                {
                    estpresent = true;
                }
            }
            return estpresent;
        }

        static bool TestColonne(int valeur, int[,] grille, int colonne) //On teste si dans une colonne fixée de la grille avec laquelle nous travaillons, une valeur est présente.
        {
            bool estpresent = false;
            for (int ligne = 0; ligne < grille.GetLength(0); ligne++) // On fait donc varier les lignes.
            {
                if (grille[ligne, colonne] == valeur)
                {
                    estpresent = true;
                }
            }
            return estpresent;
        }

        static bool TestBloc(int valeur, int[,] grille, int ligne, int colonne) //On teste si dans une colonne fixée de la grille avec laquelle nous travaillons, une valeur est présente.
        {
            bool estpresent = false;
            int ligneBloc = ligne - (ligne % 3); // Pour n'importe quelle ligne, ligneBloc représente la première ligne de la region.
            int colonneBloc = colonne - (colonne % 3); // Pour n'importe quelle colonne, colonneBloc représente la première colonne de la region.
            for (int i = ligneBloc; i < ligneBloc + 3; i++) // On fait donc varier les lignes de la région.
            {
                for (int j = colonneBloc; j < colonneBloc + 3; j++) // Puis les colonnes.
                {
                    if (grille[i, j] == valeur)
                    {
                        estpresent = true;
                    }
                }
            }
            return estpresent;
        }

        static bool Resolution(int[,] grille, int position)
        {
            bool fin = false;
            if (position == 9 * 9) // Si la postion est a la fin de la grille de sudoku alors on a fini la résolution.
            {
                fin = true;
                
            }
            int i = position / 9; // On récupère les coordonnées de la case que l'on veut traiter.
            int j = position % 9; 
            
            if (!fin && grille[i, j] != 0) // Si la case est non-vide alors on appelle récursivement la méthode en incrémentant la position.
            {
                fin = Resolution(grille, position + 1); 
            }
 
            for (int valeurpossible = 1; valeurpossible <= 9 && !fin; valeurpossible++) // On teste des valeurs de 1 à 9 pour chaque case.
            {
                if (!TestLigne(valeurpossible, grille, i) && !TestColonne(valeurpossible, grille, j) && !TestBloc(valeurpossible, grille, i, j)) // S'il est possible de placer la valeur.
                {
                    grille[i,j] = valeurpossible; // On affecte cette valeur a la case.
                    Console.Clear(); // On enlève la grille précédente à l'affichage.
                    AfficherGrille(grille); // On affiche la grille.
                    System.Threading.Thread.Sleep(50); // On fixe un temps de latence afin que l'on puisse distinguer la différence entre la grille précédente et la grille actuelle.

                    if (Resolution(grille, position + 1)) // Si La position suivant est validée alors on sort de la boucle.
                    {
                        fin = true;
                    }        
                }
             
            }
            if (!fin)
            { grille[i, j] = 0; } // Si aucune des valeurs n'est possbiles alors on réinitialise la case à 0.
            return fin;
        } // On résoud la grille avec le backtracking.

        

        #endregion Backtracking
    }
}
