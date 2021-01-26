using System;
using System.Collections.Generic;

namespace QuadaxExcercise
{
    public class Mastermind
    {
        private List<int> gamePieces;
        private List<bool> positionChecked;
        private int numberOfGuesses;
        private const int NumberOfPieces = 4;
        private const int NumberOfColors = 6;
        private const int MaxGuesses = 10;
        private int correctPositionGuess;
        private int wrongPositionGuess;

        public Mastermind()
        {
            gamePieces = new List<int>(NumberOfPieces);
            positionChecked = new List<bool>(NumberOfPieces);
            numberOfGuesses = 0;
            correctPositionGuess = 0;
            wrongPositionGuess = 0;
        }

        public void NewGame()
        {
            gamePieces.Clear();
            numberOfGuesses = 0;

            for (var i = 0; i < NumberOfPieces; i++)
            {
                gamePieces.Add(RandomGamePiece());
                positionChecked.Add(false);
            }
        }

        public int GetNumberOfPieces()
        {
            return NumberOfPieces;
        }

        public int GetNumberOfColors()
        {
            return NumberOfColors;
        }

        public bool validGame()
        {
            return (numberOfGuesses < MaxGuesses);
        }

        public string Guess(List<int> guesses)
        {
            correctPositionGuess = 0;
            wrongPositionGuess = 0;
            numberOfGuesses++;


            for (var i = 0; i < NumberOfPieces; i++)
            {
                positionChecked[i] = false;
            }

            var position = 0;
            guesses.ForEach(g => ValidateGuess(g, position++));

            if (correctPositionGuess == NumberOfPieces)
            {
                numberOfGuesses = MaxGuesses;
                return "You Win!!!";
            }
            else if (numberOfGuesses == MaxGuesses)
            {
                var correctOrder = "";
                for( var i = 0; i< NumberOfPieces; i++){
                    correctOrder += gamePieces[i].ToString();
                }
                return ("You Lose, Better Luck Next Time.\nThe correct order was: " + correctOrder);
            }

            return string.Concat(new String('-', wrongPositionGuess), new String('+', correctPositionGuess));
        }

        private void ValidateGuess(int guess, int p)
        {
            if (guess == gamePieces[p])
            {
                if (positionChecked[p])
                {
                    wrongPositionGuess--;
                }
                correctPositionGuess++;
                positionChecked[p] = true;
            }
            else if (gamePieces.Contains(guess))
            {
                for (var i = gamePieces.IndexOf(guess); i < NumberOfPieces; i++){
                    if (gamePieces[i] == guess && !positionChecked[i]){
                        positionChecked[i] = true;
                        wrongPositionGuess++;
                        break;
                    }
                }
            }
        }
        private int RandomGamePiece()
        {
            var rnd = new Random();
            return rnd.Next(1, NumberOfColors + 1);
        }
    }
}