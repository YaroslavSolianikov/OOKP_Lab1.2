using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace OOKP_Lab1._2
{
    [Serializable]
    class ImmutableClass : ICloneable, IComparable<ImmutableClass>, ISerializable
    {
        private string name;
        public string Name { get; private set; }
        public ImmutableClass(string name)
        {
            Name = name;
        }
        
        public override bool Equals(object obj)
        {
            if (obj.GetType() != this.GetType()) return false;

            ImmutableClass immutableClass  = (ImmutableClass)obj;
            return (this.Name == immutableClass.Name);
        }
        public override int GetHashCode()
        {
            return this.ToString().GetHashCode();
        }
        public override string ToString()
        {
            return string.Format("{0}", this.Name);
        }
        public object Clone()
        {
            return new ImmutableClass(Name = this.Name);
        }
        public int CompareTo(ImmutableClass o)
        {
            ImmutableClass immutableClass = o as ImmutableClass;
            if (immutableClass != null)
            {
                return this.Name.CompareTo(immutableClass.Name);
            }
            else
                throw new Exception("Невозможно сравнить два объекта");

        }
        public void Serializble()
        {
            ImmutableClass immutableClass = new ImmutableClass("Tom");
            BinaryFormatter formatter = new BinaryFormatter();
            using (FileStream fs = new FileStream("d://Ярослав/C#/OOkp_2sem/Lab1.2/test.txt", FileMode.OpenOrCreate))
            {
                // сериализация (сохранение объекта в поток байт)
                formatter.Serialize(fs, immutableClass);
            }
        }
    }
}
