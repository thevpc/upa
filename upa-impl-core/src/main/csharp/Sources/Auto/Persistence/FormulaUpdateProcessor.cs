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



namespace Net.Vpc.Upa.Impl.Persistence
{


    /**
     * @author Taha BEN SALAH <taha.bensalah@gmail.com>
     */
    public class FormulaUpdateProcessor {

        internal bool nothingToValidate = false;

        internal bool forceExpressionTypeCasting = false;

        private System.Collections.Generic.IDictionary<int? , Net.Vpc.Upa.Impl.Persistence.ValidationPass[]> orderedPasses = new System.Collections.Generic.Dictionary<int? , Net.Vpc.Upa.Impl.Persistence.ValidationPass[]>(1);

        private System.Collections.Generic.ISet<Net.Vpc.Upa.Field> inUseFields = new System.Collections.Generic.HashSet<Net.Vpc.Upa.Field>();

        private int size = 0;

        private Net.Vpc.Upa.Persistence.EntityOperationManager entityOperationManager;

        private Net.Vpc.Upa.PersistenceUnit persistenceUnit;

        private Net.Vpc.Upa.Entity entity;

        private bool onPersist;

        private Net.Vpc.Upa.Expressions.Expression expr;

        private Net.Vpc.Upa.Persistence.EntityExecutionContext context;

        private System.Collections.Generic.IList<object> keysToUpdate = null;

        internal bool isUpdateComplexValuesStatementSupported;

        internal bool isUpdateComplexValuesIncludingUpdatedTableSupported;

        public FormulaUpdateProcessor(bool onPersist, System.Collections.Generic.IList<Net.Vpc.Upa.Field> fields, Net.Vpc.Upa.Expressions.Expression expr, Net.Vpc.Upa.Persistence.EntityExecutionContext context, Net.Vpc.Upa.Entity entity, Net.Vpc.Upa.Persistence.EntityOperationManager epm) {
            this.entityOperationManager = epm;
            this.entity = entity;
            this.expr = expr;
            this.context = context;
            this.onPersist = onPersist;
            this.persistenceUnit = entity.GetPersistenceUnit();
            foreach (Net.Vpc.Upa.Field field in fields) {
                AddField(field);
            }
            isUpdateComplexValuesStatementSupported = persistenceUnit.GetPersistenceStore().GetProperties().GetBoolean("isUpdateComplexValuesStatementSupported", false);
            isUpdateComplexValuesIncludingUpdatedTableSupported = persistenceUnit.GetPersistenceStore().GetProperties().GetBoolean("isUpdateComplexValuesIncludingUpdatedTableSupported", false);
        }

        private static Net.Vpc.Upa.Expressions.Expression GetFieldExpression(Net.Vpc.Upa.Field field, bool forPersist) {
            if (forPersist) {
                return (field.GetPersistFormula() is Net.Vpc.Upa.ExpressionFormula) ? ((Net.Vpc.Upa.ExpressionFormula) field.GetPersistFormula()).GetExpression() : null;
            } else {
                return (field.GetUpdateFormula() is Net.Vpc.Upa.ExpressionFormula) ? ((Net.Vpc.Upa.ExpressionFormula) field.GetUpdateFormula()).GetExpression() : null;
            }
        }

        public virtual bool AddField(Net.Vpc.Upa.Field f) {
            if (inUseFields.Contains(f)) {
                return false;
            }
            Net.Vpc.Upa.Formula formula = onPersist ? f.GetPersistFormula() : f.GetUpdateFormula();
            Net.Vpc.Upa.Impl.Persistence.ValidationPass pass = null;
            int formulaPassInteger = onPersist ? f.GetPersistFormulaOrder() : f.GetUpdateFormulaOrder();
            // passIndexes.add(formulaPassInteger);
            Net.Vpc.Upa.Impl.Persistence.ValidationPass[] passArray = Net.Vpc.Upa.Impl.FwkConvertUtils.GetMapValue<int?,Net.Vpc.Upa.Impl.Persistence.ValidationPass[]>(orderedPasses,formulaPassInteger);
            if (passArray == null) {
                orderedPasses[formulaPassInteger]=passArray = new Net.Vpc.Upa.Impl.Persistence.ValidationPass[((Net.Vpc.Upa.Impl.Persistence.ValidationPassType[])System.Enum.GetValues(typeof(Net.Vpc.Upa.Impl.Persistence.ValidationPassType))).Length];
            }
            int pass1 = formulaPassInteger;
            if (formula is Net.Vpc.Upa.CustomUpdaterFormula) {
                pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.MANUAL_VALIDATION)];
                if (pass == null) {
                    pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.MANUAL_VALIDATION)] = new Net.Vpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.Vpc.Upa.Impl.Persistence.ValidationPassType.MANUAL_VALIDATION);
                    size++;
                }
            } else if (formula is Net.Vpc.Upa.CustomFormula) {
                pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.CUSTOM_VALIDATION)];
                if (pass == null) {
                    pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.CUSTOM_VALIDATION)] = new Net.Vpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.Vpc.Upa.Impl.Persistence.ValidationPassType.CUSTOM_VALIDATION);
                    size++;
                }
            } else if (!entityOperationManager.GetPersistenceStore().IsComplexSelectSupported()) {
                Net.Vpc.Upa.Expressions.Expression fe = GetFieldExpression(f, onPersist);
                Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression ce = (Net.Vpc.Upa.Impl.Uql.Compiledexpression.DefaultCompiledExpression) entity.Compile(fe);
                bool found = ce.FindFirstExpression<T>(Net.Vpc.Upa.Impl.Uql.Compiledfilters.CompiledExpressionHelper.QUERY_STATEMENT_FILTER) != default(T);
                if (found) {
                    pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.ITERATIVE_VALIDATION)];
                    if (pass == null) {
                        pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.ITERATIVE_VALIDATION)] = new Net.Vpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.Vpc.Upa.Impl.Persistence.ValidationPassType.ITERATIVE_VALIDATION);
                        size++;
                    }
                } else {
                    pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION)];
                    if (pass == null) {
                        pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION)] = new Net.Vpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.Vpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION);
                        size++;
                    }
                }
            } else {
                pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION)];
                if (pass == null) {
                    pass = passArray[((int)Net.Vpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION)] = new Net.Vpc.Upa.Impl.Persistence.ValidationPass(pass1, Net.Vpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION);
                    size++;
                }
            }
            pass.GetFields().Add(f);
            inUseFields.Add(f);
            System.Collections.Generic.ICollection<Net.Vpc.Upa.PrimitiveField> dependency = (System.Collections.Generic.ICollection<Net.Vpc.Upa.PrimitiveField>) f.GetProperties().GetObject<T>(onPersist ? Net.Vpc.Upa.Impl.DefaultEntity.PERSIST_DEPENDENT_FIELDS : Net.Vpc.Upa.Impl.DefaultEntity.UPDATE_DEPENDENT_FIELDS);
            if (dependency != null) {
                foreach (Net.Vpc.Upa.PrimitiveField aDependency in dependency) {
                    Net.Vpc.Upa.PrimitiveField df = (Net.Vpc.Upa.PrimitiveField) aDependency;
                    //include only dependent fields from the same entity
                    if (df.GetEntity().GetName().Equals(f.GetEntity().GetName())) {
                        // add only formulas fields that are validateSupported
                        if (onPersist) {
                            Net.Vpc.Upa.Formula ff = df.GetPersistFormula();
                            if (ff != null && df.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.PERSIST_FORMULA)) {
                                AddField(df);
                            }
                        } else {
                            Net.Vpc.Upa.Formula ff = df.GetUpdateFormula();
                            if (ff != null && df.GetModifiers().Contains(Net.Vpc.Upa.FieldModifier.UPDATE_FORMULA)) {
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
            System.Collections.Generic.SortedSet<Net.Vpc.Upa.Impl.Persistence.ValidationPass> ts = new System.Collections.Generic.SortedSet<Net.Vpc.Upa.Impl.Persistence.ValidationPass>();
            foreach (Net.Vpc.Upa.Impl.Persistence.ValidationPass[] o in (orderedPasses).Values) {
                for (int i = 0; i < 4; i++) {
                    if (o[i] != null) {
                        ts.Add(o[i]);
                    }
                }
            }
            return (ts).Count;
        }

        public virtual System.Collections.Generic.ICollection<Net.Vpc.Upa.Impl.Persistence.ValidationPass> GetValidationPasses() {
            System.Collections.Generic.SortedSet<Net.Vpc.Upa.Impl.Persistence.ValidationPass> ts = new System.Collections.Generic.SortedSet<Net.Vpc.Upa.Impl.Persistence.ValidationPass>();
            foreach (Net.Vpc.Upa.Impl.Persistence.ValidationPass[] o in (orderedPasses).Values) {
                for (int i = 0; i < 4; i++) {
                    if (o[i] != null) {
                        ts.Add(o[i]);
                    }
                }
            }
            return ts;
        }

        public virtual long UpdateFormulasCore() /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
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
            foreach (Net.Vpc.Upa.Impl.Persistence.ValidationPass validationPass in GetValidationPasses()) {
                int updates = 0;
                switch(validationPass.GetType()) {
                    case Net.Vpc.Upa.Impl.Persistence.ValidationPassType.DEFAULT_VALIDATION:
                        {
                            updates = ValidateDefault(validationPass.GetFields(), expr);
                            break;
                        }
                    case Net.Vpc.Upa.Impl.Persistence.ValidationPassType.ITERATIVE_VALIDATION:
                        {
                            updates = ValidateDefaultIterative(validationPass.GetFields(), expr);
                            break;
                        }
                    case Net.Vpc.Upa.Impl.Persistence.ValidationPassType.CUSTOM_VALIDATION:
                        {
                            updates = ValidateCustomFormula(validationPass.GetFields());
                            break;
                        }
                    case Net.Vpc.Upa.Impl.Persistence.ValidationPassType.MANUAL_VALIDATION:
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

        protected internal virtual int ValidateCustomUpdaterFormula(System.Collections.Generic.ISet<Net.Vpc.Upa.Field> fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            System.Collections.Generic.HashSet<Net.Vpc.Upa.CustomUpdaterFormula> unique = new System.Collections.Generic.HashSet<Net.Vpc.Upa.CustomUpdaterFormula>();
            foreach (Net.Vpc.Upa.Field field in fields) {
                Net.Vpc.Upa.CustomUpdaterFormula c = (Net.Vpc.Upa.CustomUpdaterFormula) (onPersist ? field.GetPersistFormula() : field.GetUpdateFormula());
                unique.Add(c);
            }
            foreach (Net.Vpc.Upa.CustomUpdaterFormula f in unique) {
                f.UpdateFormula(fields, expr, context);
            }
            return (int) entity.GetEntityCount(expr);
        }

        protected internal virtual int ValidateCustomFormula(System.Collections.Generic.ISet<Net.Vpc.Upa.Field> fields) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
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
                Net.Vpc.Upa.Record u = entity.GetBuilder().CreateRecord();
                foreach (Net.Vpc.Upa.Field field in fields) {
                    Net.Vpc.Upa.CustomFormula cf = (Net.Vpc.Upa.CustomFormula) (onPersist ? field.GetPersistFormula() : field.GetUpdateFormula());
                    object v = cf.GetValue(field, aKeysToUpdate, context);
                    u.SetObject(field.GetName(), new Net.Vpc.Upa.Expressions.Cast(new Net.Vpc.Upa.Expressions.Param(null, v), field.GetDataType()));
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

        protected internal virtual int ValidateDefaultIterative(System.Collections.Generic.ISet<Net.Vpc.Upa.Field> fields, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
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

        protected internal virtual int ValidateDefault(System.Collections.Generic.ICollection<Net.Vpc.Upa.Field> fields, Net.Vpc.Upa.Expressions.Expression expression) /* throws Net.Vpc.Upa.Exceptions.UPAException */  {
            // System.out.println("DEFAULT_VALIDATION = " +
            // validationPass.pass+" : "+ validationPass.fields);
            Net.Vpc.Upa.Record u = entity.GetBuilder().CreateRecord();
            foreach (Net.Vpc.Upa.Field field in fields) {
                Net.Vpc.Upa.Expressions.Expression fieldExpression = GetFieldExpression(field, onPersist);
                Net.Vpc.Upa.Expressions.Expression validExpression = fieldExpression;
                if (forceExpressionTypeCasting || (fieldExpression is Net.Vpc.Upa.Expressions.Literal && ((Net.Vpc.Upa.Expressions.Literal) fieldExpression).GetValue() == null)) {
                    validExpression = new Net.Vpc.Upa.Expressions.Cast(fieldExpression, field.GetDataType());
                }
                u.SetObject(field.GetName(), validExpression);
            }
            try {
                return entity.UpdateCore(u, expression, context);
            } catch (Net.Vpc.Upa.Exceptions.UPAException ex) {
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
