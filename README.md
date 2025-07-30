## Interactive 3D Climate Data Visualisation in Unity 
This Unity Project plots real TROPOMI Satellite data on 3D Earth Objects. 
In the Demo below, the middle earth is showing atmospheric Methane concentrations with the user switching between months using a keyboard or controller.
![Unity Demo](Unity_Earth_Demo.gif)

## Setup 
This project is built using unity version 2022.3.44f1 and is compatible with Windows, Linux and Mac.
The project can be run on your own computer (as per the demo gif) or interactive screens such as the CAVE at the Bristol Digital Future Institute. 

Some of the scripts and packages are specific to running the project on the Bristol Digital Future CAVE - further info on CAVE specific requirements can be found here:  https://bdfi.atlassian.net/wiki/external/ZTIzYzM2YTgzNDI3NDg1OGI1YjEyMDRiODFmZjUyYjU

### Getting Started

To get started: 

1. Download Unity Hub from here : https://unity.com/download
2. Install Unity version 2022.3.44f1 from the unity archive using this link: https://unity.com/releases/editor/archive
3. Install  Git LFS (Large File Storage) which can be done with the following command: ```git lfs install```
4. Clone this git repository 
5. Within Unity select add project and open the local git repository 'Interactive_Earth_Climate_3D_Unity'


### Folder Structure

Git LFS  (Large File Storage) is used in this repository to track larger files such as png's. Git LFS is integrated with Github and allows users free storage up to 1GB. 
Within the Unity project the git tracked files are as follows:
```text
Interactive_Earth_Climate_3D_Unity/
├── Assets/             # All game assets
├── Packages/           # Package manager settings
├── ProjectSettings/    # Unity settings (do commit)
├── .gitignore
├── README.md
```

Other files and folders NOT tracked by git (included in .gitignore) are created locally when you install Unity and open the project, these include: 

```text
Interactive_Earth_Climate_3D_Unity/
├── Library/               # Unity cache (auto-generated, should be gitignored)
├── Temp/                  # Temporary files (auto-generated, gitignored)
├── Build/                 # Output builds (should be gitignored unless sharing)
├── .vs/                   # Visual Studio settings (gitignored)
├── *.csproj, *.sln        # Auto-generated project/solution files
```



 

