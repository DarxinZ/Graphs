using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Graphs
{
    // Grapg Node Link with number of node it links to (in the graph) and its weight
    public class NodeLink
    {
        private uint linktToNode;
        private int nodeWeight;
        public NodeLink(uint linktToNode)
        {
            this.linktToNode = linktToNode;
            this.nodeWeight = 0;
        }
        public NodeLink(uint linktToNode, int nodeWeight)
        {
            this.linktToNode = linktToNode;
            this.nodeWeight = nodeWeight;
        }
        public uint LinktToNode { get => linktToNode; }
        public int NodeWeight { get => nodeWeight; set => nodeWeight = value; }
        public override string ToString()
        {
            return $"(LN:{linktToNode},W:{nodeWeight})";
        }
    }

    // Single graph node, has a name(optional), generic data and a list ognode links it connect to
    public class GraphNode<T>
    {
        private string nodeName;
        private T nodeData;
        private List<NodeLink> links2Node;
        public GraphNode(string nodeName, T nodeData)
        {
            this.nodeName = nodeName;
            this.nodeData = nodeData;
            links2Node = new List<NodeLink>();
        }
        public GraphNode(T nodeData)
        {
            this.nodeName = "";
            this.nodeData = nodeData;
            links2Node = new List<NodeLink>();
        }
        public string NodeName { get => nodeName; set => nodeName = value; }
        public T NodeDate { get => nodeData; set => nodeData = value; }
        public List<NodeLink> Links2Node { get => links2Node; }
        // returns true if the node does not link to other nodes (leaf)
        public bool IsEmpty() { return links2Node.Count == 0; }
        // check if spesific node connection exists (by serial number)
        public bool IsLinkExists(uint linkNodeNum)
        {
            foreach (NodeLink link in links2Node)
                if (link.LinktToNode == linkNodeNum)
                    return true;
            return false;
        }
        // add a link from this node to another if not exists (bye serial number)
        public bool AddLink(uint linktToNode, int nodeWeight)
        {
            if (IsLinkExists(linktToNode))
                return false;
            links2Node.Add(new NodeLink(linktToNode, nodeWeight));
            return true;
        }
        public bool AddLink(uint linktToNode)
        {
            if (IsLinkExists(linktToNode))
                return false;
            links2Node.Add(new NodeLink(linktToNode));
            return true;
        }
        // remove a link from this node to another if exists (bye serial number)
        public bool RemoveLink(uint linktToNode)
        {
            foreach (NodeLink link in links2Node)
                if (link.LinktToNode == linktToNode)
                {
                    links2Node.Remove(link);
                    return true;
                }
            return false;
        }
    }
    // Representation of a Graph (array of graph nodes)
    class Graph<T>
    {
        private List<GraphNode<T>> graph;
        public Graph()
        {
            this.graph = new List<GraphNode<T>>();
        }
        public Graph(List<T> nodeDataList)
        {
            int i = 0;
            foreach (T node in nodeDataList)
            {
                graph.Add(new GraphNode<T>(i.ToString(), node));
                i++;
            }
        }
        public void AddNode(string nodeName, T nodeData)
        {
            graph.Add(new GraphNode<T>(nodeName, nodeData));
        }
        public List<GraphNode<T>> GetGraph { get => graph; }
    }
}
