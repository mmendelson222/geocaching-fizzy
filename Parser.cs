
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

            XNamespace gs = XNamespace.Get("http://www.groundspeak.com/cache/1/0/1");
            XNamespace gpx = XNamespace.Get("http://www.topografix.com/GPX/1/0");

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
                                 State = waypoint.Element(gs + "cache").Element(gs + "state").Value,
                                 Name = waypoint.Element(gs + "cache").Element(gs + "name").Value,
                                 Archived = waypoint.Element(gs + "cache").Attribute("archived").Value == "True",
                                 sDate = waypoint.Element(gs + "cache").Element(gs + "logs").Elements().Where(z => z.Element(gs + "type").Value == "Found it" || z.Element(gs + "type").Value == "Attended" || z.Element(gs + "type").Value == "Webcam Photo Taken").First().Element(gs + "date").Value,
                             });

            return waypoints.ToList();
        }

        public class Cache
        {
            internal string Code;
            internal string Difficulty;
            internal string Terrain;
            internal string Owner;
            internal string State;
            internal string Name;
            internal bool Archived;

            private string sdt;
            internal string sDate
            {
                get { return sdt; }
                set
                {
                    sdt = value;
                    DateTime.TryParse(sdt, out Date);
                }
            }
            internal DateTime Date;
        }

        /// <summary> 
        /// When passed a file, open it and parse all tracks 
        /// and track segments from it. 
        /// </summary> 
        /// <param name="sFile">Fully qualified file name (local)</param> 
        /// <returns>string containing line delimited waypoints from the 
        /// file (for test)</returns> 
        public string LoadGPXTracks(string sFile)
        {
            XDocument gpxDoc = GetGpxDoc(sFile);
            XNamespace gpx = GetGpxNameSpace();
            var tracks = from track in gpxDoc.Descendants(gpx + "trk")
                         select new
                         {
                             Name = track.Element(gpx + "name") != null ?
                              track.Element(gpx + "name").Value : null,
                             Segs = (
                                  from trackpoint in track.Descendants(gpx + "trkpt")
                                  select new
                                  {
                                      Latitude = trackpoint.Attribute("lat").Value,
                                      Longitude = trackpoint.Attribute("lon").Value,
                                      Elevation = trackpoint.Element(gpx + "ele") != null ?
                                        trackpoint.Element(gpx + "ele").Value : null,
                                      Time = trackpoint.Element(gpx + "time") != null ?
                                        trackpoint.Element(gpx + "time").Value : null
                                  }
                                )
                         };

            StringBuilder sb = new StringBuilder();
            foreach (var trk in tracks)
            {
                // Populate track data objects. 
                foreach (var trkSeg in trk.Segs)
                {
                    // Populate detailed track segments 
                    // in the object model here. 
                    sb.Append(
                      string.Format("Track:{0} - Latitude:{1} Longitude:{2} " +
                                   "Elevation:{3} Date:{4}\n",
                      trk.Name, trkSeg.Latitude,
                      trkSeg.Longitude, trkSeg.Elevation,
                      trkSeg.Time));
                }
            }
            return sb.ToString();
        }
    }
}

