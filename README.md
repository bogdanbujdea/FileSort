# PicSort

PicSort is a tool for classifying files based on date(other classifiers coming soon).
I made this tool for sorting the photos from my Dropbox "Camera Uploads" folder. Usually that folder gets pretty big and I like to have my photos organized in the following structure

<pre>
|Photos
├── year
│   └── month
│       └── day
│         └── pic1.jpg
│         └── pic2.jpg
</pre>

#Usage

Install the tool

Use these options:
<pre>
-r|--recursive                              Recursive search
-d|--working-directory <WORKING_DIRECTORY>                     The directory to search
-u|--use-multiple-classifiers               Use multiple classifiers
-i|--interval <INTERVAL>                              year/month/day/hour
-m|--move-to-root                           Move all files to root
-?|-h|--help                                Show help information
</pre>
Examples:
1. Sort all files by month: 
`sort-files -i=month`
2. Sort all files from every subfolder by day: 
`sort-files -i=day -r`
3. Sort all files from every subfolder by day, month, year: 
`sort-files -i=day -u -i`
4. Move every file from every subfolder to the current folder:
`sort-files -m`

[![Build Status](https://dev.azure.com/bogdan-tfs/PicSort/_apis/build/status/thewindev.PicSort?branchName=master)](https://dev.azure.com/bogdan-tfs/PicSort/_build/latest?definitionId=11&branchName=master)
