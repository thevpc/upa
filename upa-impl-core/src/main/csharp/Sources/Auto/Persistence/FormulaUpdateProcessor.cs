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



namespace Net.TheVpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FormulaUpdateProcessor {

        internal bool nothingToValidate = false;

        internal bool forceExpressionTypeCasting = false;

        private System.Collections.Generic.IDictionary<int? , Net.TheVpc.Upa.Impl.Persistence.ValidationPass[]> orderedPasses = new System.Collections.Generic.Dictionary<int? , Net.TheVpc.Upa.Impl.Persistence.ValidationPass[]>(1);

        private System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> inUseFields = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.Field>();

        private int size = 0;

        private Net.TheVpc.Upa.Persistence.EntityOperationManager entityOperationManager;

        private Net.TheVpc.Upa.PersistenceUnit persistenceUnit;

        private Net.TheVpc.Upa.Entity entity;

        private bool onPersist;

        private Net.TheVpc.Upa.Expressions.Expression expr;

        private Net.TheVpc.Upa.Persistence.EntityExecutionContext context;

        private System.Collections.Generic.IList<object> keysToUpdate = null;

        internal bool isUpdateComplexValuesStatementSupported;

        internal bool isUpdateComplexValuesIncludingUpdatedTableSupported;

        public FormulaUpdateProcessor(bool onPersist, System.Collections.Generic.IList<Net.TheVpc.Upa.Field> fields, Net.TheVpc.Upa.Expressions.Expression expr, Net.TheVpc.Upa.Persistence.EntityExecutionContext context, Net.TheVpc.Upa.Entity entity, Net.TheVpc.Upa.Persistence.EntityOperationManager epm) {
            this.entityOperationManager = epm;
            this.entity = entity;
            this.expr = expr;
            this.context = context;
            this.onPersist = onPersist;
            this.persistenceUnit = entity.GetPersistenceUnit();
            foreach (Net.TheVpc.Upa.Field field in fields) {
                AddField(field);
            }
            isUpdateComplexValuesStatementSupported = persistenceUnit.GetPersistenceStore().GetProperties().GetBoolean("isUpdateComplexValuesStatementSupported", false);
            isUpdateComplexValuesIncludingUpdatedTableSupported = persistenceUnit.GetPersistenceStore().GetProperties().GetBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
        }

        private static Net.TheVpc.Upa.Expressions.Expression GetFieldExpression(Net.TheVpc.Upa.Field field, bool forPersist) {
            if (forPersist) {
                return (field.GetPersistFormula() is Net.TheVpc.Upa.ExpressionFormula) ? ((Net.TheVpc.Upa.ExpressionFormula) field.GetPersistFormula()).GetExpression() : null;
            } else {
                return (field.GetUpdateFormula() is Net.TheVpc.Upa.ExpressionFormula) ? ((Net.TheVpc.Upa.ExpressionFormula) field.GetUpdateFormula()).GetExpression() : null;
            }
        }

        public virtual bool AddField(Net.TheVpc.Upa.Field f) {
            if (inUseFields.Contains(f)) {
                return false;
            }
            Net.TheVpc.Upa.Formula formula = onPersist ? f.GetPersistFormula() : f.GetUpdateFormula();
            Net.TheVpc.Upa.Impl.Persistence.ValidationPass pass = null;
            int formulaPassInteger = onPersist ? f.GetPersistFormulaOrder() : f.GetUpdateFormulaOrder();
            // passIndexes.add(formulaPassInteger);
            Net.TheVpc.Upa.Impl.Persistence.ValidationPass[] passArray = Net.TheVpc.Upa.Impl.FwkConvertUtils.GetMapValue<int?,Net.TheVpc.Upa.Impl.Persistence.ValidationPass[]>(orderedPasses,formulaPassInteger);
            if (passArray == null) {
                orderedPasses[formulaPassInteger]=passArray = new Net.TheVpc.Upa.Impl.Persistence.ValidationPass[((Net.TheVpc.Upa.Impl.Persistence.ValidationPassType[])System.Enum.GetValues(typeof(Net.TheVpc.Upa.Impl.Persistence.ValidationPassType))).Length];
            }
            int pass1 = formulaPassInteger;
            if (formula is Net.TheVpc.Upa.CustomUpdaterFormula) {
                pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.MANUAL_VALIDATION)];
                if (pass == null) {
                    pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.MANUAL_VALIDATION)] = new Net.TheVpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.MANUAL_VALIDATION);
                    size++;
                }
            } else if (formula is Net.TheVpc.Upa.CustomFormula) {
                pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.CUSTOM_VALIDATION)];
                if (pass == null) {
                    pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.CUSTOM_VALIDATION)] = new Net.TheVpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.CUSTOM_VALIDATION);
                    size++;
                }
            } else if (!entityOperationManager.GetPersistenceStore().IsComplexSelectSupported()) {
                Net.TheVpc.Upa.Expressions.Expression fe = GetFieldExpression(f, onPersist);
                Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ce = (Net.TheVpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) entity.Compile(fe);
                bool found = ce.FindFirstExpression<T>(Net.TheVpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.QUERY_STATEMENT_FILTER) != default(T);
                if (found) {
                    pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.ITERATIVE_VALIDATION)];
                    if (pass == null) {
                        pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.ITERATIVE_VALIDATION)] = new Net.TheVpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.ITERATIVE_VALIDATION);
                        size++;
                    }
                } else {
                    pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION)];
                    if (pass == null) {
                        pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION)] = new Net.TheVpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION);
                        size++;
                    }
                }
            } else {
                pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION)];
                if (pass == null) {
                    pass = passArray[((int)Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION)] = new Net.TheVpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION);
                    size++;
                }
            }
            pass.GetFields().Add(f);
            inUseFields.Add(f);
            System.Collections.Generic.ICollection<Net.TheVpc.Upa.PrimitiveField> dependency = (System.Collections.Generic.ICollection<Net.TheVpc.Upa.PrimitiveField>) f.GetProperties().GetObject<T>(onPersist ? Net.TheVpc.Upa.Impl.DefaultEntity.PERSIST_DEPENDENT_FIELDS : Net.TheVpc.Upa.Impl.DefaultEntity.UPDATE_DEPENDENT_FIELDS);
            if (dependency != null) {
                foreach (Net.TheVpc.Upa.PrimitiveField aDependency in dependency) {
                    Net.TheVpc.Upa.PrimitiveField df = (Net.TheVpc.Upa.PrimitiveField) aDependency;
                    //include only dependent fields from the same entity
                    if (df.GetEntity().GetName().Equals(f.GetEntity().GetName())) {
                        // add only formulas fields that are validateSupported
                        if (onPersist) {
                            Net.TheVpc.Upa.Formula ff = df.GetPersistFormula();
                            if (ff != null && df.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.PERSIST_FORMULA)) {
                                AddField(df);
                            }
                        } else {
                            Net.TheVpc.Upa.Formula ff = df.GetUpdateFormula();
                            if (ff != null && df.GetModifiers().Contains(Net.TheVpc.Upa.FieldModifier.UPDATE_FORMULA)) {
                                AddField(df);
                            }
                        }
                    }
                }
            }
            return true;
        }

        public virtual int Size() {
            return size;
        }

        public virtual int Size0() {
            System.Collections.Generic.SortedSet<Net.TheVpc.Upa.Impl.Persistence.ValidationPass> ts = new System.Collections.Generic.SortedSet<Net.TheVpc.Upa.Impl.Persistence.ValidationPass>();
            foreach (Net.TheVpc.Upa.Impl.Persistence.ValidationPass[] o in (orderedPasses).Values) {
                for (int i = 0; i < 4; i++) {
                    if (o[i] != null) {
                        ts.Add(o[i]);
                    }
                }
            }
            return (ts).Count;
        }

        public virtual System.Collections.Generic.ICollection<Net.TheVpc.Upa.Impl.Persistence.ValidationPass> GetValidationPasses() {
            System.Collections.Generic.SortedSet<Net.TheVpc.Upa.Impl.Persistence.ValidationPass> ts = new System.Collections.Generic.SortedSet<Net.TheVpc.Upa.Impl.Persistence.ValidationPass>();
            foreach (Net.TheVpc.Upa.Impl.Persistence.ValidationPass[] o in (orderedPasses).Values) {
                for (int i = 0; i < 4; i++) {
                    if (o[i] != null) {
                        ts.Add(o[i]);
                    }
                }
            }
            return ts;
        }

        public virtual long UpdateFormulasCore() /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //        Object transaction = getPersistenceUnit().getPersistenceStore().getConnection().tryBeginTransaction();
            //        boolean transactionSucceeded = false;
            //        try {
            keysToUpdate = null;
            //            if (monitor != null) {
            //                if (monitor.isStopped()) {
            //                    return;
            //                }
            //                monitor.setIndeterminate(false);
            //                monitor.setIndex(0);
            //                monitor.setMax(data.size0());
            //                System.out.println("Validate " + getName() + " : max = "
            //                        + monitor.getMax());
            //            }
            int allUpdates = 0;
            foreach (Net.TheVpc.Upa.Impl.Persistence.ValidationPass validationPass in GetValidationPasses()) {
                int updates = 0;
                switch(validationPass.GetType()) {
                    case Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION:
                        {
                            updates = ValidateDefault(validationPass.GetFields(), expr);
                            break;
                        }
                    case Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.ITERATIVE_VALIDATION:
                        {
                            updates = ValidateDefaultIterative(validationPass.GetFields(), expr);
                            break;
                        }
                    case Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.CUSTOM_VALIDATION:
                        {
                            updates = ValidateCustomFormula(validationPass.GetFields());
                            break;
                        }
                    case Net.TheVpc.Upa.Impl.Persistence.ValidationPassType.MANUAL_VALIDATION:
                        {
                            // System.out.println("MANUAL_VALIDATION = " +
                            // validationPass.pass+" : "+validationPass.fields);
                            updates = ValidateCustomUpdaterFormula(validationPass.GetFields());
                            //                        if (monitor != null) {
                            //                            if (monitor.isStopped()) {
                            //                                return;
                            //                            }
                            //                            monitor.progress(String.valueOf(validationPass.pass),
                            //                                    "Passe " + (validationPass.pass + 1), null);
                            //                        }
                            break;
                        }
                }
                allUpdates += updates;
                if (updates == 0) {
                    break;
                }
            }
            return allUpdates;
        }

        protected internal virtual int ValidateCustomUpdaterFormula(System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<Net.TheVpc.Upa.CustomUpdaterFormula> unique = new System.Collections.Generic.HashSet<Net.TheVpc.Upa.CustomUpdaterFormula>();
            foreach (Net.TheVpc.Upa.Field field in fields) {
                Net.TheVpc.Upa.CustomUpdaterFormula c = (Net.TheVpc.Upa.CustomUpdaterFormula) (onPersist ? field.GetPersistFormula() : field.GetUpdateFormula());
                unique.Add(c);
            }
            foreach (Net.TheVpc.Upa.CustomUpdaterFormula f in unique) {
                f.UpdateFormula(fields, expr, context);
            }
            return (int) entity.GetEntityCount(expr);
        }

        protected internal virtual int ValidateCustomFormula(System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> fields) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //                        if (monitor != null) {
            //                            if (monitor.isStopped()) {
            //                                return;
            //                            }
            //                            monitor.stepIn(keysToUpdate.size());
            //                        }
            int x = 0;
            foreach (object aKeysToUpdate in GetKeysToUpdate()) {
                //                            if (monitor != null) {
                //                                if (monitor.isStopped()) {
                //                                    return;
                //                                }
                //                                monitor.progress(String.valueOf(validationPass.pass), "Passe "
                //                                        + (validationPass.pass + 1), null);
                //                            }
                // System.out.println("ITERATIVE_VALIDATION = " +
                // validationPass.pass+" : "+validationPass.fields+" :
                // "+keysToUpdate[r]);
                Net.TheVpc.Upa.Record u = entity.GetBuilder().CreateRecord();
                foreach (Net.TheVpc.Upa.Field field in fields) {
                    Net.TheVpc.Upa.CustomFormula cf = (Net.TheVpc.Upa.CustomFormula) (onPersist ? field.GetPersistFormula() : field.GetUpdateFormula());
                    object v = cf.GetValue(field, aKeysToUpdate, context);
                    u.SetObject(field.GetName(), new Net.TheVpc.Upa.Expressions.Cast(new Net.TheVpc.Upa.Expressions.Param(null, v), field.GetDataType()));
                }
                x += entity.UpdateCore(u, entity.GetBuilder().IdToExpression(aKeysToUpdate, entity.GetName()), context);
            }
            //                        if (monitor != null) {
            //                            monitor.stepOut();
            //                        }
            return x;
        }

        private System.Collections.Generic.IList<object> GetKeysToUpdate() {
            if (keysToUpdate == null) {
                keysToUpdate = entity.CreateQueryBuilder().ByExpression(expr).OrderBy(entity.GetUpdateFormulasOrder()).GetIdList<K>();
                if ((keysToUpdate.Count==0)) {
                    nothingToValidate = true;
                }
            }
            return keysToUpdate;
        }

        protected internal virtual int ValidateDefaultIterative(System.Collections.Generic.ISet<Net.TheVpc.Upa.Field> fields, Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            //                        if (monitor != null) {
            //                            if (monitor.isStopped()) {
            //                                return;
            //                            }
            //                            monitor.stepIn(keysToUpdate.size());
            //                        }
            int x = 0;
            foreach (object aKeysToUpdate in GetKeysToUpdate()) {
                //                            if (monitor != null) {
                //                                if (monitor.isStopped()) {
                //                                    return;
                //                                }
                //                                monitor.progress(String.valueOf(validationPass.pass), "Passe "
                //                                        + (validationPass.pass + 1), null);
                //                            }
                // System.out.println("ITERATIVE_VALIDATION = " +
                // validationPass.pass+" : "+validationPass.fields+" :
                // "+keysToUpdate[r]);
                x += ValidateDefault(fields, entity.GetBuilder().IdToExpression(aKeysToUpdate, entity.GetName()));
            }
            //                        if (monitor != null) {
            //                            monitor.stepOut();
            //                        }
            return x;
        }

        protected internal virtual int ValidateDefault(System.Collections.Generic.ICollection<Net.TheVpc.Upa.Field> fields, Net.TheVpc.Upa.Expressions.Expression expression) /* throws Net.TheVpc.Upa.Exceptions.UPAException */  {
            // System.out.println("DEFAULT_VALIDATION = " +
            // validationPass.pass+" : "+ validationPass.fields);
            Net.TheVpc.Upa.Record u = entity.GetBuilder().CreateRecord();
            foreach (Net.TheVpc.Upa.Field field in fields) {
                Net.TheVpc.Upa.Expressions.Expression fieldExpression = GetFieldExpression(field, onPersist);
                Net.TheVpc.Upa.Expressions.Expression validExpression = fieldExpression;
                if (forceExpressionTypeCasting || (fieldExpression is Net.TheVpc.Upa.Expressions.Literal && ((Net.TheVpc.Upa.Expressions.Literal) fieldExpression).GetValue() == null)) {
                    validExpression = new Net.TheVpc.Upa.Expressions.Cast(fieldExpression, field.GetDataType());
                }
                u.SetObject(field.GetName(), validExpression);
            }
            try {
                return entity.UpdateCore(u, expression, context);
            } catch (Net.TheVpc.Upa.Exceptions.UPAException ex) {
                //            Log.bug(ex);
                //            Select sb0 = new Select();
                //            for (Field f : fields) {
                //                Expression fieldExpression = getFieldExpression(f, onPersist);
                //                sb0.field(fieldExpression, f.getName() + "Expression");
                //                Expression validExpression = fieldExpression;
                //                if (forceExpressionTypeCasting || (fieldExpression instanceof Literal && ((Literal) fieldExpression).getValue() == null)) {
                //                    validExpression = new Cast(fieldExpression, f.getDataType());
                //                }
                //                sb0.field(validExpression, f.getName() + "CastExpression");
                //            }
                //            sb0.from(entity.getName());
                //            sb0.setWhere(expression);
                //
                ////            Log.bug("Values to update are : ");
                //            for (Record ur : entity.createQuery(sb0).getRecordList()) {
                //                for (Map.Entry<String, Object> entry : ur.toMap().entrySet()) {
                //                    //Log.bug(entry.getKey() + " : " + entry.getValue());
                //                }
                //            }
                throw ex;
            }
        }
    }
}
