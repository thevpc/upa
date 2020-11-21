/*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 *//*
 * To change this template, choose Tools | Templates
 * and open the template in the editor.
 */
package net.thevpc.upa.impl.bulk.xml;

import java.io.IOException;
import java.io.InputStream;
import java.io.Reader;
import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.ArrayBlockingQueue;
import java.util.concurrent.BlockingQueue;
import java.util.logging.Logger;

import net.thevpc.upa.ObjectFactory;
import net.thevpc.upa.bulk.DataColumn;
import net.thevpc.upa.bulk.XmlColumn;
import net.thevpc.upa.bulk.XmlParser;
import net.thevpc.upa.impl.bulk.AbstractDataReader;
import net.thevpc.upa.impl.XmlFactory;

/**
 *
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 */
public class DefaultXmlReader extends AbstractDataReader {

    private static final Logger log = Logger.getLogger(DefaultXmlReader.class.getName());

    private Object stream;
    private XmlParser p;
    public static final int INIT = 0;
    public static final int STARTED = 1;
    public static final int STOPPED = 2;
    int status = INIT;
//    private long rowCount = -1;
    int currentDepth = 0;
    BlockingQueue<BlockingVal> queue2;
//    private List<List<String>> queue = Collections.synchronizedList(new LinkedList<List<String>>());
    private Object[] currentLine;
    private boolean eof;
    private ObjectFactory factory;

    public DefaultXmlReader(XmlParser p, Reader reader,ObjectFactory factory) {
        super(new XmlColumn(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]), p.isContainsHeader(), p.getSkipRows());
        this.p = p;
        this.factory = factory;
        stream = reader;
        initXml();
    }

    public DefaultXmlReader(XmlParser p, InputStream inputStream,ObjectFactory factory) {
        super(new XmlColumn(), p.getColumns().toArray(new DataColumn[p.getColumns().size()]), p.isContainsHeader(), p.getSkipRows());
        this.p = p;
        this.factory = factory;
        stream = inputStream;
        initXml();
    }

    protected void initXml() {
        queue2 = new ArrayBlockingQueue<BlockingVal>(10);
        prepareHeader();
        new DefaultXmlReaderThreadImpl(this).start();
    }

    public boolean hasNext() {
        if (eof) {
            return false;
        }
        BlockingVal take;
        try {
            take = queue2.take();
        } catch (InterruptedException ex) {
            throw new RuntimeException(ex);
        }
        if (take == null) {
            eof = true;
            return false;
        }
        switch (take.getBlockingValType()) {
            case BlockingVal.TYPE_EOF: {
                eof = true;
                return false;
            }
            case BlockingVal.TYPE_THROWABLE: {
                eof = true;
                if (take.getValue() instanceof RuntimeException) {
                    throw (RuntimeException) take.getValue();
                } else {
                    throw new RuntimeException((Throwable) take.getValue());
                }
            }
            case BlockingVal.TYPE_VALUE: {
                currentLine = ((List<String>) take.getValue()).toArray();
                return true;
            }
        }
        eof = true;
        return false;
    }

    @Override
    protected Object[] nextRowArray() {
        return currentLine;
    }

//    private String validateValue(String s) {
//        if (p.isTrimValues()) {
//            return s.trim();
//        } else {
//            return s;
//        }
//    }
    void readXml() throws IOException {

        final List<String> header = new ArrayList<String>();
        XmlFactory xmlFactory = factory.getSingleton(XmlFactory.class);
        DefaultXmlReaderXmlHandler xmlHandler = new DefaultXmlReaderXmlHandler(header, this);
        if(stream instanceof Reader) {
            xmlFactory.parse((Reader) stream, xmlHandler);
        }else{
            xmlFactory.parse((InputStream) stream, xmlHandler);
        }
    }


}
