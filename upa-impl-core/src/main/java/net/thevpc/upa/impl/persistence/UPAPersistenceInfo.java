package net.thevpc.upa.impl.persistence;

import net.thevpc.upa.UPAObject;

import java.util.HashMap;
import java.util.Map;

/**
* @author Taha BEN SALAH <taha.bensalah@gmail.com>
* @creationdate 1/8/13 1:53 AM
*/
class UPAPersistenceInfo {
    UPAObject object;
    Map<String, PersistentObjectInfo> persistentObjects = new HashMap<String, PersistentObjectInfo>();

    UPAPersistenceInfo(UPAObject object) {
        this.object = object;
    }
}
