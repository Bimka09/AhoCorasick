using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aho_Corasick
{
    internal class TrieNode
    {
        private string? _pattern;
        private TrieNode? _suffixLink;
        private TrieNode? _finalLink;
        private Dictionary<char, TrieNode> _childs= new Dictionary<char, TrieNode>();
        private string _prefix;

        public string? Pattern { get => _pattern; set => _pattern = value; }
        internal TrieNode? SuffixLink { get => _suffixLink; set => _suffixLink = value; }
        internal TrieNode? FinalLink { get => _finalLink; set => _finalLink = value; }
        internal Dictionary<char, TrieNode> Childs { get => _childs; set => _childs = value; }
        public string Prefix { get => _prefix; set => _prefix = value; }

        public TrieNode(string prefix = "")
        {
            _prefix = prefix;
        }
    }
}
