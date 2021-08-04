using System;
using System.Collections.Generic;
using System.Linq;

namespace DependencyInversion
{
    public enum Relationship
    {
        Parent,
        Child,
        Sibling
    }

    public class Person
    {
        public string Name { get; set; }
    }


    public interface IRelationshipBrowser
    {
        IEnumerable<Person> FindAllChildrenOf(string name);
    }
    //LOW LEVEL PARTS OF THE SYSTEM
    public class Relationships : IRelationshipBrowser
    {
        private List<(Person, Relationship, Person)> relations = new List<(Person, Relationship, Person)>();

        public void AddParentAndChild(Person parent, Person child)
        {
            relations.Add((parent, Relationship.Parent, child));
            relations.Add((child, Relationship.Child, parent));
        }

        //public List<(Person, Relationship, Person)> Relations => relations;
        public IEnumerable<Person> FindAllChildrenOf(string name)
        {
            foreach (var r in relations.Where(
                x => x.Item1.Name == name &&
                     x.Item2 == Relationship.Parent
            ))
            {
                yield return r.Item3;
            }
        }
    }


    public class Research
    {
        //public Research(Relationships relationships)
        //{
        //    var relations = relationships.Relations;
        //    foreach (var r in relations.Where(
        //        x => x.Item1.Name == "Jeff" &&
        //             x.Item2 == Relationship.Parent
        //    ))
        //    {
        //        Console.WriteLine($"Jeff has a child called {r.Item3.Name}");
        //    }
        //}

        public Research(IRelationshipBrowser browser)
        {
            foreach(var p in browser.FindAllChildrenOf("Jeff"))
                Console.WriteLine($"Jeff has a child called {p.Name}");
        }
        static void Main(string[] args)
        {
            var parent = new Person {Name = "Jeff"};
            var child1 = new Person {Name = "Roya"};
            var child2 = new Person {Name = "TJ"};

            var relationships = new Relationships();
            relationships.AddParentAndChild(parent, child1);
            relationships.AddParentAndChild(parent, child2);

            new Research(relationships);
        }
    }
}
