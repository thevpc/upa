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



namespace Net.Vpc.Upa.Impl.Config.Callback
{


    /**
     * Created by vpc on 7/25/15.
     */
    public sealed class DefaultMethodArgumentsConverter : Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter {

        private Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] eval;

        private static bool IsAssignableFrom(Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument a, System.Type type) {
            if (a.IsAcceptSubClasses()) {
                return a.GetPlatformType().IsAssignableFrom(type);
            } else {
                return a.GetPlatformType().Equals(type);
            }
        }

        public static Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter Create(Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] args) {
            return new Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter(args);
        }

        public static Net.Vpc.Upa.Impl.Config.Callback.MethodArgumentsConverter Create(Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] userArgs, Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] apiArguments, Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] implicitArguments) {
            //        this.userTypes = userTypes;
            //        this.userNames = userNames;
            //        this.apiTypes = apiTypes;
            //        this.apiNames = apiNames;
            //        this.implicitArguments = implicitArguments;
            Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] eval = new Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[userArgs.Length];
            for (int i = 0; i < userArgs.Length; i++) {
                string un = userArgs[i].GetName();
                System.Type ut = userArgs[i].GetPlatformType();
                int up = i;
                if (un != null) {
                    Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument aa = null;
                    foreach (Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument apiArgument in apiArguments) {
                        if (apiArgument.GetName().Equals(un)) {
                            if (IsAssignableFrom(apiArgument, ut)) {
                                aa = apiArgument;
                                break;
                            } else {
                                throw new System.ArgumentException ("Invalid argument type : " + ut + " " + un + " at position " + up);
                            }
                        }
                    }
                    if (aa == null) {
                        foreach (Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument implicitArgument in implicitArguments) {
                            if (IsAssignableFrom(implicitArgument, ut)) {
                                aa = implicitArgument;
                                break;
                            } else {
                                throw new System.ArgumentException ("Invalid argument type : " + ut + " " + un + " at position " + up);
                            }
                        }
                    }
                    if (aa != null) {
                        eval[i] = aa;
                    } else {
                        throw new System.ArgumentException ("Missing argument " + ut + " " + un + " at position " + up);
                    }
                } else {
                    if (IsAssignableFrom(apiArguments[i], ut)) {
                        eval[i] = apiArguments[i];
                    } else {
                        //check if the same type isnt called twice
                        int count = 0;
                        System.Collections.Generic.IList<Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument> possible = new System.Collections.Generic.List<Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument>();
                        foreach (Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument apiArgument in apiArguments) {
                            if (IsAssignableFrom(apiArgument, ut)) {
                                possible.Add(apiArgument);
                            }
                        }
                        foreach (Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument implicitArgument in implicitArguments) {
                            if (IsAssignableFrom(implicitArgument, ut)) {
                                possible.Add(implicitArgument);
                            }
                        }
                        if ((possible).Count == 0) {
                            throw new System.ArgumentException ("Missing argument " + ut + " " + un + " at position " + up);
                        } else if ((possible).Count > 1) {
                            throw new System.ArgumentException ("Ambiguous argument " + ut + " " + un + " at position " + up);
                        } else {
                            eval[i] = possible[0];
                        }
                    }
                }
            }
            return new Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter(eval);
        }

        private DefaultMethodArgumentsConverter(Net.Vpc.Upa.Impl.Config.Callback.InvokeArgument[] eval) {
            this.eval = eval;
        }

        public object[] Convert(object[] apiArguments) {
            object[] expected = new object[eval.Length];
            for (int i = 0; i < expected.Length; i++) {
                expected[i] = eval[i].GetValue(apiArguments);
            }
            return expected;
        }


        public override bool Equals(object o) {
            if (this == o) return true;
            if (o == null || GetType() != o.GetType()) return false;
            Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter that = (Net.Vpc.Upa.Impl.Config.Callback.DefaultMethodArgumentsConverter) o;
            // Probably incorrect - comparing Object[] arrays with Arrays.equals
            return Net.Vpc.Upa.Impl.Util.UPAUtils.Equals(eval, that.eval);
        }


        public override int GetHashCode() {
            return eval != null ? Net.Vpc.Upa.Impl.Util.PlatformUtils.GetHashCode(eval) : 0;
        }
    }
}
