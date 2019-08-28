using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sudoku;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestsUnitaires.Tests
{
    [TestClass()]
    public class Tests
    {

        static int[,] GrilleTests = {
            {2,0,0,0,9,0,3,0,0},
            {0,1,9,0,8,0,0,7,4},
            {0,0,8,4,0,0,6,2,0},
            {5,9,0,6,2,1,0,0,0},
            {0,2,7,0,0,0,1,5,0},
            {0,0,0,5,7,4,0,9,3},
            {0,8,5,0,0,9,7,0,0},
            {9,3,0,0,5,0,8,4,0},
            {0,0,2,0,6,0,0,0,1}
                };

        Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTests); // On crée une grille de la banque de classes Sudoku qui prend en paramètre la grille ci-dessus, elle nous servira pour les tests.

        [TestMethod()]
        public void UneSeuleValeurLigneTest_DoitReussir()
        {
            int[,] GrilleTest = {
            {1,2,3,4,5,6,7,8,0},
            {0,1,9,0,8,0,5,4,1},
            {0,0,8,4,0,0,6,3,2},
            {5,9,0,6,2,1,0,0,3},
            {0,2,7,0,0,0,1,6,4},
            {0,0,0,5,7,4,0,9,5},
            {0,8,5,0,0,9,7,0,6},
            {9,3,0,0,5,0,8,4,7},
            {0,0,2,0,6,0,0,0,8}
                }; // A noter que la grille n'est pas une réelle grille de sudoku mais peut être utilisée pour un test unitaire.
            Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTest);
            GrilleDeSudoku.ReInitialiseTableauPossiblesAChaqueCellule();
            Assert.AreEqual(GrilleDeSudoku.UneSeuleValeurLigne(0,8), 9); // Pour la ligne 0 et colonne 8, seule la valeur 9 est possible, on a bien 9 en paramètre, le test est réussi.
        }

        [TestMethod()]
        public void UneSeuleValeurLigneTest_DoitEchouer()
        {
            int[,] GrilleTest = {
            {1,2,3,4,5,6,7,8,0},
            {0,1,9,0,8,0,5,4,1},
            {0,0,8,4,0,0,6,3,2},
            {5,9,0,6,2,1,0,0,3},
            {0,2,7,0,0,0,1,6,4},
            {0,0,0,5,7,4,0,9,5},
            {0,8,5,0,0,9,7,0,6},
            {9,3,0,0,5,0,8,4,7},
            {0,0,2,0,6,0,0,0,8}
                }; // A noter que la grille n'est pas une réelle grille de sudoku mais peut être utilisée pour un test unitaire.
            Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTest);
            GrilleDeSudoku.ReInitialiseTableauPossiblesAChaqueCellule();
            Assert.AreEqual(GrilleDeSudoku.UneSeuleValeurLigne(0, 8), 5); // Pour la ligne 0 et colonne 8, seule la valeur 9 est possible, le test échoue à cause de la valeur 5 en paramètre.
        }

        [TestMethod()]
        public void UneSeuleValeurColonneTest_DoitReussir()
        {
            int[,] GrilleTest = {
            {1,2,3,4,5,6,7,8,0},
            {2,1,9,0,8,0,5,4,1},
            {3,0,8,4,0,0,6,3,2},
            {4,9,0,6,2,1,0,0,3},
            {5,2,7,0,0,0,1,6,4},
            {6,0,0,5,7,4,0,9,5},
            {7,4,5,0,0,9,7,0,6},
            {8,3,2,0,5,0,8,4,7},
            {0,6,1,6,5,4,3,2,1}
                }; // A noter que la grille n'est pas une réelle grille de sudoku mais peut être utilisée pour un test unitaire.
            Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTest);
            GrilleDeSudoku.ReInitialiseTableauPossiblesAChaqueCellule();
            Assert.AreEqual(GrilleDeSudoku.UneSeuleValeurColonne(8, 0), 9); // Pour la ligne 8 et colonne 0, seule la valeur 9 est possible, on a bien 9 en paramètre, le test est réussi.
        }

        [TestMethod()]
        public void UneSeuleValeurColonneTest_DoitEchouer()
        {
            int[,] GrilleTest = {
            {1,2,3,4,5,6,7,8,0},
            {2,1,9,0,8,0,5,4,1},
            {3,0,8,4,0,0,6,3,2},
            {4,9,0,6,2,1,0,0,3},
            {5,2,7,0,0,0,1,6,4},
            {6,0,0,5,7,4,0,9,5},
            {7,4,5,0,0,9,7,0,6},
            {8,3,2,0,5,0,8,4,7},
            {0,6,1,6,5,4,3,2,1}
                }; // A noter que la grille n'est pas une réelle grille de sudoku mais peut être utilisée pour un test unitaire.
            Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTest);
            GrilleDeSudoku.ReInitialiseTableauPossiblesAChaqueCellule();
            Assert.AreEqual(GrilleDeSudoku.UneSeuleValeurColonne(8, 0), 3); // Pour la ligne 8 et colonne 0, seule la valeur 9 est possible, le test échoue à cause de la valeur 3 en paramètre.
        }

        [TestMethod()]
        public void UneSeuleValeurRegionTest_DoitReussir()
        {
            int[,] GrilleTest = {
            {1,2,3,4,5,6,7,8,0},
            {4,5,6,0,8,0,5,4,1},
            {7,8,0,0,0,0,0,0,0},
            {0,0,0,6,2,1,0,0,3},
            {0,0,0,0,0,0,1,6,4},
            {6,0,0,5,7,4,0,9,5},
            {7,4,0,0,0,9,7,0,6},
            {8,3,0,0,5,0,8,4,7},
            {0,6,0,6,5,4,3,2,1}
                }; // A noter que la grille n'est pas une réelle grille de sudoku mais peut être utilisée pour un test unitaire.
            Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTest);
            GrilleDeSudoku.ReInitialiseTableauPossiblesAChaqueCellule();
            Assert.AreEqual(GrilleDeSudoku.UneSeuleValeurRegion(1, 1), 9); // Pour la ligne 1 et colonne 1, seule la valeur 9 est possible dans la région, on a bien 9 en paramètre, le test est réussi.
        }

        [TestMethod()]
        public void UneSeuleValeurRegionTest_DoitEchouer()
        {
            int[,] GrilleTest = {
            {1,2,3,4,5,6,7,8,0},
            {4,5,6,0,8,0,5,4,1},
            {7,8,0,4,0,0,6,3,2},
            {4,9,0,6,2,1,0,0,3},
            {5,2,7,0,0,0,1,6,4},
            {6,0,0,5,7,4,0,9,5},
            {7,4,5,0,0,9,7,0,6},
            {8,3,2,0,5,0,8,4,7},
            {0,6,1,6,5,4,3,2,1}
                }; // A noter que la grille n'est pas une réelle grille de sudoku mais peut être utilisée pour un test unitaire.
            Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTest);
            GrilleDeSudoku.ReInitialiseTableauPossiblesAChaqueCellule();
            Assert.AreEqual(GrilleDeSudoku.UneSeuleValeurRegion(1, 1), 7); // Pour la ligne 1 et colonne 1, seule la valeur 9 est possible dans la région, le test échoue à cause de la valeur 7 en paramètre.
        }

        [TestMethod()]
        public void Egal_DoitReussir()
        {
            Sudoku.Cellule Case1 = new Sudoku.Cellule(0, 0, 0);
            Sudoku.Cellule Case2 = new Sudoku.Cellule(0, 0, 1); // On crée deux cellules.
            for (int i = 0; i < Case1.PropValPossibles.Length; i++) // On initialise les champs avec des 0.
            { 
                Case1.PropValPossibles[i] = 0;
                Case2.PropValPossibles[i] = 0;
            }
            Case1.PropValPossibles[0] = 1;
            Case1.PropValPossibles[2] = 1; // Champs des possibles de Case1 : {1,0,1,0,0,0,0,0,0}
            Case2.PropValPossibles[0] = 1;
            Case2.PropValPossibles[2] = 1;  // Champs des possibles de Case2 : {1,0,1,0,0,0,0,0,0}
            Assert.IsTrue(Case1.Egal(Case2)); // Les cases ont le même champs de possibles, le test est réussi.
        }

        [TestMethod()]
        public void Egal_DoitEchouer()
        {
            Sudoku.Cellule Case1 = new Sudoku.Cellule(0, 0, 0);
            Sudoku.Cellule Case2 = new Sudoku.Cellule(0, 0, 1); // On crée deux cellules.
            for (int i = 0; i < Case1.PropValPossibles.Length; i++) // On initialise les champs avec des 0.
            {
                Case1.PropValPossibles[i] = 0;
                Case2.PropValPossibles[i] = 0;
            }
            Case1.PropValPossibles[0] = 1;
            Case1.PropValPossibles[2] = 0; // Champs des possibles de Case1 : {1,0,0,0,0,0,0,0,0}
            Case2.PropValPossibles[0] = 1;
            Case2.PropValPossibles[2] = 1; // Champs des possibles de Case1 : {1,0,1,0,0,0,0,0,0}
            Assert.IsTrue(Case1.Egal(Case2)); // Les cases ont un champs des possibles différent, le test est un échec.
        }

        [TestMethod()]
        public void EgalPlusValeurCTest_DoitReussir()
        {
            int[] TabRef = { 1, 0, 0, 0, 0, 1, 0, 0, 0 }; 
            int[,] GrilleTest = {
            {1,2,3,4,5,6,7,8,0},
            {4,5,6,0,8,0,5,4,1},
            {7,8,0,4,0,0,6,3,2},
            {4,9,0,6,2,1,0,0,3},
            {5,2,7,0,0,0,1,6,4},
            {6,0,0,5,7,4,0,9,5},
            {7,4,5,0,0,9,7,0,6},
            {8,3,2,0,5,0,8,4,7},
            {0,6,1,6,5,4,3,2,1}
                }; // A noter que la grille n'est pas une réelle grille de sudoku mais peut être utilisée pour un test unitaire.
            Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTest);
            Sudoku.Cellule Case = new Sudoku.Cellule(0,0,0);
            for (int i = 1; i < Case.PropValPossibles.Length; i++)
            {
                Case.PropValPossibles[i] = 0;
            }
            Case.PropValPossibles[0] = 1;
            Case.PropValPossibles[5] = 1;
            Case.PropValPossibles[6] = 1; // Toutes les valeurs du champs de de la case sont nulles sauf 3, dont deux qui correspond à celles non nulles dans le tableau de reférence.
            Assert.IsTrue(GrilleDeSudoku.EgalPlusValeurC(Case,TabRef)); // Donc le test réussi, il n'y a qu'une seule valeur C en plus de A et B.
        } 

        [TestMethod()]
        public void EgalPlusValeurCTest_DoitEchouer()
        {
            int[] TabRef = { 1, 0, 0, 0, 0, 1, 0, 0, 0 };
            int[,] GrilleTest = {
            {1,2,3,4,5,6,7,8,0},
            {4,5,6,0,8,0,5,4,1},
            {7,8,0,4,0,0,6,3,2},
            {4,9,0,6,2,1,0,0,3},
            {5,2,7,0,0,0,1,6,4},
            {6,0,0,5,7,4,0,9,5},
            {7,4,5,0,0,9,7,0,6},
            {8,3,2,0,5,0,8,4,7},
            {0,6,1,6,5,4,3,2,1}
                }; // A noter que la grille n'est pas une réelle grille de sudoku mais peut être utilisée pour un test unitaire.
            Sudoku.Sudoku GrilleDeSudoku = new Sudoku.Sudoku(GrilleTest);
            Sudoku.Cellule Case = new Sudoku.Cellule(0, 0, 0);
            for (int i = 0; i < Case.PropValPossibles.Length; i++)
            {
                Case.PropValPossibles[i] = 1;
            }
            // Toutes les valeurs du champs de de la case sont vallent 1.
            Assert.IsTrue(GrilleDeSudoku.EgalPlusValeurC(Case, TabRef)); // Donc le champs contient A et B mais aussi pleins d'autres valeurs, le test échoue.
        }

        [TestMethod()]
        public void LigneContientValeurTest_DoitReussir()
        { 
            Assert.IsTrue(GrilleDeSudoku.LigneContientValeur(3, 0)); // La ligne 0 contient bien la valeur 3, le test est réussi.
        }

        [TestMethod()]
        public void ColonneContientValeurTest_DoitReussir()
        {
            Assert.IsTrue(GrilleDeSudoku.ColonneContientValeur(9, 2)); // La colonnne 2 contient bien la valeur 9, le test est réussi.
        }

        [TestMethod()]
        public void RegionContientValeurTest_DoitReussir()
        {
            Assert.IsTrue(GrilleDeSudoku.RegionContientValeur(8, 2, 4)); // La ligne 2 colonne 4 contiennent bien la valeur 8, le test est réussi.
        }

        [TestMethod()]
        public void LigneContientValeurTest_DoitEchouer()
        {
            Assert.IsTrue(GrilleDeSudoku.LigneContientValeur(4, 0)); // La ligne 0 ne contient pas la valeur 4, le test échoue.
        }

        [TestMethod()]
        public void ColonneContientValeurTest_DoitEchouer()
        {
            Assert.IsTrue(GrilleDeSudoku.ColonneContientValeur(5, 5)); // La colonne 5 ne contient pas la valeur 5, le test échoue.
        }

        [TestMethod()]
        public void RegionContientValeurTest_DoitEchouer()
        {
            Assert.IsTrue(GrilleDeSudoku.RegionContientValeur(7, 2, 4)); // La ligne 2 colonne 4 ne contiennent pas la valeur 7, le test échoue.
        }

    }
}