using System.Text.RegularExpressions;

namespace DeltaDev.HTMD
{
    public static class HTMDConvert
    {
        //public static readonly string[] mdRegEx = new[] { "#{1,3}", "*", ">", "[1-9]{1,2}." };
        public static readonly MDRegEx[] mdRegEx = new MDRegEx[]
        {
            new MDRegEx(new Regex(@"(?<=#{3})(.*)"),
                "<h3>", "</h3>"),                                                   //heading 3         |
            new MDRegEx(new Regex(@"(?<=#{2})(.*)"),
                "<h2>", "</h2>"),                                                   //heading 2         |
            new MDRegEx(new Regex(@"(?<=#{1})(.*)"),
                "<h1>", "</h1>"),                                                   //heading 1         |
            new MDRegEx(new Regex(@"(?<=\*{2}).*?(?=\*{2})"),
                "<b>", "</b>"),                                                     //bold              |
            new MDRegEx(new Regex(@"(?<=\*{1}).*?(?=\*{1})"),
                "<i>", "</i>"),                                                     //italic            |
            new MDRegEx(new Regex(@"(?<=>)(.*)"),
                "<blockquote>", "</blockquote>"),                                   //blockquote        |
            new MDRegEx(new Regex(@"(?<=[1-9]{1,2}\.(\s?))(.*)"),
                "<li>", "</li>", "<ol>", "</ol>"),                                  //ordered list      |
            new MDRegEx(new Regex(@"(?<=\-)(.*)"),
                "<li>", "</li>", "<ul>", "</ul>")                                   //unordered list    |
        };

        
        public static string ToHTML(string htmd)
        {
            return "";
        }

        public static string SingleStatementToHTML(string statement)
        {
            MDRegEx match = mdRegEx.FirstOrDefault(x => x.pattern is not null && x.pattern.IsMatch(statement), default);
            if (match.pattern is not null)
            {
                var startMatch = match.pattern.Match(statement);
                return match.htmlOpenTag + startMatch.Groups[0].Value.Trim() + match.htmlCloseTag;
            }
            return "";
        }

        public static string Between(this string input, string start, string end)
        {
            string FinalString;
            int Pos1 = input.IndexOf(start) + start.Length;
            int Pos2 = input.IndexOf(end);
            FinalString = input[Pos1..Pos2];
            return FinalString;
        }

        public readonly struct MDRegEx
        {
            public readonly Regex? pattern = null;
            public readonly string? htmlOpenTag = null;
            public readonly string? htmlCloseTag = null;
            public readonly string? parentOpenTag = null;
            public readonly string? parentCloseTag = null;

            public MDRegEx(Regex pattern, string htmlOpen, string htmlClose)
            {
                this.pattern = pattern;
                htmlOpenTag = htmlOpen;
                htmlCloseTag = htmlClose;
            }

            public MDRegEx(Regex pattern, string htmlOpen, string htmlClose, string parentOpen, string parentClose)
            {
                this.pattern = pattern;
                htmlOpenTag = htmlOpen;
                htmlCloseTag = htmlClose;
                parentOpenTag = parentOpen;
                parentCloseTag = parentClose;
            }

            public static bool operator ==(MDRegEx left, MDRegEx right)
            {
                return left.pattern == right.pattern;
            }

            public static bool operator !=(MDRegEx left, MDRegEx right)
            {
                return left.pattern != right.pattern;
            }

            public override bool Equals(object? obj)
            {
                var other = (MDRegEx?)obj;
                return other == this;
            }

            public override int GetHashCode()
            {
                return base.GetHashCode();
            }
        }
    }
}