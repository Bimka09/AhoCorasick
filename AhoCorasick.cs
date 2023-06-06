using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aho_Corasick
{
    internal class AhoCorasick
    {
        private readonly TrieNode _root;
        private readonly List<string> _patterns;

        public AhoCorasick(List<string> patterns)
        {
            _root= new TrieNode();
            _patterns = patterns;
            BuildTree();
            BuildSuffixTree();
        }

        public List<string> Patterns => _patterns;

        internal TrieNode Root => _root;

        private void BuildSuffixTree()
        {
            var queue = new Queue<TrieNode>();
            foreach (var node in Root.Childs.Values)
            {
                queue.Enqueue(node);
                node.SuffixLink = Root;
            }
            while(queue.Count > 0)
            {
                var node = queue.Dequeue();
                foreach (char c in node.Childs.Keys)
                {
                    var child = node.Childs[c];
                    queue.Enqueue(child);
                    var suffixLink = node.SuffixLink;
                    while (suffixLink != null &&
                          !suffixLink.Childs.ContainsKey(c))
                        suffixLink = suffixLink.SuffixLink;
                    child.SuffixLink = suffixLink?.Childs[c] ?? Root;
                    child.FinalLink = child.SuffixLink.Pattern != null
                                    ? child.SuffixLink
                                    : child.SuffixLink.FinalLink;
                }
            }
        }

        private void BuildTree()
        {
            foreach(string pattern in Patterns)
            {
                var node = Root;
                string prefix = "";
                foreach(char c in pattern)
                {
                    if (!node.Childs.ContainsKey(c))
                        node.Childs[c] = new TrieNode(prefix);
                    node = node.Childs[c];
                }
                node.Pattern = pattern;
            }
        }
        public List<string> FindMatches(string text)
        {
            var matches = new List<string>();
            var node = Root;
            foreach(char c in text)
            {
                while (node != null && !node.Childs.ContainsKey(c))
                    node = node.SuffixLink;
                
                if(node == null)
                {
                    node = Root;
                    continue;
                }

                node = node.Childs[c];
                if(node.Pattern!= null)
                { 
                    matches.Add(node.Pattern);
                }

                var finals = node.FinalLink;
                while(finals != null)
                {
                    matches.Add(finals.Pattern);
                    finals = finals.FinalLink;
                }
            }
            return matches;
        }

    }
}
