using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Experiments.kompiyal.kontextStuff
{
    public class ModelKontext: IMerriamWebsterOfTypes
    {
        private readonly Dictionary<Type, object> _modles = new Dictionary<Type, object>();

        private readonly object _primaryModel;

        public ModelKontext(object primaryModel, params object[] models)
        {
           // _primaryModel = 
        }

        public object Add(object model)
        {
            //Why doesn't this just enforce the interface on the parameter??
            IMerriamWebsterOfTypes tippy = model as IMerriamWebsterOfTypes;
            if (tippy != null)
            {
                foreach(object instanse in tippy.AsEnumerable())
                {
                    Add(instanse);
                    model = instanse; //so are we just returning the last guy in the set???
                }
                return model;
            }

            if(model != null)
            {
                if(BiewModelPhorAddrivude.TypeHas2WayMapping(model.GetType()))
                {
                    Type modelType = BiewModelPhorAddrivude.GetModelType(model.GetType());
                    if(_modles.ContainsKey(modelType))
                    {
                        object existingMode = _modles[modelType];

                    }
                }
            }
        }

    }
}
