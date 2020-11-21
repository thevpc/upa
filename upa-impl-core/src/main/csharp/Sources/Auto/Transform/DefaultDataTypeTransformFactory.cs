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
namespace Net.TheVpc.Upa.Impl.Transform
{


    /**
     *
     * @author taha.bensalah@gmail.com
     */
    public class DefaultDataTypeTransformFactory : Net.TheVpc.Upa.Types.DataTypeTransformFactory {

        private bool IsInt(double d) {
            double d2 = (int) d;
            return d2 == d;
        }

        private Net.TheVpc.Upa.Types.DataTypeTransformConfig CreateDataTypeTransformConfig(string expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if ((expression.Trim()).Length > 0) {
                string name = null;
                System.Collections.Generic.List<string> args = new System.Collections.Generic.List<string>();
                J2CS.IO.StreamTokenizer st = new J2CS.IO.StreamTokenizer(new System.IO.StringReader(expression.Trim()));
                int tokenizer = -1;
                const int STATUS_NAME = 1;
                const int STATUS_OPEN_PAR_OR_END = 2;
                const int STATUS_ARG_OR_CLOSE_PAR = 3;
                const int STATUS_COMMA_OR_CLOSE_PAR = 4;
                const int STATUS_ARG = 5;
                const int STATUS_END = 6;
                int status = STATUS_NAME;
                bool finish = false;
                while (!finish) {
                    try {
                        tokenizer = st.NextToken();
                    } catch (System.IO.IOException ex) {
                        throw new System.Exception("Never");
                    }
                    switch(status) {
                        case STATUS_NAME:
                            {
                                switch(tokenizer) {
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
                                switch(tokenizer) {
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
                                switch(tokenizer) {
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
                                switch(tokenizer) {
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
                                switch(tokenizer) {
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
                                switch(tokenizer) {
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

        private Net.TheVpc.Upa.Types.DataTypeTransformConfig CreateDataTypeTransformConfig(string name, string[] args) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            if (name.Equals("ToByteArray",System.StringComparison.InvariantCultureIgnoreCase)) {
                Net.TheVpc.Upa.Types.StringEncoderTransformConfig c = new Net.TheVpc.Upa.Types.StringEncoderTransformConfig();
                if (args.Length == 0) {
                    return c;
                } else if (args.Length == 1) {
                    Net.TheVpc.Upa.Config.StringEncoderType t = default(Net.TheVpc.Upa.Config.StringEncoderType);
                    try {
                        t = (Net.TheVpc.Upa.Config.StringEncoderType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.Config.StringEncoderType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != default(Net.TheVpc.Upa.Config.StringEncoderType)) {
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
                Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig c = new Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig();
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
                    return new Net.TheVpc.Upa.Types.CustomTypeDataTypeTransform(args[0]);
                } else {
                    throw new System.ArgumentException ("Config: Invalid argument count");
                }
            }
            if (name.Equals("Password",System.StringComparison.InvariantCultureIgnoreCase)) {
                if (args.Length == 0) {
                    return new Net.TheVpc.Upa.PasswordTransformConfig();
                } else if (args.Length == 1) {
                    Net.TheVpc.Upa.PasswordTransformConfig c = new Net.TheVpc.Upa.PasswordTransformConfig();
                    Net.TheVpc.Upa.PasswordStrategyType t = default(Net.TheVpc.Upa.PasswordStrategyType);
                    try {
                        t = (Net.TheVpc.Upa.PasswordStrategyType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.PasswordStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != default(Net.TheVpc.Upa.PasswordStrategyType)) {
                        c.SetCipherStrategy(t);
                    } else {
                        c.SetCipherStrategy(args[0]);
                    }
                    return c;
                } else if (args.Length == 2) {
                    Net.TheVpc.Upa.PasswordTransformConfig c = new Net.TheVpc.Upa.PasswordTransformConfig();
                    Net.TheVpc.Upa.PasswordStrategyType t = default(Net.TheVpc.Upa.PasswordStrategyType);
                    try {
                        t = (Net.TheVpc.Upa.PasswordStrategyType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.PasswordStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != default(Net.TheVpc.Upa.PasswordStrategyType)) {
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
                    return new Net.TheVpc.Upa.Types.SecretTransformConfig();
                } else if (args.Length == 1) {
                    Net.TheVpc.Upa.Types.SecretTransformConfig c = new Net.TheVpc.Upa.Types.SecretTransformConfig();
                    Net.TheVpc.Upa.SecretStrategyType t = default(Net.TheVpc.Upa.SecretStrategyType);
                    try {
                        t = (Net.TheVpc.Upa.SecretStrategyType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.SecretStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != default(Net.TheVpc.Upa.SecretStrategyType)) {
                        c.SetSecretStrategy(t);
                    } else {
                        c.SetSecretStrategy(args[0]);
                    }
                    return c;
                } else if (args.Length == 2) {
                    Net.TheVpc.Upa.Types.SecretTransformConfig c = new Net.TheVpc.Upa.Types.SecretTransformConfig();
                    Net.TheVpc.Upa.SecretStrategyType t = default(Net.TheVpc.Upa.SecretStrategyType);
                    try {
                        t = (Net.TheVpc.Upa.SecretStrategyType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.SecretStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != default(Net.TheVpc.Upa.SecretStrategyType)) {
                        c.SetSecretStrategy(t);
                    } else {
                        c.SetSecretStrategy(args[0]);
                    }
                    c.SetSize(System.Convert.ToInt32(args[1]));
                    return c;
                } else if (args.Length == 3) {
                    Net.TheVpc.Upa.Types.SecretTransformConfig c = new Net.TheVpc.Upa.Types.SecretTransformConfig();
                    Net.TheVpc.Upa.SecretStrategyType t = default(Net.TheVpc.Upa.SecretStrategyType);
                    try {
                        t = (Net.TheVpc.Upa.SecretStrategyType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.SecretStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != default(Net.TheVpc.Upa.SecretStrategyType)) {
                        c.SetSecretStrategy(t);
                    } else {
                        c.SetSecretStrategy(args[0]);
                    }
                    c.SetSize(System.Convert.ToInt32(args[1]));
                    c.SetEncodeKey(args[2]);
                    c.SetDecodeKey(args[2]);
                    return c;
                } else if (args.Length == 4) {
                    Net.TheVpc.Upa.Types.SecretTransformConfig c = new Net.TheVpc.Upa.Types.SecretTransformConfig();
                    Net.TheVpc.Upa.SecretStrategyType t = default(Net.TheVpc.Upa.SecretStrategyType);
                    try {
                        t = (Net.TheVpc.Upa.SecretStrategyType)(System.Enum.Parse(typeof(Net.TheVpc.Upa.SecretStrategyType),args[0].ToUpper()));
                    } catch (System.Exception e) {
                    }
                    //
                    if (t != default(Net.TheVpc.Upa.SecretStrategyType)) {
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

        private Net.TheVpc.Upa.Types.DataTypeTransformConfig[] CreateDataTypeTransformConfigArray(string expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.List<Net.TheVpc.Upa.Types.DataTypeTransformConfig> all = new System.Collections.Generic.List<Net.TheVpc.Upa.Types.DataTypeTransformConfig>();
            if (expression != null && (expression).Length > 0) {
                foreach (string c in System.Text.RegularExpressions.Regex.Split(expression,"\\|")) {
                    Net.TheVpc.Upa.Types.DataTypeTransformConfig cc = CreateDataTypeTransformConfig(c);
                    if (cc != null) {
                        all.Add(cc);
                    }
                }
            }
            return all.ToArray();
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform CreateTypeTransform(Net.TheVpc.Upa.PersistenceUnit pu, Net.TheVpc.Upa.Types.DataType source, Net.TheVpc.Upa.Types.DataTypeTransformConfig[] configs) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Types.DataTypeTransform t = null;
            Net.TheVpc.Upa.Types.DataType s = source;
            if (configs != null) {
                foreach (Net.TheVpc.Upa.Types.DataTypeTransformConfig c in configs) {
                    if (c != null) {
                        Net.TheVpc.Upa.Types.DataTypeTransform tt = CreateTypeTransform(pu, s, c);
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

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform CreateTypeTransform(Net.TheVpc.Upa.PersistenceUnit pu, Net.TheVpc.Upa.Types.DataType source, Net.TheVpc.Upa.Types.DataTypeTransformConfig transformConfig) {
            if (transformConfig == null) {
                return null;
            }
            if (transformConfig is Net.TheVpc.Upa.Types.DataTypeTransform) {
                return (Net.TheVpc.Upa.Types.DataTypeTransform) transformConfig;
            } else if ((transformConfig is Net.TheVpc.Upa.Types.CustomExpressionDataTypeTransform)) {
                Net.TheVpc.Upa.Types.CustomExpressionDataTypeTransform c = (Net.TheVpc.Upa.Types.CustomExpressionDataTypeTransform) transformConfig;
                return CreateTypeTransform(pu, source, CreateDataTypeTransformConfigArray(c.GetExpression()));
            } else if ((transformConfig is Net.TheVpc.Upa.Types.CustomTypeDataTypeTransform)) {
                Net.TheVpc.Upa.Types.CustomTypeDataTypeTransform c = (Net.TheVpc.Upa.Types.CustomTypeDataTypeTransform) transformConfig;
                return pu.GetFactory().CreateObject<T>(c.GetCustomType());
            } else if ((transformConfig is Net.TheVpc.Upa.Types.CustomInstanceDataTypeTransform)) {
                Net.TheVpc.Upa.Types.CustomInstanceDataTypeTransform c = (Net.TheVpc.Upa.Types.CustomInstanceDataTypeTransform) transformConfig;
                Net.TheVpc.Upa.Types.DataTypeTransform i = c.GetInstance();
                return i;
            } else if (transformConfig is Net.TheVpc.Upa.PasswordTransformConfig) {
                Net.TheVpc.Upa.PasswordTransformConfig p = (Net.TheVpc.Upa.PasswordTransformConfig) transformConfig;
                return CreatePasswordTransform(pu, source, p);
            } else if (transformConfig is Net.TheVpc.Upa.Types.SecretTransformConfig) {
                Net.TheVpc.Upa.Types.SecretTransformConfig p = (Net.TheVpc.Upa.Types.SecretTransformConfig) transformConfig;
                return CreateSecretTransform(pu, source, p);
            } else if (transformConfig is Net.TheVpc.Upa.Types.StringEncoderTransformConfig) {
                Net.TheVpc.Upa.Types.StringEncoderTransformConfig p = (Net.TheVpc.Upa.Types.StringEncoderTransformConfig) transformConfig;
                return CreateStringEncoderTransform(pu, source, p);
            } else if (transformConfig is Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig) {
                Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig p = (Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig) transformConfig;
                return CreateByteArrayEncoderTransform(pu, source, p);
            } else if (transformConfig is Net.TheVpc.Upa.Types.CharArrayEncoderTransformConfig) {
                Net.TheVpc.Upa.Types.CharArrayEncoderTransformConfig p = (Net.TheVpc.Upa.Types.CharArrayEncoderTransformConfig) transformConfig;
                return CreateCharArrayEncoderTransform(pu, source, p);
            }
            throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported Transform Method", source);
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform CreatePasswordTransform(Net.TheVpc.Upa.PersistenceUnit pu, Net.TheVpc.Upa.Types.DataType source, Net.TheVpc.Upa.PasswordTransformConfig p) {
            if (p == null) {
                p = new Net.TheVpc.Upa.PasswordTransformConfig();
            }
            object s = p.GetCipherStrategy();
            if (s == null) {
                s = Net.TheVpc.Upa.PasswordStrategyType.DEFAULT;
            }
            if (s is Net.TheVpc.Upa.PasswordStrategyType) {
                switch(((Net.TheVpc.Upa.PasswordStrategyType) s)) {
                    case Net.TheVpc.Upa.PasswordStrategyType.SHA1:
                        {
                            s = Net.TheVpc.Upa.Impl.Transform.DefaultPasswordStrategy.SHA1;
                            break;
                        }
                    case Net.TheVpc.Upa.PasswordStrategyType.SHA256:
                        {
                            s = Net.TheVpc.Upa.Impl.Transform.DefaultPasswordStrategy.SHA256;
                            break;
                        }
                    case Net.TheVpc.Upa.PasswordStrategyType.MD5:
                        {
                            s = Net.TheVpc.Upa.Impl.Transform.DefaultPasswordStrategy.MD5;
                            break;
                        }
                    case Net.TheVpc.Upa.PasswordStrategyType.DEFAULT:
                        {
                            s = Net.TheVpc.Upa.Impl.Transform.DefaultPasswordStrategy.MD5;
                            break;
                        }
                    default:
                        {
                            throw new System.ArgumentException ("Unsupported CipherStrategy " + s);
                        }
                }
            } else if (s is string) {
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty((string) s)) {
                    s = (Net.TheVpc.Upa.PasswordStrategy) pu.GetFactory().CreateObject<T>((string) s);
                } else {
                    s = Net.TheVpc.Upa.Impl.Transform.DefaultPasswordStrategy.MD5;
                }
            } else if (s is System.Type) {
                s = (Net.TheVpc.Upa.PasswordStrategy) pu.GetFactory().CreateObject<object>((System.Type) s);
            } else if (s is Net.TheVpc.Upa.PasswordStrategy) {
                s = (Net.TheVpc.Upa.PasswordStrategy) s;
            } else {
                throw new System.ArgumentException ("Unsupported CipherStrategy " + s);
            }
            p.SetCipherStrategy((Net.TheVpc.Upa.PasswordStrategy) s);
            Net.TheVpc.Upa.Types.DataTypeTransform t = null;
            object cipherValue = p.GetCipherValue();
            if (!(source is Net.TheVpc.Upa.Types.StringType)) {
                t = CreateStringEncoderTransform(pu, source, null);
                Net.TheVpc.Upa.Impl.Transform.PasswordDataTypeTransform t2 = new Net.TheVpc.Upa.Impl.Transform.PasswordDataTypeTransform((Net.TheVpc.Upa.PasswordStrategy) p.GetCipherStrategy(), cipherValue, t.GetTargetType());
                return t.Chain(t2);
            }
            return new Net.TheVpc.Upa.Impl.Transform.PasswordDataTypeTransform((Net.TheVpc.Upa.PasswordStrategy) p.GetCipherStrategy(), cipherValue, source);
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform CreateSecretTransform(Net.TheVpc.Upa.PersistenceUnit pu, Net.TheVpc.Upa.Types.DataType source, Net.TheVpc.Upa.Types.SecretTransformConfig p) {
            if (p == null) {
                p = new Net.TheVpc.Upa.Types.SecretTransformConfig();
            }
            object s = p.GetSecretStrategy();
            if (s == null) {
                s = Net.TheVpc.Upa.SecretStrategyType.DEFAULT;
            }
            if (s is Net.TheVpc.Upa.SecretStrategyType) {
                switch(((Net.TheVpc.Upa.SecretStrategyType) s)) {
                    case Net.TheVpc.Upa.SecretStrategyType.BASE64:
                        {
                            s = Net.TheVpc.Upa.Impl.Transform.Base64SecretStrategy.INSTANCE;
                            break;
                        }
                    case Net.TheVpc.Upa.SecretStrategyType.DEFAULT:
                        {
                            s = new Net.TheVpc.Upa.Impl.Transform.DefaultSecretStrategy();
                            break;
                        }
                    default:
                        {
                            throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported", s);
                        }
                }
            } else if (s is string) {
                string ss = (string) s;
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty(ss)) {
                    s = (Net.TheVpc.Upa.SecretStrategy) pu.GetFactory().CreateObject<T>((string) s);
                } else {
                    //use default
                    s = new Net.TheVpc.Upa.Impl.Transform.DefaultSecretStrategy();
                }
            } else if (s is System.Type) {
                s = (Net.TheVpc.Upa.SecretStrategy) pu.GetFactory().CreateObject<object>((System.Type) s);
            } else if (s is Net.TheVpc.Upa.SecretStrategy) {
                s = (Net.TheVpc.Upa.SecretStrategy) s;
            } else {
                throw new System.ArgumentException ("Unsupported SecretStrategy " + s);
            }
            Net.TheVpc.Upa.SecretStrategy st = (Net.TheVpc.Upa.SecretStrategy) s;
            st.Init(pu, p.GetEncodeKey(), p.GetDecodeKey());
            p.SetSecretStrategy(st);
            if (!(source is Net.TheVpc.Upa.Types.ByteArrayType)) {
                Net.TheVpc.Upa.Types.DataTypeTransform t = null;
                t = CreateByteArrayEncoderTransform(pu, source, null);
                Net.TheVpc.Upa.Impl.Transform.SecretDataTypeTransform t2 = new Net.TheVpc.Upa.Impl.Transform.SecretDataTypeTransform(st, t.GetTargetType(), p.GetSize());
                return t.Chain(t2);
            }
            return new Net.TheVpc.Upa.Impl.Transform.SecretDataTypeTransform(st, source, p.GetSize());
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform CreateStringEncoderTransform(Net.TheVpc.Upa.PersistenceUnit pu, Net.TheVpc.Upa.Types.DataType source, Net.TheVpc.Upa.Types.StringEncoderTransformConfig p) {
            if (p == null) {
                p = new Net.TheVpc.Upa.Types.StringEncoderTransformConfig();
            }
            Net.TheVpc.Upa.Types.ByteArrayEncoder toStringEncoder = null;
            int baseSize = 0;
            object encoderObject = p.GetEncoder();
            if (encoderObject == null) {
                encoderObject = Net.TheVpc.Upa.Config.StringEncoderType.DEFAULT;
            }
            if (source is Net.TheVpc.Upa.Types.IntType) {
                toStringEncoder = Net.TheVpc.Upa.Impl.Transform.IntToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.LongType) {
                toStringEncoder = Net.TheVpc.Upa.Impl.Transform.LongToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.DoubleType) {
                toStringEncoder = Net.TheVpc.Upa.Impl.Transform.DoubleToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.FloatType) {
                toStringEncoder = Net.TheVpc.Upa.Impl.Transform.FloatToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.ByteArrayType) {
                toStringEncoder = Net.TheVpc.Upa.Impl.Transform.IdentityByteArrayEncoder.INSTANCE;
                baseSize = ((Net.TheVpc.Upa.Types.ByteArrayType) source).GetMaxSize() == null ? ((int)(0)) : (((Net.TheVpc.Upa.Types.ByteArrayType) source).GetMaxSize()).Value;
                if (encoderObject == Net.TheVpc.Upa.Config.StringEncoderType.DEFAULT) {
                    encoderObject = Net.TheVpc.Upa.Config.StringEncoderType.HEXADECIMAL;
                }
            } else if (source is Net.TheVpc.Upa.Types.EnumType) {
                Net.TheVpc.Upa.Types.EnumType et = (Net.TheVpc.Upa.Types.EnumType) source;
                toStringEncoder = new Net.TheVpc.Upa.Impl.Transform.EnumToStringByteArrayEncoder(source.GetPlatformType());
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
            Net.TheVpc.Upa.Types.StringEncoder encoder = null;
            if (encoderObject is Net.TheVpc.Upa.Config.StringEncoderType) {
                Net.TheVpc.Upa.Config.StringEncoderType set = (Net.TheVpc.Upa.Config.StringEncoderType) encoderObject;
                if (set == Net.TheVpc.Upa.Config.StringEncoderType.DEFAULT) {
                    set = Net.TheVpc.Upa.Config.StringEncoderType.PLAIN;
                }
                if (set == Net.TheVpc.Upa.Config.StringEncoderType.CUSTOM) {
                    throw new System.ArgumentException ("Unsupported");
                }
                switch(set) {
                    case Net.TheVpc.Upa.Config.StringEncoderType.BASE64:
                        {
                            encoder = Net.TheVpc.Upa.Impl.Transform.Base64Encoder.INSTANCE;
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize * 4 / 3 + 2);
                            }
                            break;
                        }
                    case Net.TheVpc.Upa.Config.StringEncoderType.HEXADECIMAL:
                        {
                            encoder = Net.TheVpc.Upa.Impl.Transform.HexaEncoder.INSTANCE;
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize * 2);
                            }
                            break;
                        }
                    case Net.TheVpc.Upa.Config.StringEncoderType.PLAIN:
                        {
                            encoder = Net.TheVpc.Upa.Impl.Transform.PlainStringEncoder.INSTANCE;
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize);
                            }
                            break;
                        }
                    case Net.TheVpc.Upa.Config.StringEncoderType.XML:
                        {
                            if (p.GetSize() <= 0) {
                                p.SetSize(baseSize);
                            }
                            throw new System.ArgumentException ("Unsupported yet " + set + " Encoder");
                        }
                    case Net.TheVpc.Upa.Config.StringEncoderType.JSON:
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
                return pu.GetFactory().CreateObject<T>((string) encoderObject);
            } else if (encoderObject is System.Type) {
                return (Net.TheVpc.Upa.Types.DataTypeTransform) pu.GetFactory().CreateObject<object>((System.Type) encoderObject);
            } else {
                throw new System.ArgumentException ("Unsupported Encoder " + encoderObject);
            }
            return new Net.TheVpc.Upa.Impl.Transform.StringEncoderDataTypeTransform(encoder, source, p.GetSize(), toStringEncoder);
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform CreateByteArrayEncoderTransform(Net.TheVpc.Upa.PersistenceUnit pu, Net.TheVpc.Upa.Types.DataType source, Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig p) {
            if (p == null) {
                p = new Net.TheVpc.Upa.Types.ByteArrayEncoderTransformConfig();
            }
            int baseSize = 0;
            Net.TheVpc.Upa.Types.ByteArrayEncoder enc = null;
            if (source is Net.TheVpc.Upa.Types.IntType) {
                enc = Net.TheVpc.Upa.Impl.Transform.IntToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.LongType) {
                enc = Net.TheVpc.Upa.Impl.Transform.LongToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.DoubleType) {
                enc = Net.TheVpc.Upa.Impl.Transform.DoubleToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.FloatType) {
                enc = Net.TheVpc.Upa.Impl.Transform.FloatToStringByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.StringType) {
                enc = Net.TheVpc.Upa.Impl.Transform.StringToByteArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.ByteArrayType) {
                enc = null;
                baseSize = 255;
                Net.TheVpc.Upa.Types.EnumType et = (Net.TheVpc.Upa.Types.EnumType) source;
                enc = new Net.TheVpc.Upa.Impl.Transform.EnumToStringByteArrayEncoder(source.GetPlatformType());
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
            Net.TheVpc.Upa.Types.ByteArrayEncoder postEncoder = null;
            if (postEncoderObject == null) {
            } else if (postEncoderObject is string) {
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty((string) postEncoderObject)) {
                    postEncoder = pu.GetFactory().CreateObject<T>((string) postEncoderObject);
                }
            } else if (postEncoderObject is System.Type) {
                postEncoder = (Net.TheVpc.Upa.Types.ByteArrayEncoder) pu.GetFactory().CreateObject<object>((System.Type) postEncoderObject);
            } else if (postEncoderObject is Net.TheVpc.Upa.Types.ByteArrayEncoder) {
                postEncoder = (Net.TheVpc.Upa.Types.ByteArrayEncoder) postEncoderObject;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
            if (p.GetSize() <= 0) {
                p.SetSize(baseSize);
            }
            Net.TheVpc.Upa.Types.ByteArrayEncoder finalEncoder = null;
            if (enc == null) {
                finalEncoder = postEncoder;
            } else if (postEncoder == null) {
                finalEncoder = enc;
            } else {
                finalEncoder = new Net.TheVpc.Upa.Impl.Transform.ChainByteArrayEncoder(enc, postEncoder);
            }
            if (finalEncoder == null) {
                finalEncoder = Net.TheVpc.Upa.Impl.Transform.IdentityByteArrayEncoder.INSTANCE;
            }
            return new Net.TheVpc.Upa.Impl.Transform.ByteArrayEncoderDataTypeTransform(finalEncoder, source, p.GetSize());
        }

        public virtual Net.TheVpc.Upa.Types.DataTypeTransform CreateCharArrayEncoderTransform(Net.TheVpc.Upa.PersistenceUnit pu, Net.TheVpc.Upa.Types.DataType source, Net.TheVpc.Upa.Types.CharArrayEncoderTransformConfig p) {
            if (p == null) {
                p = new Net.TheVpc.Upa.Types.CharArrayEncoderTransformConfig();
            }
            Net.TheVpc.Upa.Types.CharArrayEncoder preEncoder = null;
            int baseSize = 0;
            if (source is Net.TheVpc.Upa.Types.IntType) {
                preEncoder = Net.TheVpc.Upa.Impl.Transform.IntToStringCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.LongType) {
                preEncoder = Net.TheVpc.Upa.Impl.Transform.LongToStringCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.DoubleType) {
                preEncoder = Net.TheVpc.Upa.Impl.Transform.DoubleToStringCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.FloatType) {
                preEncoder = Net.TheVpc.Upa.Impl.Transform.FloatToStringCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.StringType) {
                preEncoder = Net.TheVpc.Upa.Impl.Transform.StringToCharArrayEncoder.INSTANCE;
                baseSize = 255;
            } else if (source is Net.TheVpc.Upa.Types.ByteArrayType) {
                preEncoder = null;
                baseSize = 255;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
            object postEncoderObject = p.GetEncoder();
            Net.TheVpc.Upa.Types.CharArrayEncoder postEncoder = null;
            if (postEncoderObject == null) {
            } else if (postEncoderObject is string) {
                if (!Net.TheVpc.Upa.Impl.Util.StringUtils.IsNullOrEmpty((string) postEncoderObject)) {
                    postEncoder = pu.GetFactory().CreateObject<T>((string) postEncoderObject);
                }
            } else if (postEncoderObject is System.Type) {
                postEncoder = (Net.TheVpc.Upa.Types.CharArrayEncoder) pu.GetFactory().CreateObject<object>((System.Type) postEncoderObject);
            } else if (postEncoderObject is Net.TheVpc.Upa.Types.ByteArrayEncoder) {
                postEncoder = (Net.TheVpc.Upa.Types.CharArrayEncoder) postEncoderObject;
            } else {
                throw new System.ArgumentException ("Unsupported");
            }
            if (p.GetSize() <= 0) {
                p.SetSize(baseSize);
            }
            Net.TheVpc.Upa.Types.CharArrayEncoder finalEncoder = null;
            if (preEncoder == null) {
                finalEncoder = postEncoder;
            } else if (postEncoder == null) {
                finalEncoder = preEncoder;
            } else {
                finalEncoder = new Net.TheVpc.Upa.Impl.Transform.ChainCharArrayEncoder(preEncoder, postEncoder);
            }
            if (finalEncoder == null) {
                finalEncoder = Net.TheVpc.Upa.Impl.Transform.IdentityCharArrayEncoder.INSTANCE;
            }
            return new Net.TheVpc.Upa.Impl.Transform.CharArrayEncoderDataTypeTransform(finalEncoder, source, p.GetSize());
        }
    }
}
