using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Product_model
{
    class Fact
    {
        public string label;
        public string description;
        public int num;

        public Fact(string label, string description, int num)
        {
            this.label = label;
            this.description = description;
            this.num = num;
        }

        public override bool Equals(object o) => o is Fact otherFact && num == otherFact.num;
        public override int GetHashCode() => num.GetHashCode();
        public override string ToString() => label;
    }

    class Rule
    {
        public List<Fact> facts;
        public Fact result;

        public Rule(List<Fact> facts, Fact result)
        {
            this.facts = facts;
            this.result = result;
        }

        public override bool Equals(object o) =>
            o is Rule otherRule && facts.SequenceEqual(otherRule.facts) && result == otherRule.result;

        public override int GetHashCode()
        {
            return facts.Aggregate(result.GetHashCode(), (current, fact) => current ^ fact.GetHashCode());
        }

        public bool IsApplicable(HashSet<Fact> trueFacts) =>
            facts.All(trueFacts.Contains);
    }

    class ProductModel
    {
        public List<Fact> facts = new List<Fact>();
        public HashSet<Rule> rules = new HashSet<Rule>();
        public List<Fact> initialFacts = new List<Fact>();

        private void ParseDescription(string description)
        {
            foreach (var line in Regex.Split(description, "\r\n|\r|\n"))
            {
                var parts = line.Split(':');
                var newFact = new Fact(parts[0].Trim(), parts[1].Trim(), facts.Count);
                facts.Add(newFact);
            }
        }

        private void ParseRules(string rulesText)
        {
            foreach (var line in Regex.Split(rulesText, "\r\n|\r|\n"))
            {
                var rule = line.Split(';');
                List<Fact> ruleFacts = new List<Fact>();
                Fact foundFact = null;
                foreach (var fact in rule[0].Trim().Split(','))
                {
                    foundFact = facts.Find((f) => f.label == fact);
                    if (foundFact != null)
                    {
                        ruleFacts.Add(foundFact);
                    }
                    else
                    {
                        throw new InvalidOperationException($"Fact with label '{fact}' not found.");
                    }
                }
                foundFact = facts.Find((f) => f.label == rule[1].Trim());
                if (foundFact != null)
                {
                    rules.Add(new Rule(ruleFacts, foundFact));
                }
                else
                {
                    throw new InvalidOperationException($"Fact with label '{rule[1].Trim()}' not found.");
                }
            }
        }

        private void ParseInitialFacts(string initialFactsText)
        {
            foreach (var fact in initialFactsText.Split(';'))
            {
                Fact foundFact = facts.Find((f) => f.label == fact.Trim());
                if (foundFact != null)
                {
                    initialFacts.Add(foundFact);
                }
                else
                {
                    throw new InvalidOperationException($"Fact with label '{fact}' not found.");
                }
            }
        }

        public ProductModel(string rulesText, string descriptionText, string initialFactsText)
        {
            ParseDescription(descriptionText);
            ParseRules(rulesText);
            ParseInitialFacts(initialFactsText);
        }
        public List<Rule> ForwardOutput(Fact soughtFact)
        {
            HashSet<Fact> trueFacts = new HashSet<Fact>(initialFacts);
            List<Rule> result = new List<Rule>();
            if (trueFacts.Contains(soughtFact))
                return result;

            while (true)
            {
                var applicableRule = rules.FirstOrDefault(rule => rule.IsApplicable(trueFacts) && !trueFacts.Contains(rule.result));

                if (applicableRule == null)
                    break;

                trueFacts.Add(applicableRule.result);
                result.Add(applicableRule);

                if (applicableRule.result == soughtFact)
                    break;

            }
            if(!trueFacts.Contains(soughtFact)) return new List<Rule>();

            return result;
        }
        public class FactInfo
        {
            public bool status;
            public Rule usedRule = null;

            public FactInfo(bool status = false)
            {
                this.status = status;
            }
        }

        public List<Rule> BackwardOutput(Fact soughtFact)
        {
            Dictionary<Fact, FactInfo> factsDict = initialFacts.ToDictionary(fact => fact, fact => new FactInfo(true));
            factsDict[soughtFact] = new FactInfo();
            Stack<Fact> stack = new Stack<Fact>(new[] { soughtFact });
            HashSet<Rule> usedRules = new HashSet<Rule>();
            while (stack.Count() != 0 && !factsDict[soughtFact].status)
            {
                var currFact = stack.Peek();
                if (factsDict[currFact].status)
                {
                    stack.Pop();
                    continue;
                }
                bool anyCandidateRule = false;
                foreach (var candidateRule in rules.Where((rule) => rule.result == currFact))
                {
                    bool allSolved = true;
                    foreach (var fact in candidateRule.facts)
                    {
                        if (!factsDict.ContainsKey(fact) || !factsDict[fact].status)
                        {
                            allSolved = false;
                            break;
                        }
                    }
                    if (allSolved)
                    {
                        factsDict[currFact].status = true;
                        factsDict[currFact].usedRule = candidateRule;
                        break;
                    }

                    if (usedRules.Contains(candidateRule))
                        continue;
                    anyCandidateRule = true;
                    usedRules.Add(candidateRule);
                    foreach (var fact in candidateRule.facts)
                    {
                        if (!factsDict.ContainsKey(fact))
                        {
                            factsDict[fact] = new FactInfo();
                            stack.Push(fact);
                            continue;
                        }
                        if (!factsDict[fact].status)
                        {
                            stack.Push(fact);
                        }
                    }
                }

                if (!anyCandidateRule)
                {
                    stack.Pop();
                    continue;
                }
            }
            List<Rule> result = new List<Rule>();
            Stack<Fact> outStack = new Stack<Fact>(new[] { soughtFact });
            while (outStack.Count != 0) 
            {
                var usedRule = factsDict[outStack.Pop()].usedRule;

                if (usedRule == null)
                    continue;

                result.Add(usedRule);

                foreach (var fact in usedRule.facts) 
                    outStack.Push(fact);
                       
            }
            result.Reverse();
            return result;
        }
    }
}
