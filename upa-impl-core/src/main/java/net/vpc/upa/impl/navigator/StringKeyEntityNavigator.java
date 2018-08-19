package net.vpc.upa.impl.navigator;

import net.vpc.upa.Document;
import net.vpc.upa.Entity;
import net.vpc.upa.Field;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.expressions.InCollection;
import net.vpc.upa.expressions.Literal;
import net.vpc.upa.expressions.Select;
import net.vpc.upa.expressions.Var;
import net.vpc.upa.impl.upql.util.UPQLUtils;
import net.vpc.upa.impl.util.IdentifierUtils;
import net.vpc.upa.types.ConstraintsException;
import net.vpc.upa.types.StringType;
import net.vpc.upa.types.StringTypeCharValidator;
import net.vpc.upa.types.TypeValueValidator;

import java.util.List;
import java.util.TreeSet;

public class StringKeyEntityNavigator extends DefaultEntityNavigator {

    int synchNbrTry = 25;
    int asynchNbrTry = 25;

    public StringKeyEntityNavigator(Entity entity) {
        super(entity);
    }

    @Override
    public Object getNewKey() throws UPAException {

        List<Field> primaryFields = entity.getIdFields();
        if (primaryFields.size() == 1) {
            return entity.createId(getNewValue(primaryFields.get(0)));
        }
        throw new UPAException("Unsupported number of Primary Keys for StringKeyEntityNavigator");
    }

    public String getNewValue(Field field)
            throws UPAException {
        Entity entity = field.getEntity();
        String idName = field.getName();
        String goodId = null;
        for (int i = 0; i < asynchNbrTry; i++) {
            TreeSet<String> requestedIds = new TreeSet<String>();
            InCollection idsSet = new InCollection(new Var(new Var(UPQLUtils.THIS),idName));
            for (int j = 0; j < synchNbrTry; j++) {
                String id = (String) generateValue(field);
                idsSet.add(new Literal(id));
                requestedIds.add(id);
            }

            List<Document> documentList = entity.createQuery((new Select())
                    .from(entity.getName(), UPQLUtils.THIS)
                    .field(new Var(new Var(UPQLUtils.THIS),idName)).where(idsSet)).getDocumentList();
            TreeSet<String> foundIds = new TreeSet<String>();
            for (Document document : documentList) {
                foundIds.add(document.getString());
            }
            requestedIds.removeAll(foundIds);
            if (requestedIds.isEmpty()) {
                continue;
            }
            goodId = requestedIds.first();
            break;
        }

        return goodId;
    }

    protected Object generateValue(Field field) {
        try {
            StringType dataType = (StringType) field.getDataType();
            String goodChars = null;
            for (TypeValueValidator valueValidator : dataType.getValueValidators()) {
                if (valueValidator instanceof StringTypeCharValidator) {
                    StringTypeCharValidator s = (StringTypeCharValidator) valueValidator;
                    if (s.isPositive()) {
                        goodChars = s.getChars();
                        break;
                    }
                }
            }
            if (goodChars == null) {
                goodChars = IdentifierUtils.ALPHA_NUM_CHARS;
            }
            //prefer alphabetic at start
            //prefer alphanumeric at end
            //prefer no successive ponctuation
            // if too match difiicult (>100) do any thing
            StringBuilder alpha = new StringBuilder();
            StringBuilder num = new StringBuilder();
            StringBuilder ponct = new StringBuilder();
            for (int i = 0; i < goodChars.length(); i++) {
                char c = goodChars.charAt(i);
                if (Character.isLetter(c)) {
                    alpha.append(c);
                } else if (Character.isDigit(c)) {
                    num.append(c);
                } else {
                    ponct.append(c);
                }
            }
            for (int i = 0; i < 100; i++) {
                String k = IdentifierUtils.generateID(dataType.getMin(), dataType.getMax(), alpha.toString(), goodChars, alpha.toString() + num.toString());
                boolean ok = true;
                for (int j = 1; j < k.length() - 2; j++) {
                    if (ponct.toString().indexOf(k.charAt(j)) >= 0 && ponct.toString().indexOf(k.charAt(j + 1)) >= 0) {
                        ok = false;
                        break;
                    }
                }
                if (ok) {
                    return k;
                }
            }
            return IdentifierUtils.generateID(dataType.getMin(), dataType.getMax(), goodChars, goodChars, goodChars);
        } catch (ConstraintsException e) {
            return null;
        }
    }
}
