package net.vpc.upa.impl.uql;

import java.util.ArrayList;
import java.util.List;
import net.vpc.upa.impl.util.PlatformUtils;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/19/12 7:22 PM
 */
public class DefaultExpressionDeclarationList implements ExpressionDeclarationList{

    private DefaultExpressionDeclarationList parentDeclaration;
    private List<ExpressionDeclaration> exportedDeclarations;

    public DefaultExpressionDeclarationList(DefaultExpressionDeclarationList parentDeclaration) {
        exportedDeclarations = new ArrayList<ExpressionDeclaration>();
        this.parentDeclaration=parentDeclaration;
    }

    //    ExpressionDeclarationList(List<ExpressionDeclaration> list) {
    //        this.exported = list;
    //    }
    public List<ExpressionDeclaration> getExportedDeclarations() {
        List<ExpressionDeclaration> emptyList = PlatformUtils.emptyList();
        return exportedDeclarations == null ? emptyList : exportedDeclarations;
    }

    public void exportDeclaration(String name, DecObjectType type, Object referrerName, Object referrerParentId) {
        if (exportedDeclarations == null) {
            exportedDeclarations = new ArrayList<ExpressionDeclaration>(3);
        }
        exportedDeclarations.add(new ExpressionDeclaration(name, type, referrerName, referrerParentId));
    }
//    public ExpressionDeclarationList push(String name, Object value) {
//        ArrayList<ExpressionDeclaration> map2 = new ArrayList<ExpressionDeclaration>(exported.size() + 1);
//        for (ExpressionDeclaration declaration : exported) {
//            map2.add(declaration);
//        }
//        map2.add(new ExpressionDeclaration(name, value));
//        return new ExpressionDeclarationList(map2);
//    }

    public List<ExpressionDeclaration> getDeclarations(String alias) {
        if (alias == null) {
            //check all
            ArrayList<ExpressionDeclaration> objects = new ArrayList<ExpressionDeclaration>();
            if (exportedDeclarations != null) {
                for (int i = exportedDeclarations.size() - 1; i >= 0; i--) {
                    ExpressionDeclaration d = exportedDeclarations.get(i);
                    objects.add(d);
                }
            }
            if (parentDeclaration != null) {
                objects.addAll(parentDeclaration.getDeclarations(alias));
            }
            return objects;
        } else {
            ArrayList<ExpressionDeclaration> objects = new ArrayList<ExpressionDeclaration>();
            for (int i = exportedDeclarations.size() - 1; i >= 0; i--) {
                ExpressionDeclaration d = exportedDeclarations.get(i);
                if (alias.equals(d.getValidName())) {
                    objects.add(d);
                }
            }
            if (parentDeclaration != null) {
                objects.addAll(parentDeclaration.getDeclarations(alias));
            }
            return objects;
        }
    }

    @Override
    public String toString() {
        return "{" + parentDeclaration + ", " + exportedDeclarations + '}';
    }

//        public List<Object> getValues(String name) {
//            ArrayList<Object> objects = new ArrayList<Object>();
//            for (int i = map.size() - 1; i >= 0; i--) {
//                Declaration d = map.get(i);
//                if (d.name.equals(name)) {
//                    objects.add(d.referrer);
//                }
//            }
//            return objects;
//        }
    public ExpressionDeclaration getDeclaration(String name) {
        List<ExpressionDeclaration> values = getDeclarations(name);
        if (values.isEmpty()) {
            return null;
        }
        return values.get(0);
    }

    public DefaultExpressionDeclarationList getParentDeclaration() {
        return parentDeclaration;
    }

    public void setParentDeclaration(DefaultExpressionDeclarationList parentDeclaration) {
        this.parentDeclaration = parentDeclaration;
    }
}
