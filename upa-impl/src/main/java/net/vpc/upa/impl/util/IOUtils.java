package net.vpc.upa.impl.util;

import net.vpc.upa.PortabilityHint;

import java.io.*;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 1/14/13 4:57 PM
 */
@PortabilityHint(target = "C#", name = "ignore")
public class IOUtils {


    public static char[] toCharArray(Character[] bytes)  {
        if (bytes == null) {
            return null;
        }
        char[] t = new char[bytes.length];
        for (int i = 0; i < t.length; i++) {
            Character v = bytes[i];
            if (v != null) {
                t[i] = v.charValue();
            }
        }
        return t;
    }

    public static Character[] toCharRefArray(char[] bytes)  {
        if (bytes == null) {
            return null;
        }
        Character[] t = new Character[bytes.length];
        for (int i = 0; i < t.length; i++) {
            t[i] = bytes[i];
        }
        return t;
    }

    public static char[] toCharArray(Reader in) throws IOException {
        CharArrayWriter outWriter = new CharArrayWriter();
        int available = 0;
        if (available <= 0) {
            available = 1024;
        }
        char[] buffer = new char[available];
        int r = -1;
        while ((r = in.read(buffer)) > 0) {
            outWriter.write(buffer, 0, r);
        }
        return outWriter.toCharArray();
    }

    public static byte[] toByteArray(Byte[] bytes)  {
        if (bytes == null) {
            return null;
        }
        byte[] t = new byte[bytes.length];
        for (int i = 0; i < t.length; i++) {
            Byte v = bytes[i];
            if (v != null) {
                t[i] = v.byteValue();
            }
        }
        return t;
    }

    public static Byte[] toByteRefArray(byte[] bytes)  {
        if (bytes == null) {
            return null;
        }
        Byte[] t = new Byte[bytes.length];
        for (int i = 0; i < t.length; i++) {
            t[i] = bytes[i];
        }
        return t;
    }

    public static byte[] toByteArray(InputStream in) throws IOException {
        ByteArrayOutputStream outWriter = new ByteArrayOutputStream();
        int available = in.available();
        if (available <= 0) {
            available = 1024;
        }
        byte[] buffer = new byte[available];
        int r = -1;
        while ((r = in.read(buffer)) > 0) {
            outWriter.write(buffer, 0, r);
        }
        return outWriter.toByteArray();
    }

    public static Object getObjectFromSerializedForm(byte[] bytes) throws ClassNotFoundException {
        ObjectInputStream b = null;
        try {
            b = new ObjectInputStream(new ByteArrayInputStream(bytes));
            return b.readObject();
        } catch (IOException e) {
            throw new RuntimeException(e.toString());
        } finally {
            try {
                if (b != null) {
                    b.close();
                }
            } catch (IOException e) {
            }
        }
    }

    public static byte[] getSerializedFormOf(Object object) {
        ObjectOutputStream b = null;
        try {
            ByteArrayOutputStream bb = new ByteArrayOutputStream();
            b = new ObjectOutputStream(bb);
            b.writeObject(object);
            return bb.toByteArray();
        } catch (IOException e) {
            throw new RuntimeException(e.toString());
        } finally {
            try {
                if (b != null) {
                    b.close();
                }
            } catch (IOException e) {
            }
        }
    }

    public static Object getObjectFromSerializedForm(InputStream bytes) throws ClassNotFoundException {
        ObjectInputStream b = null;
        try {
            b = new ObjectInputStream(bytes);
            return b.readObject();
        } catch (IOException e) {
            throw new RuntimeException(e.toString());
        } finally {
            try {
                if (b != null) {
                    b.close();
                }
            } catch (IOException e) {
            }
        }
    }
    
    public static void copyToFile(InputStream stream,File file,int bufferSize) throws IOException{
        FileOutputStream outWriter=new FileOutputStream(file);
        byte[] b=new byte[bufferSize];
        int r;
        while((r=stream.read(b))>0){
            outWriter.write(b,0,r);
        }
        outWriter.close();
    }
}
