package net.vpc.upa;

import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.Expression;
import net.vpc.upa.extensions.HierarchyExtension;

public interface ManyToOneRelationship extends Relationship {
    HierarchyExtension getHierarchyExtension();

    void setHierarchyExtension(HierarchyExtension extension);

    Expression getFilter() ;

    void setFilter(Expression filter) ;

}
