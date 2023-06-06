using Aho_Corasick;

var patterns = new List<string>
{
    "ABLE",
    "CO",
    "COPY",
    "IG",
    "PYR",
    "RIGHT",
    "TAB",
    "TABLE"
};

var aho = new AhoCorasick(patterns);
string text = "COCOPYRIGHTABLE";
var matches = aho.FindMatches(text);
Console.WriteLine(String.Join(",", matches));
