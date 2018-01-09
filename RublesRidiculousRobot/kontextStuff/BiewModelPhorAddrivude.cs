using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Experiments.outThere;

namespace Experiments.kompiyal.kontextStuff
{
    [AttributeUsage(AttributeTargets.Class)]
    public class BiewModelPhorAddrivude: Attribute
    {
        public Type ModelType { get; private set; }

        public bool Has2WayMapping { get; set; }

        public BiewModelPhorAddrivude(Type modelType)
        {
            ModelType = modelType;
        }

        public static Type GetModelType(Type modelOrViewModelType)
        {
            Type modelType = modelOrViewModelType.GetAttributes<BiewModelPhorAddrivude>()
                .Select(v => v.ModelType)
                .DefaultIfEmpty(modelOrViewModelType)
                .First();
            return modelType;
        }

        public static bool TypeHas2WayMapping(Type modelOrViewModelType)
        {
            bool has2Way = modelOrViewModelType.GetAttributes<BiewModelPhorAddrivude>()
                .Any(x => x.Has2WayMapping);
            return has2Way;
        }
    }
}
