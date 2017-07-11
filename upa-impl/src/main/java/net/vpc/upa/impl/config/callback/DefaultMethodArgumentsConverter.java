package net.vpc.upa.impl.config.callback;

import net.vpc.upa.exceptions.UPAIllegalArgumentException;
import net.vpc.upa.impl.util.PlatformUtils;
import net.vpc.upa.impl.util.UPAUtils;

import java.lang.reflect.Method;
import java.util.ArrayList;
import java.util.Arrays;
import java.util.List;

/**
 * Created by vpc on 7/25/15.
 */
public final class DefaultMethodArgumentsConverter implements MethodArgumentsConverter {
//    String[] userNames;
//    Class[] apiTypes;
//    String[] apiNames;
//    ImplicitArgument[] implicitArguments;

    private InvokeArgument[] eval;

    private static boolean isAssignableFrom(InvokeArgument a,Class type){
        if(a.isAcceptSubClasses()){
            return a.getPlatformType().isAssignableFrom(type);
        }else{
            return a.getPlatformType().equals(type);
        }
    }

    public static MethodArgumentsConverter create(
            InvokeArgument[] args
    ) {

        return new DefaultMethodArgumentsConverter(args);
    }

    public static MethodArgumentsConverter create(
            Method m,
            InvokeArgument[] userArgs,
            InvokeArgument[] apiArguments,
            InvokeArgument[] implicitArguments
    ) {
//        this.userTypes = userTypes;
//        this.userNames = userNames;
//        this.apiTypes = apiTypes;
//        this.apiNames = apiNames;
//        this.implicitArguments = implicitArguments;
        InvokeArgument[] eval = new InvokeArgument[userArgs.length];
        for (int i = 0; i < userArgs.length; i++) {
            String un = userArgs[i].getName();
            Class ut = userArgs[i].getPlatformType();
            int up = i;
            if (un != null) {
                InvokeArgument aa = null;
                for (InvokeArgument apiArgument : apiArguments) {
                    if (apiArgument.getName().equals(un)) {
                        if (isAssignableFrom(apiArgument, ut)) {
                            aa = apiArgument;
                            break;
                        } else {
                            throw new UPAIllegalArgumentException(m.toString()+" : Invalid argument type : " + ut + " " + un + " at position " + up);
                        }
                    }
                }
                if (aa == null) {
                    for (InvokeArgument implicitArgument : implicitArguments) {
                        if (isAssignableFrom(implicitArgument, ut)) {
                            aa = implicitArgument;
                            break;
                        } else {
                            throw new UPAIllegalArgumentException(m.toString()+" : Invalid argument type : " + ut + " " + un + " at position " + up);
                        }
                    }
                }
                if (aa != null) {
                    eval[i] = aa;
                } else {
                    throw new UPAIllegalArgumentException(m.toString()+" : Missing argument " + ut + " " + un + " at position " + up);
                }
            } else {
                if (isAssignableFrom(apiArguments[i],ut)) {
                    eval[i] = apiArguments[i];
                } else {
                    //check if the same type isnt called twice

                    int count = 0;
                    List<InvokeArgument> possible = new ArrayList<InvokeArgument>();
                    for (InvokeArgument apiArgument : apiArguments) {
                        if (isAssignableFrom(apiArgument, ut)) {
                            possible.add(apiArgument);
                        }
                    }
                    for (InvokeArgument implicitArgument : implicitArguments) {
                        if (isAssignableFrom(implicitArgument, ut)) {
                            possible.add(implicitArgument);
                        }
                    }
                    if (possible.size() == 0) {
                        throw new UPAIllegalArgumentException(m.toString()+" : Missing argument " + ut + " " + un + " at position " + up);
                    } else if (possible.size() > 1) {
                        throw new UPAIllegalArgumentException(m.toString()+" : Ambiguous argument " + ut + " " + un + " at position " + up);
                    } else {
                        eval[i] = possible.get(0);
                    }
                }
            }
        }
        return new DefaultMethodArgumentsConverter(eval);
    }

    private DefaultMethodArgumentsConverter(InvokeArgument[] eval) {
        this.eval = eval;
    }

    public Object[] convert(Object[] apiArguments) {
        Object[] expected = new Object[eval.length];
        for (int i = 0; i < expected.length; i++) {
            expected[i] = eval[i].getValue(apiArguments);
        }
        return expected;
    }

    @Override
    public boolean equals(Object o) {
        if (this == o) return true;
        if (o == null || getClass() != o.getClass()) return false;

        DefaultMethodArgumentsConverter that = (DefaultMethodArgumentsConverter) o;

        // Probably incorrect - comparing Object[] arrays with Arrays.equals
        return UPAUtils.equals(eval, that.eval);

    }

    @Override
    public int hashCode() {
        return eval != null ? PlatformUtils.hashCode(eval) : 0;
    }
}
