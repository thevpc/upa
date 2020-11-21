/*
 * Created by IntelliJ IDEA.
 * User: taha
 * Date: 28 fevr. 03
 * Time: 15:28:09
 * To change template for new class use
 * Code Style | Class Templates options (Tools | IDE Options).
 */
package net.thevpc.upa.impl.sysentities;

import net.thevpc.upa.Document;
import net.thevpc.upa.Key;
import net.thevpc.upa.config.*;
import net.thevpc.upa.types.DateTime;
import net.thevpc.upa.config.*;

@Entity(name = LockInfoDesc.LOCK_INFO_ENTITY_NAME, shortName = "LKNF", idType = Key.class, entityType = Document.class)
@Ignore
public class LockInfoDesc {
    public static final String LOCK_INFO_ENTITY_NAME = "UPALockInfo";

    @Id
    @Field(valueType = String.class, max = "64", nullable = BoolEnum.FALSE, path = "lock_infos")
    private FieldDesc lockedEntity;

    @Field(valueType = String.class, max = "64", nullable = BoolEnum.TRUE, path = "lock_infos")
    private FieldDesc lockId;

    @Field(valueType = DateTime.class, nullable = BoolEnum.TRUE, path = "lock_infos")
    private FieldDesc lockTime;

//    @Override
//    public void declareFields(Entity entity) {
//        //super.declareFields(); // no need for this
//        entity.startSection("lock_infos");
//        // locked entity is the locked entity or '*' to say all tables
////        addField("lockedEntity", PRIVATE|READ_ONLY, null,FieldType.forString(0,64,true));
////        addField("lockId", PRIVATE|READ_ONLY, null,FieldType.forString(0,64,true));
////        addField("lockTime", PRIVATE|READ_ONLY, null,FieldType.forDate(null,null,DateType.DATETIME,false,true));
//        entity.defineId("lockedEntity", null, TypesFactory.forString(0, 64, true));
//        entity.addField("lockId", null, TypesFactory.forString(0, 64, true));
//        entity.addField("lockTime", null, TypesFactory.forDate(null, null, DateType.DATETIME, false, true));
//        entity.endSection();
//    }
}
