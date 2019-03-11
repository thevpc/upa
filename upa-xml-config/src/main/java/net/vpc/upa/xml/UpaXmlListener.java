package net.vpc.upa.xml;

import org.w3c.dom.Document;
import org.w3c.dom.Element;

public interface UpaXmlListener {
    void visitStartDocument(Document document);

    void visitEndDocument(Document document, UpaXml pom);

    void visitStartPersistenceUnit(Element document, Object parent);

    void visitEndPersistenceUnit(Element document, Object parent, UpaXml.PersistenceUnit item);

    void visitStartPersistenceGroup(Element document, Object parent);

    void visitEndPersistenceGroup(Element document, Object parent, UpaXml.PersistenceGroup item);

    void visitStartScan(Element document, Object parent);

    void visitEndScan(Element document, Object parent, UpaXml.Scan item);

    void visitStartProperty(Element document, Object parent);

    void visitEndProperty(Element document, Object parent, UpaXml.Property item);

    void visitStartConnection(Element document, Object parent);

    void visitEndConnection(Element document, Object parent, UpaXml.Connection item);

    void visitStartRootConnection(Element document, Object parent);

    void visitEndRootConnection(Element document, Object parent, UpaXml.Connection item);

    void visitStartInclude(Element element, Object parent);

    void visitEndInclude(Element element, Object parent, UpaXml.Include item);

    void visitStartIncludeItem(Element element, Object parent);

    void visitEndIncludeItem(Element element, Object parent, UpaXml.IncludeItem item);
}
