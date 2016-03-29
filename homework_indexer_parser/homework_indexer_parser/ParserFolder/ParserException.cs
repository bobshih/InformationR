using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///
///Contributor : 101820307
///
namespace homework_indexer_parser.Parser
{
    public class ParserException : Exception
    {
        public ParserException(string message = "parser error") :
            base(message)
        {
        }
    }
}
