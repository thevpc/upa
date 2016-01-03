package net.vpc.upa.impl.uql;

import java.util.List;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/19/12 7:22 PM
 */
public interface ExpressionDeclarationList {

    public List<ExpressionDeclaration> getExportedDeclarations();

    public void exportDeclaration(String name, DecObjectType type, Object referrerName, Object referrerParentId);

    public List<ExpressionDeclaration> getDeclarations(String alias);

    public ExpressionDeclaration getDeclaration(String name);

//    public ExpressionDeclarationList getParentDeclaration();
//
//    public void setParentDeclaration(ExpressionDeclarationList parentDeclaration);
}
