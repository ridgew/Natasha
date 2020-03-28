﻿using System;

namespace Natasha
{
    public static class DelegateExtension
    {

        public static Delegate Create(this Type instance, string content, params NamespaceConverter[] usings)
        {
            var method = instance.GetMethod("Invoke");
            return FakeMethodOperator
                .Default()
                .UseMethod(method)
                .Using(usings)
                .StaticMethodBody(content)
                .Compile();
        }




        public static AssemblyDomain GetDomain(this Delegate @delegate)
        {

            return @delegate.Method.Module.Assembly.GetDomain();

        }




        public static void RemoveReferences(this Delegate @delegate)
        {

            @delegate.Method.Module.Assembly.RemoveReferences();

        }





        public static void DisposeDomain(this Delegate @delegate)
        {

            @delegate.Method.Module.Assembly.DisposeDomain();

        }
    }
}
