# geocaching-fizzy
## What is it?

This Windows program allows you to "deep dive" into your finds, allowing you to filter them in new ways, and quickly view your logs.
For example, the calendar grid looks like the one from Geocaching.com, but you can click on any grid square to see the caches represented by that D/T rating or calendar day, with coord.info links etc.
Filtering features mean that you can show a grid of ONLY the caches in one state, or of one cache type.

Group/display caches as: 

 * Difficulty/Terrain grid.  Click on a square for a list of all caches found with that DT rating.  
 * Finds by calendar day.  Click on day for a list of your finds on that date, through the years.
 * Jasmer grid, finds organized by the month the geocache was placed. 
 * Grouped by cache owner
 * Avenged caches (previously DNF'ed, then found)

Filter caches by: 

 * Year found
 * Type of cache
 * Country or State
 * Search text in title or log (for example, all caches whose log contains "DNF", or whose title contains "Dog")

A count of currently shown caches is displayed, as well as the user and generation date. 
 
![screen shot](https://raw.githubusercontent.com/mmendelson222/geocaching-fizzy/master/images/screenshot.png)

## Installation instructions 

1. Download the zip file from https://github.com/mmendelson222/geocaching-fizzy (green button which reads "Clone or download").
1. Unzip the file into an empty directory.  Subdirectory called "latest-release" contains the executable.
1. From the geocaching.com site, request your "my finds" query, and download the gpx file.
1. Double click on Fizzy.exe.  When you see the dialog, select your my finds gpx file. 

NOTES: 
* If you've marked a cache as found twice, only the first time will be counted.   This behavior seems to differ from the calendar on geocaching.com.
* Unlike the calendar on geocaching.com, this calendar does NOT include lab caches (since they're not included in your "my finds" query).  The D/T grid should be identical to the one on geocaching.com.

## Developers 

This program is written in c#.  If you're interested in contributing, I'll respond to pull requests or feel free to contact me directly. 



