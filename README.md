# geocaching-fizzy
## What is it?

This Windows program grids based on your finds.  The difference is that each grid square is clickable, so you get all caches represented by that D/T rating, with coord.info links etc.
 * Difficulty/Terrain grid.  Click on a square for a list of all caches found with that DT rating.  
 * Finds by day Calendar.  Click on day for a list of your finds on that date, through the years.
 * Jasmer grid, which gives you all finds organized by the month the geocache was placed. 
 * Avenged DNF's, a simple list of all finds for which you previously posted a "Didn't find" log entry.  (no grid)
 
![screen shot](https://raw.githubusercontent.com/mmendelson222/geocaching-fizzy/master/images/fizzy.png)

## Installation instructions 

1. Download the zip file from https://github.com/mmendelson222/geocaching-fizzy (green button which reads "Clone or download").
1. Unzip the file into an empty directory.  Subdirectory called "latest-release" contains the executable.
1. From the geocaching.com site, request your "my finds" query, and download the gpx file.
1. Double click on Fizzy.exe.  When you see the dialog, select your my finds gpx file. 

NOTES: 
* If you've marked a cache as found twice, only the first time will be counted.   This behavior seems to differ from the calendar on geocaching.com.
* Unlike the calendar on geocaching.com, this calendar does NOT include lab caches (since they're not included in your "my finds" query).  The D/T grid should be identical.


## Developers 

This program is written in c#.  If you're interested in contributing, I'll respond to pull requests or feel free to contact me directly. 



