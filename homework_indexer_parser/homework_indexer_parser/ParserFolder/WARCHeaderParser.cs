using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
///
///Contributor : 101820307
///

namespace homework_indexer_parser.Parser
{
    public enum WARCType
    {
        warcinfo,
        response,
        resource,
        request,
        metadata,
        revisit,
        conversion,
        continuation
    };
    public static class WARCHeaderParser
    {
        public static WARCType Type(this WARCBasic basic)
        {
            return (WARCType)Enum.Parse(typeof(WARCType), basic.named_field[WARCFieldName.type], true);
        }
        public static string ID(this WARCBasic basic)
        {
            return basic.named_field[WARCFieldName.record_id];
        }
    }
}
