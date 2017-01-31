package net.vpc.upa.impl;

import net.vpc.upa.Document;
import net.vpc.upa.MultiDocument;

import java.util.HashMap;
import java.util.Map;

public class DefaultMultiDocument implements MultiDocument {
    public static final String NO_ENTITY = "*";
    private Map<String, Document> documents = new HashMap<String, Document>();
    private Document plainDocument;

    public int entitySize() {
        int size = 0;
        if (isValidDocument(plainDocument)) {
            size++;
        }
        for (Document document : documents.values()) {
            if (isValidDocument(document)) {
                size++;
            }
        }
        return size;
    }

    private boolean isValidDocument(Document r) {
        return r != null && r.size() > 0;
    }

    public int fieldSize() {
        int s = 0;
        for (Document document : documents.values()) {
            s += document.size();
        }
        return s;
    }

    public Document getPlainDocument() {
        return getPlainDocument(false);
    }

    public Document getPlainDocument(boolean create) {
        if (plainDocument == null && create) {
            plainDocument = new DefaultDocument();
        }
        return plainDocument;
    }

    public Document getDocument(String entityName) {
        return documents.get(entityName);
    }

    public void setDocument(String entityName, Document document) {
        if (document == null) {
            documents.remove(entityName);
        } else {
            documents.put(entityName, document);
        }
    }

    public Document getSingleDocument() {
        if (entitySize() == 1) {
            if (isValidDocument(plainDocument)) {
                return plainDocument;
            }
            for (Document document : documents.values()) {
                if (isValidDocument(document)) {
                    return document;
                }
            }
        }
        throw new IndexOutOfBoundsException();
    }

    public Document merge() {
        Document r = new DefaultDocument();
        if (plainDocument != null) {
            r.setAll(plainDocument);
        }
        for (Document document : documents.values()) {
            r.setAll(document);
        }
        return r;
    }

}
