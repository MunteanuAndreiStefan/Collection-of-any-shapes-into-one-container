using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1IP1
{
    public class GeoShape
    {
        public static List<GeoShape> GeoShapes;
        public string name;
        public List<Tuple<String, List<float>>> objectDefinition;

        #region Constructors

        public GeoShape(string shapeData)
        {
            if (GeoShapes == null)
                GeoShapes = new List<GeoShape>();

            string line;
            objectDefinition = new List<Tuple<String, List<float>>>();
            StringReader stringReader = new StringReader(shapeData);

            while (null != (line = stringReader.ReadLine())) {

                List<float> values = new List<float>();

                var nameValue = line.Split('=');

                if ("Name".Equals(nameValue[0]))
                    name = nameValue[1];
                else 
                {
                    var valuesString = nameValue[1].Split(';');
                    foreach (var value in valuesString)
                        values.Add(float.Parse(value));
                    objectDefinition.Add( new Tuple<string, List<float>> (nameValue[0], values));
                }
            }

            GeoShape.GeoShapes.Add(this);
        }

        public GeoShape()
        {
            name = "";
            objectDefinition = new List<Tuple<string, List<float>>>();
        }

        #endregion

        /// <summary>
        /// A function that populates GeoShapes with objects serialized.
        /// </summary>
        /// <param name="shapesData">A string that represents the serialized collection</param>
        public static void PopulateGeoShapes(string shapesData)
        {
            GeoShape val = new GeoShape();

            string line;
            StringReader stringReader = new StringReader(shapesData);

            while (null != (line = stringReader.ReadLine()))
            {
                if (line.Equals("ENDOF"))
                {
                    if (GeoShape.GeoShapes == null)
                        GeoShape.GeoShapes = new List<GeoShape>();
                    GeoShape.GeoShapes.Add(val);
                    val = new GeoShape();
                }
                else
                {
                    List<float> values = new List<float>();

                    var nameValue = line.Split('=');

                    if ("Name".Equals(nameValue[0]))
                        val.name = nameValue[1];
                    else
                    {
                        var valuesString = nameValue[1].Split(';');
                        foreach (var value in valuesString)
                            values.Add(float.Parse(value));
                        val.objectDefinition.Add(new Tuple<string, List<float>>(nameValue[0], values));
                    }
                }
            }
        }

        /// <summary>
        /// Remove a value from the list
        /// </summary>
        /// <param name="index">Index to remove</param>
        public void RemoveFromDefinition(int index) {
            objectDefinition.RemoveAt(index);
        }

        /// <summary>
        /// Add an tuple to objectDefinition
        /// </summary>
        /// <param name="toAdd">Tuple to be added</param>
        public void AddToDefinition(Tuple<string, List<float>> toAdd)
        {
            objectDefinition.Add(toAdd);
        }

        /// <summary>
        /// Serialize the object
        /// </summary>
        /// <returns>A string that represents the object</returns>
        public string SaveObject()
        {
            string toSend="";
            toSend += "Name=" + this.name + "\n";

            foreach (var obj in objectDefinition)
            {
                toSend += obj.Item1+"=";
                for (int i=0;i<obj.Item2.Count-1;i++)
                {
                    toSend += obj.Item2[i].ToString()+";";
                }
                toSend += obj.Item2.Last().ToString() + "\n";
            }
            toSend += "ENDOF\n";
            return toSend;
        }

    }
}
