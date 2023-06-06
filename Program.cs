using Aho_Corasick;

var patterns = new List<string>
{
    "A",
    "AS",
    "ARAB",
    "BAR",
    "BASS",
    "C",
    "CAR",
    "RA",
    "RAB"
};

var aho = new AhoCorasick(patterns);
string text = "CARABASSBARABASS";
var matches = aho.FindMatches(text);
Console.WriteLine(String.Join(",", matches));
