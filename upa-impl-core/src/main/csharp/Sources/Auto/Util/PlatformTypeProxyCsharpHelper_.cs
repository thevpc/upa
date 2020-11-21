using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Threading;

namespace Net.TheVpc.Upa.Impl.Util
{
    /// <summary>
    /// Delegate that is called on every request on the proxied object
    /// </summary>
    /// <typeparam name="I">the interface of the proxy</typeparam>
    /// <param name="proxiedObject">the object being proxied</param>
    /// <param name="methodname">the name of the method invoked</param>
    /// <param name="parameters">the parameters used on the method invocation</param>
    /// <param name="execute">a delegate to execute the intercepted method</param>
    /// <returns>the return result of the invocation</returns>
    public delegate object EmitProxyInterceptor<I>(I proxiedObject, string methodname, object[] parameters, EmitProxyExecute<I> execute);

    /// <summary>
    /// Delegate to execute the intercepeted method
    /// </summary>
    /// <typeparam name="I">Interface of the proxy</typeparam>
    /// <param name="objectToExecute">object to execute the method on</param>
    /// <param name="parameters">the parameters for the method invocation</param>
    /// <returns>result of the execution</returns>
    public delegate object EmitProxyExecute<I>(I objectToExecute, params object[] parameters);

    public static class PlatformTypeProxyCsharpHelper
    {
        private const string ASSEMBLY_NAME = "ProxyAssembly";
        private const string MODULE_NAME = "ProxyModule";
        private const string TYPE_SUFFIX = "Proxy";
        private const string EXECUTE_PREFIX = "Execute";

        //a little wierd but our caches need a non null object to act as our attribute
        //when we dont want to limit our proxying on attributes
        private static Type NO_ATTRIBUTE = typeof(object);

        //we cache our generated types on [interface type][attribute type]
        private static Dictionary<Type, Dictionary<Predicate<MethodInfo>, Type>> _dynamicTypeCache = new Dictionary<Type, Dictionary<Predicate<MethodInfo>, Type>>();

        /// <summary>
        /// Creates a proxy for this object
        /// </summary>
        /// <typeparam name="I">Interface to proxy</typeparam>
        /// <typeparam name="A">Will only proxy method that have this attribute</typeparam>
        /// <param name="objectToProxy"></param>
        /// <param name="interceptorDelegate">delegate to call on method invocation</param>
        /// <returns></returns>
        public static I Proxy<I, A>(this I objectToProxy, EmitProxyInterceptor<I> interceptorDelegate) where A : Attribute
        {
            return PlatformTypeProxyCsharpHelper.Proxy<I>(objectToProxy, (info) =>
            {
                //Check if hte attribute is on the interface
                //also check if our method info is actually a property value, if so we will check if the
                //attribute is on the property
                bool isAttributeOnInterface = typeof(I).GetMethod(info.Name, info.GetParameters().Select(p => p.ParameterType).ToArray()) != null;

                if (isAttributeOnInterface == false && info.IsSpecialName && (info.Name.StartsWith("get_") || info.Name.StartsWith("set_")))
                    isAttributeOnInterface = typeof(I).GetProperty(info.Name.Remove(0, 4)) != null;


                //Check if hte attribute is on our actual object
                //also check if our method info is actually a property value, if so we will check if the
                //attribute is on the property
                bool isAttributeOnMethod = info.GetCustomAttributes(typeof(A), true).Count() > 0;

                if (isAttributeOnMethod==false && info.IsSpecialName && (info.Name.StartsWith("get_") || info.Name.StartsWith("set_")))
                    isAttributeOnMethod = objectToProxy.GetType().GetProperty(info.Name.Remove(0, 4)) != null;



                //we have the attribute if it is either on the interface or method
                return isAttributeOnInterface || isAttributeOnMethod;



            }, interceptorDelegate);
        }

        /// <summary>
        /// Creates a proxy for this object
        /// </summary>
        /// <typeparam name="I">Interface to proxy</typeparam>
        /// <param name="objectToProxy"></param>
        /// <param name="interceptorDelegate">delegate to call on method invocation</param>
        /// <returns></returns>
        public static I Proxy<I>(this I objectToProxy, EmitProxyInterceptor<I> interceptorDelegate)
        {
            return PlatformTypeProxyCsharpHelper.Proxy<I>(objectToProxy, (info) => true, interceptorDelegate);
        }

        /// <summary>
        /// Creates a proxy for this object
        /// </summary>
        /// <typeparam name="I">Interface to proxy</typeparam>
        /// <param name="objectToProxy"></param>
        /// <param name="methodSelector">predicate to select which methods call the <paramref name="interceptorDelegate"/> </param>
        /// <param name="interceptorDelegate">delegate to call on method invocation</param>
        /// <returns></returns>
        public static I Proxy<I>(this I objectToProxy, Predicate<MethodInfo> methodSelector, EmitProxyInterceptor<I> interceptorDelegate)
        {
            if (!typeof(I).IsInterface)
                throw new Exception("Generic parameter must be an interface");

            //ensure we have something in our interface level cache
            if (!_dynamicTypeCache.ContainsKey(typeof(I)))
                _dynamicTypeCache[typeof(I)] = new Dictionary<Predicate<MethodInfo>, Type>();

            //Check if the type is cached first, if not we go and emit a proxy class for the given interface
            //and pass null for the attribute we are proxying
            if (!_dynamicTypeCache[typeof(I)].ContainsKey(methodSelector))
                _dynamicTypeCache[typeof(I)][methodSelector] = CreateProxy<I>(objectToProxy, methodSelector, interceptorDelegate);



            return (I)Activator.CreateInstance(_dynamicTypeCache[typeof(I)][methodSelector], objectToProxy, interceptorDelegate);

        }

        /// <summary>
        /// Gets all the methods, including inherited methods
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private static IEnumerable<MethodInfo> GetAllInterfaceMethods(this Type type)
        {
            foreach(MethodInfo info in type.GetMethods())
                yield return info;

            foreach (Type interfaceType in type.GetInterfaces())
                foreach (MethodInfo info in interfaceType.GetAllInterfaceMethods())
                    yield return info;
        }

        /// <summary>
        /// Creates a proxy
        /// </summary>
        /// <typeparam name="I">Interface of the proxy</typeparam>
        /// <param name="objectToProxy">object that is being proxied</param>
        /// <param name="interceptorDelegate">delegate to call on invocation</param>
        /// <param name="methodSelector">predicate to select which methods call the <paramref name="interceptorDelegate"/> </param>
        /// <returns>The proxy</returns>
        private static Type CreateProxy<I>(I objectToProxy, Predicate<MethodInfo> methodSelector, EmitProxyInterceptor<I> interceptorDelegate)
        {
            //create the dynamic assembly
            ModuleBuilder moduleBuilder = CreateAssembly(ASSEMBLY_NAME, MODULE_NAME);

            //create our new type that implements the proxy interface
            TypeBuilder typeBuilder = moduleBuilder.CreateType<I, object>(typeof(I).Name + TYPE_SUFFIX);

            //copy the class custom attributes
            foreach(CustomAttributeBuilder attrBuilder in CreateCustomAttributeBuilder(objectToProxy.GetType()))
                typeBuilder.SetCustomAttribute(attrBuilder);




            //create two fields, one to store the proxied object, and one to store the Interceptor delegate
            //this will also create a constructor to set both these values
            FieldInfo[] fieldInfo = typeBuilder.CreateFieldsAndConstrucutor(
                typeof(I), "ProxiedObject",
                typeof(EmitProxyInterceptor<I>), "Interceptor");

            //Create an implementation of each method in the interface. There is a direct implementation
            //to conform to the interface, and an execute method that will call the proxied object directly
            //given an object and a parameter list
            foreach (MethodInfo interfaceMethodInfo in typeof(I).GetAllInterfaceMethods())
            {
                //get a list of parameter types
                ParameterInfo[] parameterInfos = interfaceMethodInfo.GetParameters();
                Type[] parameterTypes = new Type[parameterInfos.Length];
                for (int i = 0; i < parameterInfos.Length; i++)
                    parameterTypes[i] = parameterInfos[i].ParameterType;

                //get the method info of the actual object, it might have the attributes we are looking
                MethodInfo proxiedMethodInfo = objectToProxy.GetType().GetMethod(interfaceMethodInfo.Name, parameterTypes);

                //will only create proxy to call delegate if it contains the attribute we are looking for
                //(note that either the itnerface or the actual object we are proxing can have the attribute)
                //or no attribute was defined
                MethodBuilder proxyMethod;
                if (methodSelector(proxiedMethodInfo))
                {
                    MethodInfo executeMethod = typeBuilder.CreateExecuteMethod<I>(EXECUTE_PREFIX + interfaceMethodInfo.Name, interfaceMethodInfo);
                    proxyMethod = typeBuilder.CreateProxyMethod<I>(interfaceMethodInfo, executeMethod, fieldInfo[0], fieldInfo[1]);
                }
                else
                {
                    proxyMethod = typeBuilder.CreatePassThroughMethod<I>(interfaceMethodInfo, fieldInfo[0]);
                }

                //Copy accross the attributes
                foreach(CustomAttributeBuilder attrBuilder in CreateCustomAttributeBuilder(proxiedMethodInfo))
                    proxyMethod.SetCustomAttribute(attrBuilder);

            }

            return typeBuilder.CreateType();
        }




        /// <summary>
        /// Creates a dynamic assembly and module with the given assembly name and module name
        /// </summary>
        /// <param name="assemblyName"></param>
        /// <param name="moduleName"></param>
        /// <returns></returns>
        private static ModuleBuilder CreateAssembly(string assemblyName, string moduleName)
        {
            AppDomain domain = Thread.GetDomain();
            AssemblyName assembly = new AssemblyName();
            assembly.Name = assemblyName;
            assembly.Version = new Version(0, 0, 0, 0);

            // create a new assembly
            AssemblyBuilder assemblyBuilder = domain.DefineDynamicAssembly(assembly, AssemblyBuilderAccess.Run);

            // create a new module for this proxy
            return assemblyBuilder.DefineDynamicModule(moduleName);
        }

        /// <summary>
        /// Creates a type
        /// </summary>
        /// <typeparam name="I">interface to implement</typeparam>
        /// <typeparam name="B">base type for new class</typeparam>
        /// <param name="moduleBuilder">module builder to use to construct type</param>
        /// <param name="typeName">name of type</param>
        /// <returns></returns>
        private static TypeBuilder CreateType<I, B>(this ModuleBuilder moduleBuilder, string typeName)
        {
            TypeAttributes typeAttributes = TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed;

            TypeBuilder typeBuilder = moduleBuilder.DefineType(typeName, typeAttributes, typeof(B), new Type[] { typeof(I) });
            return typeBuilder;
        }

        /// <summary>
        /// Creates the fields and constructor to set the fields
        /// </summary>
        /// <param name="typeBuilder">type builder to use to construct fields and constructor</param>
        /// <param name="fieldTypeAndName">alternating list of type, name of fields</param>
        private static FieldInfo[] CreateFieldsAndConstrucutor(this TypeBuilder typeBuilder, params object[] fieldTypeAndName)
        {
            Type[] types = new Type[fieldTypeAndName.Length / 2];
            string[] names = new string[fieldTypeAndName.Length / 2];

            //Define the types, even items are types odd items are fields
            for (int i = 0; i < types.Length; i++)
            {
                types[i] = (Type)fieldTypeAndName[i * 2];
                names[i] = (string)fieldTypeAndName[i * 2 + 1];
            }

            //create all the fields. We create them as public, as they will have to reflect
            //to see them anyway, and if they are going through that much effort i dont see
            //any reason to make it harder to access them
            FieldInfo[] fieldInfos = new FieldInfo[types.Length];
            for (int i = 0; i < types.Length; i++)
                fieldInfos[i] = typeBuilder.DefineField(names[i], types[i], FieldAttributes.Public);

            ConstructorInfo superConstructor = typeof(object).GetConstructor(Type.EmptyTypes);
            ConstructorBuilder fieldPopulateConstructor = typeBuilder.DefineConstructor(
                    MethodAttributes.Public, CallingConventions.Standard, types);




            #region( "Constructor IL Code" )
            ILGenerator constructorIL = fieldPopulateConstructor.GetILGenerator();

            //loop through all the fields adding them to the correct field
            for (int i = 0; i < fieldInfos.Length; i++)
            {
                // Load "this"
                constructorIL.Emit(OpCodes.Ldarg_0);

                // Load parameter
                constructorIL.Emit(OpCodes.Ldarg, i + 1);

                //Set the parameter into the field
                constructorIL.Emit(OpCodes.Stfld, fieldInfos[i]);
            }

            // Load "this"
            constructorIL.Emit(OpCodes.Ldarg_0);

            //call super
            constructorIL.Emit(OpCodes.Call, superConstructor);

            // Constructor return
            constructorIL.Emit(OpCodes.Ret);
            #endregion

            return fieldInfos;

        }

        /// <summary>
        /// Creates an execute method. An execute method takes an object and an array of parameters and executes
        /// a particular method on teh object with the parameters
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <param name="typeBuilder"></param>
        /// <param name="methodName">name of execute method</param>
        /// <param name="methodToExecute">method that the execute method will call</param>
        /// <returns></returns>
        private static MethodInfo CreateExecuteMethod<I>(this TypeBuilder typeBuilder, string methodName, MethodInfo methodToExecute)
        {
            //get a list of parameter types
            ParameterInfo[] parameterInfos = methodToExecute.GetParameters();
            Type[] parameterTypes = new Type[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
                parameterTypes[i] = parameterInfos[i].ParameterType;

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                methodName,
                MethodAttributes.Public | MethodAttributes.Static,
                CallingConventions.Standard,
                typeof(object),
                new Type[] { typeof(I), typeof(object[]) });

            ILGenerator il = methodBuilder.GetILGenerator();



            il.Emit(OpCodes.Ldarg_0);
            for (int i = 0; i < parameterTypes.Length; i++)
            {
                il.Emit(OpCodes.Ldarg_1);   //laod arg array
                il.Emit(OpCodes.Ldc_I4, i); //load index
                il.Emit(OpCodes.Ldelem_Ref);//get element at index from arg array
                if (parameterTypes[i].IsValueType)
                    il.Emit(OpCodes.Unbox_Any, parameterTypes[i]); //unbox if necassary
            }

            il.EmitCall(OpCodes.Call, methodToExecute, null); //call real method
            if (methodToExecute.ReturnType == typeof(void))
                il.Emit(OpCodes.Ldnull);    //if method is void return, we will return null, because we have to return something
            else if (methodToExecute.ReturnType.IsValueType)
                il.Emit(OpCodes.Box, methodToExecute.ReturnType); //we need to box our return type

            il.Emit(OpCodes.Ret);//return

            return methodBuilder;
        }

        /// <summary>
        /// Creates a proxy method. THe proxy method will call the EmitProxyInterceptor when invoked
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <param name="typeBuilder"></param>
        /// <param name="proxiedMethod"></param>
        /// <param name="executeMethod"></param>
        /// <param name="proxiedObjectField"></param>
        /// <param name="interceptorField"></param>
        private static MethodBuilder CreateProxyMethod<I>(this TypeBuilder typeBuilder, MethodInfo proxiedMethod, MethodInfo executeMethod, FieldInfo proxiedObjectField, FieldInfo interceptorField)
        {
            //get a list of parameter types
            ParameterInfo[] parameterInfos = proxiedMethod.GetParameters();
            Type[] parameterTypes = new Type[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
                parameterTypes[i] = parameterInfos[i].ParameterType;

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                proxiedMethod.Name,
                MethodAttributes.Public | MethodAttributes.Virtual,
                proxiedMethod.CallingConvention,
                proxiedMethod.ReturnType,
                parameterTypes);


            ILGenerator il = methodBuilder.GetILGenerator();
            il.DeclareLocal(typeof(object[])); //define local parameter array

            #region ("Create Parameters Array in loc_0")
            il.Emit(OpCodes.Ldc_I4, parameterTypes.Length);
            il.Emit(OpCodes.Newarr, typeof(object)); //Create new array
            il.Emit(OpCodes.Stloc_0);               //Store new array at loc_0

            for (int i = 0; i < parameterTypes.Length; i++)
            {
                il.Emit(OpCodes.Ldloc_0);           //load array
                il.Emit(OpCodes.Ldc_I4, i);         //load index
                il.Emit(OpCodes.Ldarg, i + 1);        //load argument
                if (parameterTypes[i].IsValueType)
                    il.Emit(OpCodes.Box, parameterTypes[i]); //box if needed
                il.Emit(OpCodes.Stelem_Ref);        //store arguemtn at index for array
            }
            #endregion

            il.Emit(OpCodes.Ldarg_0);                   //load this
            il.Emit(OpCodes.Ldfld, interceptorField);   //load this.Interceptor

            il.Emit(OpCodes.Ldarg_0);                   //load this
            il.Emit(OpCodes.Ldfld, proxiedObjectField); //load this.ProxiedObject

            il.Emit(OpCodes.Ldstr, proxiedMethod.Name); //load method name
            il.Emit(OpCodes.Ldloc_0);                    //load paramter array


            il.Emit(OpCodes.Ldnull);                    //load execute delegate
            il.Emit(OpCodes.Ldftn, executeMethod);
            il.Emit(OpCodes.Newobj, typeof(EmitProxyExecute<I>).GetConstructors()[0]);

            il.EmitCall(OpCodes.Callvirt, typeof(EmitProxyInterceptor<I>).GetMethod("Invoke"), null); //call interceptor delegate

            if (proxiedMethod.ReturnType == typeof(void))
                il.Emit(OpCodes.Pop);//if we are returning void get rid of the result on the stack
            else if (proxiedMethod.ReturnType.IsValueType)
                il.Emit(OpCodes.Unbox_Any, proxiedMethod.ReturnType); //unbox to make our return type the value type the interface demands
            il.Emit(OpCodes.Ret);                       //return


            return methodBuilder;



        }

        /// <summary>
        /// Creates a method that simply invokes the proxied object
        /// </summary>
        /// <typeparam name="I"></typeparam>
        /// <param name="typeBuilder"></param>
        /// <param name="proxiedMethod"></param>
        /// <param name="proxiedObjectField"></param>
        private static MethodBuilder CreatePassThroughMethod<I>(this TypeBuilder typeBuilder, MethodInfo proxiedMethod, FieldInfo proxiedObjectField)
        {
            //get a list of parameter types
            ParameterInfo[] parameterInfos = proxiedMethod.GetParameters();
            Type[] parameterTypes = new Type[parameterInfos.Length];
            for (int i = 0; i < parameterInfos.Length; i++)
                parameterTypes[i] = parameterInfos[i].ParameterType;

            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                proxiedMethod.Name,
                MethodAttributes.Public | MethodAttributes.Virtual,
                proxiedMethod.CallingConvention,
                proxiedMethod.ReturnType,
                parameterTypes);

            ILGenerator il = methodBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0); //load this
            il.Emit(OpCodes.Ldfld, proxiedObjectField); //load object
            for (int i = 0; i < parameterTypes.Length; i++)
            {
                il.Emit(OpCodes.Ldarg, i + 1);   //load all parameters
            }

            il.EmitCall(OpCodes.Callvirt, proxiedMethod, null); //call method
            il.Emit(OpCodes.Ret);                       //return

            return methodBuilder;

        }


        /// <summary>
        /// Create a custom attribute builder from the attributes found in <paramref name="oldMember"/>
        /// </summary>
        /// <param name="oldMember"></param>
        /// <returns></returns>
        private static IEnumerable<CustomAttributeBuilder> CreateCustomAttributeBuilder(MemberInfo oldMember)
        {
            foreach (CustomAttributeData att in CustomAttributeData.GetCustomAttributes(oldMember))
            {
                List<object> namedFieldValues = new List<object>();
                List<FieldInfo> namedFields = new List<FieldInfo>();

                List<object> namedPropertyValues = new List<object>();
                List<PropertyInfo> namedProperties = new List<PropertyInfo>();

                List<object> constructorArguments = new List<object>();

                //populate the constructor arguments
                foreach (CustomAttributeTypedArgument cata in att.ConstructorArguments)
                    constructorArguments.Add(cata.Value);

                //populate hte field and property values
                foreach (CustomAttributeNamedArgument cana in att.NamedArguments)
                {
                    if (cana.MemberInfo is FieldInfo)
                    {
                        namedFields.Add((FieldInfo)cana.MemberInfo);
                        namedFieldValues.Add(cana.TypedValue.Value);
                    }
                    else if (cana.MemberInfo is PropertyInfo)
                    {
                        namedProperties.Add((PropertyInfo)cana.MemberInfo);
                        namedPropertyValues.Add(cana.TypedValue.Value);
                    }
                }
                yield return new CustomAttributeBuilder(
                    att.Constructor,
                    constructorArguments.ToArray(),
                    namedProperties.ToArray(),
                    namedPropertyValues.ToArray(),
                    namedFields.ToArray(),
                    namedFieldValues.ToArray());
            }
        }

    }
}
