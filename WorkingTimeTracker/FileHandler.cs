using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Xml;
using System.IO;

namespace WorkingTimeTracker
{
    public   class FileHandler
    {
        private string path;


        public FileHandler(string file_path)
        {
            path = file_path;
        }


        //public void saveObject2XMLFile(object obj)
        //{
        //    Basis_information b = new Basis_information();

        //    if(Object.ReferenceEquals(obj.GetType(), b.GetType()))
        //    {
        //        Serialization.WriteToXmlFile<Basis_information>(path,(Basis_information) obj);
        //    }

        //    int i=0;
        //    if (Object.ReferenceEquals(obj.GetType(), i.GetType()))
        //    {
        //        Serialization.WriteToXmlFile<int>(path, (int)obj);
        //    }

        //    //Todo: Add more types here



        //}


        //public object readObjectfromXMLFile(Object obj)
        //{

            
        //    Basis_information b = new Basis_information();

        //    if (Object.ReferenceEquals(obj.GetType(), b.GetType()))
        //    {
        //        Basis_information basis_info = Serialization.ReadFromXmlFile<Basis_information>(path);
        //        return basis_info;
        //    }
        //    return null;


        //}




    }

}

