using System;
using System.Linq;

namespace JogoGourmet
{
    class Program
    {
        static void Main(string[] args)
        {
            NewGame();
        }

        static void NewGame()
        {
            Console.WriteLine("Pense em um prato que você gosta");
            var btAnimals = new BinaryTree("massa", "lasanha", "bolo de chocolate");
            btAnimals.Play();
        }
    }
}
