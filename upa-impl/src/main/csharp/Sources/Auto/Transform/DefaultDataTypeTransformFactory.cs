/*********************************************************
 *********************************************************
 **   DO NOT EDIT                                       **
 **                                                     **
 **   THIS FILE AS BEEN GENERATED AUTOMATICALLY         **
 **   BY UPA PORTABLE GENERATOR                         **
 **   (c) vpc                                           **
 **                                                     **
 *********************************************************
 ********************************************************/



using System.Linq;
namespace Net.Vpc.Upa.Impl.Transform
{


    /**
     *
     * @author vpc
     */
    public class DefaultDataTypeTransformFactory : Net.Vpc.Upa.Types.DataTypeTransformFactory {

        private bool IsInt(double d) {
            double d2 = (int) d;
            return d2 == d;
        }

        private Net.Vpc.Upa.Types.DataTypeTransformConfig CreateDataTypeTransformConfig(string expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if ((expression.Trim()).Length > 0) {
                string name = null;
                System.Collections.Generic.List<string> args = new System.Collections.Generic.List<string>();
                J2CS.IO.StreamTokenizer st = new J2CS.IO.StreamTokenizer(new System.IO.StringReader(expression.Trim()));
                int tok = -1;
                int STATUS_NAME = 1;
                int STATUS_OPEN_PAR_OR_END = 2;
                int STATUS_ARG_OR_CLOSE_PAR = 3;
                int STATUS_COMMA_OR_CLOSE_PAR = 4;
                int STATUS_ARG = 5;
                int STATUS_END = 6;
                int status = STATUS_NAME;
                bool finish = false;
                while (!finish) {
                    try {
                        tok = st.NextToken();
                    } catch (System.IO.IOException ex) {
                        throw new System.Exception("Never");
                    }
                    switch(status) {
                        case STATUS_NAME:
                            {
                                switch(tok) {
                                    case J2CS.IO.StreamTokenizer.TT_WORD:
                                        {
                                            name = st.sval;
                                            status = STATUS_OPEN_PAR_OR_END;
                                            break;
                                        }
                                    default:
                                        {
                                            throw new System.ArgumentException ("Expected name");
                                        }
                                }
                                break;
                            }
                        case STATUS_OPEN_PAR_OR_END:
                            {
                                switch(tok) {
                                    case '(':
                                        {
                                            status = STATUS_ARG_OR_CLOSE_PAR;
                                            break;
                                        }
                                    case J2CS.IO.StreamTokenizer.TT_EOF:
                                        {
                                            finish = true;
                                            break;
                                        }
                                    default:
                                        {
                                            throw new System.ArgumentException ("Expected name");
                                        }
                                }
                                break;
                            }
                        case STATUS_ARG_OR_CLOSE_PAR:
                            {
                                switch(tok) {
                                    case J2CS.IO.StreamTokenizer.TT_WORD:
                                        {
                                            args.Add(st.sval);
                                            status = STATUS_COMMA_OR_CLOSE_PAR;
                                            break;
                                        }
                                    case J2CS.IO.StreamTokenizer.TT_NUMBER:
                                        {
                                            args.Add(IsInt(st.nval) ? System.Convert.ToString(((int) st.nval)) : System.Convert.ToString(st.nval));
                                            status = STATUS_COMMA_OR_CLOSE_PAR;
                                            break;
                                        }
                                    case '\'':
                                    case '\"':
                                        {
                                            args.Add(st.sval);
                                            status = STATUS_COMMA_OR_CLOSE_PAR;
                                            break;
                                        }
                                    case ')':
                                        {
                                            args.Add(st.sval);
                                            status = STATUS_END;
                                            break;
                                        }
                                    default:
                                        {
                                            throw new System.ArgumentException ("Expected arg or close par");
                                        }
                                }
                                break;
                            }
                        case STATUS_COMMA_OR_CLOSE_PAR:
                            {
                                switch(tok) {
                                    case ',':
                                        {
                                            status = STATUS_ARG;
                                            break;
                                        }
                                    case ')':
                                        {
                                            status = STATUS_END;
                                            break;
                                        }
                                    default:
                                        {
                                            throw new System.ArgumentException ("Expected , or )");
                                        }
                                }
                                break;
                            }
                        case STATUS_ARG:
                            {
                                switch(tok) {
                                    case J2CS.IO.StreamTokenizer.TT_WORD:
                                        {
                                            args.Add(st.sval);
                                            status = STATUS_COMMA_OR_CLOSE_PAR;
                                            break;
                                        }
                                    case J2CS.IO.StreamTokenizer.TT_NUMBER:
                                        {
                                            args.Add(IsInt(st.nval) ? System.Convert.ToString(((int) st.nval)) : System.Convert.ToString(st.nval));
                                            status = STATUS_COMMA_OR_CLOSE_PAR;
                                            break;
                                        }
                                    case '\'':
                                    case '\"':
                                        {
                                            args.Add(st.sval);
                                            status = STATUS_COMMA_OR_CLOSE_PAR;
                                            break;
                                        }
                                    default:
                                        {
                                            throw new System.ArgumentException ("Expected arg or close par");
                                        }
                                }
                                break;
                            }
                        case STATUS_END:
                            {
                                switch(tok) {
                                    case J2CS.IO.StreamTokenizer.TT_EOF:
                                        {
                                            finish = true;
                                            break;
                                        }
                                }
                                break;
                            }
                        default:
                            {
                                throw new System.ArgumentException ("Un Expected " + st.sval);
                            }
                    }
                }
                return CreateDataTypeTransformConfig(name, args.ToArray());
            }
            throw new System.ArgumentException ("Unsupported converter expression");
        }

        private Net.Vpc.Upa.Types.DataTypeTransformConfig CreateDataTypeTransformConfig(string name, string[] args) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            if (name.Equals("ToByteArray",System.StringComparison.InvariantCultureIgnoreCase)) {
                Net.Vpc.Upa.Types.StringEncoderTransformConfig c = new Net.Vpc.Upa.Types.StringEncoderTransformConfig();
                if (args.Length == 0) {
                    return c;
                } else if (args.Length == 1) {
                    Net.Vpc.Upa.Config.StringEncoderType t = null;
                    try {
                        t = (Net.Vpc.Upa.Config.StringEncoderType)(System.Enum.Parse(typeof(Net.Vpc.Upa.Config.StringEncoderType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != null) {
                        c.SetEncoder(t);
                    } else {
                        c.SetEncoder(args[0]);
                    }
                    return c;
                } else {
                    throw new System.ArgumentException ("ToString: Invalid argument count");
                }
            }
            if (name.Equals("ToByteArray",System.StringComparison.InvariantCultureIgnoreCase)) {
                Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig c = new Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig();
                if (args.Length == 0) {
                    return c;
                } else if (args.Length == 1) {
                    c.SetEncoder(args[0]);
                    return c;
                } else {
                    throw new System.ArgumentException ("ToByteArray: Invalid argument count");
                }
            }
            if (name.Equals("Converter",System.StringComparison.InvariantCultureIgnoreCase)) {
                if (args.Length == 1) {
                    return new Net.Vpc.Upa.Types.CustomTypeDataTypeTransform(args[0]);
                } else {
                    throw new System.ArgumentException ("Config: Invalid argument count");
                }
            }
            if (name.Equals("Password",System.StringComparison.InvariantCultureIgnoreCase)) {
                if (args.Length == 0) {
                    return new Net.Vpc.Upa.PasswordTransformConfig();
                } else if (args.Length == 1) {
                    Net.Vpc.Upa.PasswordTransformConfig c = new Net.Vpc.Upa.PasswordTransformConfig();
                    Net.Vpc.Upa.PasswordStrategyType t = null;
                    try {
                        t = (Net.Vpc.Upa.PasswordStrategyType)(System.Enum.Parse(typeof(Net.Vpc.Upa.PasswordStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != null) {
                        c.SetCipherStrategy(t);
                    } else {
                        c.SetCipherStrategy(args[0]);
                    }
                    return c;
                } else if (args.Length == 2) {
                    Net.Vpc.Upa.PasswordTransformConfig c = new Net.Vpc.Upa.PasswordTransformConfig();
                    Net.Vpc.Upa.PasswordStrategyType t = null;
                    try {
                        t = (Net.Vpc.Upa.PasswordStrategyType)(System.Enum.Parse(typeof(Net.Vpc.Upa.PasswordStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != null) {
                        c.SetCipherStrategy(t);
                    } else {
                        c.SetCipherStrategy(args[0]);
                    }
                    c.SetCipherValue(args[1]);
                    return c;
                } else {
                    throw new System.ArgumentException ("Password: Invalid argument count");
                }
            }
            if (name.Equals("Secret",System.StringComparison.InvariantCultureIgnoreCase)) {
                if (args.Length == 0) {
                    return new Net.Vpc.Upa.Types.SecretTransformConfig();
                } else if (args.Length == 1) {
                    Net.Vpc.Upa.Types.SecretTransformConfig c = new Net.Vpc.Upa.Types.SecretTransformConfig();
                    Net.Vpc.Upa.SecretStrategyType t = null;
                    try {
                        t = (Net.Vpc.Upa.SecretStrategyType)(System.Enum.Parse(typeof(Net.Vpc.Upa.SecretStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != null) {
                        c.SetSecretStrategy(t);
                    } else {
                        c.SetSecretStrategy(args[0]);
                    }
                    return c;
                } else if (args.Length == 2) {
                    Net.Vpc.Upa.Types.SecretTransformConfig c = new Net.Vpc.Upa.Types.SecretTransformConfig();
                    Net.Vpc.Upa.SecretStrategyType t = null;
                    try {
                        t = (Net.Vpc.Upa.SecretStrategyType)(System.Enum.Parse(typeof(Net.Vpc.Upa.SecretStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != null) {
                        c.SetSecretStrategy(t);
                    } else {
                        c.SetSecretStrategy(args[0]);
                    }
                    c.SetSize(System.Convert.ToInt32(args[1]));
                    return c;
                } else if (args.Length == 3) {
                    Net.Vpc.Upa.Types.SecretTransformConfig c = new Net.Vpc.Upa.Types.SecretTransformConfig();
                    Net.Vpc.Upa.SecretStrategyType t = null;
                    try {
                        t = (Net.Vpc.Upa.SecretStrategyType)(System.Enum.Parse(typeof(Net.Vpc.Upa.SecretStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != null) {
                        c.SetSecretStrategy(t);
                    } else {
                        c.SetSecretStrategy(args[0]);
                    }
                    c.SetSize(System.Convert.ToInt32(args[1]));
                    c.SetEncodeKey(args[2]);
                    c.SetDecodeKey(args[2]);
                    return c;
                } else if (args.Length == 4) {
                    Net.Vpc.Upa.Types.SecretTransformConfig c = new Net.Vpc.Upa.Types.SecretTransformConfig();
                    Net.Vpc.Upa.SecretStrategyType t = null;
                    try {
                        t = (Net.Vpc.Upa.SecretStrategyType)(System.Enum.Parse(typeof(Net.Vpc.Upa.SecretStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != null) {
                        c.SetSecretStrategy(t);
                    } else {
                        c.SetSecretStrategy(args[0]);
                    }
                    c.SetSize(System.Convert.ToInt32(args[1]));
                    c.SetEncodeKey(args[2]);
                    c.SetDecodeKey(args[3]);
                    return c;
                } else {
                    throw new System.ArgumentException ("Password: Invalid argument count");
                }
            } else {
                throw new System.ArgumentException ("Invalid converter " + name);
            }
        }

        private Net.Vpc.Upa.Types.DataTypeTransformConfig[] CreateDataTypeTransformConfigArray(string expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.Vpc.Upa.Types.DataTypeTransformConfig> all = new System.Collections.Generic.List<Net.Vpc.Upa.Types.DataTypeTransformConfig>();
            if (expression != null && (expression).Length > 0) {
                foreach (string c in System.Text.RegularExpressions.Regex.Split(expression,"\\|")) {
                    Net.Vpc.Upa.Types.DataTypeTransformConfig cc = CreateDataTypeTransformConfig(c);
                    if (cc != null) {
                        all.Add(cc);
                    }
                }
            }
            return all.ToArray();
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform CreateTypeTransform(Net.Vpc.Upa.PersistenceUnit pu, Net.Vpc.Upa.Types.DataType source, Net.Vpc.Upa.Types.DataTypeTransformConfig[] configs) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            Net.Vpc.Upa.Types.DataTypeTransform t = null;
            Net.Vpc.Upa.Types.DataType s = source;
            if (configs != null) {
                foreach (Net.Vpc.Upa.Types.DataTypeTransformConfig c in configs) {
                    if (c != null) {
                        Net.Vpc.Upa.Types.DataTypeTransform tt = CreateTypeTransform(pu, s, c);
                        if (t == null) {
                            t = tt;
                        } else {
                            t = t.Chain(tt);
                        }
                        s = t.GetTargetType();
                    }
                }
            }
            return t;
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform CreateTypeTransform(Net.Vpc.Upa.PersistenceUnit pu, Net.Vpc.Upa.Types.DataType source, Net.Vpc.Upa.Types.DataTypeTransformConfig transformConfig) {
            if (transformConfig == null) {
                return null;
            }
            if (transformConfig is Net.Vpc.Upa.Types.DataTypeTransform) {
                return (Net.Vpc.Upa.Types.DataTypeTransform) transformConfig;
            } else if ((transformConfig is Net.Vpc.Upa.Types.CustomExpressionDataTypeTransform)) {
                Net.Vpc.Upa.Types.CustomExpressionDataTypeTransform c = (Net.Vpc.Upa.Types.CustomExpressionDataTypeTransform) transformConfig;
                return CreateTypeTransform(pu, source, CreateDataTypeTransformConfigArray(c.GetExpression()));
            } else if ((transformConfig is Net.Vpc.Upa.Types.CustomTypeDataTypeTransform)) {
                Net.Vpc.Upa.Types.CustomTypeDataTypeTransform c = (Net.Vpc.Upa.Types.CustomTypeDataTypeTransform) transformConfig;
                return pu.GetFactory().CreateObject<Net.Vpc.Upa.Types.DataTypeTransform>(c.GetCustomType());
            } else if ((transformConfig is Net.Vpc.Upa.Types.CustomInstanceDataTypeTransform)) {
                Net.Vpc.Upa.Types.CustomInstanceDataTypeTransform c = (Net.Vpc.Upa.Types.CustomInstanceDataTypeTransform) transformConfig;
                Net.Vpc.Upa.Types.DataTypeTransform i = c.GetInstance();
                return i;
            } else if (transformConfig is Net.Vpc.Upa.PasswordTransformConfig) {
                Net.Vpc.Upa.PasswordTransformConfig p = (Net.Vpc.Upa.PasswordTransformConfig) transformConfig;
                return CreatePasswordTransform(pu, source, p);
            } else if (transformConfig is Net.Vpc.Upa.Types.SecretTransformConfig) {
                Net.Vpc.Upa.Types.SecretTransformConfig p = (Net.Vpc.Upa.Types.SecretTransformConfig) transformConfig;
                return CreateSecretTransform(pu, source, p);
            } else if (transformConfig is Net.Vpc.Upa.Types.StringEncoderTransformConfig) {
                Net.Vpc.Upa.Types.StringEncoderTransformConfig p = (Net.Vpc.Upa.Types.StringEncoderTransformConfig) transformConfig;
                return CreateStringEncoderTransform(pu, source, p);
            } else if (transformConfig is Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig) {
                Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig p = (Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig) transformConfig;
                return CreateByteArrayEncoderTransform(pu, source, p);
            } else if (transformConfig is Net.Vpc.Upa.Types.CharArrayEncoderTransformConfig) {
                Net.Vpc.Upa.Types.CharArrayEncoderTransformConfig p = (Net.Vpc.Upa.Types.CharArrayEncoderTransformConfig) transformConfig;
                return CreateCharArrayEncoderTransform(pu, source, p);
            }
            throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported Transform Method", source);
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform CreatePasswordTransform(Net.Vpc.Upa.PersistenceUnit pu, Net.Vpc.Upa.Types.DataType source, Net.Vpc.Upa.PasswordTransformConfig p) {
            if (p == null) {
                p = new Net.Vpc.Upa.PasswordTransformConfig();
            }
            object s = p.GetCipherStrategy();
            if (s == null) {
                s = Net.Vpc.Upa.PasswordStrategyType.DEFAULT;
            }
            if (s is Net.Vpc.Upa.PasswordStrategyType) {
                switch(((Net.Vpc.Upa.PasswordStrategyType) s)) {
                    case Net.Vpc.Upa.PasswordStrategyType.SHA1:
                        {
                            s = Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.SHA1;
                            break;
                        }
                    case Net.Vpc.Upa.PasswordStrategyType.SHA256:
                        {
                            s = Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.SHA256;
                            break;
                        }
                    case Net.Vpc.Upa.PasswordStrategyType.MD5:
                        {
                            s = Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.MD5;
                            break;
                        }
                    case Net.Vpc.Upa.PasswordStrategyType.DEFAULT:
                        {
                            s = Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.MD5;
                            break;
                        }
                    default:
                        {
                            throw new System.ArgumentException ("Unsupported CipherStrategy " + s);
                        }
                }
            } else if (s is string) {
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty((string) s)) {
                    s = (Net.Vpc.Upa.PasswordStrategy) pu.GetFactory().CreateObject<Net.Vpc.Upa.PasswordStrategy>((string) s);
                } else {
                    s = Net.Vpc.Upa.Impl.Transform.DefaultPasswordStrategy.MD5;
                }
            } else if (s is System.Type) {
                s = (Net.Vpc.Upa.PasswordStrategy) pu.GetFactory().CreateObject<Net.Vpc.Upa.PasswordStrategy>((System.Type) s);
            } else if (s is Net.Vpc.Upa.PasswordStrategy) {
                s = (Net.Vpc.Upa.PasswordStrategy) s;
            } else {
                throw new System.ArgumentException ("Unsupported CipherStrategy " + s);
            }
            p.SetCipherStrategy((Net.Vpc.Upa.PasswordStrategy) s);
            Net.Vpc.Upa.Types.DataTypeTransform t = null;
            object cipherValue = p.GetCipherValue();
            if (!(source is Net.Vpc.Upa.Types.StringType)) {
                t = CreateStringEncoderTransform(pu, source, null);
                Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform t2 = new Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform((Net.Vpc.Upa.PasswordStrategy) p.GetCipherStrategy(), cipherValue, t.GetTargetType());
                return t.Chain(t2);
            }
            return new Net.Vpc.Upa.Impl.Transform.PasswordDataTypeTransform((Net.Vpc.Upa.PasswordStrategy) p.GetCipherStrategy(), cipherValue, source);
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform CreateSecretTransform(Net.Vpc.Upa.PersistenceUnit pu, Net.Vpc.Upa.Types.DataType source, Net.Vpc.Upa.Types.SecretTransformConfig p) {
            if (p == null) {
                p = new Net.Vpc.Upa.Types.SecretTransformConfig();
            }
            object s = p.GetSecretStrategy();
            if (s == null) {
                s = Net.Vpc.Upa.SecretStrategyType.DEFAULT;
            }
            if (s is Net.Vpc.Upa.SecretStrategyType) {
                switch(((Net.Vpc.Upa.SecretStrategyType) s)) {
                    case Net.Vpc.Upa.SecretStrategyType.BASE64:
                        {
                            s = Net.Vpc.Upa.Impl.Transform.Base64SecretStrategy.INSTANCE;
                            break;
                        }
                    case Net.Vpc.Upa.SecretStrategyType.DEFAULT:
                        {
                            s = new Net.Vpc.Upa.Impl.Transform.DefaultSecretStrategy();
                            break;
                        }
                    default:
                        {
                            throw new Net.Vpc.Upa.Exceptions.UPAException("Unsupported", s);
                        }
                }
            } else if (s is string) {
                string ss = (string) s;
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty(ss)) {
                    s = (Net.Vpc.Upa.SecretStrategy) pu.GetFactory().CreateObject<Net.Vpc.Upa.SecretStrategy>((string) s);
                } else {
                    //use default
                    s = new Net.Vpc.Upa.Impl.Transform.DefaultSecretStrategy();
                }
            } else if (s is System.Type) {
                s = (Net.Vpc.Upa.SecretStrategy) pu.GetFactory().CreateObject<Net.Vpc.Upa.SecretStrategy>((System.Type) s);
            } else if (s is Net.Vpc.Upa.SecretStrategy) {
                s = (Net.Vpc.Upa.SecretStrategy) s;
            } else {
                throw new System.ArgumentException ("Unsupported SecretStrategy " + s);
            }
            Net.Vpc.Upa.SecretStrategy st = (Net.Vpc.Upa.SecretStrategy) s;
            st.Init(pu, p.GetEncodeKey(), p.GetDecodeKey());
            p.SetSecretStrategy(st);
            if (!(source is Net.Vpc.Upa.Types.ByteArrayType)) {
                Net.Vpc.Upa.Types.DataTypeTransform t = null;
                t = CreateByteArrayEncoderTransform(pu, source, null);
                Net.Vpc.Upa.Impl.Transform.SecretDataTypeTransform t2 = new Net.Vpc.Upa.Impl.Transform.SecretDataTypeTransform(st, t.GetTargetType(), p.GetSize());
                return t.Chain(t2);
            }
            return new Net.Vpc.Upa.Impl.Transform.SecretDataTypeTransform(st, source, p.GetSize());
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform CreateStringEncoderTransform(Net.Vpc.Upa.PersistenceUnit pu, Net.Vpc.Upa.Types.DataType source, Net.Vpc.Upa.Types.StringEncoderTransformConfig p) {
            if (p == null) {
                p = new Net.Vpc.Upa.Types.StringEncoderTransformConfig();
            }
            Net.Vpc.Upa.Types.ByteArrayEncoder toStringEncoder = null;
            int baseSize = 0;
            object encoderObject = p.GetEncoder();
            if (encoderObject == null) {
                encoderObject = Net.Vpc.Upa.Config.StringEncoderType.DEFAULT;
            }
            if (source is Net.Vpc.Upa.Types.IntType) {
                toStringEncoder = Net.Vpc.Upa.Impl.Transform.IntToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.LongType) {
                toStringEncoder = Net.Vpc.Upa.Impl.Transform.LongToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.DoubleType) {
                toStringEncoder = Net.Vpc.Upa.Impl.Transform.DoubleToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.FloatType) {
                toStringEncoder = Net.Vpc.Upa.Impl.Transform.FloatToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.ByteArrayType) {
                toStringEncoder = Net.Vpc.Upa.Impl.Transform.IdentityByteArrayEncoder.INSTANCE;
                baseSize = ((Net.Vpc.Upa.Types.ByteArrayType) source).GetMaxSize() == null ? ((int)(0)) : (((Net.Vpc.Upa.Types.ByteArrayType) source).GetMaxSize()).Value;
                if (encoderObject == Net.Vpc.Upa.Config.StringEncoderType.DEFAULT) {
                    encoderObject = Net.Vpc.Upa.Config.StringEncoderType.HEXADECIMAL;
                }
            } else if (source is Net.Vpc.Upa.Types.EnumType) {
                Net.Vpc.Upa.Types.EnumType et = (Net.Vpc.Upa.Types.EnumType) source;
                toStringEncoder = new Net.Vpc.Upa.Impl.Transform.EnumToStringByteArrayEncoder(source.GetPlatformType());
                //should we
                baseSize = 3;
                foreach (object @value in et.GetValues()) {
                    if (@value != null) {
                        int cs = (System.Convert.ToString(@value)).Length;
                        if (cs > baseSize) {
                            baseSize = cs;
                        }
                    }
                }
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
            if (baseSize <= 0) {
                baseSize = 255;
            }
            Net.Vpc.Upa.Types.StringEncoder encoder = null;
            if (encoderObject is Net.Vpc.Upa.Config.StringEncoderType) {
                Net.Vpc.Upa.Config.StringEncoderType set = (Net.Vpc.Upa.Config.StringEncoderType) encoderObject;
                if (set == Net.Vpc.Upa.Config.StringEncoderType.DEFAULT) {
                    set = Net.Vpc.Upa.Config.StringEncoderType.PLAIN;
                }
                if (set == Net.Vpc.Upa.Config.StringEncoderType.CUSTOM) {
                    throw new System.ArgumentException ("Unsupported");
                }
                switch(set) {
                    case Net.Vpc.Upa.Config.StringEncoderType.BASE64:
                        {
                            encoder = Net.Vpc.Upa.Impl.Transform.Base64Encoder.INSTANCE;
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize * 4 / 3 + 2);
                            }
                            break;
                        }
                    case Net.Vpc.Upa.Config.StringEncoderType.HEXADECIMAL:
                        {
                            encoder = Net.Vpc.Upa.Impl.Transform.HexaEncoder.INSTANCE;
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize * 2);
                            }
                            break;
                        }
                    case Net.Vpc.Upa.Config.StringEncoderType.PLAIN:
                        {
                            encoder = Net.Vpc.Upa.Impl.Transform.PlainStringEncoder.INSTANCE;
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize);
                            }
                            break;
                        }
                    case Net.Vpc.Upa.Config.StringEncoderType.XML:
                        {
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize);
                            }
                            throw new System.ArgumentException ("Unsupported yet " + set + " Encoder");
                        }
                    case Net.Vpc.Upa.Config.StringEncoderType.JSON:
                        {
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize);
                            }
                            throw new System.ArgumentException ("Unsupported yet " + set + " Encoder");
                        }
                    default:
                        {
                            throw new System.ArgumentException ("Unsupported yet " + set + " Encoder");
                        }
                }
            } else if (encoderObject is string) {
                return pu.GetFactory().CreateObject<Net.Vpc.Upa.Types.DataTypeTransform>((string) encoderObject);
            } else if (encoderObject is System.Type) {
                return (Net.Vpc.Upa.Types.DataTypeTransform) pu.GetFactory().CreateObject<Net.Vpc.Upa.Types.DataTypeTransform>((System.Type) encoderObject);
            } else {
                throw new System.ArgumentException ("Unsupported Encoder " + encoderObject);
            }
            return new Net.Vpc.Upa.Impl.Transform.StringEncoderDataTypeTransform(encoder, source, p.GetSize(), toStringEncoder);
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform CreateByteArrayEncoderTransform(Net.Vpc.Upa.PersistenceUnit pu, Net.Vpc.Upa.Types.DataType source, Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig p) {
            if (p == null) {
                p = new Net.Vpc.Upa.Types.ByteArrayEncoderTransformConfig();
            }
            int baseSize = 0;
            Net.Vpc.Upa.Types.ByteArrayEncoder enc = null;
            if (source is Net.Vpc.Upa.Types.IntType) {
                enc = Net.Vpc.Upa.Impl.Transform.IntToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.LongType) {
                enc = Net.Vpc.Upa.Impl.Transform.LongToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.DoubleType) {
                enc = Net.Vpc.Upa.Impl.Transform.DoubleToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.FloatType) {
                enc = Net.Vpc.Upa.Impl.Transform.FloatToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.StringType) {
                enc = Net.Vpc.Upa.Impl.Transform.StringToByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.ByteArrayType) {
                enc = null;
                baseSize = 255;
                Net.Vpc.Upa.Types.EnumType et = (Net.Vpc.Upa.Types.EnumType) source;
                enc = new Net.Vpc.Upa.Impl.Transform.EnumToStringByteArrayEncoder(source.GetPlatformType());
                //should we
                baseSize = 3;
                foreach (object @value in et.GetValues()) {
                    if (@value != null) {
                        int cs = (System.Convert.ToString(@value)).Length;
                        if (cs > baseSize) {
                            baseSize = cs;
                        }
                    }
                }
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
            object postEncoderObject = p.GetEncoder();
            Net.Vpc.Upa.Types.ByteArrayEncoder postEncoder = null;
            if (postEncoderObject == null) {
            } else if (postEncoderObject is string) {
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty((string) postEncoderObject)) {
                    postEncoder = pu.GetFactory().CreateObject<Net.Vpc.Upa.Types.ByteArrayEncoder>((string) postEncoderObject);
                }
            } else if (postEncoderObject is System.Type) {
                postEncoder = (Net.Vpc.Upa.Types.ByteArrayEncoder) pu.GetFactory().CreateObject<Net.Vpc.Upa.Types.ByteArrayEncoder>((System.Type) postEncoderObject);
            } else if (postEncoderObject is Net.Vpc.Upa.Types.ByteArrayEncoder) {
                postEncoder = (Net.Vpc.Upa.Types.ByteArrayEncoder) postEncoderObject;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
            if (p.GetSize() <= 0) {
                p.SetSize(baseSize);
            }
            Net.Vpc.Upa.Types.ByteArrayEncoder finalEncoder = null;
            if (enc == null) {
                finalEncoder = postEncoder;
            } else if (postEncoder == null) {
                finalEncoder = enc;
            } else {
                finalEncoder = new Net.Vpc.Upa.Impl.Transform.ChainByteArrayEncoder(enc, postEncoder);
            }
            if (finalEncoder == null) {
                finalEncoder = Net.Vpc.Upa.Impl.Transform.IdentityByteArrayEncoder.INSTANCE;
            }
            return new Net.Vpc.Upa.Impl.Transform.ByteArrayEncoderDataTypeTransform(finalEncoder, source, p.GetSize());
        }

        public virtual Net.Vpc.Upa.Types.DataTypeTransform CreateCharArrayEncoderTransform(Net.Vpc.Upa.PersistenceUnit pu, Net.Vpc.Upa.Types.DataType source, Net.Vpc.Upa.Types.CharArrayEncoderTransformConfig p) {
            if (p == null) {
                p = new Net.Vpc.Upa.Types.CharArrayEncoderTransformConfig();
            }
            Net.Vpc.Upa.Types.CharArrayEncoder preEncoder = null;
            int baseSize = 0;
            if (source is Net.Vpc.Upa.Types.IntType) {
                preEncoder = Net.Vpc.Upa.Impl.Transform.IntToStringCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.LongType) {
                preEncoder = Net.Vpc.Upa.Impl.Transform.LongToStringCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.DoubleType) {
                preEncoder = Net.Vpc.Upa.Impl.Transform.DoubleToStringCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.FloatType) {
                preEncoder = Net.Vpc.Upa.Impl.Transform.FloatToStringCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.StringType) {
                preEncoder = Net.Vpc.Upa.Impl.Transform.StringToCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.Vpc.Upa.Types.ByteArrayType) {
                preEncoder = null;
                baseSize = 255;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
            object postEncoderObject = p.GetEncoder();
            Net.Vpc.Upa.Types.CharArrayEncoder postEncoder = null;
            if (postEncoderObject == null) {
            } else if (postEncoderObject is string) {
                if (!Net.Vpc.Upa.Impl.Util.Strings.IsNullOrEmpty((string) postEncoderObject)) {
                    postEncoder = pu.GetFactory().CreateObject<Net.Vpc.Upa.Types.CharArrayEncoder>((string) postEncoderObject);
                }
            } else if (postEncoderObject is System.Type) {
                postEncoder = (Net.Vpc.Upa.Types.CharArrayEncoder) pu.GetFactory().CreateObject<Net.Vpc.Upa.Types.CharArrayEncoder>((System.Type) postEncoderObject);
            } else if (postEncoderObject is Net.Vpc.Upa.Types.ByteArrayEncoder) {
                postEncoder = (Net.Vpc.Upa.Types.CharArrayEncoder) postEncoderObject;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
            if (p.GetSize() <= 0) {
                p.SetSize(baseSize);
            }
            Net.Vpc.Upa.Types.CharArrayEncoder finalEncoder = null;
            if (preEncoder == null) {
                finalEncoder = postEncoder;
            } else if (postEncoder == null) {
                finalEncoder = preEncoder;
            } else {
                finalEncoder = new Net.Vpc.Upa.Impl.Transform.ChainCharArrayEncoder(preEncoder, postEncoder);
            }
            if (finalEncoder == null) {
                finalEncoder = Net.Vpc.Upa.Impl.Transform.IdentityCharArrayEncoder.INSTANCE;
            }
            return new Net.Vpc.Upa.Impl.Transform.CharArrayEncoderDataTypeTransform(finalEncoder, source, p.GetSize());
        }
    }
}
