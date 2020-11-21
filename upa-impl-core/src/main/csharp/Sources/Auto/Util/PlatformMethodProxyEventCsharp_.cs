using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Net.TheVpc.Upa.Impl.Util
{
    public class PlatformMethodProxyEventCsharp<T> : Net.TheVpc.Upa.Impl.Util.PlatformMethodProxyEvent<T>
    {
            private T @object;
            private object[] arguments;
            private string methodName;
            private System.Reflection.MethodInfo method;
            private EmitProxyExecute<T> execute;

            public PlatformMethodProxyEventCsharp(T @object,string methodName, System.Reflection.MethodInfo method, object[] args, EmitProxyExecute<T> execute) {
                this.@object = @object;
                this.arguments = args;
                this.methodName = methodName;
                this.execute = execute;
            }

            public T GetObject() {
                return @object;
            }

            public Object[] GetArguments() {
                return arguments;
            }

            public string GetMethodName() {
                return methodName;
            }

            public System.Reflection.MethodInfo GetMethod() {
                return method;
            }

            public object InvokeBase(T obj,object[] args){
                return execute(obj, args);
            }
    }
}
