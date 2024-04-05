namespace JogoDaForca.ConsoleApp
{
    internal class Program
    {
        static string[] palavras = { "ABACATE", "ABACAXI", "ACEROLA", "AÇAI", "ARAÇA", "BACABA", "BACURI", "BANANA", "CAJA", "CAJU", "CARAMBOLA", "CUPUAÇU", "UVAIA", "GRAVIOLA", "GOIABA", "JABUTICABA", "JENIPAPO", "MAÇÃ", "MANGABA", "MANGA", "MARACUJÁ", "MURICI", "PEQUI", "PITANGA", "PITAYA", "SAPOTI", "TANGERINA", "UMBU", "UVA" };

        static void Main(string[] args)
        {
            var random = new Random();
            int indexPalavras = random.Next(palavras.Length);
            int limite = 5;
            int tentativaAtual = 0;
            char[] charArray = palavras[indexPalavras].ToCharArray();
            char[] palavraEscondida = new char[charArray.Length];
            string letrasErradas = "";
            bool areEqual;

            for (int i = 0; i < charArray.Length; i++)
            {
                palavraEscondida[i] = '_';
            }
            do
            {
                ImprimirForca(limite, tentativaAtual, palavraEscondida, letrasErradas);

                Console.Write("\nQual o seu chute? ");
                char letraChute = Convert.ToChar(Console.ReadLine().ToUpper());

                Console.Clear();

                bool letraCorreta = false;
                for (int i = 0; i < charArray.Length; i++)
                {
                    if (letraChute == charArray[i])
                    {
                        palavraEscondida[i] = letraChute;
                        letraCorreta = true;
                    }
                }

                if (letraCorreta == false)
                {
                    tentativaAtual++;
                    letrasErradas += letraChute;
                }

                areEqual = charArray.SequenceEqual(palavraEscondida);

                if (tentativaAtual == limite)
                {
                    ImprimirForca(limite, tentativaAtual, palavraEscondida, letrasErradas);
                    Console.WriteLine("Suas tentativas acabaram :(");
                    break;
                }

                if (areEqual)
                {
                    ImprimirForca(limite, tentativaAtual, palavraEscondida, letrasErradas);
                    Console.WriteLine("Parabéns! Você acertou a palavra!");
                    break;
                }

            } while (areEqual == false);

            Console.ReadKey();
        }

        private static void ImprimirForca(int limite, int tentativaAtual, char[] palavraEscondida, string letrasErradas)
        {
            string cabeca = tentativaAtual >= 1 ? " o " : " ";
            string peitoral = tentativaAtual >= 2 ? "x" : " ";
            string bracoEsquerdo = tentativaAtual >= 3 ? "/" : " ";
            string bracoDireito = tentativaAtual >= 3 ? @"\" : " ";
            string barriga = tentativaAtual >= 4 ? " x " : " ";
            string pernaEsquerda = tentativaAtual >= 5 ? "/" : " ";
            string pernaDireita = tentativaAtual >= 5 ? @" \" : " ";

            Console.WriteLine(" -----------        ");
            Console.WriteLine(" |/        |        ");
            Console.WriteLine($" |        {cabeca}       ");
            Console.WriteLine($" |        {bracoEsquerdo}{peitoral}{bracoDireito} ");
            Console.WriteLine($" |        {barriga} ");
            Console.WriteLine($" |        {pernaEsquerda}{pernaDireita}      ");
            Console.WriteLine(" | ");
            Console.WriteLine(" | ");
            Console.WriteLine(" |_");
            Console.WriteLine($"Tentativas restantes: {limite - tentativaAtual}");
            Console.WriteLine($"Letras já testadas: {string.Join(", ", letrasErradas)}");
            Console.WriteLine(palavraEscondida);
        }
    }
}

//prox passo? ss