using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using Xunit.Abstractions;
using static iter.net.Iter;
using _ = iter.net.Iter;
using static std.net.Std;
using std.net;

namespace iter.net.tests
{

    public class VisitorGeneratorTests : IternetTestBase
    {
        public VisitorGeneratorTests(ITestOutputHelper output) : base(output)
        {
        }

        [Fact]
        public void Simple_usage()
        {
            var tree = new Tree()
            {
                Id = "1",
                Leafs = new List<Tree>()
                {
                    new Tree() {
                        Id = "1.1",
                        Leafs = new List<Tree>
                        {
                            new Tree() {
                                Id = "1.1.1"
                            },
                            new Tree() {
                                Id = "1.1.2"
                            }
                        }
                    },
                    new Tree() {
                        Id = "1.2",
                        Leafs = new List<Tree>
                        {
                            new Tree() {
                                Id = "1.2.1",
                                Leafs = new List<Tree>() {
                                    new Tree() {
                                        Id = "1.2.1.1",
                                        Leafs = new List<Tree> () {
                                            new Tree {
                                                Id = "1.2.1.1.1"
                                            }
                                        }
                                    },
                                    new Tree() {
                                        Id = "1.2.1.2",
                                        Leafs = new List<Tree> () {
                                            new Tree {
                                                Id = "1.2.1.2.1"
                                            }
                                        }
                                    }
                                }
                            },
                            new Tree() {
                                Id = "1.2.2"
                            }

                        }
                    },
                }
            };

            var leafs = _.climber(tree, t => t.Leafs);


            foreach (var (depth, leaf, parent) in leafs)
            {
                var dash = string.Concat(string.Concat(Enumerable.Range(1, depth - 1).Select(x => "·")), "└");
                string message = $"{dash} ({depth}, {leaf}, {(parent?.Id ?? "NULL")})";
                //string message = $"{dash} {leaf}";
                WriteLine(message);
            }
        }

        [Fact]
        public void Advanced_usage()
        {
            var tree = new Tree()
            {
                Id = "1",
                Leafs = new List<Tree>()
                {
                    new Tree() {
                        Id = "1.1",
                        Leafs = new List<Tree>
                        {
                            new Tree() {
                                Id = "1.1.1"
                            },
                            new Tree() {
                                Id = "1.1.2"
                            }
                        }
                    },
                    new Tree() {
                        Id = "1.2",
                        Leafs = new List<Tree>
                        {
                            new Tree() {
                                Id = "1.2.1",
                                Leafs = new List<Tree>() {
                                    new Tree() {
                                        Id = "1.2.1.1",
                                        Leafs = new List<Tree> () {
                                            new Tree {
                                                Id = "1.2.1.1.1"
                                            }
                                        }
                                    },
                                    new Tree() {
                                        Id = "1.2.1.2",
                                        Leafs = new List<Tree> () {
                                            new Tree {
                                                Id = "1.2.1.2.1"
                                            }
                                        }
                                    }
                                }
                            },
                            new Tree() {
                                Id = "1.2.2"
                            }

                        }
                    },
                }
            };

            var leafs = _.climber<Tree, FlatTree>(
                root: tree,
                leafs: t => t.Leafs,
                factory: (item) =>
                {
                    var (depth, current, parent) = item;

                    return new FlatTree()
                    {
                        Depth = depth,
                        Current = current,
                        Parent = parent
                    };
                });

            foreach (FlatTree item in leafs)
            {
                var (depth, leaf, parent) = (item.Depth, item.Current, item.Parent);

                var dash = string.Concat(string.Concat(Enumerable.Range(1, depth - 1).Select(x => "·")), "└");
                string message = $"{dash} ({depth}, {leaf}, {(parent?.Id ?? "NULL")})";
                //string message = $"{dash} {item.Current}";
                WriteLine(message);
            }
        }


        [Fact]
        public void Faking_climber()
        {
            var tree = new Tree()
            {
                Id = "1"
            };

            var leafs = _.climber(
                root: tree,
                leafs: t => new List<Tree>()
                {
                    new Tree() { Id = "a" },
                    new Tree() { Id = "b" }
                }, maxDepth: 10);

            foreach (var (depth, leaf, parent) in leafs)
            {
                var dash = string.Concat(string.Concat(Enumerable.Range(1, depth - 1).Select(x => "·")), "└");
                string message = $"{dash} ({depth}, {leaf}, {(parent?.Id ?? "NULL")})";
                //string message = $"{dash} {leaf}";
                WriteLine(message);
            }
        }

        class Tree
        {
            public List<Tree> Leafs { get; set; }
            public string Id { get; set; }
            public override string ToString() => $"{Id}";
        }

        class FlatTree
        {
            public int Depth { get; set; }
            public Tree Parent { get; set; }
            public Tree Current { get; set; }
        }
    }
}
