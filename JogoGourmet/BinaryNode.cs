using System;
using System.Linq;

namespace JogoGourmet
{
    public class BinaryNode
    {
        /// <summary>
        /// Caso este nó seja uma folha, irá armazenar a descrição do prato. 
        /// Caso não seja uma folha irá armazenar a pergunta que distingue os próximos nós um do outro
        /// 
        /// If that node is a leaf, it stores the description of the food. 
        /// If it's not a leaf, it'll store the question that distinguish the next nodes from each other.
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Armazena nulo caso seja uma folha. 
        /// Se não for uma folha, irá armazenar o próximo nó no qual, quando percorrendo a árvore, deverá ser 
        /// acessado caso a resposta para a pergunta no campo Description seja verdadeira.
        /// 
        /// Stores null in case its a leaf.
        /// If not a leaf, it'll store the next node which, when going through the tree, should
        /// be accessed if the answer to the question in the Description field is truthy.
        /// </summary>
        public BinaryNode TrueNode { get; set; }

        /// <summary>
        /// Armazena nulo caso seja uma folha. 
        /// Se não for uma folha, irá armazenar o próximo nó no qual, quando percorrendo a árvore, deverá ser 
        /// acessado caso a resposta para a pergunta no campo Description seja falsa.
        /// 
        /// Stores null in case its a leaf.
        /// If not a leaf, it'll store the next node which, when going through the tree, should 
        /// be accessed if the answer to the question in the Description field is falsy.
        /// </summary>
        public BinaryNode FalseNode { get; set; }

        public BinaryNode(string description)
        {
            Description = description;
            FalseNode = null;
            TrueNode = null;
        }

        public void Run()
        {
            bool leafNode = LeafNode();
            bool rightGuess = RightGuess();

            if (leafNode)
            {
                if (rightGuess)
                    Console.WriteLine("Acertei de novo!");
                else
                    PlayerWin();
                return;
            }

            if (rightGuess)
                TrueNode.Run();
            else
                FalseNode.Run();
        }

        private bool LeafNode()
        {
            return FalseNode == null && TrueNode == null;
        }

        private bool RightGuess()
        {
            Console.WriteLine($"O prato que você pensou é { Description }?");
            Console.Write("Responda 's' para SIM e 'n' para NÃO: ");
            char chrInput = ' ';
            while (chrInput != 's' && chrInput != 'n')
            {
                chrInput = Console.ReadLine().ElementAt(0);
                chrInput = Char.ToLower(chrInput);
                Console.Clear();
            }
            return chrInput == 's';
        }

        private void PlayerWin()
        {
            Console.WriteLine("Qual prato você pensou?");
            string strUserAnimal = Console.ReadLine();
            Console.Clear();
            Console.WriteLine($"{ strUserAnimal } é ______ mas { Description } não.");
            string strQuestion = Console.ReadLine();
            Console.Clear();

            FalseNode = new BinaryNode(Description);
            TrueNode = new BinaryNode(strUserAnimal);
            Description = strQuestion;
        }
    }
}
