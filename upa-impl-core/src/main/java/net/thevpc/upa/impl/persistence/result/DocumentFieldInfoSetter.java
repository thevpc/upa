package net.thevpc.upa.impl.persistence.result;

import net.thevpc.upa.Document;

/**
 * Created by vpc on 7/2/17.
 */
class DocumentFieldInfoSetter implements ResultFieldParseDataSetter {
    private final String fieldName;

    public DocumentFieldInfoSetter(String fieldName) {
        this.fieldName = fieldName;
    }

    @Override
    public void set(Object instance, Object value) {
        ((Document) instance).setObject(fieldName, value);
    }
}
