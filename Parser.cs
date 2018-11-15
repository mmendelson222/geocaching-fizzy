
using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using System.IO;
using System.Diagnostics;

namespace Fizzy
{
    public class GPXLoader
    {
        private string gpxPath;

        public GPXLoader(string gpx)
        {
            this.gpxPath = gpx;
        }

        XDocument thedoc;
        XDocument XDoc
        {
            get
            {
                if (thedoc == null)
                    thedoc = XDocument.Load(gpxPath);
                return thedoc;
            }
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
        internal List<Cache> LoadGPXWaypoints()
        {
            XNamespace gs = GetGroundspeakNamespace(XDoc.Root);
            XNamespace gpx = XDoc.Root.GetDefaultNamespace();  //no prefix

            var waypoints = (from waypoint in XDoc.Descendants(gpx + "wpt")
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
                                 PlacedById = waypoint.Element(gs + "cache").Element(gs + "owner").Attribute("id").Value,
                                 Country = waypoint.Element(gs + "cache").Element(gs + "country").Value,
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

        internal GpxMeta GetGpxMeta()
        {
            XNamespace gs = GetGroundspeakNamespace(XDoc.Root);
            XNamespace gpx = XDoc.Root.GetDefaultNamespace();  //no prefix

            return new GpxMeta()
            {
                sDate = XDoc.Element(gpx + "gpx").Element(gpx + "time").Value,
                User = XDoc.Element(gpx + "gpx").Element(gpx + "wpt").Element(gs + "cache").Element(gs + "logs").Element(gs + "log").Element(gs + "finder").Value
            };
        }

        /// <summary>
        /// Tried a number of ways to do this, based on xml format.  This way seems to work for multiple slightly-different namespaces.   Not a great solution.
        /// </summary>
        private XNamespace GetGroundspeakNamespace(XElement root)
        {
            string schemas = root.Attribute(root.GetNamespaceOfPrefix("xsi") + "schemaLocation").Value;
            foreach (var s in schemas.Split(new char[] { ' ' }))
            {
                if (s.Contains("http://www.groundspeak.com/cache"))
                    return s;
            }
            throw new Exception("Couldn't find groundspeak schema name.  Contact the developer.");
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
                DateTime adjusted;
                Cache.TryParseGeneric(log.Element(gs + "date").Value, out adjusted);
                sb.AppendFormat("{0} {1:MM-dd-yy}\n", log.Element(gs + "type").Value, adjusted);
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
            internal string Country;

            /// <summary>
            /// Parse the date without regard to time zone.
            /// </summary>
            public static bool TryParseGeneric(string sdt, out DateTime dt)
            {
                DateTimeOffset dto;
                bool success = DateTimeOffset.TryParse(sdt, null, System.Globalization.DateTimeStyles.None, out dto);
                if (success)
                    dt = dto.DateTime.AddHours(-6);
                else
                    dt = DateTime.MinValue;
                return success;
            }

            private string sfound;
            internal string sFoundDate
            {
                get { return sfound; }
                set
                {
                    sfound = value;
                    if (sfound != null)
                        TryParseGeneric(sfound, out Found);
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
                    if (sDnf != null)
                        TryParseGeneric(sDnf, out DNF);
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

        public class GpxMeta
        {
            internal string User;
            internal string sDate
            {
                set
                {
                    DateTime.TryParse(value, out Date);
                }
            }
            internal DateTime Date;
        }

    }
}

