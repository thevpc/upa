package net.thevpc.upa.impl.util;

import net.thevpc.upa.Closeable;
import net.thevpc.upa.PortabilityHint;

import java.io.*;

@PortabilityHint(target = "C#",name = "partial")
public class CacheFile implements Closeable {
    private int status;
    private static Object START_FILE = "net.thevpc.upa.io.CacheFile.START";
    private static Object END_FILE = "net.thevpc.upa.io.CacheFile.END";
    private Object lastExtractedObject;
    private boolean objectRead;
    private boolean empty;

    @PortabilityHint(target = "C#",name = "ignore")
    private ObjectInputStream inputStream;
    @PortabilityHint(target = "C#",name = "ignore")
    private ObjectOutputStream outputStream;
    @PortabilityHint(target = "C#",name = "ignore")
    private File file;


    public CacheFile() throws CacheException {
        empty = true;
    }

    @PortabilityHint(target = "C#",name = "ignore")
    public File getFile() {
        if (file == null){
            try {
                file = File.createTempFile("cache", ".tmp");
            } catch (IOException e) {
                throw new CacheException(e);
            }
        }
        return file;
    }

    @PortabilityHint(target = "C#",name = "ignore")
    public void write(Object o) throws CacheException {
        if (!isWriting()){
            setWriting();
        }
        try {
            empty = false;
            outputStream.writeObject(o);
        } catch (IOException e) {
            throw new CacheException(e);
        }
    }


    @PortabilityHint(target = "C#",name = "ignore")
    private void setWriting()
            throws CacheException {
        try {
            outputStream = new ObjectOutputStream(new FileOutputStream(getFile()));
            outputStream.writeObject(START_FILE);
        } catch (IOException e) {
            throw new CacheException(e);
        }
        status = 1;
    }

    @PortabilityHint(target = "C#",name = "ignore")
    public void close() throws CacheException {
        try {
            if (isWriting()) {
                outputStream.writeObject(END_FILE);
                outputStream.close();
                outputStream = null;
            } else if (isReading()) {
                inputStream.close();
                inputStream = null;
            }
            status = 0;
        } catch (IOException e) {
            throw new CacheException(e);
        }
    }

    @PortabilityHint(target = "C#",name = "ignore")
    public boolean hasNext()
            throws CacheException {
        if (empty) {
            return false;
        }
        if (!isReading()) {
            setReading();
        }
        if (objectRead) {
            try {
                lastExtractedObject = inputStream.readObject();
            } catch (Exception e) {
                throw new CacheException(e);
            }
            objectRead = false;
        }
        return !END_FILE.equals(lastExtractedObject);
    }

    @PortabilityHint(target = "C#",name = "ignore")
    private void setReading()
            throws CacheException {
        status = 2;
        Object o = null;
        try {
            inputStream = new ObjectInputStream(new FileInputStream(getFile()));
            o = inputStream.readObject();
        } catch (Exception e) {
            throw new CacheException("UnableToLoadCache",e);
        }
        if (!START_FILE.equals(o)) {
            throw new CacheException("InvalidCacheFile");
        } else {
            objectRead = true;
            return;
        }
    }

    public Object read() throws CacheException {
        if (objectRead) {
            hasNext();
        }
        if (END_FILE.equals(lastExtractedObject)) {
            throw new CacheException("EndOfCacheFileReached");
        } else {
            objectRead = true;
            return lastExtractedObject;
        }
    }

    public boolean isReading() {
        return status == 2;
    }

    public boolean isWriting() {
        return status == 1;
    }

    public boolean isEmpty() {
        return empty;
    }

}
