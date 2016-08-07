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



namespace Net.Vpc.Upa.Impl.Eval
{


    /**
     * Created by vpc on 7/3/16.
     */
    public class DefaultQLEvaluatorRegistry : Net.Vpc.Upa.QLEvaluatorRegistry {

        private System.Collections.Generic.IDictionary<System.Type , Net.Vpc.Upa.QLTypeEvaluator> typeEvaluators = new System.Collections.Generic.Dictionary<System.Type , Net.Vpc.Upa.QLTypeEvaluator>();

        private System.Collections.Generic.IDictionary<string , Net.Vpc.Upa.QLTypeEvaluator> functionsEvaluators = new System.Collections.Generic.Dictionary<string , Net.Vpc.Upa.QLTypeEvaluator>();

        private Net.Vpc.Upa.QLTypeEvaluator nullEvaluator = new Net.Vpc.Upa.Impl.Eval.NullQLTypeEvaluator();

        private Net.Vpc.Upa.QLTypeEvaluator notFoundEvaluator = new Net.Vpc.Upa.Impl.Eval.NotFoundEvaluatorQLTypeEvaluator();

        private Net.Vpc.Upa.QLTypeEvaluator functionDispatchEvaluator;

        public DefaultQLEvaluatorRegistry() {
            functionDispatchEvaluator = new Net.Vpc.Upa.Impl.Eval.FunctionDispatchEvaluatorQLTypeEvaluator(functionsEvaluators);
            RegisterTypeEvaluator(null, nullEvaluator);
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.FunctionExpression), functionDispatchEvaluator);
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.Literal), Net.Vpc.Upa.Impl.Eval.LiteralTypeEvaluator.INSTANCE);
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.UnaryOperatorExpression), Net.Vpc.Upa.Impl.Eval.UnaryOperatorExpressionEvaluator.INSTANCE);
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.If), Net.Vpc.Upa.Impl.Eval.IfExpressionEvaluator.INSTANCE);
            RegisterTypeEvaluator(typeof(Net.Vpc.Upa.Expressions.BinaryOperatorExpression), Net.Vpc.Upa.Impl.Eval.BinaryOperatorExpressionEvaluator.INSTANCE);
            RegisterFunctionEvaluator("file_exists", Net.Vpc.Upa.Impl.Eval.Functions.FileExistsEvaluator.INSTANCE);
            RegisterFunctionEvaluator("coalesce", Net.Vpc.Upa.Impl.Eval.Functions.CoalesceEvaluator.INSTANCE);
            RegisterFunctionEvaluator("concat", Net.Vpc.Upa.Impl.Eval.Functions.ConcatEvaluator.INSTANCE);
            RegisterFunctionEvaluator("currentDate", Net.Vpc.Upa.Impl.Eval.Functions.CurrentDateEvaluator.INSTANCE);
            RegisterFunctionEvaluator("currentTime", Net.Vpc.Upa.Impl.Eval.Functions.CurrentTimeEvaluator.INSTANCE);
            RegisterFunctionEvaluator("currentTimestamp", Net.Vpc.Upa.Impl.Eval.Functions.CurrentTimestampEvaluator.INSTANCE);
            RegisterFunctionEvaluator("currentUser", Net.Vpc.Upa.Impl.Eval.Functions.CurrentUserEvaluator.INSTANCE);
            RegisterFunctionEvaluator("d2v", Net.Vpc.Upa.Impl.Eval.Functions.D2VEvaluator.INSTANCE);
            RegisterFunctionEvaluator("dateAdd", Net.Vpc.Upa.Impl.Eval.Functions.DateAddEvaluator.INSTANCE);
            RegisterFunctionEvaluator("datePart", Net.Vpc.Upa.Impl.Eval.Functions.DatePartEvaluator.INSTANCE);
            RegisterFunctionEvaluator("decode", Net.Vpc.Upa.Impl.Eval.Functions.DecodeEvaluator.INSTANCE);
            //        registerFunctionEvaluator("if", new IfEvaluator()); //already added as special evaluator
            RegisterFunctionEvaluator("i2v", Net.Vpc.Upa.Impl.Eval.Functions.D2VEvaluator.INSTANCE);
            RegisterFunctionEvaluator("sign", Net.Vpc.Upa.Impl.Eval.Functions.SignEvaluator.INSTANCE);
            RegisterFunctionEvaluator("strlen", Net.Vpc.Upa.Impl.Eval.Functions.StrLenEvaluator.INSTANCE);
        }


        public virtual void UnregisterTypeEvaluator(System.Type type) {
            typeEvaluators.Remove(type);
        }


        public virtual void UnregisterFunctionEvaluator(string name) {
            functionsEvaluators.Remove(name.ToLower());
        }

        public virtual void RegisterFunctionEvaluator(string name, Net.Vpc.Upa.QLTypeEvaluator t) {
            functionsEvaluators[name]=t;
        }

        public virtual void RegisterFunctionEvaluator(string name, Net.Vpc.Upa.Function t) {
            functionsEvaluators[name.ToLower()]=new Net.Vpc.Upa.Impl.Eval.DefaultFunctionEvaluator(t);
        }

        public virtual void RegisterTypeEvaluator(System.Type type, Net.Vpc.Upa.QLTypeEvaluator t) {
            typeEvaluators[type]=t;
        }

        public virtual Net.Vpc.Upa.QLTypeEvaluator GetTypeEvaluator(System.Type type) {
            Net.Vpc.Upa.QLTypeEvaluator y = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<System.Type,Net.Vpc.Upa.QLTypeEvaluator>(typeEvaluators,type);
            if (y != null) {
                return y;
            }
            if (type == null) {
                return nullEvaluator;
            }
            foreach (System.Collections.Generic.KeyValuePair<System.Type , Net.Vpc.Upa.QLTypeEvaluator> en in new System.Collections.Generic.HashSet<System.Collections.Generic.KeyValuePair<System.Type,Net.Vpc.Upa.QLTypeEvaluator>>(typeEvaluators)) {
                if (!System.Collections.Generic.EqualityComparer<System.Type>.Default.Equals((en).Key,null) && (en).Key.IsAssignableFrom(type)) {
                    return (en).Value;
                }
            }
            return notFoundEvaluator;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (!(o is Net.Vpc.Upa.Impl.Eval.DefaultQLEvaluatorRegistry)) return false;
            Net.Vpc.Upa.Impl.Eval.DefaultQLEvaluatorRegistry that = (Net.Vpc.Upa.Impl.Eval.DefaultQLEvaluatorRegistry) o;
            if (typeEvaluators != null ? !typeEvaluators.Equals(that.typeEvaluators) : that.typeEvaluators != null) return false;
            if (functionsEvaluators != null ? !functionsEvaluators.Equals(that.functionsEvaluators) : that.functionsEvaluators != null) return false;
            if (nullEvaluator != null ? !nullEvaluator.Equals(that.nullEvaluator) : that.nullEvaluator != null) return false;
            if (notFoundEvaluator != null ? !notFoundEvaluator.Equals(that.notFoundEvaluator) : that.notFoundEvaluator != null) return false;
            return !(functionDispatchEvaluator != null ? !functionDispatchEvaluator.Equals(that.functionDispatchEvaluator) : that.functionDispatchEvaluator != null);
        }


        public override int GetHashCode() {
            int result = typeEvaluators != null ? typeEvaluators.GetHashCode() : 0;
            result = 31 * result + (functionsEvaluators != null ? functionsEvaluators.GetHashCode() : 0);
            result = 31 * result + (nullEvaluator != null ? nullEvaluator.GetHashCode() : 0);
            result = 31 * result + (notFoundEvaluator != null ? notFoundEvaluator.GetHashCode() : 0);
            result = 31 * result + (functionDispatchEvaluator != null ? functionDispatchEvaluator.GetHashCode() : 0);
            return result;
        }
    }
}
