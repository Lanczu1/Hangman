//USING
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;
using HANGMAN;
using System.Reflection.Metadata;
using static System.Formats.Asn1.AsnWriter;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Collections;
using System.Data.Common;
using System.Diagnostics.Metrics;
using System.Numerics;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading.Channels;
using System.Media;
using System.IO;


//MAIN METHOD BY MULTIPLE METHOD
namespace HANGMAN
{
    internal class MainMenu
    {
        public static void Main(string[] args)
        {
            // Set console window height and width
            Console.WindowHeight = 40; // Set the desired height
            Console.WindowWidth = 100;  // Set the desired width

            if (OperatingSystem.IsWindows())
            {
                SoundPlayer sound = new SoundPlayer("Hangman.wav");
                sound.Load();
                sound.PlayLooping();
            }

            Game game = new Game();
            game.Progress();
        }


    }

}
// MULTI METHOD CLASS
internal class Game
{


    public void Progress()
    {
        Console.Title = "HANGMAN GAME CONSOLE!";
        ShowLoadingScreen();
        Console.ForegroundColor = ConsoleColor.Red;
        string title = @"
                  ██╗  ██╗ █████╗ ███╗   ██╗ ██████╗ ███╗   ███╗ █████╗ ███╗   ██╗
                  ██║  ██║██╔══██╗████╗  ██║██╔════╝ ████╗ ████║██╔══██╗████╗  ██║
                  ███████║███████║██╔██╗ ██║██║  ███╗██╔████╔██║███████║██╔██╗ ██║
                  ██╔══██║██╔══██║██║╚██╗██║██║   ██║██║╚██╔╝██║██╔══██║██║╚██╗██║
                  ██║  ██║██║  ██║██║ ╚████║╚██████╔╝██║ ╚═╝ ██║██║  ██║██║ ╚████║
                  ╚═╝  ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝ ╚═════╝ ╚═╝     ╚═╝╚═╝  ╚═╝╚═╝  ╚═══╝
";
        Console.Write(title);
        Console.WriteLine();
        Console.ResetColor();

        Console.Write("Enter your name: ");
        playerName = Console.ReadLine();


        ShowLoadingScreen();
        MainMenu();
        Console.ReadKey();
    }
    // LOADING SCREEN
    private void ShowLoadingScreen()
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Yellow;
        string text = @"                                                    ~+      
                                                                           *       +
                                                                             '              |
                                                                    ()    .-.,=""``""=.     - o -
  ██       ██████   █████  ██████  ██ ███    ██  ██████                   '=/_       \      |
  ██      ██    ██ ██   ██ ██   ██ ██ ████   ██ ██                     *   |  '=._    |
  ██      ██    ██ ███████ ██   ██ ██ ██ ██  ██ ██   ███                    \     `=./`,        '
  ██      ██    ██ ██   ██ ██   ██ ██ ██  ██ ██ ██    ██                 .   '=.__.=' `='      *
  ███████  ██████  ██   ██ ██████  ██ ██   ████  ██████  ██ ██ ██                      +
                                                                      O      *        '       .
";
        Console.WriteLine(text);
        Console.CursorVisible = false;
        Console.SetCursorPosition(10, 10);

        for (int i = 0; i < 100; i++)
        {
            Console.WriteLine();
            for (int y = 0; y < i; y++)
            {
                string loading = "\u2551";
                Console.Write(loading);
            }
            Console.Write(i + " / 100");
            Console.SetCursorPosition(10, 10); // Move the cursor to the bottom of the console window
            Console.ForegroundColor = ConsoleColor.Blue;
            System.Threading.Thread.Sleep(50);
        }

        Console.Clear();
    }

    // MAIN MENU SELECTION AND TITLE
    private void MainMenu()
    {

        string prompt = @"
.-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-.
___________.._______                                                                              |
| .__________))______|                                                                            |
| |/ /       ||                                                                                   |
| | /        ||.-''.                                                                              |
| |/         |/  _  \                *****************************************************        |
| |          ||  `/,|                *  _   _   ___   _   _ _____ ___  ___  ___   _   _  *        !
| |          (\\`_.'                 * | | | | / _ \ | \ | |  __ \|  \/  | / _ \ | \ | | *        :
| |         .-`--'.                  * | |_| |/ /_\ \|  \| | |  \/| .  . |/ /_\ \|  \| | *        :
| |        /Y . . Y\                 * |  _  ||  _  || . ` | | __ | |\/| ||  _  || . ` | *        :
| |       // |   | \\                * | | | || | | || |\  | |_\ \| |  | || | | || |\  | *        .
| |      //  | . |  \\               * \_| |_/\_| |_/\_| \_/\____/\_|  |_/\_| |_/\_| \_/ *        .
| |     ')   |   |   (`              *                                                   *        :
| |          ||'||                   *****************************************************        :
| |          || ||                                                                                :
| |          || ||                                                                                !
| |          || ||                                                                                |
| |         / | | \                                                                               |
""""""""""""""""""""|_`-' `-' |""""""|                                                                         |
|""|""""""""""""""\ \       '""|""|                                                                         |
                    Welcome to the HANGMAN GAME. What would you like to do?                       |
            (Use the arrow keys to cycle through about and press enter to select an about.)       |
`-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-

";

        string[] options;
        options = new string[] { "Create New Player Name", "Continue", "New Game", "About", "LeaderBoard", "Exit" };

        Menu mainMenu = new Menu(prompt, options);

        int selectedIndex = mainMenu.Run();

        switch (selectedIndex)
        {
            case 0:
                CreateNewPlayerName();
                break;
            case 1:
                Continue();
                break;
            case 2:
                NewGame();
                break;
            case 3:
                About();
                break;
            case 4:
                DisplayLeaderboard();
                break;
            case 5:
                Exit();
                break;
            default:
                break;
        }
    }
    // INITIALIZATION OF PLAYER NAME AND SCORE
    private string playerName;
    private int playerScore;
    List<ScoreEntry> scores = new List<ScoreEntry>();

    // SCORE OF A PLAYER
    public class ScoreEntry
    {
        public string PlayerName { get; set; }
        public int PlayerScore { get; set; }
    }
    // CENTERING A TEXTS
    private static void CenterText(params string[] texts)
    {
        int width = Console.WindowWidth;
        foreach (string text in texts)
        {
            int leftPadding = 0;
            if (text.Length <= width)
            {
                leftPadding = (int)Math.Round((width - text.Length) / 2.0);
            }
            Console.SetCursorPosition(leftPadding, Console.CursorTop);
            Console.WriteLine(text);
        }
    }
    //DISPLAY LEADERBOARD
    private void DisplayLeaderboard()
    {
        Console.Clear();

        // Display score
        CenterText($"Player Name: {playerName}");
        CenterText($"Player Score: {playerScore}");
        string prompt = @"
                    _                    _           _                         _ 
                   | |                  | |         | |                       | |
                   | |     ___  __ _  __| | ___ _ __| |__   ___   __ _ _ __ __| |
                   | |    / _ \/ _` |/ _` |/ _ \ '__| '_ \ / _ \ / _` | '__/ _` |
                   | |___|  __/ (_| | (_| |  __/ |  | |_) | (_) | (_| | | | (_| |
                   |______\___|\__,_|\__,_|\___|_|  |_.__/ \___/ \__,_|_|  \__,_|";
        Console.WriteLine(prompt);
        Console.WriteLine();
        CenterText("----------------------------");


        // Load previous highscores from the file
        List<ScoreEntry> previousScores = new List<ScoreEntry>();
        using (StreamReader reader = new StreamReader("highscores.txt"))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(':');
                if (parts.Length == 2)
                {
                    string playerName = parts[0].Trim();
                    int playerScore = int.Parse(parts[1].Trim());
                    previousScores.Add(new ScoreEntry { PlayerName = playerName, PlayerScore = playerScore });
                }
            }
        }

        // Check if the current player's score already exists
        bool playerExists = previousScores.Any(score => score.PlayerName == playerName && score.PlayerScore == playerScore);

        // Add the current player's score to the list if it doesn't exist and the score is greater than zero
        if (!playerExists && playerScore > 0)
        {
            previousScores.Add(new ScoreEntry { PlayerName = playerName, PlayerScore = playerScore });
        }

        // Sort scores in descending order
        previousScores.Sort((x, y) => y.PlayerScore.CompareTo(x.PlayerScore));

        // Display leaderboard table
        CenterText("----------------------------");

        for (int i = 0; i < previousScores.Count; i++)
        {
            if (i < previousScores.Count)
            {
                var score = previousScores[i];
                CenterText($"{score.PlayerName,-10} {score.PlayerScore,-9}");
            }
        }



        // Save highscores to the file
        using (StreamWriter writer = new StreamWriter("highscores.txt"))
        {
            foreach (var score in previousScores)
            {
                writer.WriteLine($"{score.PlayerName}: {score.PlayerScore}");
            }
        }
        // Resetting the text file
        bool repeat = true;
        while (repeat)
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Reset the Text File? ");
            string text = @"
Press D to Reset a Text File
Press C to Continue a Game
Press R to Reset Score
Press Q to Back in MainMenu";
            CenterText(text);

            string reset = Console.ReadLine();
            if (reset == "D" || reset == "d")
            {
                if (File.Exists("highscores.txt"))
                {
                    File.WriteAllText("highscores.txt", string.Empty);
                    repeat = false;
                    Console.Clear();
                    DisplayLeaderboard();
                }
            }
            else if (reset == "C" || reset == "c")
            {
                repeat = true;
                Console.Clear();
                Continue();
            }
            else if (reset == "R" || reset == "r")
            {
                repeat = true;
                Console.Clear();
                YouSure();
            }
            else if (reset == "Q" || reset == "q")
            {
                repeat = false;
                Console.Clear();
                MainMenu();
            }
        }
    }

    //IF RESETING A SCORE OF A PLAYER
    private void YouSure()
    {
        Console.Clear();
        Console.WriteLine();
        Console.WriteLine("Are you sure you want to reset the score in the Continue Game?");
        Console.WriteLine("Press Y for yes or Press N for no");
        string reset = Console.ReadLine();
        if (reset == "Y" || reset == "y")
        {
            playerScore = 0;
            Console.Clear();
            DisplayLeaderboard();
        }
        else if (reset == "N" || reset == "n")
        {
            Console.Clear();
            DisplayLeaderboard();
        }
    }




    //CREATE NAME
    private void CreateNewPlayerName()
    {
        Console.Clear();
        Game game = new Game();
        game.Progress();


    }
    //ABOUT OF THIS GAME
    private void About()
    {
        Console.Clear();
        ShowLoadingScreen();
        Console.ForegroundColor = ConsoleColor.Yellow;
        string title = @"
                /$$   /$$  /$$$$$$  /$$   /$$  /$$$$$$  /$$      /$$  /$$$$$$  /$$   /$$
               | $$  | $$ /$$__  $$| $$$ | $$ /$$__  $$| $$$    /$$$ /$$__  $$| $$$ | $$
               | $$  | $$| $$  \ $$| $$$$| $$| $$  \__/| $$$$  /$$$$| $$  \ $$| $$$$| $$
               | $$$$$$$$| $$$$$$$$| $$ $$ $$| $$ /$$$$| $$ $$/$$ $$| $$$$$$$$| $$ $$ $$
               | $$__  $$| $$__  $$| $$  $$$$| $$|_  $$| $$  $$$| $$| $$__  $$| $$  $$$$
               | $$  | $$| $$  | $$| $$ \  $$|  $$$$$$/| $$ \/  | $$| $$  | $$| $$ \  $$
               |__/  |__/|__/  |__/|__/  \__/ \______/ |__/     |__/|__/  |__/|__/  \__/
";
        Console.WriteLine(title);
        Console.ResetColor();
        string about = @"
Hangman is a classic word-guessing game where 
one player thinks of a word and the other player tries to guess it by suggesting letters. 
A blank space represents each letter in the word, 
and a stick figure is drawn for each incorrect guess. 
The guessing player has to figure out the word 
before the stick figure is fully drawn, completing the hangman. 
It's a simple yet engaging game that challenges players' word-solving skills and creativity

STORY
THE ORIGNAL MAKER OF HANG MAN 
 - William Marwood (1818[1] – 4 September 1883) was a British state hangman. 
He developed the technique of hanging known as the ""long drop"".";

        Console.WriteLine(about);
        Console.WriteLine();
        Console.WriteLine("Press any key to Next Page");
        Console.ReadKey(true);
        About2();
    }

    private void About2()
    {
        Console.Clear();
        string how = @"
1.Setup:
One player thinks of a word and marks down a blank space for each letter in the word.
For example, if the word is ""hangman,"" you would draw seven blanks: ""_ _ _ _ _ _ _.""
 
2. Guessing:
The other player (or players) starts guessing letters one at a time.
If the guessed letter is in the word, 
the person who thought of the word fills in the blanks with that letter.
If the guessed letter is not in the word, 
the person draws a part of a stick figure (representing the ""hangman"") 
on the gallows. Usually, 
there are six parts to draw: head, body, right arm, left arm, right leg, left leg.

3.Incorrect Guesses:
As incorrect guesses accumulate, more parts of the hangman are drawn.
The goal for the guessing player is to figure
out the word before the hangman is completely drawn.

4.Winning and Losing:
The guessing player wins if they correctly guess the word before the hangman is fully drawn.
The player who thought of the word wins if the hangman is completed before the word is guessed.

5.Once the game is over, reveal the word, whether it was guessed or not.

Copyright to the righteous owner -
{SoundTrack}
Magnus Berg - [Hangman.no Sountrack]

Inspiration to the Game

Game Owner -
Lance Aron Oboza

Group Members -
Lance Bautista
John Jenri Mendoza

";
        Console.WriteLine(how);
        Console.WriteLine("Press Any Key To Back In Main Menu");
        Console.ReadKey(true);
        MainMenu();
    }

    // EXIT TO CONSOLE
    private void Exit()
    {
        Console.Clear();
        Console.WriteLine("\nThankyou for encountering our code Hang Man!!!");
        Console.ReadKey(true);
        Environment.Exit(0);
    }
    // BACKGROUND OF TEXT PLUS RESET COLOR

    // MULTI METHOD CLASS
    internal class Menu
    {
        // INITIALIZATION OF PRESSING KEYS

        private string[] Options;
        private int Index;
        private string Prompt;

        public Menu(string prompt, string[] options)
        {
            Prompt = prompt;
            Options = options;
            Index = 2;
        }
        // Pressing {UPARROW, DOWNARROW, ENTER} OF MAINMENU
        public int Run()
        {

            ConsoleKey keyPressed;
            do
            {
                ShowOptions();

                ConsoleKeyInfo keyInfo = Console.ReadKey();
                keyPressed = keyInfo.Key;

                if (keyPressed == ConsoleKey.UpArrow)
                {
                    Index--;
                    if (Index < 0)
                    {
                        Index = Options.Length - 1;
                    }
                }
                else if (keyPressed == ConsoleKey.DownArrow)
                {
                    Index++;
                    if (Index == Options.Length)
                    {
                        Index = 0;
                    }
                }
            } while (keyPressed != ConsoleKey.Enter);

            return Index;
        }
        // COLOR BACKGROUND OF (PLAY, ABOUT, EXIT)
        public void ShowOptions()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Clear();
            Console.WriteLine(Prompt);

            int consoleWidth = Console.WindowWidth;
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                int prefixLength = (consoleWidth - currentOption.Length - 4) / 2;
                string prefix = new string(' ', prefixLength);

                Console.Write(prefix);
                if (i == Index)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Red;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.BackgroundColor = ConsoleColor.Black;

                }
                Console.WriteLine($">>{currentOption}<<");
                Console.ResetColor(); // Reset the background color
            }
            Console.ResetColor(); // Reset the background color
        }
        //RETURN SELECTION
        public int GetSelectedIndex()
        {
            return Index;
        }
    }




    // PLAY GAME OF HANGMAN
    private void Continue()
    {
        Console.Clear();
        //FILE PATHING
        string[] wordArray = File.ReadAllLines("words.txt");

        // RANDOMING GENERATOR OF WORDS
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(0, wordArray.Length);

        // SELECTING WORDS RANDOMLY
        string selectedWord = wordArray[randomNumber];

        // HIDDEN WORDS (" _ ")
        string hideWord = new string('_', selectedWord.Length);

        //HEALTH
        int userHealth = 6;

        //RANDOMLY SELECT A LETTER FOR HINT
        char hintLetter = selectedWord[randomGenerator.Next(selectedWord.Length)];
        while (hideWord.Contains("_") && userHealth > 0)
        {
            //Display stickman
            DisplayStickman(userHealth);

            // DISPLAY HINT FOR EACH LETTER IN THE WORD
            Console.WriteLine("Make sure a letter is not Capslock");
            Console.WriteLine("Score saved for " + playerName + ": " + playerScore);
            Console.WriteLine("Category: English");
            Console.Write("Hint: ");
            for (int i = 0; i < selectedWord.Length; i++)
            {
                Console.Write(selectedWord[i] == hintLetter ? hintLetter : "_ ");
            }
            Console.WriteLine(" ");


            // GUESSING A LETTER
            Console.WriteLine("Guess a letter of the hidden word: ");
            // ADD SPACING BETWEEN UNDERSCORES IN GUESSED LETTERS
            string spacedHideWord = string.Join(" ", hideWord.ToCharArray());

            // DISPLAY GUESSED LETTERS
            Console.WriteLine(spacedHideWord);
            string userInput = Console.ReadLine();

            // INVALID INPUT
            while (userInput.Length != 1 || !Char.IsLetter(userInput[0]))
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Please enter a single character and make sure a letter is not Capslock.");
                // DISPLAY STICKMAN, SCORE, HINT, AND GUESSED LETTERS AGAIN
                DisplayStickman(userHealth);
                // SCORE, HINT, AND GUESSED LETTERS AGAIN
                Console.WriteLine("Make sure a letter is not Capslock");
                Console.WriteLine("Score saved for " + playerName + ": " + playerScore);
                Console.WriteLine("Category: English");
                //HINT
                Console.Write("Hint: ");
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    Console.Write(selectedWord[i] == hintLetter ? hintLetter : "_ ");
                }
                Console.WriteLine(" ");
                Console.WriteLine("Guess a letter of the hidden word: ");

                // ADD SPACING BETWEEN UNDERSCORES IN GUESSED LETTERS
                Console.WriteLine(spacedHideWord);
                userInput = Console.ReadLine();
            }
            StringBuilder hideWordBuilder = new StringBuilder(hideWord);
            //GUESSING LETTER
            char charGuess = userInput[0];
            bool containsLetter = false;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == charGuess)
                {
                    hideWordBuilder[i] = charGuess;
                    containsLetter = true;
                }
            }
            hideWord = hideWordBuilder.ToString(); // Convert StringBuilder back to string and assign it to hideWord


            // BACKGROUND IF CORRECT YOUR LETTER AND IF WRONG YOUR LETTER
            //CORRECT
            if (containsLetter)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct >> {0} << is in the word!", charGuess);
                Console.ResetColor();
                Console.WriteLine("Health: " + userHealth + "/{0}", selectedWord.Length);
                // Increment the score
                playerScore++;

            }
            //INCORRECT
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry >> {0} << is not in the word!", charGuess);
                Console.ResetColor();
                userHealth -= 1;
                Console.WriteLine("Health: " + userHealth + "/{0}", selectedWord.Length);
            }
        }


        // WIN OR LOSE A USER
        //LOSE
        if (userHealth == 0 && hideWord.Contains("_"))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry you're out of lives");
            Console.WriteLine("The word was >>{0}<<", selectedWord);
            Console.ResetColor();
            DisplayStickman(userHealth);
            Console.WriteLine("Score saved for " + playerName + ": " + playerScore);


        }
        //WIN
        else if (!hideWord.Contains("_"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Made it!\n >>{0}<<", hideWord);
            Console.ResetColor();
            DisplayStickman(userHealth);
            Console.WriteLine("Score saved for " + playerName + ": " + playerScore);

        }
        // REPEATING A GAME
        bool repeat = true;
        while (repeat)
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Continue the Game?");
            Console.Write("Press C to Continue a Game or Press Q to return in MainMenu: ");
            string restart = Console.ReadLine();
            if (restart == "C" || restart == "c")
            {
                repeat = true;
                Continue();
            }
            else if (restart == "Q" || restart == "q")
            {
                repeat = false;
                MainMenu();
            }
        }
    }

    private void NewGame()
    {
        Console.Clear();
        //RESET SCORE
        playerScore = 0;
        //FILE PATHING
        string[] wordArray = File.ReadAllLines("words.txt");

        // RANDOMING GENERATOR OF WORDS
        Random randomGenerator = new Random();
        int randomNumber = randomGenerator.Next(0, wordArray.Length);

        // SELECTING WORDS RANDOMLY
        string selectedWord = wordArray[randomNumber];

        // HIDDEN WORDS (" _ ")
        string hideWord = new string('_', selectedWord.Length);

        //HEALTH
        int userHealth = 6;



        //RANDOMLY SELECT A LETTER FOR HINT
        char hintLetter = selectedWord[randomGenerator.Next(selectedWord.Length)];
        while (hideWord.Contains("_") && userHealth > 0)
        {
            // DISPLAY STICKMAN
            DisplayStickman(userHealth);
            // DISPLAY HINT FOR EACH LETTER IN THE WORD
            Console.WriteLine("Make sure a letter is not Capslock");
            Console.WriteLine("Score saved for " + playerName + ": " + playerScore);
            Console.WriteLine("Category: English");
            //HINT
            Console.Write("Hint: ");
            for (int i = 0; i < selectedWord.Length; i++)
            {
                Console.Write(selectedWord[i] == hintLetter ? hintLetter : "_ ");
            }
            Console.WriteLine(" ");


            // GUESSING A LETTER
            Console.WriteLine("Guess a letter of the hidden word: ");
            // ADD SPACING BETWEEN UNDERSCORES IN GUESSED LETTERS
            string spacedHideWord = string.Join(" ", hideWord.ToCharArray());

            // DISPLAY GUESSED LETTERS
            Console.WriteLine(spacedHideWord);
            string userInput = Console.ReadLine();

            // INVALID INPUT
            while (userInput.Length != 1 || !Char.IsLetter(userInput[0]))
            {
                Console.Clear();
                Console.WriteLine("Invalid input! Please enter a single character and make sure a letter is not Capslock.");
                Console.WriteLine();
                // DISPLAY STICKMAN
                DisplayStickman(userHealth);
                // SCORE, HINT, AND GUESSED LETTERS AGAIN
                Console.WriteLine("Make sure a letter is not Capslock");
                Console.WriteLine("Score saved for " + playerName + ": " + playerScore);
                Console.WriteLine("Category: English");
                Console.Write("Hint: ");
                for (int i = 0; i < selectedWord.Length; i++)
                {
                    Console.Write(selectedWord[i] == hintLetter ? hintLetter : "_ ");
                }
                Console.WriteLine(" ");
                Console.WriteLine("Guess a letter of the hidden word: ");
                Console.WriteLine(spacedHideWord);

                userInput = Console.ReadLine();
            }

            StringBuilder hideWordBuilder = new StringBuilder(hideWord);
            //GUESSING LETTER
            char charGuess = userInput[0];
            bool containsLetter = false;
            for (int i = 0; i < selectedWord.Length; i++)
            {
                if (selectedWord[i] == charGuess)
                {
                    hideWordBuilder[i] = charGuess;
                    containsLetter = true;
                }
            }
            hideWord = hideWordBuilder.ToString(); // Convert StringBuilder back to string and assign it to hideWord


            // BACKGROUND IF CORRECT YOUR LETTER AND IF WRONG YOUR LETTER
            //CORRECT WORD
            if (containsLetter)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Correct >> {0} << is in the word!", charGuess);
                Console.ResetColor();
                Console.WriteLine("Health: " + userHealth + "/{0}", selectedWord.Length);
                // Increment the score
                playerScore++;
            }
            //INCORRECT WORD
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Sorry >> {0} << is not in the word!", charGuess);
                Console.ResetColor();
                userHealth -= 1;
                Console.WriteLine("Health: " + userHealth + "/{0}", selectedWord.Length);
            }

        }


        // WIN OR LOSE A USER
        // LOSE
        if (userHealth == 0 && hideWord.Contains("_"))
        {

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorry you're out of lives");
            Console.WriteLine("The word was >>{0}<<", selectedWord);
            Console.ResetColor();
            DisplayStickman(userHealth);
            Console.WriteLine("Score saved for " + playerName + ": " + playerScore);
        }
        //WIN
        else if (!hideWord.Contains("_"))
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You Made it!\n >>{0}<<", hideWord);
            Console.ResetColor();
            DisplayStickman(userHealth);
            Console.WriteLine("Score saved for " + playerName + ": " + playerScore);
        }
        // REPEATING A GAME
        bool repeat = true;
        while (repeat)
        {
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine("Continue the Game?");
            Console.Write("Press C to Continue a Game or Press Q to return in MainMenu: ");
            string restart = Console.ReadLine();
            if (restart == "C" || restart == "c")
            {
                repeat = true;
                Continue();
            }
            else if (restart == "Q" || restart == "q")
            {
                repeat = false;
                MainMenu();
            }
        }
    }
    // DISPLAY STICKMAN
    static void DisplayStickman(int incorrectGuesses)
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        switch (incorrectGuesses)
        {
            case 6:
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("        _______________________________________                             ****");
                Console.WriteLine("       |                                      |                           ********");
                Console.WriteLine("       |                                      |                          **  ******");
                Console.WriteLine("       |                                      |                           *   ******     ******");
                Console.WriteLine("       |                                      |                               ******   *********");
                Console.WriteLine("       |                                      |                                ****  *****   ***");
                Console.WriteLine("       |                                      |                                ***  ***     **");
                Console.WriteLine("       |                                      |                          *************       *");
                Console.WriteLine("       |                                   =======                     ******************");
                Console.WriteLine("       |                                                              *****   H*****H*******");
                Console.WriteLine("       |                                                              ***     H-___-H  *********");
                Console.WriteLine("       |                                                               ***    H     H      *******");
                Console.WriteLine("       |                                                                **    H-___-H        *****");
                Console.WriteLine("       |                                                                  *   H     H         ****");
                Console.WriteLine("       |                                                                      H     H         ***");
                Console.WriteLine("  _____|_________                                                             H-___-H         **");
                Console.WriteLine(" /               /|                                                           H     H         *");
                Console.WriteLine(" ______________ / /                                                           H-___-H");
                Console.WriteLine("              |  /                                                            H-___-H");
                Console.WriteLine(" ______________ /                                                             H-___-H");
                Console.WriteLine("                                                                              H-___-H");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine();
                break;

            case 5:
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("        _______________________________________                             ****");
                Console.WriteLine("       |                                      |                           ********");
                Console.WriteLine("       |                                      |                          **  ******");
                Console.WriteLine("       |                                      |                           *   ******     ******");
                Console.WriteLine("       |                                      |                               ******   *********");
                Console.WriteLine("       |                                      |                                ****  *****   ***");
                Console.WriteLine("       |                                      |                                ***  ***     **");
                Console.WriteLine("       |                                      |                          *************       *");
                Console.WriteLine("       |                                   =======                     ******************");
                Console.WriteLine("       |                                      |                       *****   H*****H*******");
                Console.WriteLine("       |                                      @                       ***     H-___-H  *********");
                Console.WriteLine("       |                                                               ***    H     H      *******");
                Console.WriteLine("       |                                                                **    H-___-H        *****");
                Console.WriteLine("       |                                                                  *   H     H         ****");
                Console.WriteLine("       |                                                                      H     H         ***");
                Console.WriteLine("  _____|_________                                                             H-___-H         **");
                Console.WriteLine(" /               /|                                                           H     H         *");
                Console.WriteLine(" ______________ / /                                                           H-___-H");
                Console.WriteLine("              |  /                                                            H-___-H");
                Console.WriteLine(" ______________ /                                                             H-___-H");
                Console.WriteLine("                                                                              H-___-H");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine();
                break;

            case 4:
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("        _______________________________________                             ****");
                Console.WriteLine("       |                                      |                           ********");
                Console.WriteLine("       |                                      |                          **  ******");
                Console.WriteLine("       |                                      |                           *   ******     ******");
                Console.WriteLine("       |                                      |                               ******   *********");
                Console.WriteLine("       |                                      |                                ****  *****   ***");
                Console.WriteLine("       |                                      |                                ***  ***     **");
                Console.WriteLine("       |                                      |                          *************       *");
                Console.WriteLine("       |                                   =======                     ******************");
                Console.WriteLine("       |                                      |                       *****   H*****H*******");
                Console.WriteLine("       |                                      @                       ***     H-___-H  *********");
                Console.WriteLine("       |                                     /|                        ***    H     H      *******");
                Console.WriteLine("       |                                                                **    H-___-H        *****");
                Console.WriteLine("       |                                                                  *   H     H         ****");
                Console.WriteLine("       |                                                                      H     H         ***");
                Console.WriteLine("  _____|_________                                                             H-___-H         **");
                Console.WriteLine(" /               /|                                                           H     H         *");
                Console.WriteLine(" ______________ / /                                                           H-___-H");
                Console.WriteLine("              |  /                                                            H-___-H");
                Console.WriteLine(" ______________ /                                                             H-___-H");
                Console.WriteLine("                                                                              H-___-H");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine();
                break;

            case 3:
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("        _______________________________________                             ****");
                Console.WriteLine("       |                                      |                           ********");
                Console.WriteLine("       |                                      |                          **  ******");
                Console.WriteLine("       |                                      |                           *   ******     ******");
                Console.WriteLine("       |                                      |                               ******   *********");
                Console.WriteLine("       |                                      |                                ****  *****   ***");
                Console.WriteLine("       |                                      |                                ***  ***     **");
                Console.WriteLine("       |                                      |                          *************       *");
                Console.WriteLine("       |                                   =======                     ******************");
                Console.WriteLine("       |                                      |                       *****   H*****H*******");
                Console.WriteLine("       |                                      @                       ***     H-___-H  *********");
                Console.WriteLine("       |                                     /|\\                       ***    H     H      *******");
                Console.WriteLine("       |                                                                **    H-___-H        *****");
                Console.WriteLine("       |                                                                  *   H     H         ****");
                Console.WriteLine("       |                                                                      H     H         ***");
                Console.WriteLine("  _____|_________                                                             H-___-H         **");
                Console.WriteLine(" /               /|                                                           H     H         *");
                Console.WriteLine(" ______________ / /                                                           H-___-H");
                Console.WriteLine("              |  /                                                            H-___-H");
                Console.WriteLine(" ______________ /                                                             H-___-H");
                Console.WriteLine("                                                                              H-___-H");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine();
                break;

            case 2:
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("        _______________________________________                             ****");
                Console.WriteLine("       |                                      |                           ********");
                Console.WriteLine("       |                                      |                          **  ******");
                Console.WriteLine("       |                                      |                           *   ******     ******");
                Console.WriteLine("       |                                      |                               ******   *********");
                Console.WriteLine("       |                                      |                                ****  *****   ***");
                Console.WriteLine("       |                                      |                                ***  ***     **");
                Console.WriteLine("       |                                      |                          *************       *");
                Console.WriteLine("       |                                   =======                     ******************");
                Console.WriteLine("       |                                      |                       *****   H*****H*******");
                Console.WriteLine("       |                                      @                       ***     H-___-H  *********");
                Console.WriteLine("       |                                     /|\\                       ***    H     H      *******");
                Console.WriteLine("       |                                      |                         **    H-___-H        *****");
                Console.WriteLine("       |                                                                  *   H     H         ****");
                Console.WriteLine("       |                                                                      H     H         ***");
                Console.WriteLine("  _____|_________                                                             H-___-H         **");
                Console.WriteLine(" /               /|                                                           H     H         *");
                Console.WriteLine(" ______________ / /                                                           H-___-H");
                Console.WriteLine("              |  /                                                            H-___-H");
                Console.WriteLine(" ______________ /                                                             H-___-H");
                Console.WriteLine("                                                                              H-___-H");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine();
                break;

            case 1:
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("        _______________________________________                             ****");
                Console.WriteLine("       |                                      |                           ********");
                Console.WriteLine("       |                                      |                          **  ******");
                Console.WriteLine("       |                                      |                           *   ******     ******");
                Console.WriteLine("       |                                      |                               ******   *********");
                Console.WriteLine("       |                                      |                                ****  *****   ***");
                Console.WriteLine("       |                                      |                                ***  ***     **");
                Console.WriteLine("       |                                      |                          *************       *");
                Console.WriteLine("       |                                   =======                     ******************");
                Console.WriteLine("       |                                      |                       *****   H*****H*******");
                Console.WriteLine("       |                                      @                       ***     H-___-H  *********");
                Console.WriteLine("       |                                     /|\\                       ***    H     H      *******");
                Console.WriteLine("       |                                      |                         **    H-___-H        *****");
                Console.WriteLine("       |                                     /                            *   H     H         ****");
                Console.WriteLine("       |                                                                      H     H         ***");
                Console.WriteLine("  _____|_________                                                             H-___-H         **");
                Console.WriteLine(" /               /|                                                           H     H         *");
                Console.WriteLine(" ______________ / /                                                           H-___-H");
                Console.WriteLine("              |  /                                                            H-___-H");
                Console.WriteLine(" ______________ /                                                             H-___-H");
                Console.WriteLine("                                                                              H-___-H");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine();
                break;

            case 0:
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine("        _______________________________________                             ****");
                Console.WriteLine("       |                                      |                           ********");
                Console.WriteLine("       |                                      |                          **  ******");
                Console.WriteLine("       |                                      |                           *   ******     ******");
                Console.WriteLine("       |                                      |                               ******   *********");
                Console.WriteLine("       |                                      |                                ****  *****   ***");
                Console.WriteLine("       |                                      |                                ***  ***     **");
                Console.WriteLine("       |                                      |                          *************       *");
                Console.WriteLine("       |                                   =======                     ******************");
                Console.WriteLine("       |                                      |                       *****   H*****H*******");
                Console.WriteLine("       |                                      @                       ***     H-___-H  *********");
                Console.WriteLine("       |                                     /|\\                       ***    H     H      *******");
                Console.WriteLine("       |                                      |                         **    H-___-H        *****");
                Console.WriteLine("       |                                     / \\                          *   H     H         ****");
                Console.WriteLine("       |                                                                      H     H         ***");
                Console.WriteLine("  _____|_________                                                             H-___-H         **");
                Console.WriteLine(" /               /|                                                           H     H         *");
                Console.WriteLine(" ______________ / /                                                           H-___-H");
                Console.WriteLine("              |  /                                                            H-___-H");
                Console.WriteLine(" ______________ /                                                             H-___-H");
                Console.WriteLine("                                                                              H-___-H");
                Console.WriteLine("****************************************************************************************************");
                Console.WriteLine();
                break;
        }
    }

}