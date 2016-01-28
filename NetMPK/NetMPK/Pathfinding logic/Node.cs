using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NetMPK
{
    public class Node
    {
        public int U { get; set; }
        public int V { get; set; }
        public int W { get; set; }

        public Node(int U, int V, int W)
        {
            this.U = U;
            this.V = V;
            this.W = W;
        }
    }
}