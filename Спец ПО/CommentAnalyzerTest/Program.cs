using System;
using Antlr4.Runtime;

namespace CommentAnalyzerTest
{
    class Program
    {
        static void Main(string[] args)
        {
			try
			{
				// В качестве входного потока символов устанавливаем консольный ввод
				AntlrInputStream input = new AntlrInputStream(Console.In);
				// Настраиваем лексер на этот поток
				CommentsFortranLexer lexer = new CommentsFortranLexer(input);
				// Создаем поток токенов на основе лексера
				CommonTokenStream tokens = new CommonTokenStream(lexer);
				// Создаем парсер
				CommentsFortranParser parser = new CommentsFortranParser(tokens);
				// И запускаем первое правило грамматики!!!
				parser.prog();
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}
			Console.ReadKey();
		}
    }
}
