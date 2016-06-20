/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.util.classpath;

import java.io.File;
import java.util.Iterator;
import java.util.Stack;

/**
 *
 * @author vpc
 */
public class FolderClassPathRootIterator implements Iterator<ClassPathResource> {

    private File root;
    private FileClassPathResource last;
    private Stack<File> stack = new Stack<File>();

    public FolderClassPathRootIterator(File root) {
        this.root = root;
        File[] f = root.listFiles();
        if (f != null) {
            for (int i = f.length-1; i >= 0; i--) {
                File file = f[i];
                stack.push(file);
            }
        }
    }

    public boolean hasNext() {
        return !stack.isEmpty();
    }

    public ClassPathResource next() {
        File r = stack.pop();
        if (r.isDirectory()) {
            File[] f = r.listFiles();
            if (f != null) {
                for (int i = f.length-1; i >= 0; i--) {
                    File file = f[i];
                    stack.push(file);
                }
            }
            String p = r.getPath().substring(root.getPath().length()+1).replace("\\", "/");
            return last = new FileClassPathResource(p + "/", r);
        } else {
            String p = r.getPath().substring(root.getPath().length()+1).replace("\\", "/");
            return last = new FileClassPathResource(p, r);
        }
    }

    public void remove() {
        //should remove last
        throw new UnsupportedOperationException("Not supported.");
    }

}
