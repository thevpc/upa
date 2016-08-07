package net.vpc.upa.test;

import java.util.ArrayList;
import java.util.List;

/**
 * Created by vpc on 7/3/16.
 */
public class TestVisitingStrategy {
    public static class Node{
        private Node parent;
        private String name;
        private List<Node> nodes=new ArrayList<Node>();

        public Node(String name) {
            this(null,name);
        }
        public Node(Node parent,String name) {
            this.parent = parent;
            this.name = name;
        }

        public Node add(String s){
            Node n=new Node(this,s);
            nodes.add(n);
            return n;
        }

        private Node parent(){
            return parent;
        }

        public String toString(){
            return toString("");
        }

        private String toString(String prefix){
            StringBuilder s=new StringBuilder(prefix).append(name);
            String prefix1 = prefix + " ";
            for (Node node : nodes) {
                s.append("\n").append(node.toString(prefix1));
            }
            return s.toString();
        }
    }

    /**
     * 1
     *  1.1
     *    1.1.1
     *    1.1.2
     *  1.2
     *  1.3
     * @return
     */
    public static Node build(){
        Node r=new Node("1");
        r.add("1.1").add("1.1.1").parent().add("1.1.2").parent().parent().add("1.2")
                .parent().add("1.3");
        System.out.println(r);
        return r;
    }

    public static void main(String[] args) {
        build();
    }
}
