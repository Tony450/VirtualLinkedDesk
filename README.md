# **VirtualLinkedDesk**

## About VirtualLinkedDesk

### The project

VirtualLinkedDesk is a remote desktop program that lets you control a machine from a distance as if you were in front of it. There are a lot of applications that are capable of doing this function, but what is the most powerful characteristic that this program has that others don't? The fact that it is very simple and easy to understand if you have intermediate level programming knowledge.

Do you like technology? Are you a curious person who likes knowing how things in general work? Then, you will love this program. Remote desktop technology has left its footprint since computing first appeared, and nowadays, it continues evolving in different types of functionalities like Airplay, Chrome Cast, Windows 365, etc. From this moment on, you will have the possibility of understanding this technology if you download the source code of this program, it is very exciting, isn't it?. So, I invite you to do it, I hope you enjoy using it and seeing its structure as much as I have.

This is the program that I created from scratch for my Computer Science Engineering Bachelor thesis. The corresponding document is [TFG_Antonio_Manuel_Hernandez_DeLeon_2021.pdf](Thesis/TFG_Antonio_Manuel_Hernandez_DeLeon_2021.pdf).


### Feature comparison

Here you can find the most important features that this program has and also a comparison to other similar programs in the marketplace. As mentioned above, the most powerful aspect of this application is its legible code, therefore, the possibility of using it for teaching purposes.



| Program                               | Remote desktop     | Free                | Open source         | Public protocol    | Encrypted connections  | Code usable for teaching |
| --------------------------------------|:------------------:|:-------------------:|:-------------------:|:------------------:|:----------------------:|:------------------------:|
| Telnet                                | :x:                | :white_check_mark:  | :white_check_mark:  | :white_check_mark: | :x:*                   | :x:                      |
| Rlogin                                | :x:                | :white_check_mark:  | :white_check_mark:  | :white_check_mark: | :x:*                   | :x:                      |
| SSH                                   | :x:                | :white_check_mark:  | :white_check_mark:  | :white_check_mark: | :white_check_mark:     | :x:                      |
| X Window System                       | :white_check_mark: | :white_check_mark:  | :white_check_mark:  | :white_check_mark: | :x:                    | :x:                      |
| VNC                                   | :white_check_mark: | :white_check_mark:* | :white_check_mark:* | :white_check_mark: | :white_check_mark:*    | :x:                      |
| TeamViewer                            | :white_check_mark: | :white_check_mark:* | :x:                 | :x:                | :white_check_mark:     | :x:                      |
| Terminal Server (Microsoft Windows)   | :white_check_mark: | :x:                 | :x:                 | :x:                | :white_check_mark:     | :x:                      |
| Google Chrome Remote Desktop          | :white_check_mark: | :white_check_mark:  | :x:                 | :x:                | :white_check_mark:     | :x:                      |
| Windows 365                           | :white_check_mark: | :x:                 | :x:                 | :x:                | :white_check_mark:     | :x:                      |
| Thesis proposal                       | :white_check_mark: | :white_check_mark:  | :white_check_mark:  | :white_check_mark: | :white_check_mark:     | :white_check_mark:       |


*The most advanced versions of RealVNC project and TeamViewer are not free, only their versions of personal use are. \
*It's worth mentioning that some branches such as TightVNC dont't encrypt connections. Telnet and Rlogin themselves neither encrypt connections, it is possible to use a SSH tunnel along with them to encrypt the connection. Nevertheless, not all users have the technical knowledge to do this and those who do can also forget it. Consequently, implementing this feature in the tool is more appropriate. 


## Installation

### Installer file

Installing the program by downloading an installer is very easy. You only have to go to [Releases](/release/latest) section and download the latest published version. When download finishes, you have to follow the installer steps like any other application.

<!-- https://docs.github.com/es/github/administering-a-repository/releasing-projects-on-github/linking-to-releases -->


### Building from source

You will need the following things to build and use this software:

- Two Machines with Microsoft Windows installed
- Visual Studio 2019 (v16.8.0 or newer)
- .NET 5.0 SDK

Once you have everything prepared you have to follow the next steps:

1. Clone repository using Visual Studio 2019.
2. Build BitmapLibrary project to let other projects use its output.
3. Build Client or Server project depending on which program you will use on the current machine.
4. Repeat the previous steps on the other machine, this time building the project that you want to run on this machine.

<!-- Proyectos: Prometheus, windows_exporter, VS Code, Telegram, VLC, Gimp, VNC -->

<!-- Enlace a Github Wiki o MD para instrucciones de compilación -->


<!-- ## Usage -->

<!-- Instrucciones de uso en un futuro https://docs.github.com/es/communities/documenting-your-project-with-wikis/editing-wiki-content -->

## License

Copyright (C) Antonio Manuel Hernández De León.

Licensed under the [GPL license](LICENSE.txt).

Logo icon made by [Freepik](https://www.flaticon.com/authors/freepik) from [www.flaticon.com](https://www.flaticon.com/).
