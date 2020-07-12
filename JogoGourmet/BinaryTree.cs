using System;
using System.Linq;

namespace JogoGourmet
{
    class BinaryTree
    {
        BinaryNode btnRoot;
        public BinaryTree(string description, string truthyDesc, string falsyDesc)
        {
            btnRoot = new BinaryNode(description);
            btnRoot.TrueNode = new BinaryNode(truthyDesc);
            btnRoot.FalseNode = new BinaryNode(falsyDesc);
        }
        public void Play()
        {
            var chrInput = 's';
            while (chrInput == 's')
            {
                btnRoot.Run();
                Console.WriteLine("Quer jogar novamente?");
                Console.Write("Responda 'S' para SIM e 'N' para NÃO: ");
                chrInput = Console.ReadLine().ElementAt(0);
                Console.Clear();
            }
        }
    }
}
