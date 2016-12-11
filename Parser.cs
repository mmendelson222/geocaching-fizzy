
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.IO;

namespace Fizzy
{
    public class GPXLoader
    {
        /// <summary> 
        /// Load the Xml document for parsing 
        /// </summary> 
        /// <param name="sFile">Fully qualified file name (local)</param> 
        /// <returns>XDocument</returns> 
        private XDocument GetGpxDoc(string sFile)
        {
            XDocument gpxDoc = XDocument.Load(sFile);
            return gpxDoc;
        }

        /// <summary> 
        /// Load the namespace for a standard GPX document 
        /// </summary> 
        /// <returns></returns> 
        private XNamespace GetGpxNameSpace()
        {
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/0");
            return gpx;
        }

        /// <summary> 
        /// When passed a file, open it and parse all waypoints from it. 
        /// </summary> 
        /// <param name="sFile">Fully qualified file name (local)</param> 
        /// <returns>string containing line delimited waypoints from 
        /// the file (for test)</returns> 
        /// <remarks>Normally, this would be used to populate the 
        /// appropriate object model</remarks> 
        internal List<Cache> LoadGPXWaypoints(string sFile)
        {
            XDocument gpxDoc = XDocument.Load(sFile);

            XNamespace gs = XNamespace.Get("http://www.groundspeak.com/cache/1/0/1");  //groundspeak:
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/0");  //no prefix

            var waypoints = (from waypoint in gpxDoc.Descendants(gpx + "wpt")
                             select new Cache
                             {
                                 //Latitude = waypoint.Attribute("lat").Value,
                                 //Longitude = waypoint.Attribute("lon").Value,
                                 //Elevation = waypoint.Element(gpx + "ele") != null ? waypoint.Element(gpx + "ele").Value : null,
                                 Code = waypoint.Element(gpx + "name") != null ? waypoint.Element(gpx + "name").Value : null,
                                 Difficulty = waypoint.Element(gs + "cache").Element(gs + "difficulty").Value,
                                 Terrain = waypoint.Element(gs + "cache").Element(gs + "terrain").Value,
                                 Owner = waypoint.Element(gs + "cache").Element(gs + "owner").Value,
                                 PlacedBy = waypoint.Element(gs + "cache").Element(gs + "placed_by").Value,
                                 PlacedById =  waypoint.Element(gs + "cache").Element(gs + "owner").Attribute("id").Value,
                                 State = waypoint.Element(gs + "cache").Element(gs + "state").Value,
                                 Name = waypoint.Element(gs + "cache").Element(gs + "name").Value,
                                 sHidden = waypoint.Element(gpx + "time").Value,
                                 Archived = waypoint.Element(gs + "cache").Attribute("archived").Value == "True",
                                 sFoundDate = DateFromCacheElement(gs, waypoint, FoundFilter(gs)),
                                 sDNFDate = DateFromCacheElement(gs, waypoint, NotFoundFilter(gs)),
                                 GCType = waypoint.Element(gs + "cache").Element(gs + "type").Value,
                                 Log = LogsFromCacheElement(gs, waypoint),
                             });

            return waypoints.ToList();
        }

        /// <summary>
        /// Get the date of the first log of this type, based on filter.  
        /// Return the date of that log, or null if not found.
        /// </summary>
        private string DateFromCacheElement(XNamespace gs, XElement waypoint, Func<XElement, bool> filter)
        {
            //get the first log conforming to the filter, or null.
            XElement log = waypoint.Element(gs + "cache").Element(gs + "logs").Elements().Where(filter).FirstOrDefault();
            if (log == null) return null;
            return log.Element(gs + "date").Value;
        }

        /// <summary>
        /// Gets all log text.
        /// TODO: format nicely
        /// </summary>
        private string LogsFromCacheElement(XNamespace gs, XElement waypoint)
        {
            //get the first log conforming to the filter, or null.
            var logs = waypoint.Element(gs + "cache").Element(gs + "logs").Elements();
            if (logs == null) return null;

            StringBuilder sb = new StringBuilder();
            foreach (var log in logs)
            {
                sb.AppendFormat("{0} {1}\n", log.Element(gs + "type").Value, log.Element(gs + "date").Value.Substring(0, 10));
                sb.AppendFormat("{0}\n\n", log.Element(gs + "text").Value);                
            }
            return sb.ToString().Trim();
        }

        /// <summary>
        /// Find the "found" log(s)
        /// </summary>
        private static Func<XElement, bool> FoundFilter(XNamespace gs)
        {
            return z => z.Element(gs + "type").Value == "Found it" || z.Element(gs + "type").Value == "Attended" || z.Element(gs + "type").Value == "Webcam Photo Taken";
        }

        /// <summary>
        /// Take the "not found" log(s)
        /// </summary>
        private static Func<XElement, bool> NotFoundFilter(XNamespace gs)
        {
            return z => z.Element(gs + "type").Value == "Didn't find it";
        }

        public class Cache
        {
            internal string Code;
            internal string Difficulty;
            internal string Terrain;
            internal string Owner;
            internal string PlacedBy;
            internal string PlacedById;
            internal string State;
            internal string Name;
            internal bool Archived;
            internal string GCType;
            internal string Log;

            private string sfound;
            internal string sFoundDate
            {
                get { return sfound; }
                set
                {
                    sfound = value;
                    DateTime.TryParse(sfound, out Found);
                }
            }
            internal DateTime Found;

            private string sDnf;
            internal string sDNFDate
            {
                get { return sDnf; }
                set
                {
                    sDnf = value;
                    DateTime.TryParse(sDnf, out DNF);
                }
            }
            internal DateTime DNF;

            internal string sHidden
            {
                set
                {
                    DateTime.TryParse(value, out Hidden);
                }
            }
            internal DateTime Hidden;

        }

    }
}

