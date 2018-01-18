﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection.Emit;
using System.Reflection;
using System.IO;

namespace Fortress
{
    public class ModuleScope
    {
        private readonly bool savePhysicalAssembly;
        private readonly bool disableSignedModule;
        private readonly string strongAssemblyName;
        private readonly string strongModulePath;
        private readonly string weakAssemblyName;
        private readonly string weakModulePath;
        private readonly INamingScope namingScope;
        private readonly Lock cacheLock = Lock.Create();
        private readonly Dictionary<CacheKey, Type> typeCache = new Dictionary<CacheKey, Type>();
        private readonly object moduleLocker = new object();
        private ModuleBuilder moduleBuilderWithStrongName;


        public static readonly string DEFAULT_ASM_NAME = "DynProxGenAsm";
        public static readonly string DEFAULT_FILE_NAME = "FortressProx.dll";

        public Lock Lock
        {
            get { return cacheLock; }
        }

        public INamingScope NamingScope
        {
            get { return this.namingScope; }
        }

        public ModuleBuilder StrongNamedModule
        {
            get { return this.moduleBuilderWithStrongName; }
        }

        public string StrongNamedModuleName
        {
            get { return Path.GetFileName(this.strongModulePath); }
        }

        public string WeakNamedModuleName
        {
            get { return Path.GetFileName(this.weakModulePath); }
        }

        public ModuleScope()
            :this(false,false)
        { }

        public ModuleScope(bool savePhysicalAssembly)
            :this(savePhysicalAssembly,false)
        { }

        public ModuleScope(bool savePhysicalAssembly, bool disableSignedModule)
            :this(savePhysicalAssembly,disableSignedModule,DEFAULT_ASM_NAME,DEFAULT_FILE_NAME,DEFAULT_ASM_NAME,DEFAULT_FILE_NAME)
        { }

        public ModuleScope(bool savePhysicalAssembly,bool disableSignedModule,string strongAssemblyName,
            string strongModulePath,string weakAssemblyName,string weakModulePath)
            :this(savePhysicalAssembly,disableSignedModule,new NamingScope(),strongAssemblyName,strongModulePath,weakAssemblyName,weakModulePath)
        { }

        public ModuleScope(bool savePhysicalAssembly, bool disableSignedModule, INamingScope namingScope,
            string strongAssemblyName, string strongModulePath,string weakAssemblyName,string weakModulePath)
        {
            this.savePhysicalAssembly = savePhysicalAssembly;
            this.disableSignedModule = disableSignedModule;
            this.namingScope = namingScope;
            this.strongAssemblyName = strongAssemblyName;
            this.strongModulePath = strongModulePath;
            this.weakAssemblyName = weakAssemblyName;
            this.weakModulePath = weakModulePath;
        }

        public Type GetFromCache(CacheKey key)
        {
            Type type;
            this.typeCache.TryGetValue(key, out type);
            return type;

        }

        public void RegisterInCache(CacheKey key, Type type)
        {
            this.typeCache[key] = type;
        }

        public TypeBuilder DefineType(bool inSignedModePreferably, string name, TypeAttributes flags)
        {
            Obt
        }

        public ModuleBuilder ObtainDynamicModule(bool isStrongNamed)
        {
            if(isStrongNamed)
            {

            }
        }

        public ModuleBuilder ObtainDynamicModuleWithStronGname()
        {
            if(this.disableSignedModule)
            {
                throw new InvalidOperationException("sighned module shouldn't be diabled");
            }
            lock(this.moduleLocker)
            {
                if(this.moduleBuilderWithStrongName == null)
                {
                    this.moduleBuilderWithStrongName 
                }
            }
        }

        public ModuleBuilder CreateModule(bool signStrongName)
        {
            AssemblyName assemblyName = this.GetAssemblyName(signStrongName);
            string moduleName = signStrongName ? this.StrongNamedModuleName : this.WeakNamedModuleName;
            //flag: FEATURE_APPDOMAIN
                
        }

        private AssemblyName GetAssemblyName(bool signStrongName)
        {
            AssemblyName assemblyName = new AssemblyName {
                Name = signStrongName? this.strongAssemblyName : weakAssemblyName
            };

            //#INSPECT:

            return assemblyName;

        }


    }
}
