using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;


namespace comment_analyzer
{
    class AntlrErrorListener : BaseErrorListener
    {
        public List<string> errorsList = new List<string>();

        public override void SyntaxError(TextWriter output, IRecognizer recognizer, IToken offendingSymbol, int line, int charPositionInLine, string msg, RecognitionException e)
        {
            errorsList.Add("Error(" + line + ":" + charPositionInLine + "): " + msg);
            //base.SyntaxError(output, recognizer, offendingSymbol, line, charPositionInLine, msg, e);
        }

    }
}
