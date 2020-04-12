using System;
using System.Collections.Generic;

namespace NumerosPrimos
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Operações com números primos:");
            Console.WriteLine();

            Console.Write("Quantos números terá o conjunto dos números naturais? ");
            int n = int.Parse(Console.ReadLine());

            HashSet<int> A = new HashSet<int>(); // Conjunto que vai receber os números naturais...
            HashSet<int> B = new HashSet<int>(); // Comjunto que vai receber os números primos...
            HashSet<int> C = new HashSet<int>() {1}; // Conjunto que vai receber os números compostos. OBS: recebe {1} por padrão..

            for (int i = 1; i <= n; i++) // Inseri 'N' números no conjunto A (Conjuntos dos números naturais)...
            {
                A.Add(i);
                if (i > 1) // Inicia a verificação para colocar os números primos no conjunto 'B'...
                    if (NumeroEhPrimo(A, i)) // Se a função 'NumeroEhPrimo' retornar 'true', adiciona o número no conjunto 'B' dos números primos...
                        B.Add(i); 
                    else // Senão adiciona o número no conjunto 'C' dos números compostos... 
                        C.Add(i);
            }

            // Escreve na tela o conjunto 'A'
            Console.WriteLine();
            Console.Write("Cn = { ");
            foreach (int x in A)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("}");

            // Escreve na tela o conjunto 'B'
            Console.WriteLine();
            Console.Write("Cnp = { ");
            foreach (int x in B)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("}");

            // Escreve na tela o conjunto 'C'
            Console.WriteLine();
            Console.Write("Cnc = { ");
            foreach (int x in C)
            {
                Console.Write(x + " ");
            }
            Console.WriteLine("}");

            // Solicita um número do conjunto 'A' para fatorar...
            Console.WriteLine();
            Console.Write("Digite um número do conjunto 'Cn' que deseja fatorar: ");
            n = int.Parse(Console.ReadLine());

            while (A.Contains(n) == false) // Verifica se o número pertence ao conjunto 'A'...
            {
                Console.Write("Número não pertence ao conjunto 'Cn'. Informe outro número: ");
                n = int.Parse(Console.ReadLine());
            }

            Fatoracao(B, n); // Chama a função 'Fatoraçao'...

            Console.ReadLine();
        }

        public static bool NumeroEhPrimo(HashSet<int> conjunto, int numero)
        {
            HashSet<int> A = new HashSet<int>() { 1, numero };
            HashSet<int> B = new HashSet<int>();
            foreach (int x in conjunto) // faz uma cópia do Conjunto A da classe program no conjunto B da função...
            {
                B.Add(x);
            }
            bool retorno = true; // Variável que será retornada no fim da função. 
            B.ExceptWith(A); // Exclui do conjunto 'B' os elementos do conjunto 'A' que contem {1 e o numero testado} para depois testar se é divisível por algum outro numero do conjunto 'B'...
            foreach (int x in B)
            {
                switch (numero % x) // Verifica se o resto da divisaõ é 0...
                {
                    case 0: // Caso verdadeiro, numero é tratado como composto...
                        retorno = false; // Variável retorno recebe 'false'...
                        break; // sai do swith...
                }
                if (retorno == false) // Se ao sair do Swith a variável retorno recebeu 'fasle'... 
                    break; // Pára o loop... 
            }
            return retorno; // A funçao retorna 'false' através da variável retorno indicando q o número testado não é primo
        }

        public static void Fatoracao(HashSet<int> conjunto, int numero)
        {
            int divisao = numero; // Inicia com o número que será testado, mas receberá as divisões entre o número testado e os elementos do conjunto dos números primos...
            string fatoracao = ""; // Guarda as escritas dos algorítimos da fatoração
            HashSet<int> fatores = new HashSet<int>(); // Conjunto que receberá os números primos não permitindo repetições...
            List<int> expoentes = new List<int>(); // Lista que receberá o números primos premitindo repetições que servirão para contar e definir os expoentes

            Console.WriteLine();
            Console.WriteLine("Fatorando...");
            Console.WriteLine();
             
            foreach (int x in conjunto) // Percorre o conjunto dos números primos... 
            {
                while (divisao % x == 0) // Verifica se o número testado é divisível pelo elemento atual do conjunto...
                {
                    fatoracao += x + "x";
                    fatores.Add(x);
                    expoentes.Add(x);
                    Console.WriteLine(divisao + " / " + x + " = " + divisao/x); // Se for divisível escreve o 1º algorítimo da fatoração, dividindo, enquanto o valor da varíavel 'divisao' for divisível pelo elemento atual do conjunto...
                    divisao /= x; // Atualiza a variável com o valor da divisão para o calculo com o próximo elemento...
                }
            }

            Console.WriteLine();
            Console.WriteLine("Ou");
            Console.WriteLine(fatoracao.Substring(0,fatoracao.Length-1) + "=" + numero); // Escreve o 2º algorítimo da fatoração
            Console.WriteLine();
            Console.WriteLine("Ou");

            fatoracao = ""; // Limpa a variável para receber as escritas dos próximos algorítimos 
            foreach (int x in fatores) // Percorre o conjunto de fatores primos que não contém duplicatas
            {
                fatoracao += x.ToString(); // Atualiza a variável com os elementos do do conjunto de fatores
                int expoente = expoentes.FindAll(y => y == x).Count; // Atribui o valor do expoente com o número de elementos retornado pela função FindAll da Lista de expoentes
                if(expoente > 1){ // Varifica se o valor do expoente retornado é maior que 1...
                    fatoracao += ("(" + expoente + ")x"); // Atualiza a variável que recebe a escrita do algorítimo com o expoente...
                }
                else
                {
                    fatoracao += ("x"); // Atualiza a variável que recebe a escrita do algorítimo sem o expoente...
                }
            }
            Console.WriteLine(fatoracao.Substring(0, fatoracao.Length - 1) + "=" + numero); // Escreve o 3º algorítimo da fatoração
        }    
    }
}
