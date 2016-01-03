//package net.vpc.upa.impl.persistence;
//
//import net.vpc.upa.*;
//import net.vpc.upa.exception.UPAException;
//import net.vpc.upa.impl.util.ConvertedList;
//import net.vpc.upa.impl.util.Converter;
//import net.vpc.upa.persistence.ResultMetaData;
//
//import java.util.List;
//
///**
// * Created with IntelliJ IDEA.
// * User: vpc
// * Date: 8/19/12
// * Time: 6:45 PM
// * To change this template use File | Settings | File Templates.
// */
//public class KeyListQuery<K, R> extends AbstractQuery<K, R> {
//    private List<K> list;
//    private Entity<K, R> defaultEntity;
//    private ResultMetaData md;
//
//    public KeyListQuery(List<K> list, Entity<K, R> defaultEntity) {
//        this.list = list;
//        this.defaultEntity = defaultEntity;
//    }
//
//    @Override
//    public ResultMetaData getMetaData() throws UPAException {
//        if (md == null) {
//            DefaultResultMetaData md = new DefaultResultMetaData();
//            for (Field field : defaultEntity.getPrimaryFields()) {
//                md.addField(field.getName(), field.getDataType(), field);
//            }
//            this.md = md;
//        }
//        return md;
//    }
//
//    @Override
//    public <K2, R2> List<R2> getEntityList(Entity<K2, R2> e) throws UPAException {
//        throw new IllegalArgumentException("No supported");
//    }
//
//    @Override
//    public <K2, R2> List<K2> getIdList(Entity<K2, R2> e) throws UPAException {
//        if (getDefaultEntity().equals(e)) {
//            return (List<K2>) list;
//        }
//        throw new IllegalArgumentException("No supported");
//    }
//
//    @Override
//    public List<Key> getKeyList() throws UPAException {
//        return new ConvertedList<K, Key>(getIdList(), new Converter<K, Key>() {
//            @Override
//            public Key convert(K k) {
//                return defaultEntity.getBuilder().idToKey(k);
//            }
//        });
//    }
//
//    @Override
//    public Entity getDefaultEntity() {
//        if (defaultEntity == null) {
//            throw new IllegalArgumentException("No Default Entity is associated to this Find Query");
//        }
//        return defaultEntity;
//    }
//
//    @Override
//    public List<MultiRecord> getMultiRecordList() throws UPAException {
//        throw new IllegalArgumentException("No supported");
//    }
//
//    @Override
//    public List<Record> getRecordList() throws UPAException {
//        throw new IllegalArgumentException("No supported");
//    }
//}
