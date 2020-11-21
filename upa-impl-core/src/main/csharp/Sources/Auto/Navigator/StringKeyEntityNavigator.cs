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



namespace Net.TheVpc.Upa.Impl.Navigator
{


    public class StringKeyEntityNavigator : Net.TheVpc.Upa.Impl.Navigator.DefaultEntityNavigator {

        internal int synchNbrTry = 25;

        internal int asynchNbrTry = 25;

        public StringKeyEntityNavigator(Net.TheVpc.Upa.Entity entity)  : base(entity){

        }


        public override object GetNewKey() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.IList<Net.TheVpc.Upa.Field> primaryFields = entity.GetPrimaryFields();
            if ((primaryFields).Count == 1) {
                return entity.CreateId(GetNewValue(primaryFields[0]));
            }
            throw new Net.TheVpc.Upa.Exceptions.UPAException("Unsupported number of Primary Keys for StringKeyEntityNavigator");
        }

        public virtual string GetNewValue(Net.TheVpc.Upa.Field field) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            Net.TheVpc.Upa.Entity entity = field.GetEntity();
            string idName = field.GetName();
            string goodId = null;
            for (int i = 0; i < asynchNbrTry; i++) {
                System.Collections.Generic.SortedSet<string> requestedIds = new System.Collections.Generic.SortedSet<string>();
                Net.TheVpc.Upa.Expressions.InCollection idsSet = new Net.TheVpc.Upa.Expressions.InCollection(new Net.TheVpc.Upa.Expressions.Var(idName));
                for (int j = 0; j < synchNbrTry; j++) {
                    string id = (string) GenerateValue(field);
                    idsSet.Add(new Net.TheVpc.Upa.Expressions.Literal(id));
                    requestedIds.Add(id);
                }
                System.Collections.Generic.IList<Net.TheVpc.Upa.Record> recordList = entity.CreateQuery((new Net.TheVpc.Upa.Expressions.Select()).From(entity.GetName()).Field(new Net.TheVpc.Upa.Expressions.Var(idName)).Where(idsSet)).GetRecordList();
                System.Collections.Generic.SortedSet<string> foundIds = new System.Collections.Generic.SortedSet<string>();
                foreach (Net.TheVpc.Upa.Record record in recordList) {
                    foundIds.Add(record.GetString());
                }
                Net.TheVpc.Upa.Impl.FwkConvertUtils.SetRemoveRange(requestedIds, foundIds);
                if ((requestedIds.Count==0)) {
                    continue;
                }
                goodId = Net.TheVpc.Upa.Impl.FwkConvertUtils.CollectionSetFirst<string>(requestedIds);
                break;
            }
            return goodId;
        }

        protected internal virtual object GenerateValue(Net.TheVpc.Upa.Field field) {
            try {
                Net.TheVpc.Upa.Types.StringType dataType = (Net.TheVpc.Upa.Types.StringType) field.GetDataType();
                string goodChars = null;
                foreach (Net.TheVpc.Upa.Types.TypeValueValidator valueValidator in dataType.GetValueValidators()) {
                    if (valueValidator is Net.TheVpc.Upa.Types.StringTypeCharValidator) {
                        Net.TheVpc.Upa.Types.StringTypeCharValidator s = (Net.TheVpc.Upa.Types.StringTypeCharValidator) valueValidator;
                        if (s.IsPositive()) {
                            goodChars = s.GetChars();
                            break;
                        }
                    }
                }
                if (goodChars == null) {
                    goodChars = Net.TheVpc.Upa.Impl.Util.IdentifierUtils.ALPHA_NUM_CHARS;
                }
                //prefer alphabetic at start
                //prefer alphanumeric at end
                //prefer no successive ponctuation
                // if too match difiicult (>100) do any thing
                System.Text.StringBuilder alpha = new System.Text.StringBuilder();
                System.Text.StringBuilder num = new System.Text.StringBuilder();
                System.Text.StringBuilder ponct = new System.Text.StringBuilder();
                for (int i = 0; i < (goodChars).Length; i++) {
                    char c = goodChars[i];
                    if (char.IsLetter(c)) {
                        alpha.Append(c);
                    } else if (char.IsDigit(c)) {
                        num.Append(c);
                    } else {
                        ponct.Append(c);
                    }
                }
                for (int i = 0; i < 100; i++) {
                    string k = Net.TheVpc.Upa.Impl.Util.IdentifierUtils.GenerateID(dataType.GetMin(), dataType.GetMax(), alpha.ToString(), goodChars, alpha.ToString() + num.ToString());
                    bool ok = true;
                    for (int j = 1; j < (k).Length - 2; j++) {
                        if (ponct.ToString().IndexOf(k[j]) >= 0 && ponct.ToString().IndexOf(k[j + 1]) >= 0) {
                            ok = false;
                            break;
                        }
                    }
                    if (ok) {
                        return k;
                    }
                }
                return Net.TheVpc.Upa.Impl.Util.IdentifierUtils.GenerateID(dataType.GetMin(), dataType.GetMax(), goodChars, goodChars, goodChars);
            } catch (Net.TheVpc.Upa.Types.ConstraintsException e) {
                return null;
            }
        }
    }
}
