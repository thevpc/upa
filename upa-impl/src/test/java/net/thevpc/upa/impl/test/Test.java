package net.thevpc.upa.impl.test;

import net.thevpc.upa.impl.util.PlatformUtils;
import net.thevpc.upa.impl.DefaultDocument;

public class Test {
    public static class Toto {
        private int x;

        public int getX() {
            return x;
        }

        public void setX(int x) {
            this.x = x;
        }
    }

    public static void main(String[] args) {
        DefaultDocument d = new DefaultDocument();
        Toto t = PlatformUtils.createEntityBeanForDocument(Toto.class, d,null);
        t.setX(3);
        System.out.println(t.getX());
        System.out.println(d);
    }


}
