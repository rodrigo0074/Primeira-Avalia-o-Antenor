//Dupla: Alysson Luiz Tavares da Rocha - Matrícula:01359689
//José Rodrigo Lins de Barros - Matrícula:01349064

//Use o comando no Terminal: dotnet run

//Essa linha importa a biblioteca System.Text.RegularExpressions, que fornece recursos para trabalhar com expressões regulares no código.
using System.Text.RegularExpressions;

//Essa linha exibe uma mensagem no console solicitando ao usuário que digite uma sequência de caracteres.
Console.WriteLine("Digite uma sequência de caracteres (máximo de 10 caracteres):");

//Essa parte do código realiza a leitura da entrada do usuário por meio do Console.ReadLine().
//Em seguida, ele verifica se a sequência de caracteres digitada pelo usuário tem um tamanho válido (entre 1 e 10 caracteres).
//Se a entrada for inválida, uma mensagem de erro é exibida e o usuário é solicitado a fornecer uma nova entrada.
string inputString = "";

while (inputString.Length == 0 || inputString.Length > 10)
{
    inputString = Console.ReadLine();
    if (inputString.Length > 10)
    {
        Console.WriteLine("Entrada inválida. Digite uma sequência de caracteres com no máximo 10 caracteres:");
    }
}


//Essa linha chama a função Tokenize() para tokenizar a sequência de caracteres fornecida pelo usuário.
//O resultado é uma lista de tokens, que são subsequências válidas encontradas na sequência de caracteres.
List<string> tokens = Tokenize(inputString);

//Essas linhas exibem os tokens encontrados na sequência de caracteres. Cada token é impresso em uma nova linha.
Console.WriteLine("Tokens:");
foreach (string token in tokens)
{
    Console.WriteLine(token);
}

//Essas linhas chamam a função IsMathExpression() para verificar se a sequência de caracteres fornecida pelo usuário corresponde a uma expressão matemática.
//Se for o caso, uma mensagem informando que é uma expressão matemática é exibida.
//Função IsMathExpression(string inputString):
//Essa função verifica se a sequência de caracteres fornecida é uma expressão matemática válida. Ele realiza as seguintes verificações:
//Verifica se a sequência possui pelo menos 3 caracteres.
//Verifica se o primeiro caractere é uma letra.
//Verifica se o segundo caractere é um operador matemático válido.
//Verifica se o terceiro caractere é uma letra.
//Se todas essas condições forem atendidas, a função retorna true, indicando que é uma expressão matemática válida. Caso contrário, retorna false.
if (IsMathExpression(inputString))
{
    Console.WriteLine("Isso é uma expressão matemática.");
}

static bool IsMathExpression(string inputString)
{
    // Verificar se a sequência possui pelo menos 3 caracteres
    if (inputString.Length < 3)
    {
        return false;
    }

    // Verificar se o primeiro caractere é uma letra
    if (!Char.IsLetter(inputString[0]))
    {
        return false;
    }

    // Verificar se o segundo caractere é um operador matemático
    if (!IsMathOperator(inputString[1]))
    {
        return false;
    }

    // Verificar se o terceiro caractere é uma letra
    if (!Char.IsLetter(inputString[2]))
    {
        return false;
    }

    return true;
}

//Função IsMathOperator(char character):
//Essa função verifica se o caractere fornecido é um operador matemático válido.
//Os operadores válidos são +, -, *, /, %, <, >, =, !, &, |, ~ e ^. 
//A função retorna true se o caractere for um operador válido e false caso contrário.
static bool IsMathOperator(char character)
{
    HashSet<char> validOperators = new HashSet<char>("+-*/%<>=!&|~^");
    return validOperators.Contains(character);
}

//Função Tokenize(string inputString):
//Essa função recebe a sequência de caracteres fornecida pelo usuário e a divide em tokens. Um token é uma subsequência válida que consiste em letras, dígitos e operadores matemáticos válidos.
//A função percorre a sequência de caracteres caractere por caractere e constrói os tokens conforme as regras definidas.
//A função também verifica se há caracteres inválidos na sequência de entrada e exibe uma mensagem de erro para cada caractere inválido encontrado.
//Além disso, a função verifica se os tokens começam com um dígito e exibe uma mensagem informando que essas palavras são reservadas pelo sistema.
//Por fim, a função retorna a lista de tokens encontrados. Cada token é uma string na lista.
static List<string> Tokenize(string inputString)
{
    HashSet<char> validChars = new HashSet<char>("abcdefghijklmnopqrsuvABCDEFGHIJKLMNOPQRSUV0123456789+-*/%()[]{}<>=!&|~^,$.@#?");
    HashSet<char> validOperators = new HashSet<char>("+-*/%<>=!&|~^");
    List<string> tokens = new List<string>();
    string buffer = "";

    for (int i = 0; i < inputString.Length; i++)
    {
        char currentChar = inputString[i];

        if (validChars.Contains(currentChar))
        {
            buffer += currentChar;

            // Verificar se o próximo caractere não é um caractere válido ou se chegamos ao final da sequência
            if (i + 1 == inputString.Length || !validChars.Contains(inputString[i + 1]))
            {
                tokens.Add(buffer);
                buffer = "";
            }
        }
        else if (!Char.IsWhiteSpace(currentChar))
        {
            Console.WriteLine($"Caractere inválido: {currentChar}");
        }
    }

    
  if (Char.IsDigit(inputString[0])) {
    Console.WriteLine("Palavras iniciadas com números são sempre palavras reservadas pelo sistema.");
}


        for (int i = 0; i < tokens.Count; i++) {
            string token = tokens[i];
            if (Char.IsDigit(token[0])) {
                Console.WriteLine($"A palavra '{token}' é uma palavra reservada.");
            }
        }

    return tokens;
}