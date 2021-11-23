using Antlr4.Runtime;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace comment_analyzer
{
    public class Commands
    {

        public void CommandCreate()
        {
            if (StaticData.unsaved)
            {
                StaticData.currentData = StaticData.mainForm.TextBox.Text;
                var saveBeforeCloseWindow = new SaveBeforeCloseForm();
                saveBeforeCloseWindow.ShowDialog();
            }

            StaticData.dialogService.FilePath = "";
            StaticData.currentData = "";
            StaticData.mainForm.TextBox.Text = StaticData.currentData;
            StaticData.mainForm.Heading = "Language Processor - unnamed";
        }

        public void CommandOpen()
        {
            if (StaticData.unsaved)
            {
                StaticData.currentData = StaticData.mainForm.TextBox.Text;
                var saveBeforeCloseWindow = new SaveBeforeCloseForm();
                saveBeforeCloseWindow.ShowDialog();
            }

            StaticData.dialogService.OpenFileDialog();
            StaticData.currentData = StaticData.fileService.ReadFile(StaticData.dialogService.FilePath);

            StaticData.mainForm.TextBox.Text = StaticData.currentData;

            StaticData.mainForm.Heading = "Language Processor";
            if (StaticData.dialogService.FilePath != null || StaticData.dialogService.FilePath != "")
                StaticData.mainForm.Heading += " - " + StaticData.dialogService.FilePath;
            else
                StaticData.mainForm.Heading += " - unnamed";

            StaticData.unsaved = false;
        }

        public void CommandSave()
        {
            StaticData.currentData = StaticData.mainForm.TextBox.Text;

            if (StaticData.dialogService.FilePath == null)
            {
                StaticData.dialogService.SaveFileDialog();
                StaticData.fileService.SaveFile(StaticData.dialogService.FilePath, StaticData.currentData);
            }
            else
            {
                StaticData.fileService.SaveFile(StaticData.dialogService.FilePath, StaticData.currentData);
            }

            StaticData.unsaved = false;
            StaticData.mainForm.Heading = "Language Processor - " + StaticData.dialogService.FilePath;
        }

        public void CommandSaveAs()
        {
            StaticData.currentData = StaticData.mainForm.TextBox.Text;
            StaticData.dialogService.SaveFileDialog();
            StaticData.fileService.SaveFile(StaticData.dialogService.FilePath, StaticData.currentData);
            StaticData.mainForm.Heading = "Language Processor - " + StaticData.dialogService.FilePath;
            StaticData.unsaved = false;
        }

        public void CommandUndo()
        {
            if (StaticData.undoStack.Count > 0)
            {
                StaticData.redoStack.Push(StaticData.mainForm.TextBox.Text);
                string newValue = StaticData.undoStack.Pop();
                StaticData.mainForm.TextBox.Text = newValue;
            }
        }

        public void CommandRedo()
        {
            if (StaticData.redoStack.Count > 0)
            {
                StaticData.undoStack.Push(StaticData.mainForm.TextBox.Text);
                string newValue = StaticData.redoStack.Pop();
                StaticData.mainForm.TextBox.Text = newValue;
            }
        }

        public void CommandCopy()
        {
            if (StaticData.mainForm.TextBox.SelectionLength > 0)
                StaticData.mainForm.TextBox.Copy();
        }
        public void CommandPaste()
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text) == true)
            {
                if (StaticData.mainForm.TextBox.SelectionLength > 0)
                {
                    StaticData.mainForm.TextBox.SelectionStart = StaticData.mainForm.TextBox.SelectionStart + StaticData.mainForm.TextBox.SelectionLength;
                }
                StaticData.mainForm.TextBox.Paste();
            }
        }

        public void CommandCut()
        {
            if (StaticData.mainForm.TextBox.SelectedText != "")
                StaticData.mainForm.TextBox.Cut();
        }

        public void CommandDelete()
        {
            int StartPosDel = StaticData.mainForm.TextBox.SelectionStart;
            int LenSelection = StaticData.mainForm.TextBox.SelectionLength;
            StaticData.mainForm.TextBox.Text = StaticData.mainForm.TextBox.Text.Remove(StartPosDel, LenSelection);
        }

        public void CommandSelectAll()
        {
            StaticData.mainForm.TextBox.SelectAll();
        }

        public void CommandHelp()
        {
            Help.ShowHelp(null, StaticData.prePath + "help/help1.html");
        }

        public void CommandCheck()
        {
            switch (StaticData.mode) {
                case "Automata":
                    CommandCheckAutomata();
                    break;
                case "ANTLR":
                    CommandCheckANTLR();
                    break;
                case "Flex+Bison":
                    CommandCheckFlexBison();
                    break;
                default:
                    break;
            }
        }

        public void CommandCheckAutomata()
        {
            string[] errors = { "Ошибок не обнаружено",
                                "Пустая строка",
                                "Строка не является комментарием(начинается не с символа *)"};
            string warning = "Обнаружена последовательность символов не из алфавита '";

            int line = 0;
            int status = 0;
            bool hasErrors = false;

            int errorsCount = 0;
            int warnCount = 0;

            string[] strings = StaticData.mainForm.TextBox.Text.Split('\n');
            for (int i = 0; i < strings.Length; i++)
            {
                strings[i] = strings[i].TrimEnd('\r');
            }

            List<string> wrongSymbols = new List<string>();
            List<int> wrongPositions = new List<int>();
            Automata automata = new Automata();

            StaticData.mainForm.ResultsTextBox.Text = "";

            for (line = 0; line < strings.Length; line++)
            {
                status = automata.analyzeLine(strings[line], ref wrongSymbols, ref wrongPositions);

                if (status >= 3)
                {
                    for (int j = 0; wrongSymbols.Count > j; j++)
                    {
                        warnCount++;
                        StaticData.mainForm.ResultsTextBox.Text += "Строка " + (line + 1).ToString() + ": [Предуп] " +
                            warning + wrongSymbols[j] + "'(начало с " + (wrongPositions[j] + 1) + " символа)" + Environment.NewLine;
                    }
                    status -= 3;
                    wrongSymbols.Clear();
                    wrongPositions.Clear();
                }
                if (status != 0)
                {
                    StaticData.mainForm.ResultsTextBox.Text += "Строка " + (line + 1).ToString() + ": [Ошибка] " +
                            errors[status] + Environment.NewLine;
                    hasErrors = true;
                    errorsCount++;
                }

            }

            StaticData.mainForm.ResultsTextBox.Text += Environment.NewLine;

            if (warnCount > 0)
            {
                StaticData.mainForm.ResultsTextBox.Text += "Предупреждений: " + warnCount + Environment.NewLine;
            }
            if (!hasErrors)
            {
                StaticData.mainForm.ResultsTextBox.Text += "Ошибок не обнаружено" + Environment.NewLine;
            }
            else
            {
                StaticData.mainForm.ResultsTextBox.Text += "Ошибок: " + errorsCount + Environment.NewLine;
            }
        }

        public void CommandCheckANTLR()
        {
            // Выделяем элемент формы с исходным текстом
            String source = StaticData.mainForm.TextBox.Text;

            // Устанавливаем входной поток символов из элемента формы
            ICharStream input = CharStreams.fromString(source);
            // Настраиваем лексер на этот поток
            CommentsFortranLexer lexer = new CommentsFortranLexer(input);
            // Создаем поток токенов на основе лексера
            CommonTokenStream tokens = new CommonTokenStream(lexer);
            // Создаем парсер
            CommentsFortranParser parser = new CommentsFortranParser(tokens);

            // Удаляем стандартный обработчик ошибок
            parser.RemoveErrorListeners();
            // Объявляем самописный обработчик ошибок
            AntlrErrorListener customListener = new AntlrErrorListener();
            // Добавляем его в парсер
            parser.AddErrorListener(customListener);
            // Запускаем первое правило грамматики
            parser.prog();

            StaticData.mainForm.ResultsTextBox.Text = "";

            // Далее идет вывод результатов анализа исходного текста
            if (customListener.errorsList.Count == 0)
                StaticData.mainForm.ResultsTextBox.Text = "No errors\r\n";

            foreach (var error in customListener.errorsList)
            {
                StaticData.mainForm.ResultsTextBox.Text += error + "\r\n";
            }
        }

        public void CommandCheckFlexBison ()
        {
            String source = StaticData.mainForm.TextBox.Text;

            int port = 777;
            string address = "127.0.0.1";

            try
            {
                IPEndPoint ipPoint = new IPEndPoint(IPAddress.Parse(address), port);

                Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                // подключаемся к удаленному хосту
                socket.Connect(ipPoint);
                //Console.Write("Введите сообщение:");
                string message = Console.ReadLine();
                byte[] data = Encoding.Unicode.GetBytes(source);
                data = Encoding.ASCII.GetBytes(source);
                socket.Send(data);

                // получаем ответ
                data = new byte[256]; // буфер для ответа
                StringBuilder builder = new StringBuilder();
                int bytes = 0; // количество полученных байт

                do
                {
                    bytes = socket.Receive(data, data.Length, 0);
                    builder.Append(Encoding.ASCII.GetString(data, 0, bytes));
                }
                while (socket.Available > 0);
                //Console.WriteLine("ответ сервера: " + builder.ToString());
                StaticData.mainForm.ResultsTextBox.Text = builder.ToString();

                // закрываем сокет
                socket.Shutdown(SocketShutdown.Both);
                socket.Close();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.Message);
                StaticData.mainForm.ResultsTextBox.Text = ex.Message.ToString();
            }
            /*
            String source = StaticData.mainForm.TextBox.Text;
            List<String> sourceLines = new List<string>(source.Split('\n'));

            //Write source text
            String pathInput = "../../Flex+Bison engine/input.txt";
            using (StreamWriter sw = File.CreateText(pathInput))
            {
                foreach(String line in sourceLines)
                {
                    sw.WriteLine(line.Trim('\r'));
                }
            }

            //Here executing analyzer process
            var cppProcess = new Process();
            cppProcess.StartInfo = new ProcessStartInfo
            {
                FileName = "../../Flex+Bison engine/CommentAnalyzer.exe",
                UseShellExecute = false,
                RedirectStandardInput = true,
                RedirectStandardOutput = true,
            };

            cppProcess.Start();

            StreamReader str = cppProcess.StandardOutput;
            StreamWriter stw = cppProcess.StandardInput;

            StaticData.mainForm.ResultsTextBox.Text = "";
            foreach (string line in sourceLines)
            {
                stw.WriteLine(line);
                StaticData.mainForm.ResultsTextBox.Text += str.ReadLine();
            }

            StaticData.mainForm.ResultsTextBox.Text = str.ReadToEnd();

            cppProcess.WaitForExit();

            //Read and show result of analysis
            /*
            String pathOutput = "../../Flex+Bison engine/output.txt";
            if (File.Exists(pathOutput))
            {
                using (StreamReader sr = File.OpenText(pathOutput))
                {
                    String line;
                    StaticData.mainForm.ResultsTextBox.Text = "";
                    while ((line = sr.ReadLine()) != null)
                    {
                        StaticData.mainForm.ResultsTextBox.Text += line + '\n';
                    }
                }
            }
            */
            /*
            var cppProcess = new Process();
            cppProcess.StartInfo = new ProcessStartInfo
            {
                FileName = "../../Flex+Bison engine/CommentAnalyzer.exe",
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardInput = true,
            };
            */
            /*
            cppProcess.OutputDataReceived += (sender, arg) =>
            {
                Console.WriteLine("Received: {0}", arg.Data);
            };
            */

            /*
            cppProcess.Start();

            StreamReader reader = cppProcess.StandardOutput;
            StreamWriter writer = cppProcess.StandardInput;

            foreach (String line in sourceLines)
            {
                writer.WriteLine(line);
            }

            StaticData.mainForm.ResultsTextBox.Text = reader.ReadToEnd();
            */
            /*
            cppProcess.OutputDataReceived += new DataReceivedEventHandler
            (
                delegate(object sender, DataReceivedEventArgs e)
                {
                    using (StreamReader output = cppProcess.StandardOutput)
                    {
                        StaticData.mainForm.ResultsTextBox.Text += output.ReadToEnd();
                    }
                }
            );
            */



            //writer.Close();
            //reader.Close();
            //cppProcess.WaitForExit();

        }
    }
}
