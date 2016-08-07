/*
 * To change this license header, choose License Headers in Project Properties.
 *
 * and open the template in the editor.
 */
package net.vpc.upa.impl.transform;

import java.io.IOException;
import java.io.StreamTokenizer;
import java.io.StringReader;
import java.util.ArrayList;

import net.vpc.upa.PasswordStrategy;
import net.vpc.upa.PasswordStrategyType;
import net.vpc.upa.PasswordTransformConfig;
import net.vpc.upa.PersistenceUnit;
import net.vpc.upa.SecretStrategy;
import net.vpc.upa.SecretStrategyType;
import net.vpc.upa.config.StringEncoderType;
import net.vpc.upa.exceptions.UPAException;
import net.vpc.upa.impl.util.StringUtils;
import net.vpc.upa.types.*;

/**
 *
 * @author taha.bensalah@gmail.com
 */
public class DefaultDataTypeTransformFactory implements DataTypeTransformFactory {

    private boolean isInt(double d) {
        double d2 = (int) d;
        return d2 == d;
    }

    private DataTypeTransformConfig createDataTypeTransformConfig(String expression) throws UPAException {
        if (expression.trim().length() > 0) {
            String name = null;
            ArrayList<String> args = new ArrayList<String>();

            StreamTokenizer st = new StreamTokenizer(new StringReader(expression.trim()));

            int tok = -1;
            final int STATUS_NAME = 1;
            final int STATUS_OPEN_PAR_OR_END = 2;
            final int STATUS_ARG_OR_CLOSE_PAR = 3;
            final int STATUS_COMMA_OR_CLOSE_PAR = 4;
            final int STATUS_ARG = 5;
            final int STATUS_END = 6;
            int status = STATUS_NAME;
            boolean finish = false;
            while (!finish) {
                try {
                    tok = st.nextToken();
                } catch (IOException ex) {
                    throw new RuntimeException("Never");
                }
                switch (status) {
                    case STATUS_NAME: {
                        switch (tok) {
                            case StreamTokenizer.TT_WORD: {
                                name = st.sval;
                                status = STATUS_OPEN_PAR_OR_END;
                                break;
                            }
                            default: {
                                throw new IllegalArgumentException("Expected name");
                            }
                        }
                        break;
                    }
                    case STATUS_OPEN_PAR_OR_END: {
                        switch (tok) {
                            case '(': {
                                status = STATUS_ARG_OR_CLOSE_PAR;
                                break;
                            }
                            case StreamTokenizer.TT_EOF: {
                                finish = true;
                                break;
                            }
                            default: {
                                throw new IllegalArgumentException("Expected name");
                            }
                        }
                        break;
                    }
                    case STATUS_ARG_OR_CLOSE_PAR: {
                        switch (tok) {
                            case StreamTokenizer.TT_WORD: {
                                args.add(st.sval);
                                status = STATUS_COMMA_OR_CLOSE_PAR;
                                break;
                            }
                            case StreamTokenizer.TT_NUMBER: {
                                args.add(isInt(st.nval) ? String.valueOf(((int) st.nval)) : String.valueOf(st.nval));
                                status = STATUS_COMMA_OR_CLOSE_PAR;
                                break;
                            }
                            case '\'':
                            case '\"': {
                                args.add(st.sval);
                                status = STATUS_COMMA_OR_CLOSE_PAR;
                                break;
                            }
                            case ')': {
                                args.add(st.sval);
                                status = STATUS_END;
                                break;
                            }
                            default: {
                                throw new IllegalArgumentException("Expected arg or close par");
                            }
                        }
                        break;
                    }
                    case STATUS_COMMA_OR_CLOSE_PAR: {
                        switch (tok) {
                            case ',': {
                                status = STATUS_ARG;
                                break;
                            }
                            case ')': {
                                status = STATUS_END;
                                break;
                            }
                            default: {
                                throw new IllegalArgumentException("Expected , or )");
                            }
                        }
                        break;
                    }
                    case STATUS_ARG: {
                        switch (tok) {
                            case StreamTokenizer.TT_WORD: {
                                args.add(st.sval);
                                status = STATUS_COMMA_OR_CLOSE_PAR;
                                break;
                            }
                            case StreamTokenizer.TT_NUMBER: {
                                args.add(isInt(st.nval) ? String.valueOf(((int) st.nval)) : String.valueOf(st.nval));
                                status = STATUS_COMMA_OR_CLOSE_PAR;
                                break;
                            }
                            case '\'':
                            case '\"': {
                                args.add(st.sval);
                                status = STATUS_COMMA_OR_CLOSE_PAR;
                                break;
                            }
                            default: {
                                throw new IllegalArgumentException("Expected arg or close par");
                            }
                        }
                        break;
                    }
                    case STATUS_END: {
                        switch (tok) {
                            case StreamTokenizer.TT_EOF: {
                                finish = true;
                                break;
                            }
                        }
                        break;
                    }
                    default: {
                        throw new IllegalArgumentException("Un Expected " + st.sval);
                    }

                }
            }
            return createDataTypeTransformConfig(name, args.toArray(new String[args.size()]));
        }
        throw new IllegalArgumentException("Unsupported converter expression");
    }

    private DataTypeTransformConfig createDataTypeTransformConfig(String name, String[] args) throws UPAException {
        if (name.equalsIgnoreCase("ToByteArray")) {
            StringEncoderTransformConfig c = new StringEncoderTransformConfig();
            if (args.length == 0) {
                return c;
            } else if (args.length == 1) {
                StringEncoderType t = null;
                try {
                    t = StringEncoderType.valueOf(args[0].toUpperCase());
                } catch (Exception e) {
                    //
                }
                if (t != null) {
                    c.setEncoder(t);
                } else {
                    c.setEncoder(args[0]);
                }
                return c;
            } else {
                throw new IllegalArgumentException("ToString: Invalid argument count");
            }
        }
        if (name.equalsIgnoreCase("ToByteArray")) {
            ByteArrayEncoderTransformConfig c = new ByteArrayEncoderTransformConfig();
            if (args.length == 0) {
                return c;
            } else if (args.length == 1) {
                c.setEncoder(args[0]);
                return c;
            } else {
                throw new IllegalArgumentException("ToByteArray: Invalid argument count");
            }
        }
        if (name.equalsIgnoreCase("Converter")) {
            if (args.length == 1) {
                return new CustomTypeDataTypeTransform(args[0]);
            } else {
                throw new IllegalArgumentException("Config: Invalid argument count");
            }
        }
        if (name.equalsIgnoreCase("Password")) {
            if (args.length == 0) {
                return new PasswordTransformConfig();
            } else if (args.length == 1) {
                PasswordTransformConfig c = new PasswordTransformConfig();
                PasswordStrategyType t = null;
                try {
                    t = PasswordStrategyType.valueOf(args[0].toUpperCase());
                } catch (Exception e) {
                    //
                }
                if (t != null) {
                    c.setCipherStrategy(t);
                } else {
                    c.setCipherStrategy(args[0]);
                }
                return c;
            } else if (args.length == 2) {
                PasswordTransformConfig c = new PasswordTransformConfig();
                PasswordStrategyType t = null;
                try {
                    t = PasswordStrategyType.valueOf(args[0].toUpperCase());
                } catch (Exception e) {
                    //
                }
                if (t != null) {
                    c.setCipherStrategy(t);
                } else {
                    c.setCipherStrategy(args[0]);
                }
                c.setCipherValue(args[1]);
                return c;
            } else {
                throw new IllegalArgumentException("Password: Invalid argument count");
            }
        }
        if (name.equalsIgnoreCase("Secret")) {
            if (args.length == 0) {
                return new SecretTransformConfig();
            } else if (args.length == 1) {
                SecretTransformConfig c = new SecretTransformConfig();
                SecretStrategyType t = null;
                try {
                    t = SecretStrategyType.valueOf(args[0].toUpperCase());
                } catch (Exception e) {
                    //
                }
                if (t != null) {
                    c.setSecretStrategy(t);
                } else {
                    c.setSecretStrategy(args[0]);
                }
                return c;
            } else if (args.length == 2) {
                SecretTransformConfig c = new SecretTransformConfig();
                SecretStrategyType t = null;
                try {
                    t = SecretStrategyType.valueOf(args[0].toUpperCase());
                } catch (Exception e) {
                    //
                }
                if (t != null) {
                    c.setSecretStrategy(t);
                } else {
                    c.setSecretStrategy(args[0]);
                }
                c.setSize(Integer.parseInt(args[1]));
                return c;
            } else if (args.length == 3) {
                SecretTransformConfig c = new SecretTransformConfig();
                SecretStrategyType t = null;
                try {
                    t = SecretStrategyType.valueOf(args[0].toUpperCase());
                } catch (Exception e) {
                    //
                }
                if (t != null) {
                    c.setSecretStrategy(t);
                } else {
                    c.setSecretStrategy(args[0]);
                }
                c.setSize(Integer.parseInt(args[1]));
                c.setEncodeKey(args[2]);
                c.setDecodeKey(args[2]);
                return c;
            } else if (args.length == 4) {
                SecretTransformConfig c = new SecretTransformConfig();
                SecretStrategyType t = null;
                try {
                    t = SecretStrategyType.valueOf(args[0].toUpperCase());
                } catch (Exception e) {
                    //
                }
                if (t != null) {
                    c.setSecretStrategy(t);
                } else {
                    c.setSecretStrategy(args[0]);
                }
                c.setSize(Integer.parseInt(args[1]));
                c.setEncodeKey(args[2]);
                c.setDecodeKey(args[3]);
                return c;
            } else {
                throw new IllegalArgumentException("Password: Invalid argument count");
            }
        } else {
            throw new IllegalArgumentException("Invalid converter " + name);
        }
    }

    private DataTypeTransformConfig[] createDataTypeTransformConfigArray(String expression) throws UPAException {
        ArrayList<DataTypeTransformConfig> all = new ArrayList<DataTypeTransformConfig>();
        if (expression != null && expression.length() > 0) {
            for (String c : expression.split("\\|")) {
                DataTypeTransformConfig cc = createDataTypeTransformConfig(c);
                if (cc != null) {
                    all.add(cc);
                }
            }
        }
        return all.toArray(new DataTypeTransformConfig[all.size()]);
    }

    public DataTypeTransform createTypeTransform(PersistenceUnit pu, DataType source, DataTypeTransformConfig[] configs) throws UPAException {
        DataTypeTransform t = null;
        DataType s = source;
        if (configs != null) {
            for (DataTypeTransformConfig c : configs) {
                if (c != null) {
                    DataTypeTransform tt = createTypeTransform(pu, s, c);
                    if (t == null) {
                        t = tt;
                    } else {
                        t = t.chain(tt);
                    }
                    s = t.getTargetType();
                }
            }
        }
        return t;
    }

    public DataTypeTransform createTypeTransform(PersistenceUnit pu, DataType source, DataTypeTransformConfig transformConfig) {
        if (transformConfig == null) {
            return null;
        }
        if (transformConfig instanceof DataTypeTransform) {
            return (DataTypeTransform) transformConfig;
        } else if ((transformConfig instanceof CustomExpressionDataTypeTransform)) {
            CustomExpressionDataTypeTransform c = (CustomExpressionDataTypeTransform) transformConfig;
            return createTypeTransform(pu, source, createDataTypeTransformConfigArray(c.getExpression()));
        } else if ((transformConfig instanceof CustomTypeDataTypeTransform)) {
            CustomTypeDataTypeTransform c = (CustomTypeDataTypeTransform) transformConfig;
            return pu.getFactory().createObject(c.getCustomType());
        } else if ((transformConfig instanceof CustomInstanceDataTypeTransform)) {
            CustomInstanceDataTypeTransform c = (CustomInstanceDataTypeTransform) transformConfig;
            DataTypeTransform i = c.getInstance();
            return i;
        } else if (transformConfig instanceof PasswordTransformConfig) {
            PasswordTransformConfig p = (PasswordTransformConfig) transformConfig;
            return createPasswordTransform(pu, source, p);
        } else if (transformConfig instanceof SecretTransformConfig) {
            SecretTransformConfig p = (SecretTransformConfig) transformConfig;
            return createSecretTransform(pu, source, p);
        } else if (transformConfig instanceof StringEncoderTransformConfig) {
            StringEncoderTransformConfig p = (StringEncoderTransformConfig) transformConfig;
            return createStringEncoderTransform(pu, source, p);
        } else if (transformConfig instanceof ByteArrayEncoderTransformConfig) {
            ByteArrayEncoderTransformConfig p = (ByteArrayEncoderTransformConfig) transformConfig;
            return createByteArrayEncoderTransform(pu, source, p);
        } else if (transformConfig instanceof CharArrayEncoderTransformConfig) {
            CharArrayEncoderTransformConfig p = (CharArrayEncoderTransformConfig) transformConfig;
            return createCharArrayEncoderTransform(pu, source, p);
        }
        throw new UPAException("Unsupported Transform Method", source);
    }

    public DataTypeTransform createPasswordTransform(PersistenceUnit pu, DataType source, PasswordTransformConfig p) {
        if (p == null) {
            p = new PasswordTransformConfig();
        }
        Object s = p.getCipherStrategy();
        if (s == null) {
            s = PasswordStrategyType.DEFAULT;
        }
        if (s instanceof PasswordStrategyType) {
            switch (((PasswordStrategyType) s)) {
                case SHA1: {
                    s = DefaultPasswordStrategy.SHA1;
                    break;
                }
                case SHA256: {
                    s = DefaultPasswordStrategy.SHA256;
                    break;
                }
                case MD5: {
                    s = DefaultPasswordStrategy.MD5;
                    break;
                }
                case DEFAULT: {
                    s = DefaultPasswordStrategy.MD5;
                    break;
                }
                default: {
                    throw new IllegalArgumentException("Unsupported CipherStrategy " + s);
                }
            }
        } else if (s instanceof String) {
            if (!StringUtils.isNullOrEmpty((String) s)) {
                s = (PasswordStrategy) pu.getFactory().createObject((String) s);
            } else {
                s = DefaultPasswordStrategy.MD5;
            }
        } else if (s instanceof Class) {
            s = (PasswordStrategy) pu.getFactory().createObject((Class) s);
        } else if (s instanceof PasswordStrategy) {
            s = (PasswordStrategy) s;
        } else {
            throw new IllegalArgumentException("Unsupported CipherStrategy " + s);
        }
        p.setCipherStrategy((PasswordStrategy) s);
        DataTypeTransform t = null;
        Object cipherValue = p.getCipherValue();
        if (!(source instanceof StringType)) {
            t = createStringEncoderTransform(pu, source, null);
            PasswordDataTypeTransform t2 = new PasswordDataTypeTransform((PasswordStrategy) p.getCipherStrategy(), cipherValue, t.getTargetType());
            return t.chain(t2);
        }
        return new PasswordDataTypeTransform((PasswordStrategy) p.getCipherStrategy(), cipherValue, source);
    }

    public DataTypeTransform createSecretTransform(PersistenceUnit pu, DataType source, SecretTransformConfig p) {
        if (p == null) {
            p = new SecretTransformConfig();
        }
        Object s = p.getSecretStrategy();
        if (s == null) {
            s = SecretStrategyType.DEFAULT;
        }
        if (s instanceof SecretStrategyType) {
            switch (((SecretStrategyType) s)) {
                case BASE64: {
                    s = Base64SecretStrategy.INSTANCE;
                    break;
                }
                case DEFAULT: {
                    s = new DefaultSecretStrategy();
                    break;
                }
                default: {
                    throw new UPAException("Unsupported", s);
                }
            }
        } else if (s instanceof String) {
            String ss = (String) s;
            if (!StringUtils.isNullOrEmpty(ss)) {
                s = (SecretStrategy) pu.getFactory().createObject((String) s);
            } else {
                //use default
                s = new DefaultSecretStrategy();
            }
        } else if (s instanceof Class) {
            s = (SecretStrategy) pu.getFactory().createObject((Class) s);
        } else if (s instanceof SecretStrategy) {
            s = (SecretStrategy) s;
        } else {
            throw new IllegalArgumentException("Unsupported SecretStrategy " + s);
        }
        SecretStrategy st = (SecretStrategy) s;
        st.init(pu, p.getEncodeKey(), p.getDecodeKey());
        p.setSecretStrategy(st);
        if (!(source instanceof ByteArrayType)) {
            DataTypeTransform t = null;
            t = createByteArrayEncoderTransform(pu, source, null);
            SecretDataTypeTransform t2 = new SecretDataTypeTransform(st, t.getTargetType(), p.getSize());
            return t.chain(t2);
        }
        return new SecretDataTypeTransform(st, source, p.getSize());
    }

    public DataTypeTransform createStringEncoderTransform(PersistenceUnit pu, DataType source, StringEncoderTransformConfig p) {
        if (p == null) {
            p = new StringEncoderTransformConfig();
        }

        ByteArrayEncoder toStringEncoder = null;
        int baseSize = 0;
        Object encoderObject = p.getEncoder();
        if (encoderObject == null) {
            encoderObject = StringEncoderType.DEFAULT;
        }
        if (source instanceof IntType) {
            toStringEncoder = IntToStringByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof LongType) {
            toStringEncoder = LongToStringByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof DoubleType) {
            toStringEncoder = DoubleToStringByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof FloatType) {
            toStringEncoder = FloatToStringByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof ByteArrayType) {
            toStringEncoder = IdentityByteArrayEncoder.INSTANCE;
            baseSize = ((ByteArrayType) source).getMaxSize() == null ? 0 : ((ByteArrayType) source).getMaxSize();
            if (encoderObject == StringEncoderType.DEFAULT) {
                encoderObject = StringEncoderType.HEXADECIMAL;
            }
        } else if (source instanceof EnumType) {
            EnumType et = (EnumType) source;
            toStringEncoder = new EnumToStringByteArrayEncoder(source.getPlatformType());
            //should we
            baseSize = 3;
            for (Object value : et.getValues()) {
                if (value != null) {
                    int cs = String.valueOf(value).length();
                    if (cs > baseSize) {
                        baseSize = cs;
                    }
                }
            }
        } else {
            throw new IllegalArgumentException("Unsupported");
        }
        if (baseSize <= 0) {
            baseSize = 255;
        }
        StringEncoder encoder = null;
        if (encoderObject instanceof StringEncoderType) {
            StringEncoderType set = (StringEncoderType) encoderObject;
            if (set == StringEncoderType.DEFAULT) {
                set = StringEncoderType.PLAIN;
            }
            if (set == StringEncoderType.CUSTOM) {
                throw new IllegalArgumentException("Unsupported");
            }
            switch (set) {
                case BASE64: {
                    encoder = Base64Encoder.INSTANCE;
                    if (p.getSize() <= 0) {
                        p.setSize(baseSize * 4 / 3 + 2);
                    }
                    break;
                }
                case HEXADECIMAL: {
                    encoder = HexaEncoder.INSTANCE;
                    if (p.getSize() <= 0) {
                        p.setSize(baseSize*2);
                    }
                    break;
                }
                case PLAIN: {
                    encoder = PlainStringEncoder.INSTANCE;
                    if (p.getSize() <= 0) {
                        p.setSize(baseSize);
                    }
                    break;
                }
                case XML: {
                    if (p.getSize() <= 0) {
                        p.setSize(baseSize);
                    }
                    throw new IllegalArgumentException("Unsupported yet " + set + " Encoder");
                }
                case JSON: {
                    if (p.getSize() <= 0) {
                        p.setSize(baseSize);
                    }
                    throw new IllegalArgumentException("Unsupported yet " + set + " Encoder");
                }
                default: {
                    throw new IllegalArgumentException("Unsupported yet " + set + " Encoder");
                }
            }
        } else if (encoderObject instanceof String) {
            return pu.getFactory().createObject((String) encoderObject);
        } else if (encoderObject instanceof Class) {
            return (DataTypeTransform) pu.getFactory().createObject((Class) encoderObject);
        } else {
            throw new IllegalArgumentException("Unsupported Encoder " + encoderObject);
        }
        return new StringEncoderDataTypeTransform(encoder, source, p.getSize(), toStringEncoder);
    }

    public DataTypeTransform createByteArrayEncoderTransform(PersistenceUnit pu, DataType source, ByteArrayEncoderTransformConfig p) {
        if (p == null) {
            p = new ByteArrayEncoderTransformConfig();
        }
        int baseSize = 0;
        ByteArrayEncoder enc = null;
        if (source instanceof IntType) {
            enc = IntToStringByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof LongType) {
            enc = LongToStringByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof DoubleType) {
            enc = DoubleToStringByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof FloatType) {
            enc = FloatToStringByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof StringType) {
            enc = StringToByteArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof ByteArrayType) {
            enc = null;
            baseSize = 255;
            EnumType et = (EnumType) source;
            enc = new EnumToStringByteArrayEncoder(source.getPlatformType());
            //should we
            baseSize = 3;
            for (Object value : et.getValues()) {
                if (value != null) {
                    int cs = String.valueOf(value).length();
                    if (cs > baseSize) {
                        baseSize = cs;
                    }
                }
            }
        } else {
            throw new IllegalArgumentException("Unsupported");
        }
        Object postEncoderObject = p.getEncoder();
        ByteArrayEncoder postEncoder = null;
        if (postEncoderObject == null) {

        } else if (postEncoderObject instanceof String) {
            if (!StringUtils.isNullOrEmpty((String) postEncoderObject)) {
                postEncoder = pu.getFactory().createObject((String) postEncoderObject);
            }
        } else if (postEncoderObject instanceof Class) {
            postEncoder = (ByteArrayEncoder) pu.getFactory().createObject((Class) postEncoderObject);

        } else if (postEncoderObject instanceof ByteArrayEncoder) {
            postEncoder = (ByteArrayEncoder) postEncoderObject;
        } else {
            throw new IllegalArgumentException("Unsupported");
        }

        if (p.getSize() <= 0) {
            p.setSize(baseSize);
        }
        ByteArrayEncoder finalEncoder = null;
        if (enc == null) {
            finalEncoder = postEncoder;
        } else if (postEncoder == null) {
            finalEncoder = enc;
        } else {
            finalEncoder = new ChainByteArrayEncoder(enc, postEncoder);
        }
        if (finalEncoder == null) {
            finalEncoder = IdentityByteArrayEncoder.INSTANCE;
        }
        return new ByteArrayEncoderDataTypeTransform(finalEncoder, source, p.getSize());
    }

    public DataTypeTransform createCharArrayEncoderTransform(PersistenceUnit pu, DataType source, CharArrayEncoderTransformConfig p) {
        if (p == null) {
            p = new CharArrayEncoderTransformConfig();
        }
        CharArrayEncoder preEncoder = null;
        int baseSize = 0;
        if (source instanceof IntType) {
            preEncoder = IntToStringCharArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof LongType) {
            preEncoder = LongToStringCharArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof DoubleType) {
            preEncoder = DoubleToStringCharArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof FloatType) {
            preEncoder = FloatToStringCharArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof StringType) {
            preEncoder = StringToCharArrayEncoder.INSTANCE;
            baseSize = 255;
        } else if (source instanceof ByteArrayType) {
            preEncoder = null;
            baseSize = 255;
        } else {
            throw new IllegalArgumentException("Unsupported");
        }
        Object postEncoderObject = p.getEncoder();

        CharArrayEncoder postEncoder = null;
        if (postEncoderObject == null) {

        } else if (postEncoderObject instanceof String) {
            if (!StringUtils.isNullOrEmpty((String) postEncoderObject)) {
                postEncoder = pu.getFactory().createObject((String) postEncoderObject);
            }
        } else if (postEncoderObject instanceof Class) {
            postEncoder = (CharArrayEncoder) pu.getFactory().createObject((Class) postEncoderObject);

        } else if (postEncoderObject instanceof ByteArrayEncoder) {
            postEncoder = (CharArrayEncoder) postEncoderObject;
        } else {
            throw new IllegalArgumentException("Unsupported");
        }

        if (p.getSize() <= 0) {
            p.setSize(baseSize);
        }
        CharArrayEncoder finalEncoder = null;
        if (preEncoder == null) {
            finalEncoder = postEncoder;
        } else if (postEncoder == null) {
            finalEncoder = preEncoder;
        } else {
            finalEncoder = new ChainCharArrayEncoder(preEncoder, postEncoder);
        }
        if (finalEncoder == null) {
            finalEncoder = IdentityCharArrayEncoder.INSTANCE;
        }
        return new CharArrayEncoderDataTypeTransform(finalEncoder, source, p.getSize());
    }

}
