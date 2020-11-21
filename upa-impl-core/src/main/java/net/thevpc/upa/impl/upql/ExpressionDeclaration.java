package net.thevpc.upa.impl.upql;

/**
 * @author Taha BEN SALAH <taha.bensalah@gmail.com>
 * @creationdate 11/19/12 7:24 PM
 */
public class ExpressionDeclaration {

    private String name;
    private Object referrerName;
    private Object referrerParent;
    private DecObjectType referrerType;

    public ExpressionDeclaration(String name, DecObjectType referrerType, Object referrerName, Object referrerParent) {
        this.name = name;
        this.referrerName = referrerName;
        this.referrerParent = referrerParent;
        this.referrerType = referrerType;
    }

    public Object getReferrerName() {
        return referrerName;
    }

    public void setReferrerName(Object referrerName) {
        this.referrerName = referrerName;
    }

    public Object getReferrerParent() {
        return referrerParent;
    }

    public void setReferrerParent(Object referrerParent) {
        this.referrerParent = referrerParent;
    }

    public DecObjectType getReferrerType() {
        return referrerType;
    }

    public void setReferrerType(DecObjectType referrerType) {
        this.referrerType = referrerType;
    }

    public String getValidName() {
        if(name!=null){
            return name;
        }
        if(referrerName!=null && referrerName instanceof String){
            return (String)referrerName;
        }
        return null;
//        throw new UPAIllegalArgumentException("Invalid Declaration Name");
    }
    public String getName() {
        return name;
    }

    public void setName(String name) {
        this.name = name;
    }

    @Override
    public String toString() {
        return "Declaration{" + name + ", referrerType=" + referrerType + ", referrerName=" + referrerName + ", referrerParent=" + referrerParent + '}';
    }
}
