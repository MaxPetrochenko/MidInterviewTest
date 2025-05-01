using Xunit;
using Xunit.Abstractions;

namespace MidInterviewTest;

/*
    The task is to remove from the object tree all nodes
    where the Alive property is false. However, if a node
    has an Alive property that is true, all of its parents
    and children should remain in the tree.
    
    Extra:
    Perform the task using recursive and iterative algorithms,
    explain in which cases each one should be used, as well as
    the advantages and disadvantages of each approach.
*/

public record Node(int Id, int? ParentId, bool Alive, List<Node> Children);

public static class NodesCleaner
{
    public static void Clean(Node root)
    {
        if (!root.Alive)
        {
            int cnt = 0;
            if (root.Children != null)
            {
                foreach (var item in root.Children)
                {
                    if (!item.Alive)
                        Clean(item);
                    else cnt++;
                }

            }
            else
            {
                // all the way down
                

                return;
            }
        }
        else
        {
            //
        }
    }
}



public static class NodeUtils
{
    public static Node T(this Node parent) => CreateChild(parent, true);

    public static Node F(this Node parent) => CreateChild(parent, false);

    public static Node CreateChild(this Node parent, bool alive)
    {
        var child = new Node(
            (parent.Children.Count > 0 ? parent.Children[^1].Id : parent.Id * 10) + 1,
            parent.Id,
            alive,
            new List<Node>()
        );

        parent.Children.Add(child);
        return child;
    }
}
