using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;

namespace Battleships
{
    internal class Program
    {
        static (char[,], int, int, string, string) PlayersTurn(ref char[,] computersField, ref int sRow, ref int sCollumn, ref string shotType, ref string shotDirection)
        { 
            Console.WriteLine("S: STANDARD SHOT   B: BOMB (3x3 cross shape)   L: LONG BOMBARDING (2x1)");
            shotType = Console.ReadLine();
            while (shotType != "S" && shotType != "B" && shotType != "L") //DODELAT ZE MUZE SPECIAL ABILITKY POUZIT JEN JEDNOU + artillery
            {
                Console.WriteLine("enter a valid statement");
                shotType = Console.ReadLine();
            }
            if (shotType == "S")
            {
                Console.WriteLine("Select a row 0 - 9");
                string selectedRow = Console.ReadLine();
                while (!int.TryParse(selectedRow, out sRow) || sRow > 9 || sRow < 0)
                {
                    Console.WriteLine("enter a valid statement");
                    selectedRow = Console.ReadLine();
                }
                Console.WriteLine("Select a collumn 0 - 9");
                string selectedCollumn = Console.ReadLine();
                while (!int.TryParse(selectedCollumn, out sCollumn) || sCollumn > 9 || sCollumn < 0)
                {
                    Console.WriteLine("enter a valid statement");
                    selectedCollumn = Console.ReadLine();
                }
            }
            else if (shotType == "B")
            {
                Console.WriteLine("you will now be selecting coordinates for the middle of the cross");
                Console.WriteLine("Select a row 0 - 9");
                string selectedRow = Console.ReadLine();
                while (!int.TryParse(selectedRow, out sRow) || sRow > 9 || sRow < 0)
                {
                    Console.WriteLine("enter a valid statement");
                    selectedRow = Console.ReadLine();
                }
                Console.WriteLine("Select a collumn 0 - 9");
                string selectedCollumn = Console.ReadLine();
                while (!int.TryParse(selectedCollumn, out sCollumn) || sCollumn > 9 || sCollumn < 0)
                {
                    Console.WriteLine("enter a valid statement");
                    selectedCollumn = Console.ReadLine();
                }
            }
            else if (shotType == "L")
            {
                Console.WriteLine("you will now be selecting coordinates for the bottom left of the shot");
                Console.WriteLine("Select a row 0 - 9");
                string selectedRow = Console.ReadLine();
                while (!int.TryParse(selectedRow, out sRow) || sRow > 9 || sRow < 0)
                {
                    Console.WriteLine("enter a valid statement");
                    selectedRow = Console.ReadLine();
                }
                Console.WriteLine("Select a collumn 0 - 9");
                string selectedCollumn = Console.ReadLine();
                while (!int.TryParse(selectedCollumn, out sCollumn) || sCollumn > 9 || sCollumn < 0)
                {
                    Console.WriteLine("enter a valid statement");
                    selectedCollumn = Console.ReadLine();
                }
                Console.WriteLine("Select direction: vertically/horizontally");
                shotDirection = Console.ReadLine();
                while (shotDirection != "vertically" && shotDirection != "horizontally")
                {
                    Console.WriteLine("enter a valid statement");
                    shotDirection = Console.ReadLine();
                }

            }
            return (computersField, sRow, sCollumn, shotType, shotDirection);
        }

        static (char[,], int, int, bool, int) ComputersTurn(char[,] playersField, string difficulty, ref int cRow, ref int cCollumn, ref bool computerWon, ref int shipsHit)
        {
            int cRowLower = cRow;
            int cRowUpper = cRow;
            int cCollumnLower = cCollumn;
            int cCollumnUpper = cCollumn;

            Random r = new Random();
            if (difficulty == "noob")
            {
                cRow = r.Next(0, 10);
                cCollumn = r.Next(0, 10);
                if (playersField[cRow, cCollumn] == Convert.ToChar("X")) //hit
                {
                    playersField[cRow, cCollumn] = Convert.ToChar("O");
                    shipsHit++;
                }
                else //miss
                {
                    playersField[cRow, cCollumn] = Convert.ToChar("M");
                }
            }
            else if (difficulty == "pro")
            {
                bool computerValidhit = false;

                if (playersField[cRow, cCollumn] == Convert.ToChar("O")) //last turn hit
                {
                    while (!computerValidhit)
                    {
                        if (cRow - 1 < 0) cRowLower = cRow;
                        else cRowLower = cRow - 1;
                        if (cRow + 1 > 9) cRowUpper = cRow;
                        else cRowUpper = cRow + 1;
                        cRow = r.Next(cRowLower, cRowUpper + 1);
                        if (cCollumn - 1 < 0) cCollumnLower = cCollumn;
                        else cCollumnLower = cCollumnLower - 1;
                        if (cCollumnUpper + 1 > 9) cCollumnUpper = cCollumn;
                        else cCollumnUpper = cCollumn + 1;
                        cCollumn = r.Next(cCollumnLower, cCollumnUpper + 1);
                        if (playersField[cRow, cCollumn] == Convert.ToChar("-"))
                        {
                            playersField[cRow, cCollumn] = Convert.ToChar("M");
                            computerValidhit = true;
                        }
                        else if (playersField[cRow, cCollumn] == Convert.ToChar("X"))
                        {
                            playersField[cRow, cCollumn] = Convert.ToChar("O");
                            computerValidhit = true;
                            shipsHit++;
                        }
                    }
                }
                else //last hit byl miss
                {
                    while (!computerValidhit)
                    {
                        cRow = r.Next(0, 10);
                        cCollumn = r.Next(0, 10);
                        if (playersField[cRow, cCollumn] == Convert.ToChar("X")) //hit
                        {
                            playersField[cRow, cCollumn] = Convert.ToChar("O");
                            computerValidhit = true;
                            shipsHit++;
                        }
                        else if (playersField[cRow, cCollumn] == Convert.ToChar("-"))
                        {
                            playersField[cRow, cCollumn] = Convert.ToChar("M");
                            computerValidhit = true;
                        }
                    }
                }
            }
            else //impossible diff
            {
                bool computerValidhit = false;

                if (playersField[cRow, cCollumn] == Convert.ToChar("O")) //last turn hit
                {
                    while (!computerValidhit)
                    {
                        cRow = r.Next(0, 10);
                        cCollumn = r.Next(0, 10);
                        if (playersField[cRow, cCollumn] == Convert.ToChar("X"))
                        {
                            playersField[cRow, cCollumn] = Convert.ToChar("O");
                            computerValidhit = true;
                            shipsHit++;
                        }
                    }
                }
                else //last hit byl miss (v tomhle pripade pro prvni turn)
                {
                    while (!computerValidhit)
                    {
                        cRow = r.Next(0, 10);
                        cCollumn = r.Next(0, 10);
                        if (playersField[cRow, cCollumn] == Convert.ToChar("X")) //hit
                        {
                            playersField[cRow, cCollumn] = Convert.ToChar("O");
                            computerValidhit = true;
                            shipsHit++;
                        }
                    }

                }
            }
                if (shipsHit > 16) computerWon = true;
                return (playersField, cRow, cCollumn, computerWon, shipsHit);
            
        }

        static void PlayerEditedFieldPrint(char[,] playersFieldToPrint)
        {
            Console.WriteLine("This is your battlefield now:");
            for (int i = 0; i < playersFieldToPrint.GetLength(0); i++) //i jsou radky
            {
                for (int j = 0; j < playersFieldToPrint.GetLength(1); j++) //j jsou sloupce
                {
                    Console.Write(playersFieldToPrint[i, j] + " ");
                }
                Console.WriteLine("");
            }
        }

        static bool ComputerEditedFieldPrint(char[,] computersFieldToPrint, char[,] computersField, int sRow, int sCollumn, string shotType, string shotDirection, ref bool playerWon, ref int shipsHit)
        {
            string hit = "O";
            string miss = "M";
            int sRowBLower = sRow-1; //promenne pro ochraneni, aby mi nepresahovala bomba B hranice pole
            int sRowBUpper = sRow + 1;
            int sCollumnBLower = sCollumn-1;
            int sCollumnBUpper = sCollumn + 1;
            if (sRowBLower < 0) sRowBLower = sRow;
            else if (sRowBUpper > 9) sRowBUpper = sRow;
            if (sCollumnBLower < 0) sCollumnBLower = sCollumn;
            else if (sCollumnBUpper > 9) sCollumnBUpper = sCollumn;
            while (computersFieldToPrint[sRow, sCollumn] == Convert.ToChar("O") || computersFieldToPrint[sRow, sCollumn] == Convert.ToChar("M"))
            {
                Console.WriteLine("You are shooting to a spot you already shot at, you muppet. Try again:");
                Console.WriteLine("Select a new spot:");
                PlayersTurn(ref computersField, ref sRow, ref sCollumn, ref shotType, ref shotDirection);
                
            }
            Console.WriteLine("This is the computers current battlefield:");
            Console.WriteLine("");
            if (shotType == "S")
            {
                if (computersField[sRow, sCollumn] == Convert.ToChar("X"))
                {
                    computersFieldToPrint[sRow, sCollumn] = Convert.ToChar(hit);
                }
                else
                {
                    computersFieldToPrint[sRow, sCollumn] = Convert.ToChar(miss);
                }
                for (int i = 0; i < computersFieldToPrint.GetLength(0); i++) //i jsou radky
                {
                    for (int j = 0; j < computersFieldToPrint.GetLength(1); j++) //j jsou sloupce
                    {
                        Console.Write(computersFieldToPrint[i, j] + " ");
                    }
                    Console.WriteLine("");
                }
            }
            else if (shotType == "B")
            {
                for(int i = sRowBLower; i <= sRowBUpper; i++)
                {
                    
                    
                    if (computersField[i, sCollumn] == Convert.ToChar("X"))
                    {
                        computersFieldToPrint[i, sCollumn] = Convert.ToChar(hit);
                            shipsHit++;
                    }
                    else
                    {
                        computersFieldToPrint[i, sCollumn] = Convert.ToChar(miss);
                    }
                    
                }
                for (int i = sCollumnBLower; i <= sCollumnBUpper; i++)
                {
                     
                     
                    if (computersField[sRow, i] == Convert.ToChar("X"))
                    {
                        computersFieldToPrint[sRow, i] = Convert.ToChar(hit);
                            shipsHit++;
                        }
                    else
                    {
                        computersFieldToPrint[sRow, i] = Convert.ToChar(miss);
                    }
                    
                }
                for (int i = 0; i < computersFieldToPrint.GetLength(0); i++) //i jsou radky
                {
                    for (int j = 0; j < computersFieldToPrint.GetLength(1); j++) //j jsou sloupce
                    {
                        Console.Write(computersFieldToPrint[i, j] + " ");
                    }
                    Console.WriteLine("");
                }
            }
            else if (shotType == "L")
            {
                if (shotDirection == "vertically")
                {
                    if (computersField[sRow, sCollumn] == Convert.ToChar("X"))
                    {
                        computersFieldToPrint[sRow, sCollumn] = Convert.ToChar(hit);
                            shipsHit++;
                        }
                    else
                    {
                        computersFieldToPrint[sRow, sCollumn] = Convert.ToChar(miss);
                    }
                    if(sRow -1 <= 0)
                    {
                    }
                    else 
                    { 
                    if (computersField[sRow-1, sCollumn] == Convert.ToChar("X"))
                    {
                        computersFieldToPrint[sRow-1, sCollumn] = Convert.ToChar(hit);
                                shipsHit++;
                    }
                    else
                    {
                        computersFieldToPrint[sRow-1, sCollumn] = Convert.ToChar(miss);
                    }
                    }
                }
                else if (shotDirection == "horizontally")
                {
                    if (computersField[sRow, sCollumn] == Convert.ToChar("X"))
                    {
                        computersFieldToPrint[sRow, sCollumn] = Convert.ToChar(hit);
                            shipsHit++;
                        }
                    else
                    {
                        computersFieldToPrint[sRow, sCollumn] = Convert.ToChar(miss);
                    }

                    if(sCollumn +1 > 9)
                    {
                    }
                    else 
                    { 
                    if (computersField[sRow, sCollumn+1] == Convert.ToChar("X"))
                    {
                        computersFieldToPrint[sRow, sCollumn+1] = Convert.ToChar(hit);
                                shipsHit++;
                            }
                    else
                    {
                        computersFieldToPrint[sRow, sCollumn+1] = Convert.ToChar(miss);
                    }
                    }
                }
                for (int i = 0; i < computersFieldToPrint.GetLength(0); i++) //i jsou radky
                {
                    for (int j = 0; j < computersFieldToPrint.GetLength(1); j++) //j jsou sloupce
                    {
                        Console.Write(computersFieldToPrint[i, j] + " ");
                    }
                    Console.WriteLine("");
                }
            }
            if (shipsHit > 16) playerWon = true;
            return playerWon;
        }

        static void PlayerFieldPrint(char[,] currentField)
        {
            Console.WriteLine("This is your current battlefield:");
            Console.WriteLine("");
            for (int i = 0; i < currentField.GetLength(0); i++) //i jsou radky
            {
                for (int j = 0; j < currentField.GetLength(1); j++) //j jsou sloupce
                {
                    Console.Write(currentField[i, j] + " ");
                }
                Console.WriteLine("");
            }
            
        }

        static void ComputerFieldPrint(char[,] currentField)
        {
            Console.WriteLine("This is computers current battlefield:");
            Console.WriteLine("");
            for (int i = 0; i < currentField.GetLength(0); i++) //i jsou radky
            {
                for (int j = 0; j < currentField.GetLength(1); j++) //j jsou sloupce
                {
                    Console.Write(currentField[i, j] + " ");
                }
                Console.WriteLine("");
            }

        }

        static (bool, bool, int, int, int, int, int) ValidPosition(ref int validShipTypeL, ref int  validShipTypeB,ref int validShipTypeK,ref int validShipTypeP,ref int validShipTypeT, int row, int col, string type, string orientation) //tuple od chatGpt
        {
           //tahle funkce zjistuje jestli je muj placement pro lod validni a to tak, aby lod nebyla mimo hraci plochu, abych nemohl pridat 2 a vice lodi toho stejneho typu a aby se neprekryvaly 
                if (validShipTypeL + validShipTypeB + validShipTypeK + validShipTypeP + validShipTypeT >= 4)
                {
                    //return (false, false, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT);
                }
                else
                {
                if (type == "L")
                {
                    if(validShipTypeL > 0) { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                    else { 
                    if (orientation == "vertically")
                    {
                        if (row >= 4) { //validShipTypeL++; 
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                    }
                    else //horizontally
                    {
                        if (col <= 5) { //validShipTypeL++;
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); ; }
                    }
                    }
                }
                else if (type == "B")
                {
                if (validShipTypeB > 0) { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                else { 
                if (orientation == "vertically")
                    {
                        if (row >= 3) { //validShipTypeB++; 
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else {  return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); ; }
                    }
                    else //horizontally
                    {
                        if (col <= 6) { //validShipTypeB++;
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                    }
                }
                }
                else if (type == "K")
                {
                if (validShipTypeK > 0) { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                else { 
                if (orientation == "vertically")
                    {
                        if (row >= 2) { //validShipTypeK++;
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); ; }
                    }
                    else //horizontally
                    {
                        if (col <= 7) { //validShipTypeK++; 
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); ; }
                    }
                }
                }
                else if (type == "P")
                {
                if (validShipTypeP > 0) { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                else { 
                if (orientation == "vertically")
                    {
                        if (row >= 2) { //validShipTypeP++;
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }   
                    }
                    else //horizontally
                    {
                        if (col <= 7) { //validShipTypeP++;
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                    }
                }
                }
                else if (type == "T")
                {
                if (validShipTypeT > 0) { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                else { 
                if (orientation == "vertically")
                    {
                        if (row >= 1) { //validShipTypeT++;
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                    }
                    else //horizontally
                    {
                        if (col <= 8) { //validShipTypeT++; 
                                        return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                        else { return (false, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT); }
                    }
                }
                }
            }
            return (true, true, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT);
        }

        static (char[,], int, int, int, int, int) PlaceShip(char[,] currentField, int row, int col, string type, string orientation, ref int shipsPlaced, ref int validShipTypeL, ref int validShipTypeB, ref int validShipTypeK, ref int validShipTypeP, ref int validShipTypeT)
        {
            if(orientation == "vertically")  
            {
                if (type == "L") 
                {
                    for (int y = row; y > row - 5; y--)
                    {
                        
                        if (currentField[y, col] == Convert.ToChar("X"))
                        {
                                Console.WriteLine("ship cannot be placed here");
                                
                                SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }                                        
                    }
                    validShipTypeL++;
                    for (int x = row; x > row - 5; x--) 
                    {
                        currentField[x, col] = Convert.ToChar("X");
                    }
                }
                else if (type == "B") 
                {
                    for (int y = row; y > row - 4; y--)
                    {

                        if (currentField[y, col] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                    }
                    validShipTypeB++;
                    for (int i = row; i > row - 4; i--) 
                    { 
                        currentField[i, col] = Convert.ToChar("X"); 
                    } 
                }
                else if (type == "K") 
                {
                    for (int y = row; y > row - 3; y--)
                    {

                        if (currentField[y, col] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                    
                    }
                    validShipTypeK++;
                    for (int i = row; i > row - 3; i--)
                    {
                        currentField[i, col] = Convert.ToChar("X");
                    } 
                
                }
                else if (type == "P")
                {
                    for (int y = row; y > row - 3; y--)
                    {

                        if (currentField[y, col] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                        
                    }
                    validShipTypeP++;
                    for (int i = row; i > row - 3; i--)
                    {
                        currentField[i, col] = Convert.ToChar("X");
                    }
                }
                else if (type == "T") //type == T
                {
                    for (int y = row; y > row - 2; y--)
                    {

                        if (currentField[y, col] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                    
                    }
                    validShipTypeT++;
                    for (int i = row; i > row - 2; i--) 
                    {
                        currentField[i, col] = Convert.ToChar("X"); 
                    } 
                }  

            }
            else //horizontally
            {
                if (type == "L") 
                {
                    for (int x = col; x < col +5; x++)
                    {
                        if (currentField[row, x] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                    }
                    validShipTypeL++;
                    for (int i = col; i < col + 5; i++) 
                    {
                        currentField[row, i] = Convert.ToChar("X"); 
                    }
                }
                else if (type == "B") 
                {
                    for (int x = col; x < col + 4; x++)
                    {
                        if (currentField[row, x] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                    }
                    validShipTypeB++;
                    for (int i = col; i < col + 4; i++)
                    {
                        currentField[row, i] = Convert.ToChar("X");
                    } 
                }
                else if (type == "K") 
                {
                    for (int x = col; x < col + 3; x++)
                    {
                        if (currentField[row, x] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                    }
                    validShipTypeK++;
                    for (int i = col; i < col + 3; i++) 
                    { 
                        currentField[row, i] = Convert.ToChar("X");
                    } 
                }
                else if (type == "P")
                {
                    for (int x = col; x < col + 3; x++)
                    {
                        if (currentField[row, x] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                    }
                    validShipTypeP++;
                    for (int i = col; i < col + 3; i++)
                    {
                        currentField[row, i] = Convert.ToChar("X");
                    }
                }
                else if (type == "T")
                {
                    for (int x = col; x < col + 2; x++)
                    {
                        if (currentField[row, x] == Convert.ToChar("X"))
                        {
                            Console.WriteLine("ship cannot be placed here");
                            SetShips(currentField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                        }
                    }
                    validShipTypeT++;
                    for (int i = col; i < col + 2; i++) 
                    { 
                        currentField[row, i] = Convert.ToChar("X");
                    } 
                } 
            }
            return (currentField, validShipTypeL, validShipTypeB, validShipTypeK, validShipTypeP, validShipTypeT);
        }

        static char[,] SetShips(char[,] playersField, ref int validShipTypeL, ref int validShipTypeB, ref int validShipTypeK, ref int validShipTypeP, ref int validShipTypeT )
        {
            PlayerFieldPrint(playersField);
            Console.WriteLine("Lets set your ships. First select a row then collumn for you ship.");
            Console.WriteLine("This place will represent the most left bottom part of your ship.");
            Console.WriteLine("Next, you will select which ship you want to place there and its orientation.");
            var validPosition = (false, true, 0, 0, 0, 0, 0);
            int shipsPlaced = 0;
            //for (shipsPlaced = 0; shipsPlaced < 5;) //5x zadavam argumenty pro lod
            while (validShipTypeL + validShipTypeB + validShipTypeK + validShipTypeP + validShipTypeT <= 4)
            {
                Console.WriteLine("Select a row 0 - 9");
                string selectedRow = Console.ReadLine();
                int sRow; //user row input
                while (!int.TryParse(selectedRow, out sRow) || sRow > 9 || sRow < 0)
                {
                    Console.WriteLine("enter a valid statement");
                    selectedRow = Console.ReadLine();
                }
                Console.WriteLine("Select a collumn 0 - 9");
                string selectedCollumn = Console.ReadLine();
                int sCollumn; //user collumn input
                while (!int.TryParse(selectedCollumn, out sCollumn) || sCollumn > 9 || sCollumn < 0)
                {
                    Console.WriteLine("enter a valid statement");
                    selectedCollumn = Console.ReadLine();
                }
                Console.WriteLine("Select ship type: L for 1x5, B for 1x4, K for 1x3, P for 1x3, T for 1x2");
                string shipType = Console.ReadLine(); //ship type
                                                      //shipType.ToUpper();
                while (shipType != "L" && shipType != "B" && shipType != "K" && shipType != "P" && shipType != "T")
                {
                    Console.WriteLine("enter a valid statement");
                    shipType = Console.ReadLine();
                }

                Console.WriteLine("Select orientation: horizontally/vertically");
                string orientation = Console.ReadLine(); //ship orientation
                                                         //orientation.ToLower();
                while (orientation != "horizontally" && orientation != "vertically")
                {
                    Console.WriteLine("enter a valid statement");
                    orientation = Console.ReadLine();

                }

                validPosition = ValidPosition(ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT, sRow, sCollumn, shipType, orientation); //ref pres chatgpt
                if (validPosition.Item1 == false) //.Item - chatgpt
                {
                    Console.WriteLine("set valid arguements for ship placement");
                }
                else
                {
                    Console.Clear();
                    shipsPlaced++;
                    PlaceShip(playersField, sRow, sCollumn, shipType, orientation, ref shipsPlaced, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);
                    PlayerFieldPrint(playersField);
                }
                
            }
            return playersField;
        }

        static char[,] ComputersFieldSet(char[,] currentField)
        {
            Random rnd = new Random();
            int row = 0;
            int col = 0;
            int orientation = 0; //orientace lodi 0 = vertikalne, 1 = horizontalne 
            //int computerShipsPlaced = 0;
            bool validComputerShipPlacement = false;
            bool probehlyBrikule = false;
            //pridaval L 1x5 i = 0
            //Pridavam B 1x4 i = 1
            //Pridavam K 1x3 i = 2
            //Pridavam P 1x3 i = 3
            //Pridavam T 1x2 i = 4
            for (int i = 0; i < 5; i++)
            {
                orientation = rnd.Next(0, 2);
                if(orientation == 0) //vertikalne 
                {
                    if(i == 0)
                    {
                        
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            row = rnd.Next(4, 10);
                            col = rnd.Next(0, 10);
                            for (int y = row; y > row - 5; y--)
                            {

                                if (currentField[y, col] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int y = row; y > row - 5; y--)
                        {
                            currentField[y, col] = Convert.ToChar("X");
                        }
                        
                        validComputerShipPlacement = false;
                    }
                    else if (i == 1)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            row = rnd.Next(3, 10);
                            col = rnd.Next(0, 10);
                            for (int y = row; y > row - 4; y--)
                            {

                                if (currentField[y, col] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int y = row; y > row - 4; y--)
                        {
                            currentField[y, col] = Convert.ToChar("X");
                        }
                       
                        validComputerShipPlacement = false;
                    }
                    else if (i == 2)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            row = rnd.Next(2, 10);
                            col = rnd.Next(0, 10);
                            for (int y = row; y > row - 3; y--)
                            {

                                if (currentField[y, col] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int y = row; y > row - 3; y--)
                        {
                            currentField[y, col] = Convert.ToChar("X");
                        }
                        validComputerShipPlacement = false;
                    }
                    else if (i == 3)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            row = rnd.Next(2, 10);
                            col = rnd.Next(0, 10);
                            for (int y = row; y > row - 3; y--)
                            {

                                if (currentField[y, col] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int y = row; y > row - 3; y--)
                        {
                            currentField[y, col] = Convert.ToChar("X");
                        }
                        validComputerShipPlacement = false;
                    }
                    else if (i == 4)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            row = rnd.Next(1, 10);
                            col = rnd.Next(0, 10);
                            for (int y = row; y > row - 2; y--)
                            {

                                if (currentField[y, col] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int y = row; y > row - 2; y--)
                        {
                            currentField[y, col] = Convert.ToChar("X");
                        }
                        validComputerShipPlacement = false;
                    }
                }
                else if (orientation == 1) //horizontalne
                {
                    if (i == 0)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            col = rnd.Next(0, 6);
                            row = rnd.Next(0, 10);
                            for (int x = col; x < col + 5; x++)
                            {

                                if (currentField[row, x] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int x = col; x < col + 5; x++)
                        {
                            currentField[row, x] = Convert.ToChar("X");
                        }
                        validComputerShipPlacement = false;
                    }
                    else if (i == 1)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            col = rnd.Next(0, 7);
                            row = rnd.Next(0, 10);
                            for (int x = col; x < col + 4; x++)
                            {

                                if (currentField[row, x] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int x = col; x < col + 4; x++)
                        {
                            currentField[row, x] = Convert.ToChar("X");
                        }
                        validComputerShipPlacement = false;
                    }
                    else if (i == 2)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            col = rnd.Next(0, 8);
                            row = rnd.Next(0, 10);
                            for (int x = col; x < col + 3; x++)
                            {

                                if (currentField[row, x] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int x = col; x < col + 3; x++)
                        {
                            currentField[row, x] = Convert.ToChar("X");
                        }
                        validComputerShipPlacement = false;
                    }
                    else if (i == 3)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            col = rnd.Next(0, 8);
                            row = rnd.Next(0, 10);
                            for (int x = col; x < col + 3; x++)
                            {

                                if (currentField[row, x] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int x = col; x < col + 3; x++)
                        {
                            currentField[row, x] = Convert.ToChar("X");
                        }
                        validComputerShipPlacement = false;
                    }
                    else if (i == 4)
                    {
                        while (!validComputerShipPlacement)
                        {
                            probehlyBrikule = false;
                            col = rnd.Next(0, 9);
                            row = rnd.Next(0, 10);
                            for (int x = col; x < col + 2; x++)
                            {

                                if (currentField[row, x] == Convert.ToChar("X"))
                                {
                                    validComputerShipPlacement = false;
                                    probehlyBrikule = true;
                                }
                            }
                            if (probehlyBrikule)
                            {
                                validComputerShipPlacement = false;
                            }
                            else if (!probehlyBrikule)
                            {
                                validComputerShipPlacement = true;
                            }
                        }
                        for (int x = col; x < col + 2; x++)
                        {
                            currentField[row, x] = Convert.ToChar("X");
                        }
                        validComputerShipPlacement = false;
                    }
                }
            }

            return currentField;
        }

        static void Main(string[] args)
        {
            int validShipTypeL = 0; //menim podle toho co mi hodi funkce ValidPosition za string, abych ohlidal, ze nedava dve lode stejnyho type idk jak jinak to udelat
            int validShipTypeB = 0;
            int validShipTypeK = 0;
            int validShipTypeP = 0;
            int validShipTypeT = 0;
            int playerShipsHit = 0;
            int computerShipsHit = 0;
            Random rnd = new Random();
            int turn;
            bool playerWon = false;
            bool computerWon = false;
            int sRow = 0; //selected row hracem vyuzito ve funkci playersTurn
            int sCollumn = 0; //selected collumn hracem vyuzito ve funkci playersTurn
            int cRow = 0; //selected row pocitacem vyuzito ve funkci computerssTurn
            int cCollumn = 0; //selected row pocitacem vyuzito ve funkci computersTurn
            string shotType = "easter egg";
            string shotDirection = "easter egg";
            Console.WriteLine("WELCOME TO THE BATTLESHIP GAME");
            Console.WriteLine("Please select difficulty: noob/pro/impossible"); //noob znamena, ze pc strili nahodne, pro ze strili logicky a impossible, ze vi, kam jsem dal svoje lode
            string difficulty = Console.ReadLine();
            while (difficulty != "noob" && difficulty != "pro" && difficulty != "impossible")
            {
                Console.WriteLine("enter a valid statement");
                difficulty = Console.ReadLine();
            }
            char space = Convert.ToChar("-");
            char[,] playersField = new char[10, 10]; //hracovo pole
            for (int i = 0; i < playersField.GetLength(0); i++) //i jsou radky
            {
                for (int j = 0; j < playersField.GetLength(1); j++) //j jsou sloupce
                {
                    playersField[i, j] = space;
                }
            }
            SetShips(playersField, ref validShipTypeL, ref validShipTypeB, ref validShipTypeK, ref validShipTypeP, ref validShipTypeT);

            char[,] computersField = new char[10, 10]; //pole pocitace
            for (int i = 0; i < computersField.GetLength(0); i++) //i jsou radky
            {
                for (int j = 0; j < computersField.GetLength(1); j++) //j jsou sloupce
                {
                    computersField[i, j] = space;
                }
            }
            char[,] computersFieldForPlayer = new char[10, 10]; //pole co uvidi hrac
            for (int i = 0; i < computersFieldForPlayer.GetLength(0); i++) //i jsou radky
            {
                for (int j = 0; j < computersFieldForPlayer.GetLength(1); j++) //j jsou sloupce
                {
                    computersFieldForPlayer[i, j] = space;
                }
            }
            ComputersFieldSet(computersField);
            //ComputerFieldPrint(computersField);
            ComputerFieldPrint(computersFieldForPlayer);
            turn = rnd.Next(0, 2); //0 pro hrace, 1 pocitac
            while(!playerWon && !computerWon)
            {
                if(turn == 0)
                {
                    Console.WriteLine("Players turn");
                    PlayersTurn(ref computersField, ref sRow, ref sCollumn, ref shotType, ref shotDirection);
                    ComputerEditedFieldPrint(computersFieldForPlayer, computersField, sRow, sCollumn, shotType, shotDirection, ref playerWon, ref playerShipsHit);
                    turn++;
                }
                else if(turn == 1)
                {
                    Console.WriteLine("Computers turn");
                    ComputersTurn(playersField, difficulty, ref cRow, ref cCollumn, ref computerWon, ref computerShipsHit);
                    PlayerEditedFieldPrint(playersField);
                    turn--;
                }
            }
            if (playerWon) Console.WriteLine("YOU WON!!!");
            else Console.WriteLine("COMPUTER WON YOU BOZO!!!");
            Console.ReadKey();

        }
    }
}
