package net.vpc.upa.impl.persistence.specific.oracle;

import net.vpc.upa.types.*;
import net.vpc.upa.*;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.persistence.DefaultPersistenceStore;
import net.vpc.upa.impl.persistence.shared.ConstantDataMarshallerFactory;
import net.vpc.upa.impl.persistence.shared.NullValANSISQLProvider;
import net.vpc.upa.impl.persistence.shared.SignANSISQLProvider;

import java.util.LinkedHashSet;
import java.util.List;
import java.util.Set;
import net.vpc.upa.filters.Fields;
import net.vpc.upa.persistence.EntityExecutionContext;

@PortabilityHint(target = "C#", name = "suppress")
public class OraclePersistenceStore extends DefaultPersistenceStore {

    private static final OracleSerializablePlatformObjectMarshaller oracleSerializablePlatformObjectWrapper = new OracleSerializablePlatformObjectMarshaller();

    public OraclePersistenceStore() {
        Properties map = getProperties();
        map.setBoolean("isComplexSelectSupported", Boolean.TRUE);
        map.setBoolean("isUpdateComplexValuesStatementSupported", Boolean.TRUE);
        map.setBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", Boolean.TRUE);
        map.setBoolean("isFromClauseInUpdateStatementSupported", Boolean.FALSE);
        map.setBoolean("isFromClauseInDeleteStatementSupported", Boolean.FALSE);
        map.setBoolean("isReferencingSupported", Boolean.TRUE);
        map.setBoolean("isViewSupported", Boolean.TRUE);
        map.setBoolean("isTopSupported", Boolean.FALSE);
        getSqlManager().register(new OracleCoalesceSQLProvider());
        getSqlManager().register(new OracleConcatSQLProvider());
        getSqlManager().register(new OracleDateTruncSQLProvider());
        getSqlManager().register(new OracleDateAddSQLProvider());
        getSqlManager().register(new OracleDatePartSQLProvider());
        getSqlManager().register(new OracleDateDiffSQLProvider());
        getSqlManager().register(new OracleDecodeSQLProvider());
        getSqlManager().register(new OracleIfSQLProvider());
        getSqlManager().register(new SignANSISQLProvider());
        getSqlManager().register(new OracleStrLenSQLProvider());
        getSqlManager().register(new OracleCurrentTimestampSQLProvider());
        getSqlManager().register(new OracleMonthStartSQLProvider());
        getSqlManager().register(new OracleMonthEndSQLProvider());
        getSqlManager().register(new OracleCastSQLProvider());
        getSqlManager().register(new OracleI2VSQLProvider());
        getSqlManager().register(new OracleD2VSQLProvider());
        getSqlManager().register(new NullValANSISQLProvider());
        getSqlManager().register(new OracleTypeNameSQLProvider());
        getSqlManager().register(new OracleSelectSQLProvider());

        getMarshallManager().setTypeMarshaller(Float.class, new OracleFloatAsDoubleMarshaller());
//        getMarshallManager().setTypeMarshaller(ImageData.class, oracleSerializableJavaObjectWrapper);
        getMarshallManager().setTypeMarshaller(Object.class, oracleSerializablePlatformObjectWrapper);
        getMarshallManager().setTypeMarshaller(FileData.class, oracleSerializablePlatformObjectWrapper);
        getMarshallManager().setTypeMarshaller(DataType.class, oracleSerializablePlatformObjectWrapper);
        ConstantDataMarshallerFactory blobfactory = new ConstantDataMarshallerFactory(oracleSerializablePlatformObjectWrapper);
        getMarshallManager().setTypeMarshallerFactory(DataType.class, blobfactory);

        getMarshallManager().setTypeMarshallerFactory(ImageType.class, blobfactory);
        getMarshallManager().setTypeMarshallerFactory(FileType.class, blobfactory);
//        DataWrapperUtils.setWrapperFactory(DateType.class, F_DATE);
//        DataWrapperUtils.setWrapperFactory(NumberType.class, F_NUMBER);
//        DataWrapperUtils.setWrapperFactory(StringType.class, F_STRING);
//        DataWrapperUtils.setWrapperFactory(BooleanType.class, F_BOOLEAN_FROM_NUMBER);
//        DataWrapperUtils.setWrapperFactory(ListType.class, F_LIST);

        //parser.registerFunction("cast", new CastAsSQLProvider());
    }

    @Override
    public Set<String> getSupportedDrivers() {
        LinkedHashSet<String> valid = new LinkedHashSet<String>();
        valid.add(DRIVER_TYPE_DEFAULT);
        return valid;
    }

    @Override
    public String getFieldDeclaration(PrimitiveField field, net.vpc.upa.persistence.EntityExecutionContext entityPersistenceContext) throws UPAException {
        String s = super.getFieldDeclaration(field,entityPersistenceContext);
//        if (field.isAutoIncrement()) {
        //throw new IllegalArgumentException("Not yet supported");
        //s += " IDENTITY(" + field.getAutoIncrement().getSeed() + "," + field.getAutoIncrement().getIncrement() + ")";
//        }
        return s;
    }

    @Override
    public void dropStorage(EntityExecutionContext context) throws UPAException {
    }

    @Override
    public String getDisableIdentityConstraintsStatement(Entity table) {
        return null;
    }

    @Override
    public String getEnableIdentityConstraintsStatement(Entity table) {
        return null;
    }

    @Override
    public String getCreateIndexStatement(Index index) throws UPAException {
        StringBuilder sb = new StringBuilder("Create");
        //how is cluster supported ?
//        switch(index.getDataType()){
//        	case CLUSTERED:{
//        		sb.append(" CLUSTERED");
//        		break;
//        	}
//        	case NON_CLUSTERED:{
//        		sb.append(" NON_CLUSTERED");
//        		break;
//        	}
//        }
        sb.append(" Index ");
        sb.append(getValidIdentifier(getPersistenceName(index)));
        sb.append(" On ");
        sb.append(index.getEntity().getPersistenceName());
        sb.append("(");
        boolean first = true;
        List<PrimitiveField> primitiveFields = index.getEntity().getPrimitiveFields(
                Fields.regular().and(Fields.byList(index.getFields()))
        );
        for (Field field : primitiveFields) {
            if (first) {
                first = false;
            } else {
                sb.append(", ");
            }
            sb.append(getValidIdentifier(getPersistenceName(field)));
        }
        sb.append(")");
        return (sb.toString());
    }

}
