Purpose of this Plugin
- Click One Button to Download all data in Google Sheet and save it to ScriptableObject in Unity project
- works only in Editor, while the database used in Runtime
- Easy and fast to download data from Google Sheet

Requirement Plugins
- [NaughtyAttributes](https://github.com/dbrizov/NaughtyAttributes) by dbrizov

Requirement Setup
1. Google Sheet must set access to the public as a Viewer
2. Download NaughtyAttributes plugin to use [Button]
3. This plugin uses assembly.

How to use
1. Create class present as data
2. Create class that inherits form RemoteDatabase<T> where T is data class
3. Add "CreateAssetMenu" to class RemoteDatabase

Example Google Sheet Link
- [Google Sheet Example](https://docs.google.com/spreadsheets/d/1Ecqa5EU_-vAD7erb5KzyKy3ku7IGQPDWLZ4hH2Ye0Ao/edit?usp=sharing)

TODO
- case "," in column
