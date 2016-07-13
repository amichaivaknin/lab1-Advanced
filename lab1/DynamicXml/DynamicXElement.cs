using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DynamicXml
{
    class DynamicXElement: DynamicObject
    {
        private readonly XElement _element;

        private DynamicXElement(XElement element)
        {
            _element = element;
        }

        public static dynamic Create(XElement element)
        {
            return new DynamicXElement(element);
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            result = new DynamicXElement(_element.Element(binder.Name));
            if (result == null)
            {
                return false;
            }
            return true;
        }

        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            if (indexes.Length != 2)
            {
                result = null;
                return false;
            }

            if (indexes[0].GetType() != typeof(string) || indexes[1].GetType() != typeof(int))
            {
                result = null;
                return false;
            }

            List<XElement> childrens =_element.Elements((string) indexes[0]).ToList();
            result = new DynamicXElement(childrens.ElementAt((int) indexes[1]));
            return result != null;
        }

        public override string ToString()
        {
            return _element.Value.ToString();
        }

    }
}
