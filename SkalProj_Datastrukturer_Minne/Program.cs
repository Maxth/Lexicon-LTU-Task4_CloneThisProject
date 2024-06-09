using System;
using System.Collections;
using System.Text;

/*
TEORI & FAKTA

Fråga 1: Hur fungerar stacken och heapen? Förklara gärna med exempel eller skiss på dess
grundläggande funktion

Svar: Stacken lagrar värdetyper i en trave där man för att komma åt den näst översta först behöver flytta på den översta osv.
      Heapen lagrar referenstyper i spridd form där allt är tillgängligt på en gång, likt saker spridda över ett golv.


Fråga 2: Vad är Value Types respektive Reference Types och vad skiljer dem åt?

Svar: Value types lagras på stacken medan reference types lagras på heapen. Jag brukar tänka att value types är primitivare typer än reference types,
      med undantag från string som uppför sig som en value type men som faktiskt är en reference type.


Fråga 3:

Svar: Det beror på skillnaden mellan value types och reference types.

      I den första metoden används enbart valuetypes så raden då "y = x" gör ingenting annat än
      att y "kopierar" värdet på x så efterföljande rad "y = 4" har ingen påverkan på värdet för x.

      I den andra däremot skapar vi upp ett objekt med propertien MyValue. På raden då "y = x" säger vi att y ska PEKA PÅ samma objekt som x redan gör.
      Raden efter sätts detta objekts MyValue till 4 med "y.MyValue = 4". Sedan returneras x.MyValue vilket vi precis satte till 4, dock med en annan referens än x - nämligen y.
*/



namespace SkalProj_Datastrukturer_Minne
{
    class Program
    {
        /// <summary>
        /// The main method, vill handle the menues for the program
        /// </summary>
        /// <param name="args"></param>
        static void Main()
        {
            while (true)
            {
                Console.WriteLine(
                    "Please navigate through the menu by inputting the number \n(1, 2, 3 , 4, 5, 0) of your choice"
                        + "\n1. Examine a List"
                        + "\n2. Examine a Queue"
                        + "\n3. Examine a Stack"
                        + "\n4. CheckParenthesis"
                        + "\n5. ReverseText"
                        + "\n0. Exit the application"
                );
                char input = ' '; //Creates the character input to be used with the switch-case below.
                try
                {
                    input = Console.ReadLine()![0]; //Tries to set input to the first char in an input line
                }
                catch (IndexOutOfRangeException) //If the input line is empty, we ask the users for some input.
                {
                    Console.Clear();
                    Console.WriteLine("Please enter some input!");
                }
                switch (input)
                {
                    case '1':
                        ExamineList();
                        break;
                    case '2':
                        ExamineQueue();
                        break;
                    case '3':
                        ExamineStack();
                        break;
                    case '4':
                        CheckParanthesis();
                        break;
                    case '5':
                        ReverseText();
                        break;
                    /*
                     * Extend the menu to include the recursive
                     * and iterative exercises.
                     */
                    case '0':
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Please enter some valid input (0, 1, 2, 3, 4, 5)");
                        break;
                }
            }
        }

        /// <summary>
        /// Examines the datastructure List
        /// </summary>
        static void ExamineList()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch statement with cases '+' and '-'
             * '+': Add the rest of the input to the list (The user could write +Adam and "Adam" would be added to the list)
             * '-': Remove the rest of the input from the list (The user could write -Adam and "Adam" would be removed from the list)
             * In both cases, look at the count and capacity of the list
             * As a default case, tell them to use only + or -
             * Below you can see some inspirational code to begin working.
            */
            List<string> theList = new List<string>();
            System.Console.WriteLine(
                "Enter +<something> or -<something> to add or remove <something> to the list, respectively. Enter anything else to go back to main menu."
            );
            bool keepExamining = true;
            do
            {
                string input = Console.ReadLine()!;
                char nav = input![0];
                string value = input.Substring(1);

                switch (nav)
                {
                    case '+':
                        theList.Add(value);
                        Utils.PrintListDetails(theList);
                        break;

                    case '-':
                        theList.Remove(value);
                        Utils.PrintListDetails(theList);
                        break;
                    default:
                        keepExamining = false;
                        break;
                }
            } while (keepExamining);
            /*
            Fråga 2: När ökar listans kapacitet? (Alltså den underliggande arrayens storlek)

            Svar: Den ökar då man lägger till något den inte har plats för.


            Fråga 3:  Med hur mycket ökar kapaciteten?

            Svar: Den initiala kapaciteten var 4 och den ökar med en faktor 2 varje gång man lägger till något den inte har plats för.


            Fråga 4: Varför ökar inte listans kapacitet i samma takt som element läggs till?

            Svar: Eftersom det är en resurskrävande operation att reallokera listans föremål till en ny array så ökas listans capacity
                  inte varje gång man lägger till något den inte har plats med.


            Fråga 5: Minskar kapaciteten när element tas bort ur listan?

            Svar: Nej. Jag antar av samma anledning som för Fråga 4.


            Fråga 6: När är det då fördelaktigt att använda en egendefinierad array istället för en lista?

            Svar: När man vet hur många föremål man behöver lagra på förhand.
            
            */
        }

        /// <summary>
        /// Examines the datastructure Queue
        /// </summary>
        static void ExamineQueue()
        {
            /*
             * Loop this method untill the user inputs something to exit to main menue.
             * Create a switch with cases to enqueue items or dequeue items
             * Make sure to look at the queue after Enqueueing and Dequeueing to see how it behaves
            */
            bool keepExamining = true;

            Queue<string> queue = new Queue<string>();
            System.Console.WriteLine(
                "Enter +<something> or - to add <something> or remove from the queue, respectively. Enter anything else to go back to main menu."
            );
            do
            {
                string input = Console.ReadLine()!;
                char nav = input![0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        queue.Enqueue(value);
                        Utils.PrintCollectionDetails(queue);
                        break;
                    case '-':
                        queue.Dequeue();
                        Utils.PrintCollectionDetails(queue);
                        break;
                    default:
                        keepExamining = false;
                        break;
                }
            } while (keepExamining);
        }

        /// <summary>
        /// Examines the datastructure Stack
        /// </summary>
        static void ExamineStack()
        {
            /*
             * Loop this method until the user inputs something to exit to main menue.
             * Create a switch with cases to push or pop items
             * Make sure to look at the stack after pushing and and poping to see how it behaves
            */

            bool keepExamining = true;

            Stack<string> stack = new Stack<string>();
            System.Console.WriteLine(
                "Enter +<something> or - to add <something> or remove from the stack, respectively. Enter anything else to go back to main menu."
            );
            do
            {
                string input = Console.ReadLine()!;
                char nav = input![0];
                string value = input.Substring(1);
                switch (nav)
                {
                    case '+':
                        stack.Push(value);
                        Utils.PrintCollectionDetails(stack);
                        break;
                    case '-':
                        stack.Pop();
                        Utils.PrintCollectionDetails(stack);
                        break;
                    default:
                        keepExamining = false;
                        break;
                }
            } while (keepExamining);

            /*
            Fråga 1: Simulera ännu en gång ICA-kön på papper. Denna gång med en stack. Varför är det
                     inte så smart att använda en stack i det här fallet?
            
            Svar:    Eftersom en kö på ICA kräver FIFU, annars skulle folk bli irriterade. En stack som implementerar FISU skulle medföra
                     att den senaste personen som ställde sig i kön fick hjälp först, medans den som var först in för vänta längst.
            
            */
        }

        /*
            Fråga 2: Implementera en ReverseText-metod som läser in en sträng från användaren och
                     med hjälp av en stack vänder ordning på teckenföljden för att sedan skriva ut den
                     omvända strängen till användaren.
        */
        static void ReverseText()
        {
            System.Console.WriteLine("Enter a string to be reverted with the help of a Stack!");

            string input = Console.ReadLine()!;

            Stack stack = new Stack();

            for (int i = 0; i < input.Length; i++)
            {
                stack.Push(input[i]);
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < input.Length; i++)
            {
                sb.Append(stack.Pop());
            }

            System.Console.WriteLine(sb);
        }

        static void CheckParanthesis()
        {
            /*
             * Use this method to check if the paranthesis in a string is Correct or incorrect.
             * Example of correct: (()), {}, [({})],  List<int> list = new List<int>() { 1, 2, 3, 4 };
             * Example of incorrect: (()]), [), {[()}],  List<int> list = new List<int>() { 1, 2, 3, 4 );
             */

            System.Console.WriteLine("Enter a string to be checked whether it is well formed!");

            string input = Console.ReadLine()!;

            char[] startingParenthesis = ['(', '[', '{'];
            char[] endingParenthesis = [')', ']', '}'];
            bool isWellFormed = true;
            var stack = new Stack<char>();

            for (int i = 0; i < input.Length; i++)
            {
                if (startingParenthesis.Contains(input[i]))
                {
                    stack.Push(input[i]);
                }
                if (endingParenthesis.Contains(input[i]))
                {
                    if (stack.Count > 0)
                    {
                        if (!isParenthesisMatching(stack.Pop(), input[i]))
                        {
                            isWellFormed = false;
                            break;
                        }
                    }
                    else
                    {
                        isWellFormed = false;
                        break;
                    }
                }
            }

            System.Console.WriteLine("String wellformed: " + isWellFormed);
        }

        static bool isParenthesisMatching(char openingChar, char closingChar)
        {
            switch (openingChar)
            {
                case '(':
                    return closingChar == ')';
                case '[':
                    return closingChar == ']';
                case '{':
                    return closingChar == '}';
                default:
                    return false;
            }
        }
    }
}
