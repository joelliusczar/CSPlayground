using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR.Pipeline;
using MediatR;
using System.IO;

namespace CSPlayground
{
    using Ninject;
    using Ninject.Extensions.Conventions;
    using Ninject.Planning.Bindings.Resolvers;
    using NinSyn = Ninject.Extensions.Conventions.Syntax;
    
    internal class Program
    {
        internal static void Main(string[] args)
        {
            Deadrace dr = new Deadrace();
            dr.RunRace();
            Console.ReadKey();
        }


        public static void JenericStuph()
        {
            Type bh = typeof(BigHead);
            Type jPlurType = typeof(JenericaPluralis<object,object,object>);
            Type jenericType = jPlurType.GetGenericTypeDefinition().MakeGenericType(new[] { typeof(String),typeof(BigHead),typeof(int) });
            JenericaPluralis<object,object,object> obj = (JenericaPluralis<object, object, object>)Activator.CreateInstance(jenericType);

        }

        public static IMediator BuildMediator()
        {
            IKernel kernel = new StandardKernel();
            kernel.Components.Add<IBindingResolver, ContravariantBindingResolver>();
            kernel.Bind((scan) => {
                NinSyn.IIncludingNonPublicTypesSelectSyntax fromAsm = scan.FromAssemblyContaining<IMediator>();
                NinSyn.IJoinFilterWhereExcludeIncludeBindSyntax allClasses = fromAsm.SelectAllClasses();
                allClasses.BindDefaultInterface();
            });
            kernel.Bind<TextWriter>().ToConstant(Console.Out);
            kernel.Bind((scan) => { 
                NinSyn.IIncludingNonPublicTypesSelectSyntax fromAsm = scan.FromAssemblyContaining<Ping>();
                NinSyn.IJoinFilterWhereExcludeIncludeBindSyntax allClasses = fromAsm.SelectAllClasses();
                NinSyn.IJoinFilterWhereExcludeIncludeBindSyntax inherited = allClasses.InheritedFrom(typeof(IRequestHandler<,>));
                inherited.BindAllInterfaces();
            });
            kernel.Bind((scan) => {
                NinSyn.IIncludingNonPublicTypesSelectSyntax fromAsm = scan.FromAssemblyContaining<Ping>();
                NinSyn.IJoinFilterWhereExcludeIncludeBindSyntax allClasses = fromAsm.SelectAllClasses();
                NinSyn.IJoinFilterWhereExcludeIncludeBindSyntax inherited = allClasses.InheritedFrom(typeof(IRequestHandler<>));
                inherited.BindAllInterfaces();
            });
            kernel.Bind(scan => {
                NinSyn.IIncludingNonPublicTypesSelectSyntax fromAsm = scan.FromAssemblyContaining<PingNotice>();
                NinSyn.IJoinFilterWhereExcludeIncludeBindSyntax allClasses = fromAsm.SelectAllClasses();
                NinSyn.IJoinFilterWhereExcludeIncludeBindSyntax inherited = allClasses.InheritedFrom(typeof(INotificationHandler<>));
                inherited.BindAllInterfaces();
            });

            //kernel.Bind(typeof(IPipelineBehavior<,>)).To(typeof(RequestPreProcessorBehavior<,>));
            //kernel.Bind(typeof(IPipelineBehavior<,>)).To(typeof(RequestPostProcessorBehavior<,>));
            //kernel.Bind(typeof(IPipelineBehavior<,>)).To(typeof(GenericPipelineBehavior<,>));
            //kernel.Bind(typeof(IRequestPreProcessor<>)).To(typeof(GenericRequestPreProcessor<>));
            //kernel.Bind(typeof(IRequestPostProcessor<,>)).To(typeof(GenericRequestPostProcessor<,>));


            kernel.Bind<SingleInstanceFactory>().ToMethod(ctx => {
                return t => {
                    var something = ctx.Kernel.TryGet(t);
                    return something;
                };
            });

            kernel.Bind<MultiInstanceFactory>().ToMethod(ctx => {
                return t => {
                    var allSomethings = ctx.Kernel.GetAll(t);
                    return allSomethings;
                };
            });

            IMediator m = kernel.Get<IMediator>();

            return m;
        }


    }
}
